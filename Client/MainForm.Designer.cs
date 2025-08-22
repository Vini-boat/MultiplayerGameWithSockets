namespace Client
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ChatRichTextBox = new RichTextBox();
            messageTextBox = new TextBox();
            sendButton = new Button();
            label1 = new Label();
            nicknameTextBox = new TextBox();
            label2 = new Label();
            connectButton = new Button();
            label3 = new Label();
            portTextBox = new TextBox();
            label4 = new Label();
            ipTextBox = new TextBox();
            SuspendLayout();
            // 
            // ChatRichTextBox
            // 
            ChatRichTextBox.CausesValidation = false;
            ChatRichTextBox.Enabled = false;
            ChatRichTextBox.Location = new Point(278, 119);
            ChatRichTextBox.Name = "ChatRichTextBox";
            ChatRichTextBox.ReadOnly = true;
            ChatRichTextBox.Size = new Size(238, 184);
            ChatRichTextBox.TabIndex = 0;
            ChatRichTextBox.Text = "";
            // 
            // messageTextBox
            // 
            messageTextBox.Enabled = false;
            messageTextBox.Location = new Point(278, 309);
            messageTextBox.Name = "messageTextBox";
            messageTextBox.Size = new Size(165, 23);
            messageTextBox.TabIndex = 1;
            messageTextBox.KeyDown += messageTextBox_KeyDown;
            // 
            // sendButton
            // 
            sendButton.Enabled = false;
            sendButton.Location = new Point(449, 309);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(67, 23);
            sendButton.TabIndex = 2;
            sendButton.Text = "send";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(383, 101);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // nicknameTextBox
            // 
            nicknameTextBox.Location = new Point(49, 62);
            nicknameTextBox.Name = "nicknameTextBox";
            nicknameTextBox.Size = new Size(100, 23);
            nicknameTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 65);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 5;
            label2.Text = "Nick";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(155, 62);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 6;
            connectButton.Text = "conectar";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 36);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 8;
            label3.Text = "Port";
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(49, 33);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(100, 23);
            portTextBox.TabIndex = 7;
            portTextBox.Text = "8888";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 7);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 10;
            label4.Text = "Ip";
            // 
            // ipTextBox
            // 
            ipTextBox.Location = new Point(49, 4);
            ipTextBox.Name = "ipTextBox";
            ipTextBox.Size = new Size(100, 23);
            ipTextBox.TabIndex = 9;
            ipTextBox.Text = "127.0.0.1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(ipTextBox);
            Controls.Add(label3);
            Controls.Add(portTextBox);
            Controls.Add(connectButton);
            Controls.Add(label2);
            Controls.Add(nicknameTextBox);
            Controls.Add(label1);
            Controls.Add(sendButton);
            Controls.Add(messageTextBox);
            Controls.Add(ChatRichTextBox);
            Name = "MainForm";
            Text = "Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox ChatRichTextBox;
        private TextBox messageTextBox;
        private Button sendButton;
        private Label label1;
        private TextBox nicknameTextBox;
        private Label label2;
        private Button connectButton;
        private Label label3;
        private TextBox portTextBox;
        private Label label4;
        private TextBox ipTextBox;
    }
}
