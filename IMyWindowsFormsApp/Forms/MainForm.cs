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
    public partial class MainForm : Form
    {
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;

        public MainForm(ITeacherService teacherService, IStudentService studentService)
        {
            InitializeComponent();
            _teacherService = teacherService;
            _studentService = studentService;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(100, 100);
            RefreshTeachers();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher
            {
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Age = Convert.ToInt32(txtAge.Text)
            };
            _teacherService.Add(teacher);
            RefreshTeachers();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Teacher teacher = _teacherService.Get(Guid.Parse(grdTeachers.SelectedRows[0].Cells["Id"].Value.ToString()));
            _teacherService.Remove(teacher);
            RefreshTeachers();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher
            {
                Id = Guid.Parse(lblGuid.Text),
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Age = Convert.ToInt32(txtAge.Text)
            };
            _teacherService.Update(teacher);
            RefreshTeachers();
        }
        private void grdTeachers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowRow();
        }
        private void RefreshTeachers()
        {
            grdTeachers.DataSource = null;
            grdTeachers.DataSource = _teacherService.GetAll().MapTeachersToViewModel();
            if (grdTeachers.Rows.Count > 0)
            {
                grdTeachers.Rows[0].Selected = true;
            }
        }
        private void ShowRow()
        {
            if (grdTeachers.SelectedRows.Count > 0)
            {
                lblGuid.Visible = true;
                lblGuid.Text = grdTeachers.SelectedRows[0].Cells["Id"].Value.ToString();
                string[] names = grdTeachers.SelectedRows[0].Cells["FullName"].Value.ToString().Split(' ');
                txtLastName.Text = names.Last();
                txtFirstName.Text = names.First();
                txtAge.Text = grdTeachers.SelectedRows[0].Cells["Age"].Value.ToString();
            }
        }
        private void grdTeachers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Guid id = Guid.Parse(((DataGridView)sender).SelectedRows[0].Cells["Id"].Value.ToString());
                SecondForm frm = new SecondForm(_studentService);
                frm.TeacherInfo = _teacherService.Get(id);
                frm.Location = new System.Drawing.Point(this.Width + 100, 100);
                frm.Show();
                frm.Activate();
            }
        }
    }
}
