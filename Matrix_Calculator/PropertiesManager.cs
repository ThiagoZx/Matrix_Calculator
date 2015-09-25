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
                double element_a = getValue ("Matrix_" + j + "_" + i + "_1");
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
}
