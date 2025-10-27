namespace KeramikDamageControl
{
    partial class UsersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUsers = new Button();
            btnTables = new Button();
            btnSettings = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            btnDelete = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnUsers
            // 
            btnUsers.Enabled = false;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Location = new Point(0, 173);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(150, 69);
            btnUsers.TabIndex = 7;
            btnUsers.Text = "Пользователи";
            btnUsers.UseVisualStyleBackColor = true;
            // 
            // btnTables
            // 
            btnTables.FlatStyle = FlatStyle.Flat;
            btnTables.Location = new Point(0, 104);
            btnTables.Name = "btnTables";
            btnTables.Size = new Size(150, 69);
            btnTables.TabIndex = 6;
            btnTables.Text = "Таблицы";
            btnTables.UseVisualStyleBackColor = true;
            btnTables.Click += btnTables_Click;
            // 
            // btnSettings
            // 
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Location = new Point(0, 37);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(150, 69);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "Настройки";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(47, 5);
            label1.Name = "label1";
            label1.Size = new Size(54, 21);
            label1.TabIndex = 4;
            label1.Text = "Меню";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(156, 37);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(532, 401);
            dataGridView1.TabIndex = 8;
            // 
            // btnDelete
            // 
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(694, 187);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 69);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(694, 37);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 69);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(694, 112);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 69);
            btnEdit.TabIndex = 17;
            btnEdit.Text = "Изменить";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(dataGridView1);
            Controls.Add(btnUsers);
            Controls.Add(btnTables);
            Controls.Add(btnSettings);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UsersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Пользователи";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUsers;
        private Button btnTables;
        private Button btnSettings;
        private Label label1;
        private DataGridView dataGridView1;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
    }
}