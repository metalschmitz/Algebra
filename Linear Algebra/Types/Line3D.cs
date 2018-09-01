namespace Linear_Algebra.Types
{
    /// <summary>
    /// A line in three dimensional space define by a local point and a directional vector.
    /// </summary>
    class Line3D
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Line3D()
        {
            Point = new Point3D();
            Direction = new Vector3D();
        }

        /// <summary>
        /// Construct a line defined by a point and a direction.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="direction"></param>
        public Line3D(Point3D point, Vector3D direction)
        {
            Point = point;
            Direction = direction;
        }

        /// <summary>
        /// Construct a line using two points. The first point defines the origin while the direction is calculated from the two points.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public Line3D(Point3D point1, Point3D point2)
        {
            Point = point1;
            Direction = new Vector3D(point1, point2);
        }

        /// <summary>
        /// Local point of the the line.
        /// </summary>
        public Point3D Point
        { get; set; }

        /// <summary>
        /// Direction vector of the line.
        /// </summary>
        public Vector3D Direction
        { get; set; }
    }
}
