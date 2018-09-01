using Linear_Algebra.Exceptions;
using System;

namespace Linear_Algebra.Types
{
    /// <summary>
    /// Square matrix is especially thought to be used for operations that are only defined on square matrices.
    /// </summary>
    class SquareMatrix : Matrix
    {
        /// <summary>
        /// Creates a square matrix of size x size format.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="unified">Set this parameter to true to create a unified matrix.</param>
        public SquareMatrix(uint size, bool unified = false) : base(size, size)
        {
            if(unified)
            {
                for(uint i = 0; i < size; i++)
                {
                    this[i, i] = 1;
                }
            }
        }

        /// <summary>
        /// Copy Contructor
        /// </summary>
        /// <param name="matrix"></param>
        public SquareMatrix(SquareMatrix matrix) : base(matrix)
        { }

        /// <summary>
        /// Create a square Matrix with initial values.
        /// </summary>
        /// <exception cref="ArgumentException">Throws an exception if the supplied array is not of equal size in each dimension.</exception>
        /// <param name="values"></param>
        public SquareMatrix(double[,] values)
        {
            if (values.GetLength(0) != values.GetLength(1))
                throw new ArgumentException("Square matrix can not be created with an array of different sizes in each dimension.");

            Values = values;
        }

        /// <summary>
        /// Get the trace of a matrix.
        /// </summary>
        /// <remarks>The trace of a square matrix is defined as the sum of the main diagonal's elements.</remarks>
        /// <returns></returns>
        public double Trace()
        {
            double result = 0;
            for (uint i = 0; i < Lines; i++)
            {
                result += this[i, i];
            }
            return result;
        }

        /// <summary>
        /// Calculate the determinant of a 3 x 3 matrix.
        /// 
        /// If this function is called on a matrix that is not of 3 x 3 format a WrongFormatException is thrown.
        /// </summary>
        /// <exception cref="WrongFormatException"></exception>
        /// <returns>The determinant value of the matrix.</returns>
        public double Sarrus()
        {
            if (Lines != 3 || Columns != 3)
                throw new WrongFormatException("This operation can only be performed on 3x3 matrices");

            return this[0, 0] * this[1, 1] * this[2, 2] +
                this[0, 1] * this[1, 2] * this[2, 0] +
                this[0, 2] * this[1, 0] * this[2, 1] -
                this[0, 2] * this[1, 1] * this[2, 0] -
                this[0, 0] * this[1, 2] * this[2, 1] -
                this[0, 1] * this[1, 0] * this[2, 2];
        }

        /// <summary>
        /// Calculate the determinant of a 2 x 2 matrix.
        /// 
        /// If this method is called on a matrix that is not of 2 x 2 format a WrongFormatException is thrown.
        /// </summary>
        /// <exception cref="WrongFormatException"></exception>
        /// <returns>The determinant value of the matrix.</returns>
        public double Determinaten2x2()
        {
            if (Lines != 2 || Columns != 2)
                throw new WrongFormatException("This operation can only be performed on 2x2 matrices");

            return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
        }

        /// <summary>
        /// Caclulate the determinant of a matrix using the La Place algorithm.
        /// </summary>
        /// <remarks>Performance wise this is a very expensive calculation.</remarks>
        /// <returns></returns>
        public double LaPlaceDeterminant()
        {
            if (Lines == 1 && Columns == 1) return this[0, 0];

            double result = 0;
            for (uint i = 0; i < Columns; i++)
            {
                var complement = AlgebraicComplement(0, i);
                var complementProduct = this[0, i] * complement;
                result += complementProduct;
            }
            return result;
        }

        /// <summary>
        /// Get the minor value of a matrix index. The minor is defined by the determinant of the matrix that 
        /// remains when removing the line and column of the matrix index.
        /// </summary>
        /// <param name="lineIndex"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public double Minor(uint lineIndex, uint columnIndex)
        {
            return GetMatrixPartition(lineIndex, columnIndex).LaPlaceDeterminant();
        }

        /// <summary>
        /// The algebraic complement of a matrix index is the alternatingly positive or negative determinant of a sub determinant of the sub matrix that
        /// you get by discarding the line and column of the given index.
        /// </summary>
        /// <param name="lineIndex"></param>
        /// <param name="columnIndex"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <returns></returns>
        public double AlgebraicComplement(uint lineIndex, uint columnIndex)
        {
            if (lineIndex >= Lines || columnIndex >= Columns) throw new IndexOutOfRangeException();

            if (Lines == 1 && Columns == 1)
                return (lineIndex + columnIndex) % 2 == 0 ? this[0, 0] : -this[0, 0];

            if (Lines == 2 && Columns == 2)
                return (lineIndex + columnIndex) % 2 == 0 ? Determinaten2x2() : -Determinaten2x2();

            if (Lines == 3 && Columns == 3)
                return (lineIndex + columnIndex) % 2 == 0 ? Sarrus() : -Sarrus();

            return (lineIndex + columnIndex) % 2 == 0 ? Minor(lineIndex, columnIndex) : -Minor(lineIndex, columnIndex);

        }

        /// <summary>
        /// Calculate adjunt matrix of this matrix.
        /// </summary>
        /// <returns></returns>
        public Matrix Adjunct()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculate the inverse of a matrix using the Gauss-Jordan method.
        /// </summary>
        /// <returns></returns>
        public SquareMatrix InverseGaussJordan()
        {
            throw new NotImplementedException();
            SquareMatrix resultMatrix = new SquareMatrix(Lines, true);
            
            return resultMatrix;
        }

        /// <summary>
        /// Check if all values above the main diagonal of a sqaure matrix are 0.
        /// </summary>
        /// <returns></returns>
        public bool IsUpperTriangularMatrix()
        {
            if (!IsSquare) return false;

            for (var i = 0; i < Lines; i++)
            {
                for (var j = i + 1; j < Columns; j++)
                {
                    if (Values[i, j] != 0) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check if all values below the main diagonal of a square matrix are 0.
        /// </summary>
        /// <returns></returns>
        public bool IsLowerTriangularMatrix()
        {
            if (!IsSquare) return false;

            for (var i = 0; i < Lines; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (Values[i, j] != 0) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check if all values either above or below the main diagonal are 0.
        /// </summary>
        /// <returns></returns>
        public bool IsTriangularMatrix()
        {
            return IsUpperTriangularMatrix() || IsLowerTriangularMatrix();
        }

        /// <summary>
        /// Get the submatrix that remains by erasing a line and a column from a matrix.
        /// </summary>
        /// <remarks>
        /// This function is basically the same as GetSubMatrix from the base class <see cref="Matrix"/>. However hiding the base method
        /// and using a copy constructor or an object mapper to do this operation felt not right.
        /// </remarks>
        /// <param name="ignoredLine"></param>
        /// <param name="ignoredColumn"></param>
        /// <exception cref="IndexOutOfRangeException">Is thrown if the indices are higher than the allowed range.</exception>
        /// <returns></returns>
        public SquareMatrix GetMatrixPartition(uint ignoredLine, uint ignoredColumn)
        {
            if (ignoredLine >= Lines || ignoredColumn >= Columns) throw new IndexOutOfRangeException();
            SquareMatrix result = new SquareMatrix(Lines - 1);

            for (uint i = 0, ii = 0; i < Lines; i++)
            {
                if (i == ignoredLine) continue;
                for (uint j = 0, jj = 0; j < Columns; j++)
                {
                    if (j == ignoredColumn) continue;
                    result[ii, jj] = this[i, j];
                    jj++;
                }
                ii++;
            }
            return result;
        }
    }
}
