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
using System.Text.RegularExpressions;

namespace Matrix_Calculator
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawCartesianGrid(25, "#000000");

            Polygon polygon = new Polygon();
            polygon.FillRule = FillRule.Nonzero;
            polygon.Fill = new SolidColorBrush(Colors.DarkOrchid);
            polygon.Points = PointCollection;

            Canvas.Children.Add(polygon);
        }

        OperationManager OprtnManager = new OperationManager();
        PropertiesManager PrprtsManager = new PropertiesManager();
        public static PointCollection PointCollection = new PointCollection();

        // <Help Section>

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

        // </HelpSection>

        private TextBox getGridElement(Grid grid, string elementName)
        {
            object obj = LogicalTreeHelper.FindLogicalNode(grid, elementName);

            return (TextBox)obj;
        }

        private double getValue(int matrix, string name)
        {
            Grid grid = (Grid)FindName("Matrix_0" + matrix);
            TextBox tbx = getGridElement(grid, name);
            string text = tbx.Text.ToString();
            double value = Convert.ToDouble(text);

            return value;

        }

        private void deleteAllTbx(int matrix) { 
        
            for(int i = 1; i <= 10; i++){
                for (int j = 1; j <= 10; j++)
                {
                    try
                    {
                        Grid grid = (Grid)FindName("Matrix_0" + matrix);
                        TextBox tbx = getGridElement(grid, "Matrix_" + i + "_" + j + "_" + matrix);
                        grid.Children.Remove(tbx);
                    }
                    catch { 
                    }
                }
            }
        
        }

        private bool validadeMatrix(int matrix)
        {

            int lines_int = 0;
            int column_int = 0;

            try {
                TextBox line = (TextBox)this.FindName ("Line_Input_" + matrix);
                TextBox column = (TextBox)this.FindName ("Column_Input_" + matrix);
                lines_int = Convert.ToInt32 (line.Text);
                column_int = Convert.ToInt32 (column.Text);
            } catch {
                MessageBoxResult result = MessageBox.Show ("Para executar tal operação, deve preencher as duas matrizes corretamente", "Calculadora diz:");
            }
            
            for (int i = 1; i <= lines_int; i++) {
                for (int j = 1; j <= column_int; j++) { 
                    try
                    {
                        double Try = getValue(matrix, "Matrix_" + i + "_" + j + "_" + matrix);
                    }
                    catch
                    {
                        MessageBoxResult result = MessageBox.Show("Você construiu a matriz " + matrix + " com algum elemento incorreto" + i + " " + j, "Calculadora diz:");
                        return false;
                    }
                }
            }

            return true;
        }

        private string[] rtnMatrix(int matrix)
        {
            int lines_int = 0;
            int column_int = 0;

            try {
                TextBox line = (TextBox)this.FindName ("Line_Input_" + matrix);
                TextBox column = (TextBox)this.FindName ("Column_Input_" + matrix);
                lines_int = Convert.ToInt32 (line.Text);
                column_int = Convert.ToInt32 (column.Text);
            } catch {
                MessageBoxResult result = MessageBox.Show ("Para executar tal operação, deve preencher as duas matrizes corretamente", "Calculadora diz:");
            }

            string[] elements = new string[lines_int * column_int];
            int index = 0;

            for (int i = 1; i <= lines_int; i++)
            {
                for (int j = 1; j <= column_int; j++)
                {
                    elements[index] = getValue(matrix, "Matrix_" + i + "_" + j + "_" + matrix).ToString() + "$" + i + "_" + j;
                    index++;
                }
            }

            return elements;

        }

        private string splitElement(string[] matrix, int line, int column)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].IndexOf(line + "_" + column) != -1)
                {
                    string[] splited = matrix[i].Split('$');
                    return (splited[0]);
                }
            }

            return "0";
        }

        private void generateGrid_1(object sender, RoutedEventArgs e)
        {
            deleteAllTbx(1);
            TextBox line = (TextBox)this.FindName("Line_Input_1");
            TextBox column = (TextBox)this.FindName("Column_Input_1");
            int lines_int;
            int column_int;

            try
            {
                lines_int = Convert.ToInt32(line.Text);
                column_int = Convert.ToInt32(column.Text);
                if (lines_int <= 0 || column_int <= 0) {
                    MessageBoxResult result = MessageBox.Show ("Sinto muito! Que tal colocar números inteiros positivos não nulos como índice?", "Calculadora diz:");
                    return;
                }
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("Sinto muito! Só aceitamos matrizes que tenham somente números inteiros em seu índice", "Calculadora diz:");
                return;
            }

            if ((lines_int > 10) || (column_int > 10)) {
                MessageBoxResult result = MessageBox.Show("Sinto muito! Só aceitamos matrizes de até 10x10", "Calculadora diz:");
                return;
            }

            for (int i = 1; i <= lines_int; i++) {
                for (int j = 1; j <= column_int; j++) {

                    //Não pergunte.
                    int margin_top = i - 6;
                    int margin_left = j - 6;
                    //Só aceite.

                    TextBox tb = new TextBox();
                    Matrix_01.Children.Add(tb);
                    tb.Name = ("Matrix_" + i + "_" + j + "_" + 1).ToString();
                    tb.Margin = new Thickness(margin_left * 45, margin_top * 45, 0, 0);
                    tb.Width = 20; tb.Height = 20;
                    tb.Text = "0";
                }
            }
        }

        private void generateGrid_2(object sender, RoutedEventArgs e)
        {
            deleteAllTbx(2);
            TextBox line = (TextBox)this.FindName("Line_Input_2");
            TextBox column = (TextBox)this.FindName("Column_Input_2");
            int lines_int;
            int column_int;

            try
            {
                lines_int = Convert.ToInt32(line.Text);
                column_int = Convert.ToInt32(column.Text);
                if (lines_int <= 0 || column_int <= 0) {
                    MessageBoxResult result = MessageBox.Show ("Sinto muito! Que tal colocar números inteiros positivos não nulos como índice?", "Calculadora diz:");
                    return;
                }
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("Sinto muito! Só aceitamos matrizes que tenham somente números inteiros em seu índice", "Calculadora diz:");
                return;
            }

            if ((lines_int > 10) || (column_int > 10))
            {
                MessageBoxResult result = MessageBox.Show("Sinto muito! Só aceitamos matrizes de até 10x10", "Calculadora diz:");
                return;
            }

            for (int i = 1; i <= lines_int; i++)
            {
                for (int j = 1; j <= column_int; j++)
                {
                    //Não pergunte.
                    int margin_top = i - 6;
                    int margin_left = j - 6;
                    //Só aceite.

                    TextBox tb = new TextBox();
                    Matrix_02.Children.Add(tb);

                    tb.Name = ("Matrix_" + i + "_" + j + "_" + 2).ToString();
                    tb.Margin = new Thickness(margin_left * 45, margin_top * 45, 0, 0);
                    tb.Width = 20; tb.Height = 20;
                    tb.Text = "0";
                }
            }
        }

        private void generateGrid_3(int lines, int columns, string[] matrix)
        {
            deleteAllTbx(3);
            int index = 0;

            for (int i = 1; i <= lines; i++)
            {
                for (int j = 1; j <= columns; j++)
                {

                    //Não pergunte.
                    int margin_top = i - 6;
                    int margin_left = j - 2;
                    //Só aceite.
                    string text = "";

                    if (matrix[index].IndexOf("$") != -1)
                    {
                        text = splitElement(matrix, i, j);
                        index++;
                    }
                    else
                    {
                        text = matrix[index];
                        index++;
                    }

                    TextBox tb = new TextBox();
                    Matrix_03.Children.Add(tb);
                    tb.Name = ("Matrix_" + i + "_" + j + "_" + 3).ToString();
                    tb.Margin = new Thickness (margin_left * 85, margin_top * 45, 0, 0);
                    tb.Width = 40; tb.Height = 20;
                    tb.Text = text;
                }
            }
        }

        private void Calcular_SelectionChanged(object sender, EventArgs e)
        {
            string text = Operation.Text;

            if (text == "Multiplicação escalar") {
                Factor.Margin = new Thickness(70, 100, 0, 0);
                x.Margin = new Thickness(60, 100, 0, 0);
            } else {
                Factor.Margin = new Thickness(260, 100, -130, 0);
                x.Margin = new Thickness(260, 100, -130, 0);
            }
            
            switch (text){
                case "Soma":
                    Gerar_01.IsEnabled = true; Gerar_02.IsEnabled = true; Calcular.IsEnabled = true;
                    break;
                case "Subtração":
                    Gerar_01.IsEnabled = true; Gerar_02.IsEnabled = true; Calcular.IsEnabled = true;
                    break;
                case "Multiplicação":
                    Gerar_01.IsEnabled = true; Gerar_02.IsEnabled = true; Calcular.IsEnabled = true;
                    break;
                case "Multiplicação escalar":
                    Gerar_01.IsEnabled = true; Gerar_02.IsEnabled = false; Calcular.IsEnabled = true;
                    break;
                case "Inversa":
                    Gerar_01.IsEnabled = true; Gerar_02.IsEnabled = false; Calcular.IsEnabled = true;
                    break;
                case "Transposta":
                    Gerar_01.IsEnabled = true; Gerar_02.IsEnabled = false; Calcular.IsEnabled = true;
                    break;
                case "Verificação de simétrica":
                    Gerar_01.IsEnabled = true; Gerar_02.IsEnabled = false; Calcular.IsEnabled = true;
                    break;
                case "Determinante":
                    Gerar_01.IsEnabled = true; Gerar_02.IsEnabled = false; Calcular.IsEnabled = true;
                    break;
                case "Oposta":
                    Gerar_01.IsEnabled = true; Gerar_02.IsEnabled = false; Calcular.IsEnabled = true;
                    break;
                case "Verificação de inversa":
                    Gerar_01.IsEnabled = true; Gerar_02.IsEnabled = true; Calcular.IsEnabled = true;
                    break;
            }
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {

            string[] matrix_1 = new string[0]; 
            string[] matrix_2 = new string[0];

            if(Gerar_02.IsEnabled) {
                if ((validadeMatrix(1)) || (validadeMatrix(2))) {
                    matrix_1 = rtnMatrix(1);
                    matrix_2 = rtnMatrix(2);
                }
                else
                {
                    return;
                }
            } else {
                if (validadeMatrix(1)) {
                    matrix_1 = rtnMatrix(1);
                }
                else
                {
                    return;
                }
            }

            string[] result = new string[1];
            string text = Operation.Text;

            TextBox line_1 = (TextBox)this.FindName("Line_Input_1");
            TextBox column_1 = (TextBox)this.FindName("Column_Input_1");
            int lines_int_1 = Convert.ToInt32(line_1.Text);
            int column_int_1 = Convert.ToInt32(column_1.Text);

            int lines_int_2 = 0;
            int column_int_2 = 0;

            if (Gerar_02.IsEnabled == true)
            {
                TextBox line_2 = (TextBox)this.FindName("Line_Input_2");
                TextBox column_2 = (TextBox)this.FindName("Column_Input_2");
                lines_int_2 = Convert.ToInt32(line_2.Text);
                column_int_2 = Convert.ToInt32(column_2.Text);
            }

            switch (text)
            {
                case "Soma":
                    result = OprtnManager.sum(lines_int_1, column_int_1, matrix_1, matrix_2);
                    break;

                case "Subtração":
                    result = OprtnManager.sbtr(lines_int_1, column_int_1, matrix_1, matrix_2);
                    break;

                case "Multiplicação":
                    result = OprtnManager.mult(lines_int_1, column_int_1, lines_int_2, column_int_2, matrix_1, matrix_2);
                    break;

                case "Multiplicação escalar":
                    try
                    {
                        double factor = Convert.ToDouble(Factor.Text);
                        result = OprtnManager.multEsc(lines_int_1, column_int_1, factor, matrix_1);
                    }
                    catch
                    {
                        MessageBoxResult rst = MessageBox.Show("O valor para a multiplicação não é válido! Lembre-se: Decimais são separados por '.' e somente um!", "Calculadora diz:");
                        return;
                    }
                    break;

                case "Inversa":
                    result = PrprtsManager.inverse(lines_int_1, column_int_1, matrix_1);

                    if (result[0] == "badresult") {
                        return;
                    }

                    result = PrprtsManager.transposed (lines_int_1, column_int_1, result);
                    break;

                case "Transposta":
                    result = PrprtsManager.transposed(lines_int_1, column_int_1, matrix_1);
                    if (lines_int_1 != column_int_1) {
                        int temp = lines_int_1;
                        lines_int_1 = column_int_1;
                        column_int_1 = temp;
                    }
                    break;

                case "Verificação de simétrica":
                    bool a = PrprtsManager.isSimetric(lines_int_1, column_int_1, matrix_1);
                    return;

                case "Determinante":
                    result[0] = PrprtsManager.determinant(lines_int_1, column_int_1, matrix_1);
                    generateGrid_3(1, 1, result);
                    return;

                case "Oposta":
                    result = PrprtsManager.oposite(lines_int_1, column_int_1, matrix_1);
                    break;

                case "Verificação de inversa":
                    bool b = PrprtsManager.isInverse(lines_int_1, column_int_1, matrix_1, matrix_2);
                    return;

            }

            generateGrid_3(lines_int_1, column_int_1, result);
            
        }

        //<Canvas Section>

        public void DrawLine(int X1, int Y1, int X2, int Y2, String color, int thickness)
        {
            Line line = new Line();
            line.X1 = X1;
            line.X2 = X2;
            line.Y1 = Y1;
            line.Y2 = Y2;

            line.StrokeThickness = thickness;
            line.Stroke = (Brush)new BrushConverter().ConvertFromString(color);

            Canvas.Children.Add(line);
        }

        private void Text(double x, double y, string text, Color color)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(color);

            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            Canvas.Children.Add(textBlock);
        }

        public void DrawCartesianGrid(int size, string color)
        {
            for (int i = 0; i < 11; i++) {
                DrawLine(size * i, 0, size * i, 250, color, 1);
                DrawLine(0, size * i, 250, size * i, color, 1);
            }

            DrawLine(0, 250 / 2, 250, 250 / 2, "#AA0000", 1);
            DrawLine(250 / 2, 0, 250 / 2, 250, "#AA0000", 1);
        }

        public Point GetMousePositionCanvas()
        {
            Point point = Mouse.GetPosition(Canvas);
            Text(point.X, point.Y, "(" + (point.X - 125) + ":" + (point.Y - 125) + ")", Colors.Blue);
            bool added = false;

            if (point.X > 0 && point.Y > 0) {
                PointCollection.Add(point);
                added = true;
            }

            if (buttonsDisplay.Children.Count < 10 && added) {
                Button b = new Button();
                b.Click += new RoutedEventHandler(this.ButtonClick);
                b.Content = "Mudar";
                b.Name = "Button" + PointCollection.IndexOf(point).ToString();

                buttonsDisplay.Children.Add(b);

                TextBox tx = new TextBox();
                tx.Name = "X" + PointCollection.IndexOf(point).ToString();
                tx.Text = (point.X - 125).ToString();
                tx.MaxLength = 4;
                tx.MaxLines = 1;
                xDisplay.Children.Add(tx);

                TextBox ty = new TextBox();
                ty.Name = "Y" + PointCollection.IndexOf(point).ToString();
                ty.Text = (point.Y - 125).ToString();
                ty.MaxLength = 4;
                ty.MaxLines = 1;
                yDisplay.Children.Add(ty);
            }

            return new Point(point.X, point.Y);
        }

        private void GetPoint(object sender, MouseButtonEventArgs e)
        {
            GetMousePositionCanvas();
        }

        protected void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            
            int index = buttonsDisplay.Children.IndexOf((sender as Button));
            PointCollection[index] = new Point(double.Parse((xDisplay.Children[index] as TextBox).Text) + 125,

            double.Parse((yDisplay.Children[index] as TextBox).Text) + 125);
            HudUpdate();
        }

        public void HudUpdate()
        {
            try {
                 List<TextBlock> textBlocks = Canvas.Children.OfType<TextBlock>().ToList();

                 foreach (TextBlock t in textBlocks) {
                     Canvas.Children.Remove(t);
                 }

                 for (int i = 0; i < PointCollection.Count; i++) {
                     (xDisplay.Children[i] as TextBox).Text = (PointCollection[i].X-125).ToString();
                     (yDisplay.Children[i] as TextBox).Text = (PointCollection[i].Y-125).ToString();
                     Text(PointCollection[i].X, PointCollection[i].Y, "(" + (PointCollection[i].X -125) + "," + (PointCollection[i].Y-125) + ")", Colors.Blue);
                 }
             } catch {
             }
        }

        private void Rotation(object sender, RoutedEventArgs e)
        {
            Rotate.Text = Regex.Replace(Rotate.Text, "[^0-9,]+", "", RegexOptions.Compiled);
            Rotate.Text = (String.IsNullOrEmpty(Rotate.Text) || String.IsNullOrWhiteSpace(Rotate.Text)) ? "0" : Rotate.Text;

            try {
                Canvas.Children.Clear();
                DrawCartesianGrid(25, "#555555");

                Polygon p = new Polygon();
                p.Fill = new SolidColorBrush(Colors.DarkOrchid);
                PointCollection = Matrix.MatrixToCollection( Matrix.rotate( Matrix.CollectionToMatrix(PointCollection, -125, -125), double.Parse(Rotate.Text)), 125, 125);
                p.Points = PointCollection;
                Canvas.Children.Add(p);

                HudUpdate();
            } catch {
            }
        }

        private void Translation(object sender, RoutedEventArgs e)
        {
            TranslateX.Text = Regex.Replace(TranslateX.Text, "[^0-9,]+", "", RegexOptions.Compiled);
            TranslateX.Text = (String.IsNullOrEmpty(TranslateX.Text) || String.IsNullOrWhiteSpace(TranslateX.Text)) ? "0" : TranslateX.Text;
            TranslateY.Text = Regex.Replace(TranslateY.Text, "[^0-9,]+", "", RegexOptions.Compiled);
            TranslateY.Text = (String.IsNullOrEmpty(TranslateY.Text) || String.IsNullOrWhiteSpace(TranslateY.Text)) ? "0" : TranslateY.Text;

            try {
                Canvas.Children.Clear();
                DrawCartesianGrid(25, "#555555");

                Polygon p = new Polygon();
                p.Fill = new SolidColorBrush(Colors.DarkOrchid);
                PointCollection = Matrix.MatrixToCollection( Matrix.translate( Matrix.CollectionToMatrix(PointCollection, 0, 0), double.Parse(TranslateY.Text), double.Parse(TranslateY.Text)), 0, 0);
                p.Points = PointCollection;
                Canvas.Children.Add(p);

                HudUpdate();
            } catch {
            }
        }

        private void Scaling(object sender, RoutedEventArgs e)
        {
            ScaleX.Text = Regex.Replace(ScaleX.Text, "[^0-9,]+", "", RegexOptions.Compiled);
            ScaleX.Text = (String.IsNullOrEmpty(ScaleX.Text) || String.IsNullOrWhiteSpace(ScaleX.Text)) ? "1" : ScaleX.Text;
            ScaleY.Text = Regex.Replace(ScaleY.Text, "[^0-9,]+", "", RegexOptions.Compiled);
            ScaleY.Text = (String.IsNullOrEmpty(ScaleY.Text) || String.IsNullOrWhiteSpace(ScaleY.Text)) ? "1" : ScaleY.Text;

            try {
                Canvas.Children.Clear();
                DrawCartesianGrid(25, "#555555");

                Polygon p = new Polygon();
                p.Fill = new SolidColorBrush(Colors.DarkOrchid);
                PointCollection = Matrix.MatrixToCollection( Matrix.scale( Matrix.CollectionToMatrix(PointCollection, -125, -125), double.Parse(ScaleX.Text), double.Parse(ScaleY.Text) ), 125, 125);
                p.Points = PointCollection;
                Canvas.Children.Add(p);

                HudUpdate();
            } catch {
            }
        }

        public void ClearPoints(object sender, RoutedEventArgs e)
        {
            PointCollection.Clear();
            List<TextBlock> textBlocks = Canvas.Children.OfType<TextBlock>().ToList();

            foreach (TextBlock t in textBlocks) {
                Canvas.Children.Remove(t);
            }

            xDisplay.Children.Clear();
            yDisplay.Children.Clear();
            buttonsDisplay.Children.Clear();
        }

        //</Canvas Section>

        //<Formula Section>

        public void Formula(ref TextBox fT, ref Grid Matrix, int numb)
        {
            Matrix temp;
            try {
                deleteAllTbx(numb);
                TextBox line = (TextBox)this.FindName("Line_Input_" + numb.ToString());
                TextBox column = (TextBox)this.FindName("Column_Input_" + numb.ToString());
                int lines_int;
                int column_int;

                try
                {
                    lines_int = Convert.ToInt32(line.Text);
                    column_int = Convert.ToInt32(column.Text);
                }
                catch
                {
                    MessageBoxResult result = MessageBox.Show("Sinto muito! Só aceitamos matrizes que tenham somente números inteiros em seu índice", "Calculadora diz:");
                    return;
                }

                if ((lines_int > 10) || (column_int > 10))
                {
                    MessageBoxResult result = MessageBox.Show("Sinto muito! Só aceitamos matrizes de até 10x10", "Calculadora diz:");
                    return;
                }

                temp = new Matrix(lines_int, column_int, fT.Text);

                for (int i = 1; i <= lines_int; i++)
                {
                    for (int j = 1; j <= column_int; j++)
                    {

                        //Não pergunte.
                        int margin_top = i - 6;
                        int margin_left = j - 6;
                        //Só aceite.

                        TextBox tb = new TextBox();
                        Matrix.Children.Add(tb);
                        tb.Name = ("Matrix_" + i + "_" + j + "_" + numb.ToString()).ToString();
                        tb.Margin = new Thickness(margin_left * 45, margin_top * 45, 0, 0);
                        tb.Width = 20; tb.Height = 20;
                        tb.Text = temp.array[(i - 1), (j - 1)].ToString();
                    }
                }
            } catch {
            }
        }

        private void GetFormula1(object sender, RoutedEventArgs e)
        {
            Formula(ref Formula1, ref Matrix_01, 1);
        }

        private void GetFormula2(object sender, RoutedEventArgs e)
        {
            Formula(ref Formula2, ref Matrix_02, 2);
        }

        //</Formula Section>
    }
}
