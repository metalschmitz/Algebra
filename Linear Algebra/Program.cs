using Linear_Algebra.Types;
using Linear_Algebra.Types.Tests;
using System;

namespace Linear_Algebra
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixTest.TestSarrus();
            MatrixTest.TestMatrixAddSub();
            MatrixTest.TesetLaPlace();
            MatrixTest.TestTransposedMatrix();
            VectorTest.VectorConstructionTest();

            MatrixTest.TestSquareMatrixTrace();
            MatrixTest.TestSqaureMatrixUnifiedConstructor();

            MatrixTest.TestHiddenGetSubMatrix();
            Console.ReadKey();
        }
    }
}
