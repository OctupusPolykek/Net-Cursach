using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursachV2
{
    public partial class Search : Form
    {
        public string value;
        public string domainValue;
        public bool isCancel = true;

        public string[] arrDomain;
        public Search()
        {
            InitializeComponent();
        }
        private void Search_Load(object sender, EventArgs e)
        {
            DomainUpDown.DomainUpDownItemCollection collection = this.searchDomain.Items;
            for (int i = 0; i < arrDomain.Length; i++)
            {
                collection.Add(arrDomain[i]);
            }
            this.searchDomain.Text = arrDomain[0];
            this.searchDomain.ReadOnly = true;
        }
        private void initBtn_Click(object sender, EventArgs e)
        {
            domainValue = this.searchDomain.Text;

            if (valueTxtBox.Text.Length < 1)
                MessageBox.Show("Введите что-то.");
            else
            {
                value = valueTxtBox.Text;
                isCancel = false;
                this.Close();
            }
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            isCancel = true;
            this.Close();
        }
    }
}
