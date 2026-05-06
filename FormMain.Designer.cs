namespace WindowsFormsWorkstationsBD
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvLeft;
        private System.Windows.Forms.DataGridView dgvCenter;
        private System.Windows.Forms.DataGridView dgvRight;
        private System.Windows.Forms.Button btnModeServersIvanovLev;
        private System.Windows.Forms.Button btnModeOperators;
        private System.Windows.Forms.Button btnAddLeft;
        private System.Windows.Forms.Button btnDeleteServer;
        private System.Windows.Forms.Button btnDeleteOperator;
        private System.Windows.Forms.Button btnAddCenter;
        private System.Windows.Forms.Button btnDeleteCenter;
        private System.Windows.Forms.Button btnAddRight;
        private System.Windows.Forms.Button btnDeleteRight;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblCenter;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // ПсковГУ ПИШ - Иванов Лев, 0483-05 гр. 2026 год, к курсовой работе

        private void InitializeComponent()
        {
            this.dgvLeft = new System.Windows.Forms.DataGridView();
            this.dgvCenter = new System.Windows.Forms.DataGridView();
            this.dgvRight = new System.Windows.Forms.DataGridView();
            this.btnModeServersIvanovLev = new System.Windows.Forms.Button();
            this.btnModeOperators = new System.Windows.Forms.Button();
            this.btnAddLeft = new System.Windows.Forms.Button();
            this.btnDeleteServer = new System.Windows.Forms.Button();
            this.btnDeleteOperator = new System.Windows.Forms.Button();
            this.btnAddCenter = new System.Windows.Forms.Button();
            this.btnDeleteCenter = new System.Windows.Forms.Button();
            this.btnAddRight = new System.Windows.Forms.Button();
            this.btnDeleteRight = new System.Windows.Forms.Button();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblCenter = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRight)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLeft
            // 
            this.dgvLeft.AllowUserToAddRows = false;
            this.dgvLeft.AllowUserToDeleteRows = false;
            this.dgvLeft.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLeft.BackgroundColor = System.Drawing.Color.White;
            this.dgvLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLeft.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeft.Location = new System.Drawing.Point(20, 80);
            this.dgvLeft.MultiSelect = false;
            this.dgvLeft.Name = "dgvLeft";
            this.dgvLeft.ReadOnly = true;
            this.dgvLeft.RowHeadersVisible = false;
            this.dgvLeft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLeft.Size = new System.Drawing.Size(250, 420);
            this.dgvLeft.TabIndex = 0;
            this.dgvLeft.SelectionChanged += new System.EventHandler(this.dgvLeft_SelectionChanged);
            // 
            // dgvCenter
            // 
            this.dgvCenter.AllowUserToAddRows = false;
            this.dgvCenter.AllowUserToDeleteRows = false;
            this.dgvCenter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCenter.BackgroundColor = System.Drawing.Color.White;
            this.dgvCenter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCenter.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCenter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCenter.Location = new System.Drawing.Point(285, 80);
            this.dgvCenter.MultiSelect = false;
            this.dgvCenter.Name = "dgvCenter";
            this.dgvCenter.ReadOnly = true;
            this.dgvCenter.RowHeadersVisible = false;
            this.dgvCenter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCenter.Size = new System.Drawing.Size(250, 420);
            this.dgvCenter.TabIndex = 1;
            this.dgvCenter.SelectionChanged += new System.EventHandler(this.dgvCenter_SelectionChanged);
            // 
            // dgvRight
            // 
            this.dgvRight.AllowUserToAddRows = false;
            this.dgvRight.AllowUserToDeleteRows = false;
            this.dgvRight.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRight.BackgroundColor = System.Drawing.Color.White;
            this.dgvRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRight.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRight.Location = new System.Drawing.Point(550, 80);
            this.dgvRight.MultiSelect = false;
            this.dgvRight.Name = "dgvRight";
            this.dgvRight.ReadOnly = true;
            this.dgvRight.RowHeadersVisible = false;
            this.dgvRight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRight.Size = new System.Drawing.Size(250, 420);
            this.dgvRight.TabIndex = 2;
            // 
            // btnModeServersIvanovLev
            // 
            this.btnModeServersIvanovLev.BackColor = System.Drawing.Color.White;
            this.btnModeServersIvanovLev.FlatAppearance.BorderSize = 0;
            this.btnModeServersIvanovLev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModeServersIvanovLev.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnModeServersIvanovLev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnModeServersIvanovLev.Location = new System.Drawing.Point(560, 18);
            this.btnModeServersIvanovLev.Name = "btnModeServersIvanovLev";
            this.btnModeServersIvanovLev.Size = new System.Drawing.Size(100, 26);
            this.btnModeServersIvanovLev.TabIndex = 1;
            this.btnModeServersIvanovLev.Text = "Серверы";
            this.btnModeServersIvanovLev.UseVisualStyleBackColor = false;
            this.btnModeServersIvanovLev.Click += new System.EventHandler(this.btnModeServers_Click);
            // 
            // btnModeOperators
            // 
            this.btnModeOperators.BackColor = System.Drawing.Color.White;
            this.btnModeOperators.FlatAppearance.BorderSize = 0;
            this.btnModeOperators.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModeOperators.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnModeOperators.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnModeOperators.Location = new System.Drawing.Point(670, 18);
            this.btnModeOperators.Name = "btnModeOperators";
            this.btnModeOperators.Size = new System.Drawing.Size(100, 26);
            this.btnModeOperators.TabIndex = 2;
            this.btnModeOperators.Text = "Операторы";
            this.btnModeOperators.UseVisualStyleBackColor = false;
            this.btnModeOperators.Click += new System.EventHandler(this.btnModeOperators_Click);
            // 
            // btnAddLeft
            // 
            this.btnAddLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.btnAddLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnAddLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnAddLeft.Location = new System.Drawing.Point(20, 535);
            this.btnAddLeft.Name = "btnAddLeft";
            this.btnAddLeft.Size = new System.Drawing.Size(125, 32);
            this.btnAddLeft.TabIndex = 6;
            this.btnAddLeft.Text = "Добавить";
            this.btnAddLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddLeft.UseVisualStyleBackColor = false;
            this.btnAddLeft.Click += new System.EventHandler(this.btnAddLeft_Click);
            // 
            // btnDeleteServer
            // 
            this.btnDeleteServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.btnDeleteServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnDeleteServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(59)))), ((int)(((byte)(48)))));
            this.btnDeleteServer.Location = new System.Drawing.Point(150, 535);
            this.btnDeleteServer.Name = "btnDeleteServer";
            this.btnDeleteServer.Size = new System.Drawing.Size(120, 32);
            this.btnDeleteServer.TabIndex = 7;
            this.btnDeleteServer.Text = "Удалить сервер";
            this.btnDeleteServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteServer.UseVisualStyleBackColor = false;
            this.btnDeleteServer.Click += new System.EventHandler(this.btnDeleteServer_Click);
            // 
            // btnDeleteOperator
            // 
            this.btnDeleteOperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.btnDeleteOperator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnDeleteOperator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(59)))), ((int)(((byte)(48)))));
            this.btnDeleteOperator.Location = new System.Drawing.Point(150, 535);
            this.btnDeleteOperator.Name = "btnDeleteOperator";
            this.btnDeleteOperator.Size = new System.Drawing.Size(120, 32);
            this.btnDeleteOperator.TabIndex = 8;
            this.btnDeleteOperator.Text = "Удалить оператора";
            this.btnDeleteOperator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteOperator.UseVisualStyleBackColor = false;
            this.btnDeleteOperator.Visible = false;
            this.btnDeleteOperator.Click += new System.EventHandler(this.btnDeleteOperator_Click);
            // 
            // btnAddCenter
            // 
            this.btnAddCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.btnAddCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAddCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnAddCenter.Location = new System.Drawing.Point(285, 535);
            this.btnAddCenter.Name = "btnAddCenter";
            this.btnAddCenter.Size = new System.Drawing.Size(120, 32);
            this.btnAddCenter.TabIndex = 9;
            this.btnAddCenter.Text = "Добавить";
            this.btnAddCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCenter.UseVisualStyleBackColor = false;
            this.btnAddCenter.Click += new System.EventHandler(this.btnAddCenter_Click);
            // 
            // btnDeleteCenter
            // 
            this.btnDeleteCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.btnDeleteCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnDeleteCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(59)))), ((int)(((byte)(48)))));
            this.btnDeleteCenter.Location = new System.Drawing.Point(415, 535);
            this.btnDeleteCenter.Name = "btnDeleteCenter";
            this.btnDeleteCenter.Size = new System.Drawing.Size(120, 32);
            this.btnDeleteCenter.TabIndex = 10;
            this.btnDeleteCenter.Text = "Удалить";
            this.btnDeleteCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteCenter.UseVisualStyleBackColor = false;
            this.btnDeleteCenter.Click += new System.EventHandler(this.btnDeleteCenter_Click);
            // 
            // btnAddRight
            // 
            this.btnAddRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.btnAddRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAddRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnAddRight.Location = new System.Drawing.Point(550, 535);
            this.btnAddRight.Name = "btnAddRight";
            this.btnAddRight.Size = new System.Drawing.Size(120, 32);
            this.btnAddRight.TabIndex = 11;
            this.btnAddRight.Text = "Установить";
            this.btnAddRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRight.UseVisualStyleBackColor = false;
            this.btnAddRight.Click += new System.EventHandler(this.btnAddRight_Click);
            // 
            // btnDeleteRight
            // 
            this.btnDeleteRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.btnDeleteRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnDeleteRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(59)))), ((int)(((byte)(48)))));
            this.btnDeleteRight.Location = new System.Drawing.Point(680, 535);
            this.btnDeleteRight.Name = "btnDeleteRight";
            this.btnDeleteRight.Size = new System.Drawing.Size(120, 32);
            this.btnDeleteRight.TabIndex = 12;
            this.btnDeleteRight.Text = "Удалить";
            this.btnDeleteRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteRight.UseVisualStyleBackColor = false;
            this.btnDeleteRight.Click += new System.EventHandler(this.btnDeleteRight_Click);
            // 
            // lblLeft
            // 
            this.lblLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblLeft.Location = new System.Drawing.Point(20, 505);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(250, 20);
            this.lblLeft.TabIndex = 3;
            this.lblLeft.Text = "СЕРВЕРЫ";
            this.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCenter
            // 
            this.lblCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblCenter.Location = new System.Drawing.Point(285, 505);
            this.lblCenter.Name = "lblCenter";
            this.lblCenter.Size = new System.Drawing.Size(250, 20);
            this.lblCenter.TabIndex = 4;
            this.lblCenter.Text = "РАБОЧИЕ СТАНЦИИ";
            this.lblCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRight
            // 
            this.lblRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblRight.Location = new System.Drawing.Point(550, 505);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(250, 20);
            this.lblRight.TabIndex = 5;
            this.lblRight.Text = "ПРОГРАММЫ";
            this.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.btnModeServersIvanovLev);
            this.headerPanel.Controls.Add(this.btnModeOperators);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(820, 60);
            this.headerPanel.TabIndex = 13;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(16, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(254, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Workstations";
            // 
            // FormMain
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(820, 590);
            this.Controls.Add(this.dgvLeft);
            this.Controls.Add(this.dgvCenter);
            this.Controls.Add(this.dgvRight);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.lblCenter);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.btnAddLeft);
            this.Controls.Add(this.btnDeleteServer);
            this.Controls.Add(this.btnDeleteOperator);
            this.Controls.Add(this.btnAddCenter);
            this.Controls.Add(this.btnDeleteCenter);
            this.Controls.Add(this.btnAddRight);
            this.Controls.Add(this.btnDeleteRight);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workstations";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRight)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}