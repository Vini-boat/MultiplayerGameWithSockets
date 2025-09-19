using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class NewGroupForm : Form
    {
        public string GroupName => GroupNameTextBox.Text;
        public List<string> SelectedContacts => ContactsListBox.CheckedItems.Cast<string>().ToList();
        public NewGroupForm(List<string> contacts)
        {

            InitializeComponent();
            ContactsListBox.Items.AddRange(contacts.ToArray());
        }

        private void AcceptButton_Click(object sender, EventArgs e) 
        { 
            this.DialogResult = DialogResult.OK; 
            this.Close(); 
        }
        private void CancelButton_Click(object sender, EventArgs e) 
        { 
            this.DialogResult = DialogResult.Cancel; 
            this.Close(); 
        }
    }
}
