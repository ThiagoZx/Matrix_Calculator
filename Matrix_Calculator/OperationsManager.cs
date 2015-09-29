using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Matrix_Calculator
{

    public class OperationManager
    {

        private double getValue(string name)
        {

            TextBox tbx = (TextBox)this.FindName(name);
            string text = tbx.Text;
            double value = Convert.ToDouble(text);

            return value;

        }

        public string[] sum()
        {

            //Achar a ordem da Matriz
            TextBox line = (TextBox)this.FindName("Line_Input");
            TextBox column = (TextBox)this.FindName("Column_Input");
            int lines = Convert.ToInt32(line.Text);
            int columns = Convert.ToInt32(column.Text);

            //Local onde colocaremos os resultados, em ordem hehe
            string[] results = new string[lines * columns];

            for (int i = 1; i <= lines; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    //Convertendo os simpáticos textos para serem somados
                    double element_a = getValue("Matrix_" + i + "_" + j + "_1");
                    double element_b = getValue("Matrix_" + i + "_" + j + "_2");

                    //Soma =]
                    double result = (element_a) + (element_b);
                    results[results.Length] = result.ToString();
                }
            }

            return results;

        }

        public string[] sbtr()
        {

            //Achar a ordem da Matriz
            TextBox line = (TextBox)this.FindName("Line_Input");
            TextBox column = (TextBox)this.FindName("Column_Input");
            int lines = Convert.ToInt32(line.Text);
            int columns = Convert.ToInt32(column.Text);

            //Local onde colocaremos os resultados, em ordem hehe
            string[] results = new string[lines * columns];

            for (int i = 1; i <= lines; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    //Convertendo os simpáticos textos para serem somados
                    double element_a = getValue("Matrix_" + i + "_" + j + "_1");
                    double element_b = getValue("Matrix_" + i + "_" + j + "_2");

                    //Subtração =]
                    double result = (element_a) - (element_b);
                    results[results.Length] = result.ToString();
                }
            }

            return results;

        }

        public string[] multEsc(float factor)
        {

            //Achar a ordem da Matriz
            TextBox line = (TextBox)this.FindName("Line_Input");
            TextBox column = (TextBox)this.FindName("Column_Input");
            int lines = Convert.ToInt32(line.Text);
            int columns = Convert.ToInt32(column.Text);

            //Local onde colocaremos os resultados, em ordem hehe
            string[] results = new string[lines * columns];

            for (int i = 1; i <= lines; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    //Convertendo os simpáticos textos para serem somados
                    double element_a = getValue("Matrix_" + i + "_" + j + "_1");

                    //Multiplicação =]
                    double result = (element_a) * (factor);
                    results[results.Length] = result.ToString();
                }
            }

            return results;

        }

        public string[] mult()
        {

            //Dois simpáticos valores necessáriamente idênticos. A formula de uma multiplicação é de duas matrizes A e B que geram C, onde A m x n, e B n x p 

            TextBox line_2 = (TextBox)this.FindName("Line_Input_2");
            int lines_2 = Convert.ToInt32(line_2.Text);

            TextBox column_1 = (TextBox)this.FindName("Column_Input_1");
            int columns_1 = Convert.ToInt32(column_1.Text);

            if (columns_1 != lines_2)
            {
                MessageBoxResult result = MessageBox.Show("Montagem das matrizes incorreta! Talvez eu coloque pra trancar o valor das TextBox logo...", "Simpático erro");
                string[] a = new string[0];
                return a;
            }

            //Linhas da primeira matriz
            TextBox line_1 = (TextBox)this.FindName("Line_Input_1");
            int lines_1 = Convert.ToInt32(line_1.Text);

            //Columas da segunda matriz
            TextBox column_2 = (TextBox)this.FindName("Column_Input_2");
            int columns_2 = Convert.ToInt32(column_2.Text);

            //Local onde colocaremos os resultados, em ordem hehe
            string[] results = new string[lines_1 * columns_2];

            for (int i = 1; i <= lines_1; i++)
            {

                for (int j = 1; j <= columns_2; j++)
                {

                    double result = 0;

                    for (int k = 1; k <= lines_2; k++)
                    {
                        double element_a = getValue("Matrix_" + i + "_" + k + "_1");
                        double element_b = getValue("Matrix_" + k + "_" + j + "_2");

                        result = result + ((element_a) * (element_b));
                    }

                    results[results.Length] = result.ToString();

                }
            }

            return results;
        }
    }
}