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
    public class PropertiesManager : Window
    {

        public string[] transposed(int lines, int columns, string[] matrix)
        {

            string[] results = new string[lines * columns];
            int index = 0;

            for (int i = 1; i <= columns; i++)
            {
                for (int j = 1; j <= lines; j++)
                {
                    double element_a = splitElement(matrix, j, i);
                    results[index] = element_a.ToString() + "$" + i + "_" + j;
                    index++;
                }
            }

            return results;

        }

        public string[] oposite(int lines, int columns, string[] matrix)
        {

            string[] results = new string[lines * columns];
            int index = 0;

            for (int i = 1; i <= lines; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    double element_a = splitElement(matrix, i, j);
                    element_a = element_a * (-1);
                    results[index] = element_a.ToString();
                    index++;
                }
            }

            return results;

        }

        public bool isSimetric(int lines, int columns, string[] matrix)
        {
            if (lines != columns)
            {
                MessageBoxResult rtn_1 = MessageBox.Show("Essa matriz não é simétrica!", "Calculadora diz:");
                return false;
            }

            string[] trspd = this.transposed(lines, columns, matrix);

            for(int i = 1; i <= lines; i++){
                for (int j = 1; j <= columns; j++)
                {
                    string a = splitElement(matrix, i, j).ToString();
                    string b = splitElement(trspd, i, j).ToString();

                    if (b != a)
                    {
                        MessageBoxResult rtn_1 = MessageBox.Show("Essa matriz não é simétrica!", "Calculadora diz:");
                        return false;
                    }
                }
            }

            MessageBoxResult rtn_2 = MessageBox.Show("Essa matriz é simétrica!", "Calculadora diz:");
            return true;

        }

        private double splitElement(string[] matrix, int line, int column)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                try
                {
                    if (matrix[i].IndexOf(line + "_" + column) != -1)
                    {
                        string[] splited = matrix[i].Split('$');
                        return Convert.ToDouble(splited[0]);
                    }
                }
                catch { }
            }

            return 0;
        }

        private string[] splitMatrix(string[] matrix, int line, int column)
        {

            string[] rstMatrix = new string[Convert.ToInt32(matrix.Length - ((Math.Sqrt(matrix.Length) * 2) - 1))];

            int crt_line = 1;
            int crt_column = 1;
            int index = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                if ((matrix[i].IndexOf(line + "_" + column) == -1) && (matrix[i].IndexOf("_" + column) == -1) && (matrix[i].IndexOf(line + "_") == -1))
                {

                    string[] splited = matrix[i].Split('$');
                    rstMatrix[index] = splited[0] + "$" + crt_line + "_" + crt_column;
                    index++;

                    if ((crt_column + 1) > Math.Sqrt(rstMatrix.Length))
                    {
                        crt_line++; crt_column = 1;
                    }
                    else
                    {
                        crt_column++;
                    }
                    

                }
            }

            return rstMatrix;

        }

        private string cofactor(string[] matrix, int line, int column)
        {

            string[] elements = splitMatrix(matrix, line, column);

            switch (elements.Length)
            {
                case 1:
                    return (Math.Pow((-1), line + column) * splitElement(matrix, 1, 1)).ToString();

                case 4:
                    return (Math.Pow((-1), line + column) * Convert.ToDouble(determinant_n2(elements))).ToString();

                case 9:
                    return (Math.Pow((-1), line + column) * Convert.ToDouble(determinant_nn(elements))).ToString();

                default:
                    return (Math.Pow((-1), line + column) * Convert.ToDouble(determinant_nn(elements))).ToString();
            }

        }

        private string determinant_n2(string[] matrix)
        {
            double princ = splitElement(matrix, 1, 1) * splitElement(matrix, 2, 2);
            double secnd = splitElement(matrix, 1, 2) * splitElement(matrix, 2, 1);

            double dtrmnt = princ - secnd;

            return dtrmnt.ToString();

        }

        private string determinant_n3(string[] matrix)
        {
            double[] princ = new double[4];
            double[] secnd = new double[4];

            for (int j = 1; j < princ.Length; j++)
            {

                int temp = j;
                princ[j] = 1;

                for (int i = 1; i < princ.Length; i++)
                {

                    double value = splitElement(matrix, i, temp);
                    princ[j] = princ[j] * value;

                    temp = (temp + 1) > 3 ? temp = 1 : temp++;
                }
            }

            for (int j = 3; j > 0; j--)
            {

                int temp = j;
                princ[j] = 1;

                for (int i = 1; i < secnd.Length; i++)
                {

                    double value = splitElement(matrix, i, temp);
                    secnd[j] = secnd[j] * value;

                    temp = (temp - 1) < 1 ? temp = 3 : temp--;
                }
            }

            string toReturn = (princ.Sum() - secnd.Sum()).ToString();
            return toReturn;

        }

        private string determinant_nn(string[] matrix)
        {

            double result = 0;

            for (int i = 1; i <= Math.Sqrt(matrix.Length); i++)
            {
                double element = splitElement(matrix, 1, i) * Convert.ToDouble(cofactor(matrix, 1, i));
                result = result + element;
            }

            return result.ToString();

        }

        public string determinant(int lines, int columns, string[] matrix)
        {

            if (lines != columns)
            {
                MessageBoxResult result = MessageBox.Show("O cálculo da determinante só é possivel em matrizes quadradas!", "Calculadora diz:");
                return "";
            }

            string[] elements = new string[lines * columns];
            int index = 0;

            for (int i = 1; i <= lines; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    string element_a = splitElement(matrix, i, j).ToString();
                    element_a = element_a + "$" + i + "_" + j;
                    elements[index] = element_a;
                    index++;
                }
            }

            switch (lines * columns)
            {
                case 1:
                    return splitElement(matrix, 1, 1).ToString();

                case 4:
                    return determinant_n2(elements);

                case 9:
                    return determinant_nn(elements);

                default:
                    return determinant_nn(elements);
            }

        }

        public string[] inverse(int lines, int columns, string[] matrix)
        {

            string[] elements = new string[lines * columns];
            int index = 0;

            for (int i = 1; i <= lines; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    string element_a = splitElement(matrix, i, j).ToString();
                    element_a = element_a + "$" + i + "_" + j;
                    elements[index] = element_a.ToString();
                    index++;
                }
            }

            double dtrmnt = Convert.ToDouble(determinant_nn(elements));

            if (dtrmnt == 0 || lines != columns)
            {
                MessageBoxResult result = MessageBox.Show("Essa matriz não possui inversa!", "Calculadora diz:");
                string[] badresult = new string[1];
                return badresult;
            }

            string[] cofactors = new string[lines * columns];

            index = 0;
            for (int i = 1; i <= lines; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    double cftr = Convert.ToDouble(cofactor(elements, i, j));
                    cftr = cftr * 1 / dtrmnt;
                    cofactors[index] = cftr.ToString();
                    index++;
                }
            }

            return cofactors;

        }

        public bool isInverse(int lines, int columns, string[] matrix_1, string[] matrix_2)
        {

            string[] matrix = this.inverse(lines, columns, matrix_1);


            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix_2[i] != matrix[i])
                {
                    MessageBoxResult rtn_1 = MessageBox.Show("Essa matriz não é inversa à primeira!", "Calculadora diz:");
                    return false;
                }
            }

            MessageBoxResult rtn_2 = MessageBox.Show("Essa matriz é inversa à segunda!", "Calculadora diz:");
            return true;

        }
    }
}