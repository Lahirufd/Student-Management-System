using System;
using System.Windows.Forms;
using Student_Management_System.Models;
using Student_Management_System.Services;

namespace Student_Management_System.Forms
{
    public partial class ManageDepartmentForm : Form
    {
        private readonly DepartmentService _departmentService;

        public ManageDepartmentForm()
        {
            InitializeComponent();

            // Initialize the service layer
            string connectionString = "Data Source=THADIYA;Initial Catalog=Student_Management;Integrated Security=True";
            _departmentService = new DepartmentService(connectionString);

            // Load department data when the form loads
            LoadDepartmentData();
        }

        // Method to load department data into the DataGridView
        private void LoadDepartmentData()
        {
            try
            {
                var departments = _departmentService.GetAllDepartments();
                dataGridView1.DataSource = departments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading department data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to validate inputs
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txt_number.Text))
            {
                MessageBox.Show("Department ID cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Department name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Method to clear inputs
        private void ClearInputs()
        {
            txt_number.Clear();
            comboBox1.Text = string.Empty;
        }

        // Clear Inputs Button Click Event
        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            MessageBox.Show("Inputs cleared!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Exit Button Click Event
        private void btn_exit_Click(object sender, EventArgs e)
        {
            new DashboardForm().Show();
            this.Close();
        }

        // Add Department Button Click Event
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    var department = new Department
                    {
                        DepartmentId = txt_number.Text,
                        DepartmentName = comboBox1.Text
                    };

                    _departmentService.AddDepartment(department);
                    LoadDepartmentData(); // Refresh the DataGridView
                    ClearInputs();
                    MessageBox.Show("Department added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Update Department Button Click Event
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    var department = new Department
                    {
                        DepartmentId = txt_number.Text,
                        DepartmentName = comboBox1.Text
                    };

                    _departmentService.UpdateDepartment(department);
                    LoadDepartmentData(); // Refresh the DataGridView
                    ClearInputs();
                    MessageBox.Show("Department updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Delete Department Button Click Event
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_number.Text))
            {
                MessageBox.Show("Department ID cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _departmentService.DeleteDepartment(txt_number.Text);
                LoadDepartmentData(); // Refresh the DataGridView
                ClearInputs();
                MessageBox.Show("Department deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            new DashboardForm().Show();
            this.Close();
        }

        private void btn_clear_Click_1(object sender, EventArgs e)
        {
            ClearInputs();
        }
    }
}