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
        CarShop carShop, carShopSearch, carShopMinLot5, carShopCoutShop;
        public int count;

        NewRecords newRec;
        NewRecords redactionRec;
        Search search;
        Search redactionSearch;
        Search deleateEl;
        //AppA
            Search deleateStore;
            Search searchStore;
        //-=-
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            carShop = new CarShop(0);
            AddRecord.Enabled = false;
            dataGridView1.Enabled = false;
            label1.Text = "Весь список:";
            this.FormClosed += MyClosedHandlerMainForm;
        }
        protected void MyClosedHandlerMainForm(object sender, EventArgs e)
        {
            if (carShop.ReturnLenght() < 1) ;
            else
            {
                var save = MessageBox.Show("Хотите сохранить значения?", "Сохранение", MessageBoxButtons.YesNo);
                if (save == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;

                    // получаем выбранный файл
                    string filename = saveFileDialog1.FileName;

                    carShop.SaveTo(filename);

                    MessageBox.Show("Файл сохранен");
                }
            }
        }
        private void AddRecord_Click(object sender, EventArgs e)
        {
            newRec = new NewRecords();
            newRec.btnTxt = "Добавить";
            newRec.Show();
            newRec.FormClosed += MyClosedHandlerRecords;
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
            carShop = new CarShop(1);
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))//Считывание  
            {
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
            carShop.WriteIn(dataGridView1);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (carShop.ReturnLenght() < 1)
            {
                MessageBox.Show("Файл должен иметь хотя бы 1 запись.");
            }
            else {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;

                carShop.SaveTo(filename);

                MessageBox.Show("Файл сохранен");
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddRecord.Enabled = true;
            dataGridView1.Enabled = true;
        }

        //--Search--//
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search = new Search();
            search.arrDomain = new string[] { "Наименование", "Фирма", "Номер магазина", "Индекс массива" };
            search.Show();
            search.FormClosed += MyClosedHandlerSearch;
            label1.Text = "По ключевому слову:";
        }
        protected void MyClosedHandlerSearch(object sender, EventArgs e)
        {
            if (!search.isCancel)
            {
                carShopSearch = carShop.Search(search.domainValue, search.value);
                if (carShopSearch.ReturnLenght() < 1)
                {
                    label1.Text = "Весь список:";
                    MessageBox.Show("Запись не найдена.");
                }
                else
                    carShopSearch.WriteIn(dataGridView1);
            }
            else
                label1.Text = "Весь список:";
        }
        //---------//

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Весь список:";
            carShop.WriteIn(dataGridView1);
        }

        private void редToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redactionSearch = new Search();
            redactionSearch.Text = "Redaction";
            redactionSearch.arrDomain = new string[] { "Индекс массива" };
            redactionSearch.Show();
            redactionSearch.FormClosed += MyClosedHandlerRedaction;
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
            deleateEl = new Search();
            deleateEl.Text = "Deleate Element";
            deleateEl.arrDomain = new string[] { "Индекс массива" };
            deleateEl.Show();
            deleateEl.FormClosed += MyClosedHandlerDeleteEl;
        }
        protected void MyClosedHandlerDeleteEl(object sender, EventArgs e)
        {
            if (!deleateEl.isCancel)
            {
                carShop = carShop.DeleateElementIndex(Int32.Parse(deleateEl.value));
                carShop.WriteIn(dataGridView1);
            }
        }
        private void AppAa_Click(object sender, EventArgs e)
        {
            deleateStore = new Search();
            deleateStore.Text = "Deleate Store";
            deleateStore.arrDomain = new string[] { "Номер магазина" };
            deleateStore.Show();
            deleateStore.FormClosed += MyClosedHandlerDeleateStore;
        }
        protected void MyClosedHandlerDeleateStore(object sender, EventArgs e)
        {
            if (!deleateStore.isCancel)
            {
                carShop = carShop.DeleateElementsShop(Int32.Parse(deleateStore.value));
                carShop.WriteIn(dataGridView1);
            }
        }
        private void AppAb_Click(object sender, EventArgs e)
        {
            carShopMinLot5 = carShop.CoutMinimalLot5();
            carShopMinLot5.WriteIn(dataGridView1);
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
                carShopCoutShop = carShop.CoutShopElements(Int32.Parse(searchStore.value));
                carShopCoutShop.WriteIn(dataGridView1);
                richTextBox1.AppendText(carShopCoutShop.ReturnShopElements());
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
    }
}
