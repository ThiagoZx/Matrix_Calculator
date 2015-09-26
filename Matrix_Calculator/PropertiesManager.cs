using System;
using System.Collections.Generic;

public class PropertiesManager : Window {

    private double getValue (string name) {

        TextBox tbx = (TextBox)this.FindName (name);
        string text = tbx.Text;
        double value = Convert.ToDouble (text);

        return value;

    }
    public string[] transposed () {
        TextBox line = (TextBox)this.FindName ("Line_Input");
        TextBox column = (TextBox)this.FindName ("Column_Input");
        int lines = Convert.ToInt32 (line.Text);
        int columns = Convert.ToInt32 (column.Text);

        string[] results = new string[lines * columns];

        for (int i = 1; i <= columns; i++) {
            for (int j = 1; j <= lines; j++) {
                double element_a = getValue ("Matrix_" + j + "_" + i + "_1");
                results[results.Length] = element_a.ToString ();
            }
        }

        return results;
    }

    public string[] oposite () {
        TextBox line = (TextBox)this.FindName ("Line_Input");
        TextBox column = (TextBox)this.FindName ("Column_Input");
        int lines = Convert.ToInt32 (line.Text);
        int columns = Convert.ToInt32 (column.Text);

        string[] results = new string[lines * columns];

        for (int i = 1; i <= lines; i++) {
            for (int j = 1; j <= columns; j++) {
                double element_a = getValue ("Matrix_" + i + "_" + j + "_1");
                element_a = element_a * (-1);
                results[results.Length] = element_a.ToString ();
            }
        }

        return results;
    }

    public bool isSimetric(string[] matrix) {

        string[] trspd = this.transposed();

        for (int i = 0; i < matrix.Length; i++) {
            if (trspd[i] != matrix[i]) {
                MessageBoxResult result = MessageBox.Show("Essa matriz não é simétrica!", "Calculadora diz:");
                return false;
            }
        }

        MessageBoxResult result = MessageBox.Show("Essa matriz é simétrica!", "Calculadora diz:");
        return true;
    }

    private string determinant_n2(string[] matrix) {
        double princ = (matrix[0]) * (matrix[3]);
        double secnd = (matrix[1]) * (matrix[2]);

        double dtrmnt = princ - secnd;

        return dtrmnt.ToString();
    }

    private string determinant_n3(string[] matrix) {
        double[] princ = new double[4];
        double[] secnd = new double[4];

        for (int i = 1; i <= 3; i++) {
            for (int j = 1; j <= 3; j++) {
                //element_a = element_a + "$Matrix_" + j + "_" + i + "_1";
            }
        }
    }

    public string determinant() {
        TextBox line = (TextBox)this.FindName("Line_Input");
        TextBox column = (TextBox)this.FindName("Column_Input");
        int lines = Convert.ToInt32(line.Text);
        int columns = Convert.ToInt32(column.Text);

        if (lines != columns) {
            MessageBoxResult result = MessageBox.Show("O cálculo da determinante só é possivel em matrizes quadradas!", "Calculadora diz:");
            return "";
        }

        string[] elements = new string[lines * columns];

        for (int i = 1; i <= lines; i++) {
            for (int j = 1; j <= columns; j++) {
                double element_a = getValue("Matrix_" + i + "_" + j + "_1").toString();
                element_a = element_a + "$" + i + "_" + j;
                elements[elements.Length] = element_a.ToString();
            }
        }

            switch (lines * columns) {
                case 1:
                    return getValue("Matrix_1_1_1").toString();
                    break;

                case 4:
                    determinant_n2(elements);
                    break;

                case 9:
                    determinant_n3(elements);
                    break;

                default:
                    break;
            }
    }
}
