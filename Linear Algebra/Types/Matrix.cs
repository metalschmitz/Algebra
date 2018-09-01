using Linear_Algebra.Exceptions;
using System;
using System.Collections.Generic;

namespace Linear_Algebra.Types
{
    /// <summary>
    /// A mathematical matrix.
    /// </summary>
    class Matrix
    {
        #region constructors
        /// <summary>
        /// Constructs a 1 x 1 matrix with the value 0.
        /// </summary>
        public Matrix() => Values = new double[1, 1] { { 0 } };
        /// <summary>
        /// Construct a matrix with the format defined by lines and columns.
        /// </summary>
        /// 
        /// <param name="lines"></param>
        /// <param name="columns"></param>
        public Matrix(uint lines, uint columns) => Values = new double[lines, columns];

        /// <summary>
        /// Construct a matrix with the values supplied by the array.
        /// </summary>
        /// 
        /// <param name="values"></param>
        public Matrix(double[,] values) => Values = values;

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="matrix"></param>
        public Matrix(Matrix matrix) => Values = (double[,]) matrix.Values.Clone();
        #endregion

        #region Indexer
        /// <summary>
        /// Get the matrix value at the index defined by line and column
        /// </summary>
        /// 
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// 
        /// <returns></returns>
        public double this[uint line, uint column]
        {
            get
            {
                return Values[line, column];
            }

            set
            {
                Values[line, column] = value;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// The values of the matrix.
        /// </summary>
        public double[,] Values
        {
            get;
            protected set;
        }

        /// <summary>
        /// Get the number of lines in the matrix.
        /// </summary>
        public uint Lines => (uint)Values.GetLength(0);

        /// <summary>
        /// Get the number of columns of the matrix.
        /// </summary>
        public uint Columns => (uint)Values.GetLength(1);

        /// <summary>
        /// Check if matrix is a square matrix.
        /// </summary>
        public bool IsSquare => Lines == Columns;
        #endregion

        #region Operators
        /// <summary>
        /// Addition of two matrices.
        /// </summary>
        /// 
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// 
        /// <returns></returns>
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if(matrix1.Lines != matrix2.Lines || matrix1.Columns != matrix2.Columns)
            {
                throw new WrongFormatException("Matrix formats are not compatible.");
            }

            Matrix result = new Matrix(matrix1.Lines, matrix1.Columns);

            for(uint i = 0; i < result.Lines; i++)
            {
                for(uint j = 0; j < result.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Subtraction operation of two matrices.
        /// </summary>
        /// 
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// 
        /// <exception cref="WrongFormatException"></exception>
        /// 
        /// <returns></returns>
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Lines != matrix2.Lines || matrix1.Columns != matrix2.Columns)
            {
                throw new WrongFormatException("Matrix formats are not compatible.");
            }

            Matrix result = new Matrix(matrix1.Lines, matrix1.Columns);

            for (uint i = 0; i < result.Lines; i++)
            {
                for (uint j = 0; j < result.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplication of two matrices.
        /// </summary>
        /// 
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// 
        /// <exception cref="WrongFormatException"></exception>
        /// 
        /// <returns></returns>
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Lines != matrix2.Columns)
            {
                throw new WrongFormatException("Matrix formats are not compatible.");
            }

            Matrix result = new Matrix(matrix1.Lines, matrix2.Columns);
            for(uint lineMatrix1 = 0; lineMatrix1 < matrix1.Lines; lineMatrix1++)
            {
                for(uint columnMatrix2 = 0; columnMatrix2 < matrix2.Columns; columnMatrix2++)
                {
                    result[lineMatrix1, columnMatrix2] = SumOfProductsLineAndColumn(matrix1, matrix2, lineMatrix1, columnMatrix2);
                }
            }

            return result;
        }

        /// <summary>
        /// Multiply matrix with a scalar.
        /// </summary>
        /// 
        /// <param name="scalar"></param>
        /// <param name="matrix"></param>
        /// 
        /// <returns></returns>
        public static Matrix operator *(double scalar, Matrix matrix)
        {
            Matrix result = new Matrix(matrix);
            for(uint i = 1; i < matrix.Lines; i++)
            {
                for(uint j = 0; j < matrix.Columns; j++)
                {
                    result[i, j] *= scalar;
                }
            }
            return result;
        }

        /// <summary>
        /// Multiply matrix with a scalar.
        /// </summary>
        /// 
        /// <param name="scalar"></param>
        /// <param name="matrix"></param>
        /// 
        /// <returns></returns>
        public static Matrix operator *(int scalar, Matrix matrix)
        {
            return (double)scalar * matrix;
        }

        /// <summary>
        /// Check if two vectors are equal.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            if ((object) matrix1 == null || (object) matrix2 == null)
            {
                throw new ArgumentNullException();
            }

            if (matrix1.Lines != matrix2.Lines || matrix1.Columns != matrix2.Columns)
            {
                return false;
            }

            for (uint i = 0; i < matrix1.Lines; i++)
            {
                for (uint j = 0; j < matrix1.Columns; j++)
                { 
                    if (matrix1[i, j] != matrix2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Check if two vectors are not equal.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static bool operator !=(Matrix matrix1, Matrix matrix2) => !(matrix1 == matrix2);
        #endregion

        #region Public Methods
        /// <summary>
        /// Calculate inverse matrix of this matrix.
        /// </summary>
        /// <returns></returns>
        public Matrix Inverse()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the rank of a matrix. The rank is defined by the highest level sub determinant that is not 0.
        /// </summary>
        /// <returns></returns>
        public double Rank()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the transposed matrix.
        /// </summary>
        /// <returns></returns>
        public Matrix Transpose()
        {
            double[,] values = new double[Columns, Lines];
            for(uint i = 0; i < Lines; i++)
            {
                for(uint j = 0; j < Columns; j++)
                {
                    values[j, i] = this[i, j];
                }
            }
            return new Matrix(values);
        }

        /// <summary>
        /// Extract a line from a matrix as vector.
        /// </summary>
        /// <param name="indexLine"></param>
        /// <returns></returns>
        public Vector GetLineVector(uint indexLine)
        {
            if(indexLine >= Lines) throw new IndexOutOfRangeException();

            double[] values = new double[Columns];

            for(uint i = 0; i < Columns; i++)
            {
                values[i] = this[indexLine, i];
            }

            return new Vector(values);
        }

        /// <summary>
        /// Extract a column from a matrix as vector.
        /// </summary>
        /// <param name="indexColumn"></param>
        /// <returns></returns>
        public Vector GetColumnVector(uint indexColumn)
        {
            if (indexColumn >= Columns) throw new IndexOutOfRangeException();

            double[] values = new double[Lines];

            for (uint i = 0; i < Lines; i++)
            {
                values[i] = this[i, indexColumn];
            }

            return new Vector(values);
        }

        /// <summary>
        /// Get the submatrix that remains by erasing a line and a column from a matrix.
        /// </summary>
        /// <param name="ignoredLine"></param>
        /// <param name="ignoredColumn"></param>
        /// <exception cref="IndexOutOfRangeException">Is thrown if the indices are higher than the allowed range.</exception>
        /// <returns></returns>
        public Matrix GetSubMatrix(uint ignoredLine, uint ignoredColumn)
        {
            if (ignoredLine >= Lines || ignoredColumn >= Columns) throw new IndexOutOfRangeException();
            Matrix result = new Matrix(Lines - 1, Columns - 1);

            for(uint i = 0, ii = 0; i < Lines; i++)
            {
                if (i == ignoredLine) continue;
                for(uint j = 0, jj = 0; j < Columns; j++)
                {
                    if (j == ignoredColumn) continue;
                    result[ii, jj] = this[i, j];
                    jj++;
                }
                ii++;
            }
            return result;
        }

        /// <summary>
        /// Swaps the values of two line of this matrix.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        public void SwapLines(uint line1, uint line2)
        {
            double swapValue;

            for(uint i = 0; i < Columns; i++)
            {
                swapValue = this[line1, i];
                this[line1, i] = this[line2, i];
                this[line2, i] = swapValue;
            }
        }

        /// <summary>
        /// Adds the multiple of a line of this matrix to another line.
        /// </summary>
        /// <param name="factor"></param>
        /// <param name="lineFrom"></param>
        /// <param name="lineTo"></param>
        public void AddMultipleOfLine(double factor, uint lineFrom, uint lineTo)
        {
            for(uint i = 0; i < Columns; i++)
            {
                this[lineTo, i] += this[lineFrom, i] * factor;
            }
        }

        /// <summary>
        /// Multiply the values of a line with a scalar.
        /// </summary>
        /// <param name="scalar"></param>
        /// <param name="lineIndex"></param>
        public void MultiplyLineWithScalar(double scalar, uint lineIndex)
        {
            for (uint i = 0; i < Columns; i++)
            {
                this[lineIndex, i] *= scalar;
            }
        }

        /// <summary>
        /// Convenience function to get a string representation of the format of a matrix.
        /// </summary>
        /// <returns></returns>
        public string GetMatrixFormat()
        {
            return Lines + " x " + Columns;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Returns a string representation of the matrix.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";

            for(var i = 0; i < Lines; i++)
            {
                result += "|";
                for(var j = 0; j < Columns; j++)
                {
                    result += $" {Values[i, j]}";
                }
                result += " |\n";
            }
            return result;
        }

        /// <summary>
        /// Checks Equality with another object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var matrix = obj as Matrix;
            return matrix != null &&
                   EqualityComparer<double[,]>.Default.Equals(Values, matrix.Values) &&
                   Lines == matrix.Lines &&
                   Columns == matrix.Columns;
        }

        /// <summary>
        /// Get the Hashcode of this object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = -1336552285;
            hashCode = hashCode * -1521134295 + EqualityComparer<double[,]>.Default.GetHashCode(Values);
            hashCode = hashCode * -1521134295 + Lines.GetHashCode();
            hashCode = hashCode * -1521134295 + Columns.GetHashCode();
            return hashCode;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Helper function to get the sum of products of the values in a matrix with the colum values of another matrix.
        /// This is used in matrix multiplication.
        /// </summary>
        /// <remarks>This function was created to make the original matrix multiplication function more readable.</remarks>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <param name="lineIndexMatrix1"></param>
        /// <param name="columnIndexMatrix2"></param>
        /// <returns></returns>
        private static double SumOfProductsLineAndColumn(Matrix matrix1, Matrix matrix2, uint lineIndexMatrix1, uint columnIndexMatrix2)
        {
            if(matrix1.Columns != matrix2.Lines) throw new WrongFormatException("Matrix formats are invalid for this Operation.");

            double result = 0;

            for(uint i = 0; i < matrix2.Lines; i++)
            {
                result += matrix1[lineIndexMatrix1, i] * matrix2[i, columnIndexMatrix2];
            }

            return result;
        }

        /// <summary>
        /// Get the line index with the most zeros in it.
        /// </summary>
        /// <remarks>This function is useful to optimize LaPlace determinant calculation.</remarks>
        /// <returns></returns>
        private uint GetLineWithMostZeroValues()
        {
            // By default if we do not find any zero values we give the first line as result
            uint result = 0;
            uint maxNumberOfZeroValues = 0;
            for(uint i = 0; i < Lines; i++)
            {
                uint numberOfZeros = 0;
                for(uint j = 0; j < Columns; j++)
                {
                    if(this[i, j] == 0)
                    {
                        numberOfZeros++;
                    }
                }
                if(numberOfZeros > maxNumberOfZeroValues)
                {
                    maxNumberOfZeroValues = numberOfZeros;
                    result = i;
                }
            }
            return result;
        }

        /// <summary>
        /// Get the column index with the most zeros in it.
        /// </summary>
        /// <remarks>This function is useful to optimize LaPlace determinant calculation.</remarks>
        /// <returns></returns>
        private uint GetColumnsWithMostZeroValues()
        {
            // By default if we do not find any zero values we give the first line as result
            uint result = 0;
            uint maxNumberOfZeroValues = 0;
            for (uint i = 0; i < Columns; i++)
            {
                uint numberOfZeros = 0;
                for (uint j = 0; j < Lines; j++)
                {
                    if (this[j, i] == 0)
                    {
                        numberOfZeros++;
                    }
                }
                if (numberOfZeros > maxNumberOfZeroValues)
                {
                    maxNumberOfZeroValues = numberOfZeros;
                    result = i;
                }
            }
            return result;
        }
        #endregion
    }
}
