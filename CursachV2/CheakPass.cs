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
    public partial class CheakPass : Form
    {
        public string pass;
        public bool isCancel = true;
        ushort secretKey2 = 0x0088;
        public CheakPass()
        {
            InitializeComponent();
        }
        private void CheakPass_Load(object sender, EventArgs e)
        {
            InitPassTextBox.PasswordChar = '*';
            InitPassTextBox.MaxLength = 14;
        }
        private void Init_Click(object sender, EventArgs e)
        {
            if (InitPassTextBox.Text.Length < 1)
                MessageBox.Show("Введите что-то.");
            else
            {
                isCancel = false;
                string s = InitPassTextBox.Text;
                pass = EncodeDecrypt(s, secretKey2);
                this.Close();
            }
        }
        private static string EncodeDecrypt(string str, ushort secretKey)
        {
            var ch = str.ToArray(); //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
                newStr += TopSecret(c, secretKey);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return newStr;
        }
        private static char TopSecret(char character, ushort secretKey)
        {
            character = (char)(character ^ secretKey); //Производим XOR операцию
            return character;
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ShowChackBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ShowChackBox.Checked == true)
                InitPassTextBox.PasswordChar = '\0';
            else
                InitPassTextBox.PasswordChar = '*';
        }
    }
}
