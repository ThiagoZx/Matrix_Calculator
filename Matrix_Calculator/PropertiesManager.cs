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

    private double splitElement(string[] matrix, int line, int column){
        for(int i = 0; i < matrix.Length; i++){
            if(matrix[i].indexOf(line + "_" + column) != -1){
                string[] splited = matrix[i].Split('$');
                return Convert.ToDouble(splited[0]); 
            }
        }
    }
    
    private string[] splitMatrix(string[] matrix, int line, int column){

        string[] rstMatrix = new string[matrix.Length - ((Math.Sqrt(matrix.Length) * 2) - 1)];

        for(int i = 0; i < matrix.Length; i++){
            if((matrix[i].indexOf("_" + column) == -1) (matrix[i].indexOf(line + "_") == -1)){
                string[] splited = matrix[i].Split('$');
                rstMatrix[rstMatrix.Length] = splited[0] + "$" + line + "_" + column;
                if((column + 1) > Math.Sqrt(rstMatrix.Length)){
                    line++; column = 1;
                } else {
                    column++;
                }
            }
        }

        return rstMatrix;
    }

    private string cofactor(string[] matrix, int line, int column){

        string[] elements = splitMatrix(matrix, line, column);

        if(elements.Length == 9){
            return Math.Pow((-1), line + column) * Convert.ToDouble(determinant_n3(elements));
        } else{
            return Math.Pow((-1), line + column) * Convert.ToDouble(determinant_nn(elements));
        }
    }

    private string determinant_n2(string[] matrix) {
        double princ = Convert.ToDouble(matrix[0]) * Convert.ToDouble(matrix[3]);
        double secnd = Convert.ToDouble(matrix[1]) * Convert.ToDouble(matrix[2]);

        double dtrmnt = princ - secnd;

        return dtrmnt.ToString();
    }

    private string determinant_n3(string[] matrix) {
        double[] princ = new double[4];
        double[] secnd = new double[4];

        for (int j = 1; j < princ.Length; j++) {
            
            int temp = j;
            princ[j] = 1;

            for (int i = 1; i < princ.Length; i++) {
                
                double value = splitElement(matrix, i, temp);
                princ[j] = princ[j] * value;

                temp = (temp + 1) > 3 ? temp = 1 : temp++;
            }
        }

        for (int j = 3; j > 0; j--) {
            
            int temp = j;
            princ[j] = 1;

            for (int i = 1; i < secnd.Length; i++) {
                
                double value = splitElement(matrix, i, temp);
                secnd[j] = secnd[j] * value;

                temp = (temp - 1) < 1 ? temp = 3 : temp--;
            }
        }

        string toReturn = (princ.Sum() - secnd.Sum()).ToString();
        return toReturn.ToString();

    }

    private string determinant_nn(string[] matrix) {

        double result = 0;

        for(int i = 1; i <= Math.Sqrt(matrix.Length); i++){
            double element = splitElement(matrix, 1, i) * cofactor(matrix, 1, i);
            result = result + element;
        }

        return result.ToString();
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
                string element_a = getValue("Matrix_" + i + "_" + j + "_1").ToString();
                element_a = element_a + "$" + i + "_" + j;
                elements[elements.Length] = element_a.ToString();
            }
        }

        switch (lines * columns) {
            case 1:
                return getValue("Matrix_1_1_1").ToString();
                break;

            case 4:
                return determinant_n2(elements);
                break;

            case 9:
                return determinant_n3(elements);
                break;

            default:
                return determinant_nn(elements);
                break;
        }
    }
}
