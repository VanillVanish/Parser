using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Parser.DataModel;

namespace Parser
{
    public partial class MainForm : Form
    {
        private DataSheet data = new DataSheet();

        public MainForm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            
            dgvMain.ColumnCount = 100;
            dgvMain.RowCount = 2000;

            for (int i = 0; i < dgvMain.ColumnCount; i++)
            {
                dgvMain.Columns[i].Name = "C" + (i + 1);
                dgvMain.Columns[i].Width = 80;
            }

            for (int i = 0; i < dgvMain.RowCount; i++)
                dgvMain.Rows[i].HeaderCell.Value = "R" + (i + 1);
        }

        private void dgvMain_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            var cellIndex = new CellIndex() {Col = e.ColumnIndex + 1, Row = e.RowIndex + 1};
            Cell cell;
            var isEditMode = dgvMain.CurrentCell != null && dgvMain.CurrentCell.IsInEditMode;

            if (data.Cells.TryGetValue(cellIndex, out cell))
                e.Value = isEditMode ? cell.Expression : cell.CachedValue.ToString();
        }

        private void dgvMain_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            var cellIndex = new CellIndex() { Col = e.ColumnIndex + 1, Row = e.RowIndex + 1 };

            Cell cell;
            if (data.Cells.TryGetValue(cellIndex, out cell))
                cell.Expression = e.Value.ToString();
            else
                data.Cells[cellIndex] = new Cell {Expression = e.Value.ToString()};

            data.Calculate();
            dgvMain.Invalidate();
        }

        private void miNew_Click(object sender, EventArgs e)
        {
            data.Cells.Clear();
            dgvMain.Invalidate();
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() {Filter = "DataSheet|*.ds"};
            if (ofd.ShowDialog() == DialogResult.OK)
                try
                {
                    using (var fs = File.OpenRead(ofd.FileName))
                        data = (DataSheet) new BinaryFormatter().Deserialize(fs);

                    data.Calculate();
                    dgvMain.Invalidate();

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "DataSheet|*.ds" };
            if (sfd.ShowDialog() == DialogResult.OK)
                try
                {
                    using (var fs = File.OpenWrite(sfd.FileName))
                        new BinaryFormatter().Serialize(fs, data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    private void MainForm_Load(object sender, EventArgs e)
    {

    }


  }
}
