using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E3_WGM
{
    public partial class FormNameContainer : Form
    {
        public String containerName = "";
        public FormNameContainer()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string input = textBoxContainerName.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Наименование не может быть пустым. Введите значение.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // форма не закрывается
            }

            containerName = input;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }    
    }
}
