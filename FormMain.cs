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
            DBHelper.OnQueryExecuted += (query, action) =>
            {
                if (InvokeRequired)
                    Invoke(new Action(() => LogAction(query)));
                else
                    LogAction(query);
            };
            dgvLeft.CellMouseEnter += DgvLeft_CellMouseEnter;
            dgvLeft.CellMouseLeave += DgvLeft_CellMouseLeave;
            dgvCenter.CellMouseEnter += DgvCenter_CellMouseEnter;
            dgvCenter.CellMouseLeave += DgvCenter_CellMouseLeave;
            dgvRight.CellMouseEnter += DgvRight_CellMouseEnter;
            dgvRight.CellMouseLeave += DgvRight_CellMouseLeave;
            dgvLeft.CellDoubleClick += DgvLeft_CellDoubleClick;
            dgvLeft.CellDoubleClick += DgvLeft_CellDoubleClick;
            dgvCenter.CellDoubleClick += DgvCenter_CellDoubleClick;
            dgvRight.CellDoubleClick += DgvRight_CellDoubleClick;
            LoadServers();
            LoadOperators();
            SetModeServers();
            UpdateStats();
        }

        private void LogAction(string query)
        {
            string shortQuery = query.Trim();
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {shortQuery}" + Environment.NewLine);
            txtLog.ScrollToCaret();
        }

        private void UpdateStats()
        {
            int servers = Convert.ToInt32(DBHelper.ExecuteQuery("SELECT COUNT(*) FROM Servers", false).Rows[0][0]);
            int workstations = Convert.ToInt32(DBHelper.ExecuteQuery("SELECT COUNT(*) FROM Workstations", false).Rows[0][0]);
            int software = Convert.ToInt32(DBHelper.ExecuteQuery("SELECT COUNT(*) FROM Software", false).Rows[0][0]);
            int operators = Convert.ToInt32(DBHelper.ExecuteQuery("SELECT COUNT(*) FROM Operators", false).Rows[0][0]);
            lblStats.Text = $"Серверов: {servers} | РС: {workstations} | ПО: {software} | Операторов: {operators}";
        }

        private void DgvLeft_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string currentMode = lblLeft.Text;
            if (currentMode == "Серверы")
            {
                int id = Convert.ToInt32(dgvLeft.Rows[e.RowIndex].Cells["id"].Value);
                string oldName = dgvLeft.Rows[e.RowIndex].Cells["name"].Value.ToString();

                string newName = Microsoft.VisualBasic.Interaction.InputBox("Новое название сервера:", "Редактирование", oldName);
                if (string.IsNullOrEmpty(newName) || newName == oldName) return;

                string query = $"UPDATE Servers SET name = '{newName.Replace("'", "''")}' WHERE id = {id}";
                DBHelper.ExecuteNonQuery(query);
                LoadServers();
                UpdateStats();
                return;
            }
            if (currentMode == "Операторы")
            {
                int id = Convert.ToInt32(dgvLeft.Rows[e.RowIndex].Cells["id"].Value);
                string oldName = dgvLeft.Rows[e.RowIndex].Cells["ФИО"].Value.ToString();

                string newName = Microsoft.VisualBasic.Interaction.InputBox("Новое ФИО оператора:", "Редактирование", oldName);
                if (string.IsNullOrEmpty(newName) || newName == oldName) return;

                string query = $"UPDATE Operators SET fio = '{newName.Replace("'", "''")}' WHERE id = {id}";
                DBHelper.ExecuteNonQuery(query);
                LoadOperators();
                UpdateStats();
                return;
            }
        }
        private void DgvCenter_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvCenter.Rows[e.RowIndex].Cells["id"].Value);
            string oldName = dgvCenter.Rows[e.RowIndex].Cells["Рабочая станция"].Value.ToString();

            string newName = Microsoft.VisualBasic.Interaction.InputBox("Новое название рабочей станции:", "Редактирование", oldName);
            if (string.IsNullOrEmpty(newName) || newName == oldName) return;

            string query = $"UPDATE Workstations SET name = '{newName.Replace("'", "''")}' WHERE id = {id}";
            DBHelper.ExecuteNonQuery(query);
            if (lblLeft.Text == "Серверы")
                LoadWorkstationsByServer(currentServerId);
            else
                LoadWorkstationsByOperator(currentOperatorId);

            UpdateStats();
        }

        private void DgvRight_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int id = Convert.ToInt32(dgvRight.Rows[e.RowIndex].Cells["id"].Value);
            string oldName = dgvRight.Rows[e.RowIndex].Cells["Программа"].Value.ToString();
            string newName = Microsoft.VisualBasic.Interaction.InputBox("Новое название программы:", "Редактирование", oldName);
            if (string.IsNullOrEmpty(newName) || newName == oldName) return;
            string query = $"UPDATE Software SET name = '{newName.Replace("'", "''")}' WHERE id = {id}";
            DBHelper.ExecuteNonQuery(query);
            LoadSoftwareOnWorkstation(currentWorkstationForSoftware);
            UpdateStats();
        }

        private void LoadServers()
        {
            DataTable dt = DBHelper.ExecuteQuery("SELECT id, name FROM Servers ORDER BY id", false);
            dgvLeft.DataSource = dt;
            dgvLeft.Columns["id"].Visible = false;
            dgvLeft.Columns["name"].HeaderText = "Серверы";
            if (dgvLeft.Rows.Count > 0)
            {
                int firstServerId = Convert.ToInt32(dgvLeft.Rows[0].Cells["id"].Value);
                LoadWorkstationsByServer(firstServerId);
            }
            UpdateStats();
        }

        private void LoadWorkstationsByServer(int serverId)
        {
            DataTable dt = DBHelper.ExecuteQuery($@"
            SELECT w.id, w.name AS ""Рабочая станция""
            FROM Workstations w
            WHERE w.server_id = {serverId}
            ORDER BY w.id", false);
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
            ORDER BY s.id", false);
            dgvRight.DataSource = dt;
            dgvRight.Columns["id"].Visible = false;
            dgvRight.Columns["Программа"].HeaderText = "Установленные программы";
        }

        private void LoadOperators()
        {
            DataTable dt = DBHelper.ExecuteQuery("SELECT id, fio AS \"ФИО\", post AS \"Должность\" FROM Operators ORDER BY id", false);
            dgvLeft.DataSource = dt;
            dgvLeft.Columns["id"].Visible = false;
            dgvLeft.Columns["ФИО"].HeaderText = "Операторы";
            dgvLeft.Columns["Должность"].HeaderText = "Должность";
            if (dgvLeft.Rows.Count > 0)
            {
                int firstOperatorId = Convert.ToInt32(dgvLeft.Rows[0].Cells["id"].Value);
                LoadWorkstationsByOperator(firstOperatorId);
            }
            UpdateStats();
        }

        private void LoadWorkstationsByOperator(int operatorId)
        {
            DataTable dt = DBHelper.ExecuteQuery($@"
            SELECT w.id, w.name AS ""Рабочая станция""
            FROM Workstations w
            JOIN Workstation_Operator wo ON w.id = wo.workstation_id
            WHERE wo.operator_id = {operatorId}
            ORDER BY w.id", false);
            dgvCenter.DataSource = dt;
            dgvCenter.Columns["id"].Visible = false;
            dgvCenter.Columns["Рабочая станция"].HeaderText = "РС для оператора";
            if (dgvCenter.Rows.Count > 0)
            {
                int firstWorkstationId = Convert.ToInt32(dgvCenter.Rows[0].Cells["id"].Value);
                LoadSoftwareOnWorkstation(firstWorkstationId);
            }
        }

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
                    if (dgvLeft.Rows.Count > 0)
                    {
                        int firstServerId = Convert.ToInt32(dgvLeft.Rows[0].Cells["id"].Value);
                        LoadWorkstationsByServer(firstServerId);
                    }
                }
            }
            else
            {
                FormSelect form = new FormSelect("Operator");
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadOperators();
                    if (dgvLeft.Rows.Count > 0)
                    {
                        int firstOperatorId = Convert.ToInt32(dgvLeft.Rows[0].Cells["id"].Value);
                        LoadWorkstationsByOperator(firstOperatorId);
                    }
                }
            }
            UpdateStats();
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
                UpdateStats();
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
                UpdateStats();
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
                    UpdateStats();
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
                    UpdateStats();
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
                    UpdateStats();
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
                UpdateStats();
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

        private void DgvLeft_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvLeft.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 220, 200);
        }

        private void DgvLeft_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvLeft.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
        }

        private void DgvCenter_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvCenter.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 220, 200);
        }

        private void DgvCenter_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvCenter.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
        }

        private void DgvRight_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvRight.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 220, 200);
        }

        private void DgvRight_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvRight.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
        }
    }
}

// ПсковГУ ПИШ - Иванов Лев, 0483-05 гр. 2026 год, к курсовой работе