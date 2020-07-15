using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanKorSeged_v01
{
    public partial class DataGridViewKai : System.Windows.Forms.DataGridView
    {
        //public static List<DataGridViewKai> l = new List<DataGridViewKai>();
        /*static int cp_x;
        static int cp_y;
        static bool firstclick = true;
        static DataGridView dgw = null;*/

        public DataGridViewKai()
        {
            InitializeComponent();
            AllowDrop = true;
            //l.Add(this);
        }



        /*static Rectangle dragBoxFromMouseDown;
        static int rowIndexFromMouseDown;
        static int rowIndexOfItemUnderMouseToDrop;*/



        static DataGridViewKai dgwk = null;
        static DataGridViewRow rowToMove = null;
        static Rectangle dragBoxFromMouseDown;
        static int rowIndexFromMouseDown;
        static int rowIndexOfItemUnderMouseToDrop;
        static Point MouseDownLocation;
        ///////
        static List<DataGridViewRow> rowstomove = new List<DataGridViewRow>();
        static List<int> rowstodel = new List<int>();
        ///////
        private void DataGridViewKai_MouseDown(object sender, MouseEventArgs e)
        {
            ///////
            rowstomove.Clear(); rowstodel.Clear();
            Int32 selectedRowCount = this.Rows.GetRowCount(DataGridViewElementStates.Selected);
            for (int i = 0; i < selectedRowCount; i++)
            {
                rowstomove.Add((DataGridViewRow)this.SelectedRows[i].Clone());
                rowstodel.Add(this.SelectedRows[i].Index);
            }
            ///////
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left) // SOR ADAT MOZGATÁSA BAL KLIKKEL
            {
                dgwk = this;
                // Get the index of the item the mouse is below.
                rowIndexFromMouseDown = this.HitTest(e.X, e.Y).RowIndex;
                if (rowIndexFromMouseDown != -1)
                {
                    // Remember the point where the mouse down occurred. The DragSize indicates the size that the mouse can move before a drag event should be started.                
                    Size dragSize = SystemInformation.DragSize;
                    // Create a rectangle using the DragSize, with the mouse position being at the center of the rectangle.
                    dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                }
                else // Reset the rectangle if the mouse is not over an item in the ListBox.
                    dragBoxFromMouseDown = Rectangle.Empty;
            }
        }
        private void DataGridViewKai_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be converted to client coordinates.
            //Point clientPoint = this.PointToClient(new Point(e.X, e.Y));
            // Get the row index of the item the mouse is below. 
            //rowIndexOfItemUnderMouseToDrop = this.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {

                /*rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                dgwk.Rows.RemoveAt(rowIndexFromMouseDown); 
                if (rowIndexOfItemUnderMouseToDrop >= this.Rows.Count) { rowIndexOfItemUnderMouseToDrop--; }

                this.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);*/

                //////
                for (int i = 0; i < rowstomove.Count; i++)
                {
                    rowToMove = dgwk.Rows[rowstodel.ElementAt(i)];
                    dgwk.Rows.RemoveAt(rowstodel.ElementAt(i));
                    Point clientPoint = this.PointToClient(new Point(e.X, e.Y));
                    rowIndexOfItemUnderMouseToDrop = this.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
                    if (rowIndexOfItemUnderMouseToDrop >= this.Rows.Count) { rowIndexOfItemUnderMouseToDrop--; }
                    this.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
                }
                //////
            }
        }
















        private void DataGridViewKai_MouseMove(object sender, MouseEventArgs e)
        {

            // SOR ADAT MOZGATÁSA BAL KLIKKEL
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = this.DoDragDrop(dgwk.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
                }
            }
        }

        private void DataGridViewKai_DragEnter(object sender, DragEventArgs e)
        {
        }

        private void DataGridViewKai_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
    }
}
