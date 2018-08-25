namespace Linear_Algebra.Types
{
    class Line2D
    {
        public Line2D()
        {
            Point = new Point2D();
            Direction = new Vector2D();
        }

        public Line2D(Point2D point, Vector2D direction)
        {
            Point = point;
            Direction = direction;
        }

        public Point2D Point
        { get; set; }

        public Vector2D Direction
        { get; set; }
    }
}
