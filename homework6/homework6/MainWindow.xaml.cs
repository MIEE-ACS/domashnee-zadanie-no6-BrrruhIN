using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace homework6
{
    abstract class Currency
    {

        public virtual double ConvertToRub(double input)
        {
            return 0;
        }



    }
    class EUR : Currency
    {
        public override double ConvertToRub(double input)
        {
            return input * 67.53;
        }
    }
    class USD : Currency
    {
        public override double ConvertToRub(double input)
        {
            return input * 63.42;
        }
    }
    class CNY : Currency
    {
        public override double ConvertToRub(double input)
        {
            return input * 9.12;
        }
    }
    public partial class MainWindow : Window
    {
        static bool CheckNumber(string s) //Функция для проверки строки на содержание символов(для преобразования в число)
        {
            foreach (char item in s) //Цикл для поочередного обращения к элементам строки
            {
                if (item != ',')
                {
                    if (char.IsDigit(item) == false) // IsDigit функция определяет относится ли символ к категории чисел
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public MainWindow()
        {
            InitializeComponent();
            
        }
        int angel = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            angel += 1;
            RotateTransform a = new RotateTransform(angel);
            button1.RenderTransform = a;
            
            int index = combobox.SelectedIndex;
            if (CheckNumber(textbox1.Text) || textbox1.Text == "")
            {
                MessageBox.Show("Ошибка. Введите число.");
            }
            else
            {
                switch (index)
                {
                    case 0:

                        EUR ae = new EUR();
                        double i = double.Parse(textbox1.Text);
                        double rez = ae.ConvertToRub(i);
                        textbox2.Text = Convert.ToString(rez);
                        break;
                    case 1:
                        USD ae2 = new USD();
                        double i2 = double.Parse(textbox1.Text);
                        double rez2 = ae2.ConvertToRub(i2);
                        textbox2.Text = Convert.ToString(rez2);
                        break;
                    case 2:
                        CNY ae3 = new CNY();
                        double i3 = double.Parse(textbox1.Text);
                        double rez3 = ae3.ConvertToRub(i3);
                        textbox2.Text = Convert.ToString(rez3);
                        break;
                }

            }
            
            
        }

       
    }
}
