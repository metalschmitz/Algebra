using System;

namespace Linear_Algebra.Types.Tests
{
    class VectorTest
    {
        public static void VectorConstructionTest()
        {
            Vector2D v1 = new Vector2D(2, 3);
            Vector3D v2 = new Vector3D(2.45, 12.3, 11.9);

            Console.WriteLine(v1);
            Console.WriteLine(v2);
        }
    }
}
