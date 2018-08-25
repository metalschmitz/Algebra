using System;

namespace Linear_Algebra.Types
{
    /// <summary>
    /// A three dimensional vector.
    /// </summary>
    class Vector3D : Vector
    {
        #region Constructors
        /// <summary>
        /// Constrcutor
        /// </summary>
        public Vector3D() : base(3)
        { }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="vector"></param>
        public Vector3D(Vector3D vector) : base(vector)
        { }

        /// <summary>
        /// Constructor with initial values.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3D(double x, double y, double z) : base(new double[] {x, y, z})
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Constructor with initial values.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector3D(double[] xyz) : base(xyz)
        { }

        /// <summary>
        /// Constructor with initial values.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector3D(Point3D p1, Point3D p2) : base(new double[] {p2.X - p1.X, p2.Y - p2.Y, p2.Z - p2.Z})
        { }
        #endregion

        #region Properties
        /// <summary>
        /// X-coordinate
        /// </summary>
        public double X
        {
            get => Values[0];            
            set => Values[0] = value;
        }

        /// <summary>
        /// Y-coordinate
        /// </summary>
        public double Y
        {
            get => Values[1];
            set => Values[1] = value;
        }

        /// <summary>
        /// Z-coordinate
        /// </summary>
        public double Z
        {
            get => Values[2];
            set => Values[2] = value;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get the norm of the vector.
        /// </summary>
        /// <returns></returns>
        public double Norm() => Math.Sqrt(X * X + Y * Y + Z * Z);

        /// <summary>
        /// Get a normalized vector of this vector.
        /// </summary>
        /// <returns></returns>
        public Vector3D Normalize()
        {
            double norm = Norm();

            Vector3D result = new Vector3D();

            result.X /= norm;
            result.Y /= norm;
            result.Z /= norm;

            return result;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Get a string representation of the vector.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"({X}; {Y}; {Z})";
        #endregion
    }
}
