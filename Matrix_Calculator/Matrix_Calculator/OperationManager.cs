using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class OperationManager
{

    private double getValue(string name) {

        TextBox tbx = this.FindName(name);
        string text = tbx.text;
        double value = Convert.ToDouble(text);

        return value;

    }
      
    public string[] sum(){

        //Achar a ordem da Matriz
        TextBox line = (TextBox)this.FindName("Line_Input");
        TextBox column = (TextBox)this.FindName("Column_Input");
        int lines = Convert.ToInt32(line.Text);
        int columns = Convert.ToInt32(column.Text);

        //Local onde colocaremos os resultados, em ordem hehe
        string[] results = new string[lines * columns];

        for(int i = 0; i < lines; i++) {
            for (int j = 0; j < columns; j++) {
                //Convertendo os simpáticos textos para serem somados
                double element_a = getValue("Matrix_" + i + "_" + j + "_1");
                double element_b = getValue("Matrix_" + i + "_" + j + "_2");

                //Soma =]
                int result = (element_a) + (element_b);
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

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                //Convertendo os simpáticos textos para serem somados
                double element_a = getValue("Matrix_" + i + "_" + j + "_1");
                double element_b = getValue("Matrix_" + i + "_" + j + "_2");

                //Subtração =]
                int result = (element_a) - (element_b);
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

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                //Convertendo os simpáticos textos para serem somados
                int element_a = getValue("Matrix_" + i + "_" + j + "_1");

                //Multiplicação =]
                int result = (element_a) * (factor);
                results[results.Length] = result.ToString();
            }
        }

        return results;

    }

    public string[] mult() {

        //Dois simpáticos valores necessáriamente idênticos. A formula de uma multiplicação é de duas matrizes A e B que geram C, onde A m x n, e B n x p 
        TextBox column_1 = (TextBox)this.FindName("Column_Input_1");        
        int columns_1 = Convert.ToInt32(column.Text);
        TextBox line_2 = (TextBox)this.FindName("Line_Input_2");
        int lines_2 = Convert.ToInt32(line.Text);

        if (columns_1 != lines_2) {
            Alert("Montagem das matrizes incorreta! Talvez eu coloque pra trancar o valor das TextBox logo...");
            string[] a = new string[1];
            return a;
        }

        //Linhas da primeira matriz
        TextBox line_1 = (TextBox)this.FindName("Line_Input_1");
        int lines_1 = Convert.ToInt32(line.Text);

        //Columas da segunda matriz
        TextBox column_2 = (TextBox)this.FindName("Column_Input_2");        
        int columns_2 = Convert.ToInt32(column.Text);

        //Local onde colocaremos os resultados, em ordem hehe
        string[] results = new string[lines_1 * columns_2];

        //Em construção
        int[] values_1 = new int[lines_1 * columns_1];
        int[] values_2 = new int[lines_2 * columns_2];

        for (int i = 0; i < lines_1; i++)
        {
            for (int j = 0; j < columns_2; j++)
            {
                
                
                
                
                
                
                
                
                
                
                
                //Convertendo os simpáticos textos para serem somados
                double element_a = getValue("Matrix_" + i + "_" + j + "_1");
                double element_b = getValue("Matrix_" + i + "_" + j + "_2");

                //Soma =]
                int result = (element_a) + (element_b);
                results[results.Length] = result.ToString();
            }
        }

        return results;
    }
}
