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

namespace Matrix_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        private int matrix_ID = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        void returnTextValue() {

        }
        void generateGrid(object sender, RoutedEventArgs e) {
            TextBox line = (TextBox)this.FindName("Line_Input");
            TextBox column = (TextBox)this.FindName("Column_Input");
            int lines_int = Convert.ToInt32(line.Text);
            int column_int = Convert.ToInt32(column.Text);

            for (int i = 1; i <= lines_int; i++) {
                for (int j = 1; j <= column_int; j++) {

                    TextBox tb = new TextBox();
                    tb.Name = ("Matrix_" + i + "_" + j + "_" + matrix_ID).ToString();
                    tb.Margin = new Thickness(0, 0, 50 + i * 45, 50 + j * 45);
                    tb.Width = 20; tb.Height = 20;
                    tb.Text = "0";

                    Console.WriteLine(Convert.ToDouble("22,3"));

                    Tab_01.Children.Add(tb);
                    MessageBoxResult result = MessageBox.Show("Olá", "Simpática célula");

                }
            }

            matrix_ID = matrix_ID < 2 ? matrix_ID++ : matrix_ID = 0;
        }
    }
}
