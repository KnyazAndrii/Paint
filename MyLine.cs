namespace Paint
{
    public class MyLine : BaseTool
    {
        private Point _start;
        private Point _end;

        public override void Draw(Graphics graphics, Pen pen, int X, int Y)
        {
            _end = new Point(X, Y);
            graphics.DrawLine(pen, _start, _end);
        }

        public override void AddPoint(int x, int y)
        {
            _start = new Point(x, y);
        }
    }
}