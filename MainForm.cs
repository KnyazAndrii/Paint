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
        private ArrayPoints arrayPoints;
        private List<ArrayPoints> arrayPointsList;
        Point _start;
        Bitmap _temp;
        ToolType toolType;
        public MainForm()
        {
            InitializeComponent();
            arrayPoints = new ArrayPoints(2);
            arrayPointsList = new List<ArrayPoints>();
            pbMain.Image = new Bitmap(pbMain.Width, pbMain.Height);
            _temp = (Bitmap)pbMain.Image.Clone();
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _isClicked = false;
            _temp = (Bitmap)pbMain.Image.Clone();
            arrayPointsList.Add(arrayPoints);
            arrayPoints = new ArrayPoints(2);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _isClicked = true;
            _start = e.Location;

        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isClicked)
            {
                using (var bitmap = new Bitmap(_temp, pbMain.Width, pbMain.Height))
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    Pen pen = new Pen(Color.Red, 3);

                    switch (toolType)
                    {
                        case ToolType.Pen:
                            arrayPoints.AddPoint(e.X, e.Y);
                            if (arrayPoints.GetPoints().Length >= 2)
                            {
                                graphics.DrawLines(pen, arrayPoints.GetPoints());
                            }
                            break;
                        case ToolType.Line:
                            graphics.DrawLine(pen, _start, e.Location);
                            break;
                        default:
                            break;
                    }

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
        }

        private void DisableToolMenu()
        {
            foreach (ToolStripItem item in tsMain.Items)
            {
                item.BackColor = SystemColors.Control;
            }
        }

        private void tsbLine_Click(object sender, EventArgs e)
        {
            toolType = ToolType.Line;
            DisableToolMenu();
            tsbLine.BackColor = Color.Gold;
        }
        enum ToolType
        {
            Pen = 1,
            Line = 2
        }
    }
}
