namespace Client.Forms
{
    partial class NewGroupForm
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
            ContactsListBox = new CheckedListBox();
            GroupNameTextBox = new TextBox();
            label1 = new Label();
            AcceptButton = new Button();
            CancelButton = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // ContactsListBox
            // 
            ContactsListBox.FormattingEnabled = true;
            ContactsListBox.Location = new Point(12, 77);
            ContactsListBox.Name = "ContactsListBox";
            ContactsListBox.Size = new Size(272, 130);
            ContactsListBox.TabIndex = 0;
            // 
            // GroupNameTextBox
            // 
            GroupNameTextBox.Location = new Point(113, 12);
            GroupNameTextBox.Name = "GroupNameTextBox";
            GroupNameTextBox.Size = new Size(171, 23);
            GroupNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 2;
            label1.Text = "Nome do grupo:";
            // 
            // AcceptButton
            // 
            AcceptButton.Location = new Point(125, 213);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(78, 23);
            AcceptButton.TabIndex = 3;
            AcceptButton.Text = "Criar Grupo";
            AcceptButton.UseVisualStyleBackColor = true;
            AcceptButton.Click += AcceptButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(209, 213);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 4;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 59);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 5;
            label2.Text = "Participantes:";
            // 
            // NewGroupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(296, 245);
            Controls.Add(label2);
            Controls.Add(CancelButton);
            Controls.Add(AcceptButton);
            Controls.Add(label1);
            Controls.Add(GroupNameTextBox);
            Controls.Add(ContactsListBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "NewGroupForm";
            Text = "NewGroupForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox ContactsListBox;
        private TextBox GroupNameTextBox;
        private Label label1;
        private Button AcceptButton;
        private Button CancelButton;
        private Label label2;
    }
}