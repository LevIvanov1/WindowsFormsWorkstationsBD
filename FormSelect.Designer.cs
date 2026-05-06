namespace WindowsFormsWorkstationsBD
{
    partial class FormSelect
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPost;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.DataGridView dgvSelect;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPost = new System.Windows.Forms.Label();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.dgvSelect = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelect)).BeginInit();
            this.SuspendLayout();

            // lblName
            this.lblName.Text = "Название:";
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Size = new System.Drawing.Size(100, 25);

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 12);
            this.txtName.Size = new System.Drawing.Size(250, 22);

            // lblPost
            this.lblPost.Text = "Должность:";
            this.lblPost.Location = new System.Drawing.Point(12, 45);
            this.lblPost.Size = new System.Drawing.Size(100, 25);
            this.lblPost.Visible = false;

            // txtPost
            this.txtPost.Location = new System.Drawing.Point(120, 42);
            this.txtPost.Size = new System.Drawing.Size(250, 22);
            this.txtPost.Visible = false;

            // dgvSelect
            this.dgvSelect.Location = new System.Drawing.Point(12, 12);
            this.dgvSelect.Size = new System.Drawing.Size(400, 300);
            this.dgvSelect.AllowUserToAddRows = false;
            this.dgvSelect.AllowUserToDeleteRows = false;
            this.dgvSelect.ReadOnly = true;
            this.dgvSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelect.MultiSelect = false;
            this.dgvSelect.RowHeadersVisible = false;
            this.dgvSelect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelect.Visible = false;

            // btnSave
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(120, 330);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(230, 330);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // FormSelect
            this.ClientSize = new System.Drawing.Size(430, 380);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPost);
            this.Controls.Add(this.txtPost);
            this.Controls.Add(this.dgvSelect);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Text = "Выбор";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(this.dgvSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}