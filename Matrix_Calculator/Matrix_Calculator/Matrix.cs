using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Data;

namespace Matrix_Calculator
{
    class Matrix
    {
        public int rows;
        public int columns;
        public double[,] array;

        public Matrix(int rowN, int columN)
        {
            rows = rowN;
            columns = columN;
            array = new double[rowN, columN];
        }

        public double getValue(int i, int j)
        {
            return array[i, j];
        }

        public void setValue(int i, int j, double value)
        {
            array[i, j] = value;
        }

        public static Matrix scale(Matrix m, double x, double y)
        {
            Matrix matrix = new Matrix(2, 2);
            matrix.setValue(0, 0, x);
            matrix.setValue(0, 1, 0);
            matrix.setValue(1, 0, 0);
            matrix.setValue(1, 1, y);
            return multiply(matrix, m);
        }

        public static Matrix translate(Matrix m, double x, double y)
        {
            Matrix t = new Matrix(m.rows, m.columns);
            for (int j = 0; j < m.columns; j++)
            {
                t.setValue(0, j, x);
                t.setValue(1, j, y);
            }
            return somarMatriz(t, m);
        }

        public static Matrix rotate(Matrix m, double angle)
        {
            Matrix r = new Matrix(2, 2);
            r.setValue(0, 0, Math.Round(Math.Cos(angle * (Math.PI / 180)), 2));
            r.setValue(0, 1, Math.Round(-Math.Sin(angle * (Math.PI / 180)), 2));
            r.setValue(1, 0, Math.Round(Math.Sin(angle * (Math.PI / 180)), 2));
            r.setValue(1, 1, Math.Round(Math.Cos(angle * (Math.PI / 180)), 2));
            return multiply(r, m);

        }

        public static Matrix CollectionToMatrix(PointCollection PC, double xOffset, double yOffSet)
        {
            Matrix m = new Matrix(2, PC.Count);
            for (int i = 0; i < PC.Count; i++)
            {
                m.setValue(0, i, PC[i].X + xOffset);
                m.setValue(1, i, PC[i].Y + yOffSet);
            }
            return m;
        }

        public static PointCollection MatrixToCollection(Matrix m, double xOffset, double yOffSet)
        {
            PointCollection p = new PointCollection();

            for (int i = 0; i < m.columns; i++)
            {
                Point point = new Point();
                point.X = m.getValue(0, i) + xOffset;
                point.Y = m.getValue(1, i) + yOffSet;
                p.Add(point);
            }
            return p;
        }

        public static Matrix somarMatriz(Matrix m1, Matrix m2)
        {
            Matrix r = new Matrix(m1.rows, m1.columns);
            if (m1.rows == m2.rows && m1.columns == m2.columns) {
                for (int i = 0; i < m1.rows; i++) {
                    for (int j = 0; j < m1.columns; j++) {
                        r.setValue(i, j, m1.array[i, j] + m2.array[i, j]);
                    }
                }
                return r;
            } else {
                return new Matrix(0, 0);
            }
        }

        public static Matrix multiply(Matrix m1, Matrix m2)
        {
            if (m1.columns == m2.rows)
            {
                Matrix r = new Matrix(m1.rows, m2.columns);

                double nome = 0;
                for (int i = 0; i < m1.rows; i++)
                {
                    for (int j = 0; j < m2.columns; j++)
                    {
                        for (int n = 0; n < m1.columns; n++)
                        {
                            nome += m1.array[i, n] * m2.array[n, j];
                        }
                        r.setValue(i, j, nome);
                        nome = 0;
                    }
                }
                return r;
            }
            else
            {
                return new Matrix(0, 0);
            }
        }
    }
}
