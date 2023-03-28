using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            //int iMulti;
            //try
            //{
            //    iMulti = multiplyValues(9876543, 9876543);
            //    MessageBox.Show("9876543 * 9876543=" + iMulti);
            //}
            //catch (OverflowException oEx) 
            //{
            //    MessageBox.Show("9876543 * 9876543="+oEx.Message);
            //}


            /////////////////////////////////////////////////////////////////////////////////////
            //int? i = null;

            //if (!i.HasValue)
            //    MessageBox.Show("i has NO value set");
            //else
            //    MessageBox.Show("i has A value");


            /////////////////////////////////////////////////////////////////////////////////////
            //MainWindow m = new MainWindow();
            //m.Show();


            /////////////////////////////////////////////////////////////////////////////////////
            //int i = 98;
            //object o = i;
            //MessageBox.Show("i="+i+" o="+o);
            //i = 100;
            //MessageBox.Show("i=" + i + " o=" + o);
            //o = 123;
            //MessageBox.Show("i=" + i + " o=" + o);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void buttonCalc_Click(object sender, RoutedEventArgs e)
        {
            double dailyRate = readDouble("Enter your daily rate: ");
            int noOfDays = readInt("Enter the number of days: ");
            writeFeeeeeee(calculateFee(dailyRate, noOfDays));


            optMethod(first: 99, second: 123.45, third: "World");
            optMethod(first: 100, second: 54.321);
            optMethod(third: "World", second: 123.45, first: 99);
            optMethod(first: 99, third: "World");
            optMethod(99, third: "World");  // First argument is positional


            var myAnonymousObject = new { Name = "John", Age = 44 };
            MessageBox.Show("Name: " + myAnonymousObject.Name + " Age: " + myAnonymousObject.Age + ".");
            Console.WriteLine("Name: {0} Age: {1}", myAnonymousObject.Name, myAnonymousObject.Age);
        }

        private int multiplyValues(int leftHandSide, int rightHandSide)
        {
            //return leftHandSide * rightHandSide;
            return checked(leftHandSide * rightHandSide);
        }

        private void optMethod(int first, double second = 0.0, string third = "Hello")
        {

        }

        private void writeFeeeeeee(object p)
        {

        }

        private object calculateFee(double dailyRate, int noOfDays)
        {
            return null;
        }

        private int readInt(string p)
        {
            return -1;
        }

        private double readDouble(string p)
        {
            return 2.2;
        }
    }
}
