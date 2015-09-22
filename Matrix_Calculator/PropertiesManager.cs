using System;
using System.Collections.Generic;

public class PropertiesManager : Window {

    public string[] transposed () {
        TextBox line = (TextBox)this.FindName ("Line_Input");
        TextBox column = (TextBox)this.FindName ("Column_Input");
        int lines = Convert.ToInt32 (line.Text);
        int columns = Convert.ToInt32 (column.Text);

        string[] results = new string[lines * columns];

        for (int i = 1; i <= columns; i++) {
            for (int j = 1; j <= lines; j++) {
                double element_a = getValue ("Matrix_" + j + "_" + i + "_1");
                results[results.Length] = result.ToString ();
            }
        }

        return results;
    }


}
