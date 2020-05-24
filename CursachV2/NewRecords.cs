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
    public partial class NewRecords : Form
    {
        public string name;
        public string manufacturer;
        public int price;
        public int amount;
        public int shopNumber;
        public int minimumLot;

        public bool isCorrect = false;
        public string btnTxt;
        public NewRecords()
        {
            InitializeComponent();
        }
        private void NewRecords_Load(object sender, EventArgs e)
        {
            nameTextBox.Text = name;
            manufacturerTextBox.Text = manufacturer;
            if (price != 0 || amount != 0 || shopNumber != 0 || minimumLot != 0)
            {
                priceTextBox.Text = price + "";
                amountTextBox.Text = amount + "";
                shopNumberTextBox.Text = shopNumber + "";
                minimumLotTextBox.Text = minimumLot + "";
            }
            AddBtn.Text = btnTxt;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Length < 1 || manufacturerTextBox.Text.Length < 1 || priceTextBox.Text.Length < 1 || amountTextBox.Text.Length < 1 || shopNumberTextBox.Text.Length < 1 || minimumLotTextBox.Text.Length < 1)
                MessageBox.Show("Введите что-то.");
            else
            {
                name = nameTextBox.Text;
                manufacturer = manufacturerTextBox.Text;
                price = Int32.Parse(priceTextBox.Text);
                amount = Int32.Parse(amountTextBox.Text);
                shopNumber = Int32.Parse(shopNumberTextBox.Text);
                minimumLot = Int32.Parse(minimumLotTextBox.Text);
                if (price < 1 || amount < 1 || shopNumber < 1 || minimumLot < 1)
                    MessageBox.Show("Число не можeт быть меньше 1.");
                else
                {
                    isCorrect = true;
                    this.Close();
                }
            }
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            nameTextBox.Clear();
            manufacturerTextBox.Clear();
            priceTextBox.Clear();
            amountTextBox.Clear();
            shopNumberTextBox.Clear();
            minimumLotTextBox.Clear();
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            isCorrect = false;
            this.Close();
        }
        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
        private void amountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
        private void shopNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
        private void minimumLotTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
