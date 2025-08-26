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
            textBox1 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 9);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 24;
            label4.Text = "Ip";
            // 
            // ipTextBox
            // 
            ipTextBox.Location = new Point(54, 6);
            ipTextBox.Name = "ipTextBox";
            ipTextBox.Size = new Size(100, 23);
            ipTextBox.TabIndex = 23;
            ipTextBox.Text = "127.0.0.1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 38);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 22;
            label3.Text = "Port";
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(54, 35);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(100, 23);
            portTextBox.TabIndex = 21;
            portTextBox.Text = "8888";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(10, 122);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(144, 23);
            connectButton.TabIndex = 20;
            connectButton.Text = "Conectar";
            connectButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 67);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 19;
            label2.Text = "Nick";
            // 
            // nicknameTextBox
            // 
            nicknameTextBox.Location = new Point(54, 64);
            nicknameTextBox.Name = "nicknameTextBox";
            nicknameTextBox.Size = new Size(100, 23);
            nicknameTextBox.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 96);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 26;
            label1.Text = "Senha";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(54, 93);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 25;
            // 
            // button1
            // 
            button1.Location = new Point(10, 151);
            button1.Name = "button1";
            button1.Size = new Size(144, 23);
            button1.TabIndex = 27;
            button1.Text = "Criar nova conta";
            button1.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(164, 181);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
        private Button button1;
    }
}