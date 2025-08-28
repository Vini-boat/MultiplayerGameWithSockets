namespace Client
{
    partial class ChatForm
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
            splitContainer1 = new SplitContainer();
            tabControl1 = new TabControl();
            Contatos = new TabPage();
            ContactsflowLayoutPanel = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label1 = new Label();
            Grupos = new TabPage();
            flowLayoutPanel3 = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            label2 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button1 = new Button();
            Configurações = new TabPage();
            flowLayoutPanel4 = new FlowLayoutPanel();
            button3 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            Contatos.SuspendLayout();
            ContactsflowLayoutPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            Grupos.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            Configurações.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Panel2.Controls.Add(richTextBox1);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Contatos);
            tabControl1.Controls.Add(Grupos);
            tabControl1.Controls.Add(Configurações);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(266, 450);
            tabControl1.TabIndex = 0;
            // 
            // Contatos
            // 
            Contatos.Controls.Add(ContactsflowLayoutPanel);
            Contatos.Location = new Point(4, 24);
            Contatos.Name = "Contatos";
            Contatos.Padding = new Padding(3);
            Contatos.Size = new Size(258, 422);
            Contatos.TabIndex = 0;
            Contatos.Text = "Contatos";
            Contatos.UseVisualStyleBackColor = true;
            // 
            // ContactsflowLayoutPanel
            // 
            ContactsflowLayoutPanel.AutoScroll = true;
            ContactsflowLayoutPanel.Controls.Add(groupBox1);
            ContactsflowLayoutPanel.Dock = DockStyle.Fill;
            ContactsflowLayoutPanel.Location = new Point(3, 3);
            ContactsflowLayoutPanel.Name = "ContactsflowLayoutPanel";
            ContactsflowLayoutPanel.Size = new Size(252, 416);
            ContactsflowLayoutPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(228, 47);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Contato1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(249, 249, 249);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(180, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 1;
            label3.Text = "Offline";
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.MaximumSize = new Size(220, 20);
            label1.Name = "label1";
            label1.Size = new Size(216, 20);
            label1.TabIndex = 0;
            label1.Text = "10:10 - a a a a a a a a a a a a a a a a a a a a a a a a ";
            // 
            // Grupos
            // 
            Grupos.Controls.Add(flowLayoutPanel3);
            Grupos.Controls.Add(flowLayoutPanel2);
            Grupos.Location = new Point(4, 24);
            Grupos.Name = "Grupos";
            Grupos.Padding = new Padding(3);
            Grupos.Size = new Size(258, 422);
            Grupos.TabIndex = 1;
            Grupos.Text = "Grupos";
            Grupos.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoScroll = true;
            flowLayoutPanel3.Controls.Add(groupBox2);
            flowLayoutPanel3.Dock = DockStyle.Bottom;
            flowLayoutPanel3.Location = new Point(3, 37);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(252, 382);
            flowLayoutPanel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(230, 45);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Grupo1";
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.MaximumSize = new Size(220, 20);
            label2.Name = "label2";
            label2.Size = new Size(220, 20);
            label2.TabIndex = 0;
            label2.Text = "10:10 - [Nick] - a a a a a a a a a a a a a a a a a a a a a ";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(button1);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(252, 31);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(81, 25);
            button1.TabIndex = 0;
            button1.Text = "Novo grupo";
            button1.UseVisualStyleBackColor = true;
            // 
            // Configurações
            // 
            Configurações.Controls.Add(flowLayoutPanel4);
            Configurações.Location = new Point(4, 24);
            Configurações.Name = "Configurações";
            Configurações.Size = new Size(258, 422);
            Configurações.TabIndex = 2;
            Configurações.Text = "Configurações";
            Configurações.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(button3);
            flowLayoutPanel4.Dock = DockStyle.Fill;
            flowLayoutPanel4.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel4.Location = new Point(0, 0);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(258, 422);
            flowLayoutPanel4.TabIndex = 0;
            // 
            // button3
            // 
            button3.AutoSize = true;
            button3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button3.Location = new Point(219, 3);
            button3.Name = "button3";
            button3.Size = new Size(36, 25);
            button3.TabIndex = 0;
            button3.Text = "Sair";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.Location = new Point(469, 413);
            button2.Name = "button2";
            button2.Size = new Size(49, 25);
            button2.TabIndex = 2;
            button2.Text = "Enviar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 415);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(460, 23);
            textBox1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(524, 406);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "ChatForm";
            Text = "ChatForm";
            Load += ChatForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            Contatos.ResumeLayout(false);
            ContactsflowLayoutPanel.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            Grupos.ResumeLayout(false);
            Grupos.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            Configurações.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TabControl tabControl1;
        private TabPage Contatos;
        private FlowLayoutPanel ContactsflowLayoutPanel;
        private TabPage Grupos;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button1;
        private RichTextBox richTextBox1;
        private FlowLayoutPanel flowLayoutPanel3;
        private TabPage Configurações;
        private Button button2;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel4;
        private Button button3;
        private GroupBox groupBox2;
        private Label label2;
        private Label label3;
    }
}