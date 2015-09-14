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

}
