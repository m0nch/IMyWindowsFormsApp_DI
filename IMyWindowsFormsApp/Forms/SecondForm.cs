using IMyWindowsFormsApp.Data.Models;
using IMyWindowsFormsApp.Mappers;
using IMyWindowsFormsApp.Models.ViewModels;
using IMyWindowsFormsApp.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IMyWindowsFormsApp
{
    public partial class SecondForm : Form
    {
        public Teacher TeacherInfo { get; set; }

        private readonly IStudentService _studentService;

        public SecondForm(IStudentService studentService)
        {
            InitializeComponent();
            _studentService = studentService;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshStudents();
            grdStudents.AutoGenerateColumns = false;
            if (grdStudents.SelectedRows.Count > 0)
            {
                ShowRow();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                TeacherId = TeacherInfo.Id,
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Age = Convert.ToInt32(txtAge.Text)
            };
            _studentService.Add(student);
            RefreshStudents();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Student student = _studentService.Get(Guid.Parse(grdStudents.SelectedRows[0].Cells["Id"].Value.ToString()));
            _studentService.Remove(student);
            RefreshStudents();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                Id = Guid.Parse(lblGuid.Text),
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Age = Convert.ToInt32(txtAge.Text),
                TeacherId = Guid.Parse(lblTGuid.Text)
            };
            _studentService.Update(student);
            RefreshStudents();
        }
        private void grdStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowRow();
        }
        private void RefreshStudents()
        {
            grdStudents.DataSource = null;
            grdStudents.DataSource = _studentService.GetAllByTeacher(TeacherInfo.Id).MapStudentsToViewModel();
            if (grdStudents.Rows.Count > 0)
            {
                grdStudents.Rows[0].Selected = true;
                ShowRow();
            }
        }
        private void ShowRow()
        {
            if (grdStudents.SelectedRows.Count > 0)
            {
                lblGuid.Visible = true; lblTGuid.Visible = true;
                lblGuid.Text = grdStudents.SelectedRows[0].Cells["Id"].Value.ToString();
                lblTGuid.Text = grdStudents.SelectedRows[0].Cells["TeacherId"].Value.ToString();
                string[] names = grdStudents.SelectedRows[0].Cells["stFullName"].Value.ToString().Split(' ');
                txtLastName.Text = names.Last();
                txtFirstName.Text = names.First();
                txtAge.Text = grdStudents.SelectedRows[0].Cells["stAge"].Value.ToString();
            }
        }
    }
}
