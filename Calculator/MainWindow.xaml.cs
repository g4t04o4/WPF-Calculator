using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Xml.Linq;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String firstNumber, secondNumber, firstOperator;
        Boolean isFirst = true;

        public MainWindow()
        {
            InitializeComponent();

            buttonC.Click += ButtonClear_Click;

            buttonE.Click += new RoutedEventHandler(ButtonOperator_Click);
            buttonD.Click += new RoutedEventHandler(ButtonOperator_Click);
            buttonX.Click += new RoutedEventHandler(ButtonOperator_Click);
            buttonM.Click += new RoutedEventHandler(ButtonOperator_Click);
            buttonP.Click += new RoutedEventHandler(ButtonOperator_Click);

            button9.Click += new RoutedEventHandler(ButtonNumber_Click);
            button8.Click += new RoutedEventHandler(ButtonNumber_Click);
            button7.Click += new RoutedEventHandler(ButtonNumber_Click);
            button6.Click += new RoutedEventHandler(ButtonNumber_Click);
            button5.Click += new RoutedEventHandler(ButtonNumber_Click);
            button4.Click += new RoutedEventHandler(ButtonNumber_Click);
            button3.Click += new RoutedEventHandler(ButtonNumber_Click);
            button2.Click += new RoutedEventHandler(ButtonNumber_Click);
            button1.Click += new RoutedEventHandler(ButtonNumber_Click);
            button0.Click += new RoutedEventHandler(ButtonNumber_Click);
        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            var numberButton = sender as Button;

            CalculatorDisplay.Text += numberButton.Content.ToString();

            if (isFirst)
                firstNumber += numberButton.Content.ToString();
            else
                secondNumber += numberButton.Content.ToString();
        }

        private void ButtonOperator_Click(object sender, RoutedEventArgs e)
        {
            var operatorButton = sender as Button;

            CalculatorDisplay.Text += operatorButton.Content.ToString();

            if (isFirst)
            {
                isFirst = false;
                firstOperator = operatorButton.Content.ToString();
            }
            else
            {
                switch (firstOperator)
                {
                    case "+":
                        firstNumber = (Int32.Parse(firstNumber) + Int32.Parse(secondNumber)).ToString();
                        break;
                    case "-":
                        firstNumber = (Int32.Parse(firstNumber) - Int32.Parse(secondNumber)).ToString();
                        break;
                    case "*":
                        firstNumber = (Int32.Parse(firstNumber) * Int32.Parse(secondNumber)).ToString();
                        break;
                    case "/":
                        firstNumber = (Int32.Parse(firstNumber) / Int32.Parse(secondNumber)).ToString();
                        break;
                    case "=":
                        break;

                }

                CalculatorDisplay.Text = firstNumber.ToString();
                secondNumber = "";

                isFirst = true;


            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e) // Очистить событие нажатия клавиши
        {
            CalculatorDisplay.Text = "";
            isFirst = true;
        }
    }
}
