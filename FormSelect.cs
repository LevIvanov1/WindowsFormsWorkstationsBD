using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsWorkstationsBD
{
    public partial class FormSelect : Form
    {
        private string mode; // Server, Workstation, Operator, Access, Software
        private int parentId; // для Workstation (server_id) или Access (operator_id) или Software (workstation_id)

        public FormSelect(string mode, int parentId = -1)
        {
            InitializeComponent();
            this.mode = mode;
            this.parentId = parentId;
            SetupForm();
            LoadData();
        }

        private void SetupForm()
        {
            switch (mode)
            {
                case "Server":
                    this.Text = "Добавление сервера";
                    lblName.Text = "Название сервера:";
                    break;
                case "Workstation":
                    this.Text = "Добавление рабочей станции";
                    lblName.Text = "Название РС:";
                    break;
                case "Operator":
                    this.Text = "Добавление оператора";
                    lblName.Text = "ФИО оператора:";
                    lblPost.Visible = true;
                    txtPost.Visible = true;
                    break;
                case "Access":
                    this.Text = "Добавление доступа оператору";
                    lblName.Text = "Выберите РС:";
                    lblName.Visible = true;
                    txtName.Visible = false;
                    dgvSelect.Visible = true;
                    break;
                case "Software":
                    this.Text = "Установка ПО на РС";
                    lblName.Text = "Выберите программу:";
                    lblName.Visible = true;
                    txtName.Visible = false;
                    dgvSelect.Visible = true;
                    break;
            }
        }

        private void LoadData()
        {
            if (mode == "Access")
            {
                DataTable dt = DBHelper.ExecuteQuery($@"
                    SELECT w.id, w.name AS ""Рабочая станция""
                    FROM Workstations w
                    WHERE w.id NOT IN (
                        SELECT workstation_id FROM Workstation_Operator WHERE operator_id = {parentId}
                    )
                    ORDER BY w.id");
                dgvSelect.DataSource = dt;
                dgvSelect.Columns["id"].Visible = false;
            }
            else if (mode == "Software")
            {
                DataTable dt = DBHelper.ExecuteQuery($@"
                    SELECT s.id, s.name AS ""Программа""
                    FROM Software s
                    WHERE s.id NOT IN (
                        SELECT software_id FROM Workstation_Soft WHERE workstation_id = {parentId}
                    )
                    ORDER BY s.id");
                dgvSelect.DataSource = dt;
                dgvSelect.Columns["id"].Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (mode)
                {
                    case "Server":
                        if (string.IsNullOrWhiteSpace(txtName.Text))
                        {
                            MessageBox.Show("Введите название сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        int newServerId = Convert.ToInt32(DBHelper.ExecuteQuery("SELECT COALESCE(MAX(id), 0) + 1 FROM Servers").Rows[0][0]);
                        DBHelper.ExecuteNonQuery($"INSERT INTO Servers (id, name) VALUES ({newServerId}, '{txtName.Text.Replace("'", "''")}')");
                        break;

                    case "Workstation":
                        if (string.IsNullOrWhiteSpace(txtName.Text))
                        {
                            MessageBox.Show("Введите название РС", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        int newWsId = Convert.ToInt32(DBHelper.ExecuteQuery("SELECT COALESCE(MAX(id), 0) + 1 FROM Workstations").Rows[0][0]);
                        DBHelper.ExecuteNonQuery($"INSERT INTO Workstations (id, name, server_id) VALUES ({newWsId}, '{txtName.Text.Replace("'", "''")}', {parentId})");
                        break;

                    case "Operator":
                        if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPost.Text))
                        {
                            MessageBox.Show("Введите ФИО и должность оператора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        int newOpId = Convert.ToInt32(DBHelper.ExecuteQuery("SELECT COALESCE(MAX(id), 0) + 1 FROM Operators").Rows[0][0]);
                        DBHelper.ExecuteNonQuery($"INSERT INTO Operators (id, fio, post) VALUES ({newOpId}, '{txtName.Text.Replace("'", "''")}', '{txtPost.Text.Replace("'", "''")}')");
                        break;

                    case "Access":
                        if (dgvSelect.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Выберите РС", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        int workstationId = Convert.ToInt32(dgvSelect.SelectedRows[0].Cells["id"].Value);
                        int newAccessId = Convert.ToInt32(DBHelper.ExecuteQuery("SELECT COALESCE(MAX(id), 0) + 1 FROM Workstation_Operator").Rows[0][0]);
                        DBHelper.ExecuteNonQuery($"INSERT INTO Workstation_Operator (id, workstation_id, operator_id) VALUES ({newAccessId}, {workstationId}, {parentId})");
                        break;

                    case "Software":
                        if (dgvSelect.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Выберите программу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        int softwareId = Convert.ToInt32(dgvSelect.SelectedRows[0].Cells["id"].Value);
                        int newSoftId = Convert.ToInt32(DBHelper.ExecuteQuery("SELECT COALESCE(MAX(id), 0) + 1 FROM Workstation_Soft").Rows[0][0]);
                        DBHelper.ExecuteNonQuery($"INSERT INTO Workstation_Soft (id, workstation_id, software_id) VALUES ({newSoftId}, {parentId}, {softwareId})");
                        break;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

// ПсковГУ ПИШ - Иванов Лев, 0483-05 гр. 2026 год, к курсовой работе