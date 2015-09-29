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

    public class OperationManager : Window
    {
        private double getValue(int i, string name)
        {

            TextBox tbx = (TextBox)this.FindName(name);
            string text = tbx.Text;
            double value = Convert.ToDouble(text);

            return value;

        }

        private double splitElement(string[] matrix, int line, int column)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].IndexOf(line + "_" + column) != -1)
                {
                    string[] splited = matrix[i].Split('$');
                    return Convert.ToDouble(splited[0]);
                }
            }

            return 0;
        }

        public string[] sum(int lines, int columns, string[] matrix_1, string[] matrix_2)
        {

            //Local onde colocaremos os resultados, em ordem hehe
            string[] results = new string[lines * columns];
            int index = 0;

            if(matrix_1.Length != matrix_2.Length){
                MessageBoxResult result = MessageBox.Show("A soma de matrizes só pode ser feita com matrizes de mesma ordem!", "Calculadora diz:");
                string[] badresult = new string[1];
                badresult[0] = "Bad Result!";
                return badresult;
            }

            for (int i = 1; i <= lines; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    double rst = splitElement(matrix_1, i, j) + splitElement(matrix_2, i, j);
                    results[index] = rst.ToString();
                    index++;
                }
            }

            return results;

        }

        public string[] sbtr(int lines, int columns, string[] matrix_1, string[] matrix_2)
        {

            //Local onde colocaremos os resultados, em ordem hehe
            string[] results = new string[lines * columns];
            int index = 0;

            if (matrix_1.Length != matrix_2.Length)
            {
                MessageBoxResult result = MessageBox.Show("A soma de matrizes só pode ser feita com matrizes de mesma ordem!", "Calculadora diz:");
                string[] badresult = new string[1];
                badresult[0] = "Bad Result!";
                return badresult;
            }

            for (int i = 1; i <= lines; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    double rst = splitElement(matrix_1, i, j) - splitElement(matrix_2, i, j);
                    results[index] = rst.ToString();
                    index++;
                }
            }

            return results;


        }

        public string[] multEsc(int lines, int columns, double factor, string[] matrix)
        {
            //Local onde colocaremos os resultados, em ordem hehe
            string[] results = new string[lines * columns];
            int index = 0;

            for (int i = 1; i <= lines; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    double rst = splitElement(matrix, i, j) * factor;
                    results[index] = rst.ToString();
                    index++;
                }
            }

            return results;

        }

        public string[] mult(int lines_1, int columns_1, int lines_2, int columns_2, string[] matrix_1, string[] matrix_2)
        {
            if (columns_1 != lines_2)
            {
                MessageBoxResult result = MessageBox.Show("O número de colunas da primeira matriz deve ser igual ao número de linhas da segunda", "Calculadora diz:");
                string[] badresult = new string[1];
                badresult[0] = "Bad Result!";
                return badresult;
            }

            string[] results = new string[lines_1 * columns_2];
            int index = 0;

            for (int i = 1; i <= lines_1; i++)
            {

                for (int j = 1; j <= columns_2; j++)
                {

                    double result = 0;

                    for (int k = 1; k <= lines_2; k++)
                    {
                        double element_a = splitElement(matrix_1, i, k);
                        double element_b = splitElement(matrix_2, k, j);

                        result = result + ((element_a) * (element_b));
                    }

                    results[index] = result.ToString();
                    index++;

                }
            }

            return results;
        }
    }
}