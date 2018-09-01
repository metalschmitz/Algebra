using System;
using System.Diagnostics;

namespace Linear_Algebra.Types.Tests
{
    static class MatrixTest
    {
        public static void TestSarrus()
        {
            double[,] values = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            SquareMatrix matrix = new SquareMatrix(values);

            double checkDeterminant = 0;
            double determinant = matrix.Sarrus();

            Debug.Assert(checkDeterminant == determinant);

            Console.WriteLine($"Sarrus determinant value: {determinant}");
        }

        public static void TestMatrixAddSub()
        {
            double[,] a = { { 1, 2 }, { 3, 4 } };
            double[,] b = { { 5, 6 }, { 7, 8 } };
            double[,] aPlusB = { { 6, 8}, { 10, 12} };
            double[,] aMinusB = { { -4, -4 }, { -4, -4 } };

            Matrix checkMatrixSum = new Matrix(aPlusB);
            Matrix checkMatrixDifference = new Matrix(aMinusB);

            Matrix matrixA = new Matrix(a);
            Matrix matrixB = new Matrix(b);
            Matrix matrixC = matrixA + matrixB;
            Matrix matrixD = matrixA - matrixB;

            Debug.Assert(matrixC == checkMatrixSum);
            Debug.Assert(matrixD == checkMatrixDifference);

            Console.WriteLine("Result of addition of matrices");
            Console.WriteLine(matrixC);
            Console.WriteLine("Result of subtraction of matrices");
            Console.WriteLine(matrixD);
        }

        public static void TestTransposedMatrix()
        {
            double[,] values = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            double[,] transposedValues = { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } };

            Matrix matrix = new Matrix(values);
            Matrix transposedCheckMatrix = new Matrix(transposedValues);

            Matrix transposedMatrix = matrix.Transpose();

            Debug.Assert(transposedMatrix == transposedCheckMatrix);

            Console.WriteLine("Transposed matrix: \n" + transposedMatrix);
        }

        public static void TesetLaPlace()
        {
            double[,] values = { {1, 2, 3}, {4, 5, 6 }, {7, 8, 9} };
            double checkDeterminant = 0;

            SquareMatrix laPlace = new SquareMatrix(values);

            double determinante = laPlace.LaPlaceDeterminant();

            Debug.Assert(determinante == checkDeterminant);

            Console.WriteLine(determinante);
        }

        public static void TestSqaureMatrixUnifiedConstructor()
        {
            SquareMatrix matrix3x3 = new SquareMatrix(3, true);

            Debug.Assert(matrix3x3[0, 0] == 1);
            Debug.Assert(matrix3x3[1, 1] == 1);
            Debug.Assert(matrix3x3[2, 2] == 1);

            Debug.Assert(matrix3x3[0, 1] == 0);
            Debug.Assert(matrix3x3[0, 2] == 0);
            Debug.Assert(matrix3x3[1, 0] == 0);
            Debug.Assert(matrix3x3[1, 2] == 0);
            Debug.Assert(matrix3x3[2, 0] == 0);
            Debug.Assert(matrix3x3[2, 1] == 0);

            Console.WriteLine(matrix3x3);
        }

        public static void TestSquareMatrixTrace()
        {
            double[,] values = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            double trace = 2 + 5 + 8;
            SquareMatrix matrix = new SquareMatrix(values);

            Debug.Assert(matrix.Trace() == trace);

            Console.WriteLine("Trace of square matrix: " + trace);
        }

        public static void TestHiddenGetSubMatrix()
        {
            double[,] values = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            SquareMatrix matrix = new SquareMatrix(values);

            SquareMatrix subMatrix = matrix.GetMatrixPartition(1, 1);

            Console.WriteLine("Hidden Submatrix test:\n" + subMatrix);
        }
    }
}
