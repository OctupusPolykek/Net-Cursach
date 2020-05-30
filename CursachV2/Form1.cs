using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CursachV2
{
    public partial class Form1 : Form
    {
        CarShop carShop, carShop2;
        public int count;

        string saveToPath;

        bool isPass = false;
        string password;

        NewRecords newRec;
        NewRecords redactionRec;

        Search search;
        Search redactionSearch;
        Search deleateEl;

        Password newPass;
        CheakPass cheakpass;
        //AppA
        Search searchStore;
        //-=-
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            carShop = new CarShop(0);
            this.FormClosed += MyClosedHandlerMainForm;

            AddRecord.Enabled = false;
            dataGridView1.Enabled = false;
            groupBox1.Enabled = false;
            поискToolStripMenuItem.Enabled = false;
            ShowInfoCheck.Enabled = false;
            сохранитьToolStripMenuItem.Enabled = false;
            запаролитьToolStripMenuItem.Enabled = false;
            редактированиеЗаписейToolStripMenuItem.Enabled = false;
            выводToolStripMenuItem.Enabled = false;
        }
        protected void MyClosedHandlerMainForm(object sender, EventArgs e)
        {
            if (carShop.ReturnLenght() > 0)
            {
                var save = MessageBox.Show("Хотите сохранить значения?", "Сохранение", MessageBoxButtons.YesNo);
                if (save == DialogResult.Yes)
                {
                    carShop.SaveTo(saveToPath);
                }
            }

        }
        private void AddRecord_Click(object sender, EventArgs e)
        {
            newRec = new NewRecords();
            newRec.btnTxt = "Добавить";
            newRec.Show();
            newRec.FormClosed += MyClosedHandlerRecords;

            выводToolStripMenuItem.Enabled = true;
        }
        protected void MyClosedHandlerRecords(object sender, EventArgs e)
        {
            if (newRec.isCorrect)
            {
                carShop.AddProduct(newRec.name, newRec.manufacturer, newRec.price, newRec.amount, newRec.shopNumber, newRec.minimumLot);
                carShop.WriteIn(dataGridView1);
            }
        }
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string path = openFileDialog1.FileName;
            MessageBox.Show(path);
            saveToPath = path;
            carShop = new CarShop(1);
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))//Считывание  
            {
                isPass = reader.ReadBoolean();
                if (isPass)
                    password = reader.ReadString();
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    string manufacturer = reader.ReadString();
                    int price = reader.ReadInt32();
                    int amount = reader.ReadInt32();
                    int shopNumber = reader.ReadInt32();
                    int minimumLot = reader.ReadInt32();

                    carShop.AddProduct(name, manufacturer, price, amount, shopNumber, minimumLot);
                }
            }
            if (isPass)
                запаролитьToolStripMenuItem.Text = "Изменить пароль";
            else
                запаролитьToolStripMenuItem.Text = "Запаролить";

            AddRecord.Enabled = true;
            dataGridView1.Enabled = true;
            groupBox1.Enabled = true;
            поискToolStripMenuItem.Enabled = true;
            сохранитьToolStripMenuItem.Enabled = true;
            запаролитьToolStripMenuItem.Enabled = true;
            редактированиеЗаписейToolStripMenuItem.Enabled = true;
            выводToolStripMenuItem.Enabled = true;

            carShop.WriteIn(dataGridView1);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (carShop.ReturnLenght() > 0)
            {
                carShop.SaveTo(saveToPath);
                MessageBox.Show("Файл сохранен.");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            // получаем выбранный файл
            saveToPath = saveFileDialog1.FileName;

            AddRecord.Enabled = true;
            dataGridView1.Enabled = true;
            groupBox1.Enabled = true;
            поискToolStripMenuItem.Enabled = true;
            сохранитьToolStripMenuItem.Enabled = true;
            запаролитьToolStripMenuItem.Enabled = true;
            редактированиеЗаписейToolStripMenuItem.Enabled = true;
        }

        //--Search--//
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowInfoCheck.Enabled = true;

            search = new Search();
            search.arrDomain = new string[] { "Наименование", "Фирма", "Номер магазина", "ID элемента" };
            search.Show();
            search.FormClosed += MyClosedHandlerSearch;
        }
        protected void MyClosedHandlerSearch(object sender, EventArgs e)
        {
            if (!search.isCancel)
            {
                carShop2 = carShop.Search(search.domainValue, search.value);
                if (carShop2.ReturnLenght() < 1)
                {
                    MessageBox.Show("Запись не найдена.");
                }
                else
                {
                    ShowInfoCheck.Enabled = true;
                    ShowInfoCheck.Checked = false;
                }
            }
            else
            {
                ShowInfoCheck.Checked = true;
            }
        }
        //---------//
        private void редToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isPass)
            {
                cheakpass = new CheakPass();
                cheakpass.Show();
                cheakpass.FormClosed += MyClosedHandlerCheakPass;
            }
            else 
            {
                redactionSearch = new Search();
                redactionSearch.Text = "Redaction";
                redactionSearch.arrDomain = new string[] { "ID элемента" };
                redactionSearch.Show();
                redactionSearch.FormClosed += MyClosedHandlerRedaction;
            }
        }
        protected void MyClosedHandlerCheakPass(object sender, EventArgs e)
        {
            if (!cheakpass.isCancel)
            {
                if (cheakpass.pass == password)
                {
                    redactionSearch = new Search();
                    redactionSearch.Text = "Redaction";
                    redactionSearch.arrDomain = new string[] { "Индекс массива" };
                    redactionSearch.Show();
                    redactionSearch.FormClosed += MyClosedHandlerRedaction;
                }
                else
                    MessageBox.Show("Неверный пароль.");
            }
        }
        protected void MyClosedHandlerRedaction(object sender, EventArgs e)
        {
            if (!redactionSearch.isCancel)
            {
                int x = Int32.Parse(redactionSearch.value);

                redactionRec = new NewRecords();
                redactionRec.Text = "Init redaction";
                redactionRec.btnTxt = "Изменить";

                redactionRec.name = carShop.RefreshName(x);
                redactionRec.manufacturer = carShop.RefreshManufacturer(x);
                redactionRec.price = carShop.RefreshPrice(x);
                redactionRec.amount = carShop.RefreshAmount(x);
                redactionRec.shopNumber = carShop.RefreshShopNumber(x);
                redactionRec.minimumLot = carShop.RefreshMinimumLot(x);

                redactionRec.Show();
                redactionRec.FormClosed += MyClosedHandlerInitRedaction;
            }
        }
        protected void MyClosedHandlerInitRedaction(object sender, EventArgs e)
        {
            if (redactionRec.isCorrect)
            {
                carShop.RecviationArr(Int32.Parse(redactionSearch.value), redactionRec.name, redactionRec.manufacturer, redactionRec.price, redactionRec.amount, redactionRec.shopNumber, redactionRec.minimumLot);
                carShop.WriteIn(dataGridView1);
            }
        }
        private void удалениеЗаписейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isPass)
            {
                cheakpass = new CheakPass();
                cheakpass.Show();
                cheakpass.FormClosed += MyClosedHandlerCheakPass2;
            }
            else 
            {
                deleateEl = new Search();
                deleateEl.Text = "Deleate Element";
                deleateEl.arrDomain = new string[] { "Наименование", "Фирма", "Номер магазина", "ID элемента" };
                deleateEl.Show();
                deleateEl.FormClosed += MyClosedHandlerDeleteEl;
            }

        }
        protected void MyClosedHandlerCheakPass2(object sender, EventArgs e)
        {
            if (!cheakpass.isCancel)
            {
                if (cheakpass.pass == password)
                {
                    deleateEl = new Search();
                    deleateEl.Text = "Deleate Element";
                    deleateEl.arrDomain = new string[] { "Наименование", "Фирма", "Номер магазина", "ID элемента" };
                    deleateEl.Show();
                    deleateEl.FormClosed += MyClosedHandlerDeleteEl;
                }
                else
                    MessageBox.Show("Неверный пароль.");
            }
        }
        protected void MyClosedHandlerDeleteEl(object sender, EventArgs e)
        {
            if (!deleateEl.isCancel)
            {
                carShop = carShop.DeleateElementIndex(deleateEl.domainValue, deleateEl.value);
                carShop.WriteIn(dataGridView1);
            }
        }
        private void AppAb_Click(object sender, EventArgs e)
        {
            carShop2 = carShop.CoutMinimalLot5();
            ShowInfoCheck.Enabled = true;
            ShowInfoCheck.Checked = false;
        }
        private void AppAc_Click(object sender, EventArgs e)
        {
            searchStore = new Search();
            searchStore.Text = "Search Store";
            searchStore.arrDomain = new string[] { "Номер магазина" };
            searchStore.Show();
            searchStore.FormClosed += MyClosedHandlerSearchStore;
        }
        protected void MyClosedHandlerSearchStore(object sender, EventArgs e)
        {
            if (!searchStore.isCancel)
            {
                carShop2 = carShop.CoutShopElements(Int32.Parse(searchStore.value));
                richTextBox1.AppendText(carShop2.ReturnShopElements());
                ShowInfoCheck.Checked = false;
                ShowInfoCheck.Enabled = true;
            }
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void запаролитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isPass)
            {
                cheakpass = new CheakPass();
                cheakpass.Show();
                cheakpass.FormClosed += MyClosedHandlerCheakPass3;
            }
            else 
            {
                newPass = new Password();
                newPass.Show();
                newPass.FormClosed += MyClosedHandlerNewPass;
            }
        }
        protected void MyClosedHandlerCheakPass3(object sender, EventArgs e)
        {
            if (!cheakpass.isCancel)
            {
                if (cheakpass.pass == password)
                {
                    newPass = new Password();
                    newPass.Show();
                    newPass.FormClosed += MyClosedHandlerRegenPass;
                }
                else
                    MessageBox.Show("Неверный пароль.");
            }
        }
        protected void MyClosedHandlerNewPass(object sender, EventArgs e)
        {
            if (!newPass.isCancel)
            {
                carShop.AddPassword(newPass.pass);
                carShop.SaveTo(saveToPath);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowInfoCheck.Checked == true)
            {
                carShop.WriteIn(dataGridView1);
            }
            else
            {
                carShop2.WriteIn(dataGridView1);
            }
        }
        protected void MyClosedHandlerRegenPass(object sender, EventArgs e)
        {
            if (!newPass.isCancel)
            {
                password = newPass.pass;
                carShop.AddPassword(newPass.pass);
                carShop.SaveTo(saveToPath);
            }
        }
        private void прайсЛистВTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            // получаем выбранный файл
            string writePath = saveFileDialog1.FileName + ".txt";

            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(carShop.ReturnPriceList());
            }
        }
        private void файлНа20ЗаписейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\rasia\source\repos\CursachV2\Cars";
            saveToPath = path;
            carShop = new CarShop(1);
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))//Считывание  
            {
                isPass = reader.ReadBoolean();
                if (isPass)
                    password = reader.ReadString();
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    string manufacturer = reader.ReadString();
                    int price = reader.ReadInt32();
                    int amount = reader.ReadInt32();
                    int shopNumber = reader.ReadInt32();
                    int minimumLot = reader.ReadInt32();

                    carShop.AddProduct(name, manufacturer, price, amount, shopNumber, minimumLot);
                }
            }

            AddRecord.Enabled = true;
            dataGridView1.Enabled = true;
            groupBox1.Enabled = true;
            поискToolStripMenuItem.Enabled = true;
            сохранитьToolStripMenuItem.Enabled = true;
            запаролитьToolStripMenuItem.Enabled = true;
            редактированиеЗаписейToolStripMenuItem.Enabled = true;
            выводToolStripMenuItem.Enabled = true;

            carShop.WriteIn(dataGridView1);
        }
    }
}