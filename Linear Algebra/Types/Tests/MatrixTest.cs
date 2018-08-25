using System;
using System.Diagnostics;

namespace Linear_Algebra.Types.Tests
{
    static class MatrixTest
    {
        public static void TestSarrus()
        {
            double[,] values = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix matrix = new Matrix(values);

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

        public static void TesetLaPlace()
        {
            double[,] values = { {1, 2, 3}, {4, 5, 6 }, {7, 8, 9} };
            double checkDeterminant = 0;

            Matrix laPlace = new Matrix(values);

            double determinante = laPlace.LaPlaceDeterminant();

            Debug.Assert(determinante == checkDeterminant);

            Console.WriteLine(determinante);
        }
    }
}
