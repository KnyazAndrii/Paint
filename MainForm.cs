using Paint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        private bool _isClicked;
        private BaseTool _drawingTool;
        private List<BaseTool> _toolList;
        Bitmap _temp;
        private ToolType toolType;
        private Pen pen;
        enum ToolType
        {
            Pen = 1,
            Line = 2
        }

        public MainForm()
        {
            InitializeComponent();
            _toolList = new List<BaseTool>();
            pbMain.Image = new Bitmap(pbMain.Width, pbMain.Height);
            _temp = (Bitmap)pbMain.Image.Clone();
        }

        private void GetPen()
        {
            pen = new Pen(Color.Red, 3);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void DisableToolMenu()
        {
            foreach (ToolStripItem item in tsMain.Items)
            {
                item.BackColor = SystemColors.Control;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _isClicked = false;
            _temp = (Bitmap)pbMain.Image.Clone();

            if (_drawingTool != null)
            {
                _toolList.Add(_drawingTool);

                switch (toolType)
                {
                    case ToolType.Pen:
                        _drawingTool = new MyPen(2);
                        break;
                    case ToolType.Line:
                        _drawingTool = new MyLine();
                        break;
                    default:
                        break;
                }
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _isClicked = true;
            if (_drawingTool != null)
            {
                _drawingTool.AddPoint(e.X, e.Y);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isClicked && _drawingTool != null)
            {
                using (var bitmap = new Bitmap(_temp, pbMain.Width, pbMain.Height))
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    GetPen();
                    _drawingTool.Draw(graphics, pen, e.X, e.Y);
                    pbMain.Image?.Dispose();
                    pbMain.Image = (Bitmap)bitmap.Clone();
                }
            }
        }

        private void tsb_Pen_Click(object sender, EventArgs e)
        {
            toolType = ToolType.Pen;
            DisableToolMenu();
            tsbPen.BackColor = Color.Gold;
            _drawingTool = new MyPen(2);
        }

        private void tsbLine_Click(object sender, EventArgs e)
        {
            toolType = ToolType.Line;
            DisableToolMenu();
            tsbLine.BackColor = Color.Gold;
            _drawingTool = new MyLine();
        }
    }
}
