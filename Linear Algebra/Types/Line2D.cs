namespace Linear_Algebra.Types
{
    /// <summary>
    /// A line in two dimensional space defined by a local point and a directional vector.
    /// </summary>
    class Line2D
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Line2D()
        {
            Point = new Point2D();
            Direction = new Vector2D();
        }

        /// <summary>
        /// Construct a line defined by a point and a direction.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="direction"></param>
        public Line2D(Point2D point, Vector2D direction)
        {
            Point = point;
            Direction = direction;
        }

        /// <summary>
        /// Construct a line using two points. The first point defines the origin while the direction is calculated from the two points.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public Line2D(Point2D point1, Point2D point2)
        {
            Point = point1;
            Direction = new Vector2D(point1, point2);
        }

        /// <summary>
        /// Local point of the the line.
        /// </summary>
        public Point2D Point
        { get; set; }

        /// <summary>
        /// Direction vector of the line.
        /// </summary>
        public Vector2D Direction
        { get; set; }
    }
}
