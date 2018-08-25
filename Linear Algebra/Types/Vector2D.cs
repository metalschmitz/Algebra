using System;

namespace Linear_Algebra.Types
{
    /// <summary>
    /// A two dimensional vector
    /// </summary>
    class Vector2D : Vector
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public Vector2D() : base(2)
        { }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="vector"></param>
        public Vector2D(Vector2D vector) : base(vector)
        { }

        /// <summary>
        /// Constructor with initial values.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2D(double x, double y) : base(new double[] {x, y}) 
        { }

        /// <summary>
        /// Constructor with initial values.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2D(double[] xy) : base(xy)
        { }

        /// <summary>
        /// Constructor with initial values.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2D(Point2D p1, Point2D p2) : base(new double[] {p2.X - p1.X, p2.Y - p2.Y})
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
        #endregion

        #region Public methods
        /// <summary>
        /// Get the norm of the vector
        /// </summary>
        /// <returns></returns>
        public double Norm() => Math.Sqrt(X * X + Y * Y);

        /// <summary>
        /// Get a normalized vector of this vector.
        /// </summary>
        /// <returns></returns>
        public Vector2D Normalize()
        {
            double norm = Norm();

            Vector2D result = new Vector2D();

            result.X /= norm;
            result.Y /= norm;

            return result;
        }
        #endregion

        #region Overrides
        public override string ToString() => $"({X}; {Y})";
        #endregion
    }
}
