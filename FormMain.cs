using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsWorkstationsBD
{
    public partial class FormMain : Form
    {
        private int currentServerId = -1;
        private int currentWorkstationForSoftware = -1;
        private int currentOperatorId = -1;

        public FormMain()
        {
            InitializeComponent();
            LoadServers();
            LoadOperators();
            SetModeServers();
        }

        // ==================== Загрузка данных ====================

        private void LoadServers()
        {
            DataTable dt = DBHelper.ExecuteQuery("SELECT id, name FROM Servers ORDER BY id");
            dgvLeft.DataSource = dt;
            dgvLeft.Columns["id"].Visible = false;
            dgvLeft.Columns["name"].HeaderText = "Серверы";

            if (dgvLeft.Rows.Count > 0)
            {
                int firstServerId = Convert.ToInt32(dgvLeft.Rows[0].Cells["id"].Value);
                LoadWorkstationsByServer(firstServerId);
            }
        }

        private void LoadWorkstationsByServer(int serverId)
        {
            DataTable dt = DBHelper.ExecuteQuery($@"
                SELECT w.id, w.name AS ""Рабочая станция""
                FROM Workstations w
                WHERE w.server_id = {serverId}
                ORDER BY w.id");
            dgvCenter.DataSource = dt;
            dgvCenter.Columns["id"].Visible = false;
            dgvCenter.Columns["Рабочая станция"].HeaderText = "РС на сервере";

            if (dgvCenter.Rows.Count > 0)
            {
                int firstWorkstationId = Convert.ToInt32(dgvCenter.Rows[0].Cells["id"].Value);
                LoadSoftwareOnWorkstation(firstWorkstationId);
            }
        }

        private void LoadSoftwareOnWorkstation(int workstationId)
        {
            DataTable dt = DBHelper.ExecuteQuery($@"
                SELECT s.id, s.name AS ""Программа""
                FROM Software s
                JOIN Workstation_Soft ws ON s.id = ws.software_id
                WHERE ws.workstation_id = {workstationId}
                ORDER BY s.id");
            dgvRight.DataSource = dt;
            dgvRight.Columns["id"].Visible = false;
            dgvRight.Columns["Программа"].HeaderText = "Установленные программы";
        }

        private void LoadOperators()
        {
            DataTable dt = DBHelper.ExecuteQuery("SELECT id, fio AS \"ФИО\", post AS \"Должность\" FROM Operators ORDER BY id");
            dgvLeft.DataSource = dt;
            dgvLeft.Columns["id"].Visible = false;
            dgvLeft.Columns["ФИО"].HeaderText = "Операторы";
            dgvLeft.Columns["Должность"].HeaderText = "Должность";

            if (dgvLeft.Rows.Count > 0)
            {
                int firstOperatorId = Convert.ToInt32(dgvLeft.Rows[0].Cells["id"].Value);
                LoadWorkstationsByOperator(firstOperatorId);
            }
        }

        private void LoadWorkstationsByOperator(int operatorId)
        {
            DataTable dt = DBHelper.ExecuteQuery($@"
                SELECT w.id, w.name AS ""Рабочая станция""
                FROM Workstations w
                JOIN Workstation_Operator wo ON w.id = wo.workstation_id
                WHERE wo.operator_id = {operatorId}
                ORDER BY w.id");
            dgvCenter.DataSource = dt;
            dgvCenter.Columns["id"].Visible = false;
            dgvCenter.Columns["Рабочая станция"].HeaderText = "РС для оператора";

            if (dgvCenter.Rows.Count > 0)
            {
                int firstWorkstationId = Convert.ToInt32(dgvCenter.Rows[0].Cells["id"].Value);
                LoadSoftwareOnWorkstation(firstWorkstationId);
            }
        }

        // ==================== Переключение режимов ====================

        private void SetModeServers()
        {
            lblLeft.Text = "Серверы";
            lblCenter.Text = "РС на сервере";
            lblRight.Text = "Программы на РС";
            btnAddLeft.Text = "Добавить сервер";
            btnDeleteServer.Visible = true;
            btnDeleteOperator.Visible = false;
            btnAddCenter.Text = "Добавить РС";
            btnDeleteCenter.Text = "Удалить РС";
            btnAddRight.Text = "Установить ПО";
            btnDeleteRight.Text = "Удалить ПО";
            LoadServers();
        }

        private void SetModeOperators()
        {
            lblLeft.Text = "Операторы";
            lblCenter.Text = "РС для оператора";
            lblRight.Text = "Программы на РС";
            btnAddLeft.Text = "Добавить оператора";
            btnDeleteServer.Visible = false;
            btnDeleteOperator.Visible = true;
            btnAddCenter.Text = "Добавить доступ";
            btnDeleteCenter.Text = "Удалить доступ";
            btnAddRight.Text = "Установить ПО";
            btnDeleteRight.Text = "Удалить ПО";
            LoadOperators();
        }

        // ==================== События кликов по DataGridView ====================

        private void dgvLeft_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLeft.SelectedRows.Count == 0) return;

            if (lblLeft.Text == "Серверы")
            {
                currentServerId = Convert.ToInt32(dgvLeft.SelectedRows[0].Cells["id"].Value);
                LoadWorkstationsByServer(currentServerId);
            }
            else
            {
                currentOperatorId = Convert.ToInt32(dgvLeft.SelectedRows[0].Cells["id"].Value);
                LoadWorkstationsByOperator(currentOperatorId);
            }
        }

        private void dgvCenter_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCenter.SelectedRows.Count == 0) return;

            currentWorkstationForSoftware = Convert.ToInt32(dgvCenter.SelectedRows[0].Cells["id"].Value);
            LoadSoftwareOnWorkstation(currentWorkstationForSoftware);
        }

        // ==================== Кнопки ====================

        private void btnModeServers_Click(object sender, EventArgs e)
        {
            SetModeServers();
        }

        private void btnModeOperators_Click(object sender, EventArgs e)
        {
            SetModeOperators();
        }

        private void btnAddLeft_Click(object sender, EventArgs e)
        {
            if (lblLeft.Text == "Серверы")
            {
                FormSelect form = new FormSelect("Server");
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadServers();
                }
            }
            else
            {
                FormSelect form = new FormSelect("Operator");
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadOperators();
                }
            }
        }

        private void btnDeleteServer_Click(object sender, EventArgs e)
        {
            if (dgvLeft.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сервер для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int serverId = Convert.ToInt32(dgvLeft.SelectedRows[0].Cells["id"].Value);
            string serverName = dgvLeft.SelectedRows[0].Cells["name"].Value.ToString();

            DialogResult result = MessageBox.Show($"Удалить сервер \"{serverName}\"?\n\nВсе рабочие станции на этом сервере, а также связи с операторами и ПО будут удалены.",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DBHelper.ExecuteNonQuery($@"
                    DELETE FROM Workstation_Operator 
                    WHERE workstation_id IN (SELECT id FROM Workstations WHERE server_id = {serverId})");

                DBHelper.ExecuteNonQuery($@"
                    DELETE FROM Workstation_Soft 
                    WHERE workstation_id IN (SELECT id FROM Workstations WHERE server_id = {serverId})");

                DBHelper.ExecuteNonQuery($"DELETE FROM Workstations WHERE server_id = {serverId}");
                DBHelper.ExecuteNonQuery($"DELETE FROM Servers WHERE id = {serverId}");

                LoadServers();
                dgvCenter.DataSource = null;
                dgvRight.DataSource = null;

                MessageBox.Show("Сервер удалён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteOperator_Click(object sender, EventArgs e)
        {
            if (dgvLeft.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите оператора для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int operatorId = Convert.ToInt32(dgvLeft.SelectedRows[0].Cells["id"].Value);
            string operatorName = dgvLeft.SelectedRows[0].Cells["ФИО"].Value.ToString();

            DialogResult result = MessageBox.Show($"Удалить оператора \"{operatorName}\"?\n\nВсе связи с рабочими станциями будут удалены.",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DBHelper.ExecuteNonQuery($"DELETE FROM Workstation_Operator WHERE operator_id = {operatorId}");
                DBHelper.ExecuteNonQuery($"DELETE FROM Operators WHERE id = {operatorId}");

                LoadOperators();
                dgvCenter.DataSource = null;
                dgvRight.DataSource = null;

                MessageBox.Show("Оператор удалён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddCenter_Click(object sender, EventArgs e)
        {
            if (lblLeft.Text == "Серверы")
            {
                if (currentServerId == -1)
                {
                    MessageBox.Show("Выберите сервер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FormSelect form = new FormSelect("Workstation", currentServerId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadWorkstationsByServer(currentServerId);
                }
            }
            else
            {
                if (currentOperatorId == -1)
                {
                    MessageBox.Show("Выберите оператора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FormSelect form = new FormSelect("Access", currentOperatorId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadWorkstationsByOperator(currentOperatorId);
                }
            }
        }

        private void btnDeleteCenter_Click(object sender, EventArgs e)
        {
            if (dgvCenter.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите РС", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int workstationId = Convert.ToInt32(dgvCenter.SelectedRows[0].Cells["id"].Value);

            if (lblLeft.Text == "Серверы")
            {
                DialogResult result = MessageBox.Show("Удалить рабочую станцию? Все связи с операторами и ПО будут удалены.", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DBHelper.ExecuteNonQuery($"DELETE FROM Workstation_Operator WHERE workstation_id = {workstationId}");
                    DBHelper.ExecuteNonQuery($"DELETE FROM Workstation_Soft WHERE workstation_id = {workstationId}");
                    DBHelper.ExecuteNonQuery($"DELETE FROM Workstations WHERE id = {workstationId}");
                    LoadWorkstationsByServer(currentServerId);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Удалить доступ оператора к этой РС?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DBHelper.ExecuteNonQuery($"DELETE FROM Workstation_Operator WHERE operator_id = {currentOperatorId} AND workstation_id = {workstationId}");
                    LoadWorkstationsByOperator(currentOperatorId);
                }
            }
        }

        private void btnAddRight_Click(object sender, EventArgs e)
        {
            if (currentWorkstationForSoftware == -1)
            {
                MessageBox.Show("Выберите РС", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormSelect form = new FormSelect("Software", currentWorkstationForSoftware);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSoftwareOnWorkstation(currentWorkstationForSoftware);
            }
        }

        private void btnDeleteRight_Click(object sender, EventArgs e)
        {
            if (dgvRight.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите программу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int softwareId = Convert.ToInt32(dgvRight.SelectedRows[0].Cells["id"].Value);
            DialogResult result = MessageBox.Show("Удалить программу с этой РС?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DBHelper.ExecuteNonQuery($"DELETE FROM Workstation_Soft WHERE workstation_id = {currentWorkstationForSoftware} AND software_id = {softwareId}");
                LoadSoftwareOnWorkstation(currentWorkstationForSoftware);
            }
        }
    }
}

// ПсковГУ ПИШ - Иванов Лев, 0483-05 гр. 2026 год, к курсовой работе