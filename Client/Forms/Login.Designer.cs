namespace Client
{
    partial class Login
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
            label4 = new Label();
            ipTextBox = new TextBox();
            label3 = new Label();
            portTextBox = new TextBox();
            connectButton = new Button();
            label2 = new Label();
            nicknameTextBox = new TextBox();
            label1 = new Label();
            passwordTextBox = new TextBox();
            createNewAccountButton = new Button();
            loginButton = new Button();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 15);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 24;
            label4.Text = "Ip";
            // 
            // ipTextBox
            // 
            ipTextBox.Location = new Point(84, 12);
            ipTextBox.Name = "ipTextBox";
            ipTextBox.Size = new Size(100, 23);
            ipTextBox.TabIndex = 2;
            ipTextBox.Text = "127.0.0.1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 44);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 22;
            label3.Text = "Port";
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(84, 41);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(100, 23);
            portTextBox.TabIndex = 3;
            portTextBox.Text = "8888";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(40, 70);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(144, 23);
            connectButton.TabIndex = 1;
            connectButton.Text = "Conectar";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Location = new Point(40, 102);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 19;
            label2.Text = "Nick";
            // 
            // nicknameTextBox
            // 
            nicknameTextBox.Enabled = false;
            nicknameTextBox.Location = new Point(84, 99);
            nicknameTextBox.Name = "nicknameTextBox";
            nicknameTextBox.Size = new Size(100, 23);
            nicknameTextBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Location = new Point(40, 131);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 26;
            label1.Text = "Senha";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Enabled = false;
            passwordTextBox.Location = new Point(84, 128);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 5;
            // 
            // createNewAccountButton
            // 
            createNewAccountButton.Enabled = false;
            createNewAccountButton.Location = new Point(40, 186);
            createNewAccountButton.Name = "createNewAccountButton";
            createNewAccountButton.Size = new Size(144, 23);
            createNewAccountButton.TabIndex = 7;
            createNewAccountButton.Text = "Criar nova conta";
            createNewAccountButton.UseVisualStyleBackColor = true;
            createNewAccountButton.Click += createNewAccountButton_Click;
            // 
            // loginButton
            // 
            loginButton.Enabled = false;
            loginButton.Location = new Point(40, 157);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(144, 23);
            loginButton.TabIndex = 6;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 229);
            Controls.Add(loginButton);
            Controls.Add(createNewAccountButton);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(label4);
            Controls.Add(ipTextBox);
            Controls.Add(label3);
            Controls.Add(portTextBox);
            Controls.Add(connectButton);
            Controls.Add(label2);
            Controls.Add(nicknameTextBox);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private TextBox ipTextBox;
        private Label label3;
        private TextBox portTextBox;
        private Button connectButton;
        private Label label2;
        private TextBox nicknameTextBox;
        private Label label1;
        private TextBox passwordTextBox;
        private Button createNewAccountButton;
        private Button loginButton;
    }
}