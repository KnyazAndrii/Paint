using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public class ArrayPoints
    {
        private int _index = 0;
        private Point[] _points;

        public void AddPoint(int x, int y)
        {
            if (_points.Length <= _index)
            {
                Point[] temp = _points;
                _points = new Point[temp.Length * 2];
                for (int i = 0; i < temp.Length; i++)
                {
                    _points[i] = temp[i];
                }

            }
            _points[_index] = new Point(x, y);
            _index++;
        }

        public Point[] GetPoints()
        {
            Point[] points = new Point[_index];
            for (int i = 0; i < _index; i++)
            {
                points[i] = _points[i];
            }
            return points;
        }

        public ArrayPoints(int size)
        {
            this._points = new Point[size];
        }
    }
}
