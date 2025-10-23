namespace KeramikDamageControl
{
    partial class MainForm
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
            label1 = new Label();
            btnSettings = new Button();
            btnTables = new Button();
            btnUsers = new Button();
            HostText = new TextBox();
            PortText = new TextBox();
            DatabaseText = new TextBox();
            UsernameText = new TextBox();
            PasswordText = new TextBox();
            btnConnect = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(47, 5);
            label1.Name = "label1";
            label1.Size = new Size(54, 21);
            label1.TabIndex = 0;
            label1.Text = "Меню";
            // 
            // btnSettings
            // 
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Location = new Point(0, 37);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(150, 69);
            btnSettings.TabIndex = 1;
            btnSettings.Text = "Настройки";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnTables
            // 
            btnTables.FlatStyle = FlatStyle.Flat;
            btnTables.Location = new Point(0, 104);
            btnTables.Name = "btnTables";
            btnTables.Size = new Size(150, 69);
            btnTables.TabIndex = 2;
            btnTables.Text = "Таблицы";
            btnTables.UseVisualStyleBackColor = true;
            btnTables.Click += btnTables_Click;
            // 
            // btnUsers
            // 
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Location = new Point(0, 173);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(150, 69);
            btnUsers.TabIndex = 3;
            btnUsers.Text = "Пользователи";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // HostText
            // 
            HostText.Location = new Point(354, 45);
            HostText.Name = "HostText";
            HostText.Size = new Size(292, 23);
            HostText.TabIndex = 4;
            // 
            // PortText
            // 
            PortText.Location = new Point(354, 74);
            PortText.Name = "PortText";
            PortText.Size = new Size(292, 23);
            PortText.TabIndex = 5;
            // 
            // DatabaseText
            // 
            DatabaseText.Location = new Point(354, 103);
            DatabaseText.Name = "DatabaseText";
            DatabaseText.Size = new Size(292, 23);
            DatabaseText.TabIndex = 6;
            // 
            // UsernameText
            // 
            UsernameText.Location = new Point(354, 132);
            UsernameText.Name = "UsernameText";
            UsernameText.Size = new Size(292, 23);
            UsernameText.TabIndex = 7;
            // 
            // PasswordText
            // 
            PasswordText.Location = new Point(354, 161);
            PasswordText.Name = "PasswordText";
            PasswordText.Size = new Size(292, 23);
            PasswordText.TabIndex = 8;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(513, 200);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(133, 23);
            btnConnect.TabIndex = 9;
            btnConnect.Text = "Подключится";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(316, 48);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 10;
            label2.Text = "Host";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(316, 77);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 11;
            label3.Text = "Port";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(293, 108);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 12;
            label4.Text = "Database";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(288, 135);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 13;
            label5.Text = "Username";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(291, 164);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 14;
            label6.Text = "Password";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 248);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnConnect);
            Controls.Add(PasswordText);
            Controls.Add(UsernameText);
            Controls.Add(DatabaseText);
            Controls.Add(PortText);
            Controls.Add(HostText);
            Controls.Add(btnUsers);
            Controls.Add(btnTables);
            Controls.Add(btnSettings);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Настройки";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSettings;
        private Button btnTables;
        private Button btnUsers;
        private TextBox HostText;
        private TextBox PortText;
        private TextBox DatabaseText;
        private TextBox UsernameText;
        private TextBox PasswordText;
        private Button btnConnect;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}