using System;
using System.Windows.Forms;
using Student_Management_System.Models;
using Student_Management_System.Services;

namespace Student_Management_System.Forms
{
    public partial class ManageStudentForm : Form
    {
        private readonly StudentService _studentService;

        public ManageStudentForm()
        {
            InitializeComponent();

            // Initialize the service layer
            string connectionString = "Data Source=THADIYA;Initial Catalog=Student_Management;Integrated Security=True";
            _studentService = new StudentService(connectionString);

            // Load student data when the form loads
            LoadStudentData();
        }

        // Method to load student data into the DataGridView
        private void LoadStudentData()
        {
            try
            {
                var students = _studentService.GetAllStudents();
                dataGridView1.DataSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading student data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add Student Button Click Event
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    var student = new Student
                    {
                        StudentId = txt_id.Text,
                        Name = txt_name.Text,
                        Gender = comboBox1.Text,
                        Phone = Convert.ToInt32(txt_phone.Text),
                        Address = txt_address.Text,
                        Department = comboBox2.Text
                    };

                    _studentService.AddStudent(student);
                    LoadStudentData(); // Refresh the DataGridView
                    ClearInputs();
                    MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Update Student Button Click Event
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    var student = new Student
                    {
                        StudentId = txt_id.Text,
                        Name = txt_name.Text,
                        Gender = comboBox1.Text,
                        Phone = Convert.ToInt32(txt_phone.Text),
                        Address = txt_address.Text,
                        Department = comboBox2.Text
                    };

                    _studentService.UpdateStudent(student);
                    LoadStudentData(); // Refresh the DataGridView
                    ClearInputs();
                    MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Delete Student Button Click Event
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_id.Text))
            {
                MessageBox.Show("Student ID cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _studentService.DeleteStudent(txt_id.Text);
                LoadStudentData(); // Refresh the DataGridView
                ClearInputs();
                MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to validate inputs
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txt_id.Text))
            {
                MessageBox.Show("Student ID cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                MessageBox.Show("Student name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Gender cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txt_phone.Text))
            {
                MessageBox.Show("Phone number cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txt_address.Text))
            {
                MessageBox.Show("Address cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Department cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Method to clear inputs
        private void ClearInputs()
        {
            txt_id.Clear();
            txt_name.Clear();
            comboBox1.Text = string.Empty;
            txt_phone.Clear();
            txt_address.Clear();
            comboBox2.Text = string.Empty;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            new DashboardForm().Show();
            this.Close();
        }
    }
}