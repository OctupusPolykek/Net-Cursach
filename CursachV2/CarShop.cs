using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursachV2
{
    class CarShop
    {

        BookT[] carShop;
        int LastProduct;
        public struct BookT
        {
            string name;
            string manufacturer;
            int price;
            int amount;
            int shopNumber;
            int minimumLot;

            public BookT(string name, string manufacturer, int price, int amount, int shopNumber, int minimumLot)
            {
                this.name = name;
                this.manufacturer = manufacturer;
                this.price = price;
                this.amount = amount;
                this.shopNumber = shopNumber;
                this.minimumLot = minimumLot;
            }
            public string ReturnName()
            {
                return this.name;
            }
            public string ReturnManufacturer()
            {
                return this.manufacturer;
            }
            public int ReturnPrice()
            {
                return this.price;
            }
            public int ReturnAmount()
            {
                return this.amount;
            }
            public int ReturnShopNumber()
            {
                return this.shopNumber;
            }
            public int ReturnMinimumLot()
            {
                return this.minimumLot;
            }
        }
        //-----//
        public string RefreshName(int x)
        {
            return carShop[x - 1].ReturnName();
        }
        public string RefreshManufacturer(int x)
        {
            return carShop[x - 1].ReturnManufacturer();
        }
        public int RefreshPrice(int x)
        {
            return carShop[x - 1].ReturnPrice();
        }
        public int RefreshAmount(int x)
        {
            return carShop[x - 1].ReturnAmount();
        }
        public int RefreshShopNumber(int x)
        {
            return carShop[x - 1].ReturnShopNumber();
        }
        public int RefreshMinimumLot(int x)
        {
            return carShop[x - 1].ReturnMinimumLot();
        }
        //-----//
        public CarShop()
        {
            carShop = new BookT[0];
            LastProduct = -1;
        }
        public CarShop(int N)
        {
            carShop = new BookT[N];
            LastProduct = -1;
        }
        public int ReturnLenght()
        {
            return carShop.Length;
        }
        public bool AddProduct(string name, string manufacturer, int price, int amount, int shopNumber, int minimumLot)
        {
            if (LastProduct + 1 < carShop.Length)
            {
                carShop[++LastProduct] = new BookT(name, manufacturer, price, amount, shopNumber, minimumLot);
                return true;
            }
            else
                Array.Resize(ref carShop, carShop.Length + 1);

            carShop[++LastProduct] = new BookT(name, manufacturer, price, amount, shopNumber, minimumLot);
            return false;
        }
        public void RecviationArr(int x,string name, string manufacturer, int price, int amount, int shopNumber, int minimumLot)
        {
            carShop[x - 1] = new BookT(name, manufacturer, price, amount, shopNumber, minimumLot);
        }
        public void WriteIn(DataGridView _dgv)
        {
            _dgv.Rows.Clear();

            for (int i = 0; i < carShop.Length; i++)
            {
                _dgv.Rows.Add(carShop[i].ReturnName(), carShop[i].ReturnManufacturer(), carShop[i].ReturnPrice(), carShop[i].ReturnAmount(), carShop[i].ReturnShopNumber(), carShop[i].ReturnMinimumLot());
            }

        }
        public CarShop Search(string valueUpDown, string searchValue)
        {
            CarShop carShopSearch = new CarShop(0);
            switch (valueUpDown) {
                case "Наименование":
                    for (int i = 0; i < carShop.Length; i++)
                    {
                        if (carShop[i].ReturnName() == searchValue)
                            carShopSearch.AddProduct(carShop[i].ReturnName(), carShop[i].ReturnManufacturer(), carShop[i].ReturnPrice(), carShop[i].ReturnAmount(), carShop[i].ReturnShopNumber(), carShop[i].ReturnMinimumLot());
                    }
                    break;
                case "Фирма":
                    for (int i = 0; i < carShop.Length; i++)
                    {
                        if (carShop[i].ReturnManufacturer() == searchValue)
                            carShopSearch.AddProduct(carShop[i].ReturnName(), carShop[i].ReturnManufacturer(), carShop[i].ReturnPrice(), carShop[i].ReturnAmount(), carShop[i].ReturnShopNumber(), carShop[i].ReturnMinimumLot());
                    }
                    break;
                case "Номер магазина":
                    for (int i = 0; i < carShop.Length; i++)
                    {
                        if (carShop[i].ReturnShopNumber() + "" == searchValue)
                            carShopSearch.AddProduct(carShop[i].ReturnName(), carShop[i].ReturnManufacturer(), carShop[i].ReturnPrice(), carShop[i].ReturnAmount(), carShop[i].ReturnShopNumber(), carShop[i].ReturnMinimumLot());
                    }
                    break;
                case "Индекс массива":
                    int x = Int32.Parse(searchValue) - 1;
                    carShopSearch.AddProduct(carShop[x].ReturnName(), carShop[x].ReturnManufacturer(), carShop[x].ReturnPrice(), carShop[x].ReturnAmount(), carShop[x].ReturnShopNumber(), carShop[x].ReturnMinimumLot());
                    break;
            }
            return carShopSearch;
        }
        public CarShop DeleateElementIndex(int x)
        {
            CarShop carShopDeleateElement = new CarShop(0);

            Array.Clear(carShop, x - 1, 1);

            for (int i = 0; i < carShop.Length; i++)
            {
                if (carShop[i].ReturnPrice() > 0)
                {
                    carShopDeleateElement.AddProduct(carShop[i].ReturnName(), carShop[i].ReturnManufacturer(), carShop[i].ReturnPrice(), carShop[i].ReturnAmount(), carShop[i].ReturnShopNumber(), carShop[i].ReturnMinimumLot());
                }
            }

            return carShopDeleateElement;
        }
        //App A
        public CarShop DeleateElementsShop(int shop)
        {
            CarShop carShopDeleateElementsShop = new CarShop(0);

            for (int i = 0; i < carShop.Length; i++)
            {
                if (carShop[i].ReturnShopNumber() == shop)
                    Array.Clear(carShop, i, 1);
                if (carShop[i].ReturnPrice() > 0)
                {
                    carShopDeleateElementsShop.AddProduct(carShop[i].ReturnName(), carShop[i].ReturnManufacturer(), carShop[i].ReturnPrice(), carShop[i].ReturnAmount(), carShop[i].ReturnShopNumber(), carShop[i].ReturnMinimumLot());
                }
            }

            return carShopDeleateElementsShop;
        }
        public CarShop CoutMinimalLot5()
        {
            CarShop carShopCoutMinimalLot5 = new CarShop(0);

            for (int i = 0; i < carShop.Length; i++)
            {
                if (carShop[i].ReturnMinimumLot() < 5)
                {
                    carShopCoutMinimalLot5.AddProduct(carShop[i].ReturnName(), carShop[i].ReturnManufacturer(), carShop[i].ReturnPrice(), carShop[i].ReturnAmount(), carShop[i].ReturnShopNumber(), carShop[i].ReturnMinimumLot());
                }
            }

            return carShopCoutMinimalLot5;
        }
        public CarShop CoutShopElements(int shop)
        {
            CarShop carShopCoutShopElements = new CarShop(0);

            for (int i = 0; i < carShop.Length; i++)
            {
                if (carShop[i].ReturnShopNumber() == shop)
                {
                    carShopCoutShopElements.AddProduct(carShop[i].ReturnName(), carShop[i].ReturnManufacturer(), carShop[i].ReturnPrice(), carShop[i].ReturnAmount(), carShop[i].ReturnShopNumber(), carShop[i].ReturnMinimumLot());
                }
            }

            return carShopCoutShopElements;
        }
        public string ReturnShopElements()
        {
            string result = "";
            int allStuf = 0;
            for (int i = 0; i < carShop.Length; i++)
                allStuf += carShop[i].ReturnAmount();
            result = "Количество всех товаров: " + allStuf + Environment.NewLine;
            return result;
        }
        //-=-
        public void SaveTo(string path)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    foreach (BookT s in carShop)
                    {
                        writer.Write(s.ReturnName());
                        writer.Write(s.ReturnManufacturer());
                        writer.Write(s.ReturnPrice());
                        writer.Write(s.ReturnAmount());
                        writer.Write(s.ReturnShopNumber());
                        writer.Write(s.ReturnMinimumLot());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
