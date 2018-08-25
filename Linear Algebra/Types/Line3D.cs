namespace Linear_Algebra.Types
{
    class Line3D
    {
        public Line3D()
        {
            Point = new Point3D();
            Direction = new Vector3D();
        }

        public Line3D(Point3D point, Vector3D direction)
        {
            Point = point;
            Direction = direction;
        }

        public Point3D Point
        { get; set; }

        public Vector3D Direction
        { get; set; }
    }
}
