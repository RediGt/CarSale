using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCS_CarListJson
{
    public partial class Form1 : Form
    {
        List<Car> cars = new List<Car>();

        public Form1()
        {
            InitializeComponent();
            LoadFile();
            dataGridView1.ClearSelection();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {                 
            if (tBoxType.Text != "" && tBoxModel.Text != "" && tBoxColor.Text != "" || comBoxStatus.Text == "")
            {
                cars.Add(new Car(tBoxType.Text, tBoxModel.Text, tBoxColor.Text, comBoxStatus.Text));
            }
            ClearBoxes();
            DisplayInGrid();
        }

        private void SaveFile()
        {
            FileIO.SaveToFile(cars);
        }

        private void LoadFile()
        {
            cars = FileIO.LoadFromFile();
            if (cars == null)
            {
                cars = new List<Car>();
                return;
            }
                
            DisplayInGrid();
        }

        private void ClearBoxes()
        {
            tBoxType.Text = "";
            tBoxModel.Text = "";
            tBoxColor.Text = "";
            comBoxStatus.SelectedIndex = -1;
        }

        private void DisplayInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (var car in cars)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = car.Type;
                dataGridView1.Rows[n].Cells[1].Value = car.Model;
                dataGridView1.Rows[n].Cells[2].Value = car.Color;
                dataGridView1.Rows[n].Cells[3].Value = car.Status;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DisplayDataRow();
        }

        private void DisplayDataRow()
        {       
            tBoxType.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            tBoxModel.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tBoxColor.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comBoxStatus.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected) < 1 ||
                tBoxType.Text == "" || tBoxModel.Text == "" || tBoxColor.Text == "" || comBoxStatus.Text == "")
                return;
            
            int selectedCarIndex = dataGridView1.SelectedRows[0].Index;
            cars[selectedCarIndex].Type = tBoxType.Text;
            cars[selectedCarIndex].Model = tBoxModel.Text;
            cars[selectedCarIndex].Color = tBoxColor.Text;
            cars[selectedCarIndex].Status = comBoxStatus.Text;
            DisplayInGrid();
            ClearBoxes();           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected) < 1 ||
                tBoxType.Text == "" || tBoxModel.Text == "" || tBoxColor.Text == "" || comBoxStatus.Text == "")
                return;

            int selectedStudentIndex = dataGridView1.SelectedRows[0].Index;
            cars.RemoveAt(selectedStudentIndex);
            DisplayInGrid();
            ClearBoxes();
        }
    }
}
