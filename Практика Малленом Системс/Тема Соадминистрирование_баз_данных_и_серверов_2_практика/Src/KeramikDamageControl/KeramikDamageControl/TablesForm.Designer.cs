namespace KeramikDamageControl
{
    partial class TablesForm
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
            dataGridViewTables = new DataGridView();
            listBoxTables = new ListBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTables).BeginInit();
            SuspendLayout();
            // 
            // btnUsers
            // 
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Location = new Point(0, 173);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(150, 69);
            btnUsers.TabIndex = 7;
            btnUsers.Text = "Пользователи";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnTables
            // 
            btnTables.Enabled = false;
            btnTables.FlatStyle = FlatStyle.Flat;
            btnTables.Location = new Point(0, 104);
            btnTables.Name = "btnTables";
            btnTables.Size = new Size(150, 69);
            btnTables.TabIndex = 6;
            btnTables.Text = "Таблицы";
            btnTables.UseVisualStyleBackColor = true;
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
            // dataGridViewTables
            // 
            dataGridViewTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTables.Location = new Point(156, 37);
            dataGridViewTables.Name = "dataGridViewTables";
            dataGridViewTables.Size = new Size(532, 401);
            dataGridViewTables.TabIndex = 8;
            // 
            // listBoxTables
            // 
            listBoxTables.FormattingEnabled = true;
            listBoxTables.Location = new Point(12, 269);
            listBoxTables.Name = "listBoxTables";
            listBoxTables.Size = new Size(131, 169);
            listBoxTables.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(694, 37);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 69);
            btnAdd.TabIndex = 10;
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
            btnEdit.TabIndex = 11;
            btnEdit.Text = "Изменить";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(694, 187);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 69);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 251);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 13;
            label2.Text = "Таблицы";
            // 
            // TablesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(listBoxTables);
            Controls.Add(dataGridViewTables);
            Controls.Add(btnUsers);
            Controls.Add(btnTables);
            Controls.Add(btnSettings);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "TablesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Таблицы";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTables).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUsers;
        private Button btnTables;
        private Button btnSettings;
        private Label label1;
        private DataGridView dataGridViewTables;
        private ListBox listBoxTables;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Label label2;
    }
}