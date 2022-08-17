using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public class BaseTool
    {
        public virtual void Draw(Graphics graphics, Pen pen, int X, int Y)
        {
        }

        public virtual void AddPoint(int x, int y)
        {

        }
    }
}
