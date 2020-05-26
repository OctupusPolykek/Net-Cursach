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
    public partial class Password : Form
    {
        public bool isCancel = true;
        public string pass;
        ushort secretKey1 = 0x0088;

        public Password()
        {
            InitializeComponent();
        }
        private void Password_Load(object sender, EventArgs e)
        {
            PsTextBox1.PasswordChar = '*';
            PsTextBox1.MaxLength = 14;

            PsTextBox2.PasswordChar = '*';
            PsTextBox2.MaxLength = 14;
        }
        private void Init_Click(object sender, EventArgs e)
        {
            if (PsTextBox1.Text.Length < 1 || PsTextBox2.Text.Length < 1)
                MessageBox.Show("Введите что-то.");
            else 
            {
                string s1 = PsTextBox1.Text;
                string s2 = PsTextBox2.Text;

                if (s1 == s2)
                {
                    isCancel = false;
                    pass = EncodeDecrypt(s1, secretKey1);
                    this.Close();
                }
                else
                    MessageBox.Show("Пароли не совпадают.");
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
        private void ShowChackBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowChackBox.Checked == true)
            {
                PsTextBox1.PasswordChar = '\0';
                PsTextBox2.PasswordChar = '\0';
            }
            else 
            {
                PsTextBox1.PasswordChar = '*';
                PsTextBox2.PasswordChar = '*';
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            isCancel = true;
            this.Close();
        }
    }
}
