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
        void generateGrid(object sender, RoutedEventArgs e)
        {
            TextBox line = (TextBox)this.FindName("Line_Input");
            TextBox column = (TextBox)this.FindName("Column_Input");
            int lines_int = Convert.ToInt32(line.Text);
            int column_int = Convert.ToInt32(column.Text);

            if ((lines_int > 10) || (column_int > 10))
            {
                MessageBoxResult result = MessageBox.Show("Sinto muito! Só aceitamos matrizes de até 10x10", "Calculadora diz:");
                return;
            }

            for (int i = 1; i <= lines_int; i++)
            {
                for (int j = 1; j <= column_int; j++)
                {

                    TextBox tb = new TextBox();
                    tb.Name = ("Matrix_" + i + "_" + j + "_" + matrix_ID).ToString();
                    tb.Margin = new Thickness(0, 0, 50 + i * 45, 50 + j * 45);
                    tb.Width = 20; tb.Height = 20;
                    tb.Text = "0";

                    Tab_01.Children.Add(tb);

                }
            }

            matrix_ID = matrix_ID < 2 ? matrix_ID++ : matrix_ID = 0;
        }

        private void HelpGeneral(object sender, RoutedEventArgs e)
        {
            HeadLabel.Content = "Matrizes:";
            BodyLabel.Text = "Matrizes são tabelas em que se dispõe um conjunto numérico em que cada um destes números é denominado elemento da matriz. Elas possuem, por convenção, nomes em letras maiúsculas e seus elementos em minúscula acompanhadas por dois índices que indicam, respectivamente, a linha e a coluna que o elemento ocupa. Funcionam como mecanismo de resolução de sistemas lineares.";
        }

        private void HelpType(object sender, RoutedEventArgs e)
        {
            HeadLabel.Content = "Tipos de Matriz:";
            BodyLabel.Text = "Matriz Quadrada: É aquela em que o número de linhas e de colunas é igual.                                                                       Matriz Triangular: É aquela matriz quadrada que os termos abaixo ou acima da diagonal são nulos.                                Matriz Diagonal: É aquela matriz quadrada que os termos abaixo e acima da diagonal são nulos.                                 Matriz Identidade: É aquela matriz quadrada que todos os elementos da diagonal são iguais a um e os restantes, zero. Matriz Nula: É a matriz em que todos os elementos são nulos. Matriz Linha: É a matrzi que só tem uma linha.                                         Matriz Coluna: É a matriz que só tem uma coluna.";
        }

        private void HelpSumSub(object sender, RoutedEventArgs e)
        {
            HeadLabel.Content = "Soma e Subtração de Matrizes:";
            BodyLabel.Text = "Para somarmos ou subtrairmos duas ou mais matrizes é preciso que todas elas tenham o mesmo número de linhas e de colunas. A soma ou subtração dessas matrizes irá resultar em outra matriz que também terá o mesmo número de linhas e de colunas. Os termos deverão ser somados com os seus termos de índices correspondentes. O mesmo procedimento serve para subtrações.";
        }

        private void HelpMult(object sender, RoutedEventArgs e)
        {
            HeadLabel.Content = "Multiplicação e Multiplicação Escalar de Matrizes:";
            BodyLabel.Text = "Para multiplicarmos duas matrizes precisamos que a primeira tem o número de colunas igual ao número de linhas da segunda. O resultado da multiplicação dará uma matriz com o número de linhas da primeira e de colunas da segunda. Primeiro pega-se a primeira linha da primeira matriz e a primeira coluna da segunda matriz e multiplica-se cada termo com o seu termo equivalente. Depois é preciso somar o resultado dessas multiplicações e assim teremos o primeiro elemento. O procedimento se repete para todos os elementos da matriz.                                                                                                                       Na multiplicação escalar, só é necessário multiplicar o número escolhido por cada elemento da matriz.";
        }

        private void HelpInvSim(object sender, RoutedEventArgs e)
        {
            HeadLabel.Content = "Matrizes Inversas e Simétricas:";
            BodyLabel.Text = "Matrizes são inversas quando multiplicadas por outra matriz, de mesma ordem, resultam em uma matriz identidade. Dizemos então que ela é inversa em relação a qual foi multiplicada.                                                                                                                               A matriz é simétrica quando ela é totalmente igual a sua transposta.";
        }

        private void HelpDeter(object sender, RoutedEventArgs e)
        {
            HeadLabel.Content = "Determinantes:";
            BodyLabel.Text = "Determinantes são números associados as matrizes QUADRADAS. O determinante de uma matriz quadrada pode ser obtido pelo Teorema de Laplace, em que soma dos produtos dos elementos de uma fila qualquer ( linha ou coluna) da matriz pelos respectivos cofatores. Cofator de um elemento de uma matriz quadrada é -1 elevado a soma de seus índices multiplicado pelo seu menor complementar. O determinante de matrizes 2x2 também pode ser dado pela diferença do produto da diagonal principal com o produto da diagonal secundária.";
        }

        private void HelpTrans(object sender, RoutedEventArgs e)
        {
            HeadLabel.Content = "Matrizes Transpostas:";
            BodyLabel.Text = "Matrizes transpostas são dadas a partir de uma matriz inicial. Ela é igual a inicial a não ser pela ordem de seus índices. Na transposta é trocado, ordenadamente, as linhas por colunas ou as colunas por linhas, de forma que os índices agora inverteram suas posições.";
        }
    }
}
