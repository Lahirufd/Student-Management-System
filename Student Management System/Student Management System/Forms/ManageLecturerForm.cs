using System;
using System.Windows.Forms;
using Student_Management_System.Models;
using Student_Management_System.Services;

namespace Student_Management_System.Forms
{
    public partial class ManageLecturerForm : Form
    {
        private readonly LecturerService _lecturerService;

        public ManageLecturerForm()
        {
            InitializeComponent();

            // Initialize the service layer
            string connectionString = "Data Source=THADIYA;Initial Catalog=Student_Management;Integrated Security=True";
            _lecturerService = new LecturerService(connectionString);

            // Load lecturer data when the form loads
            LoadLecturerData();
        }

        // Method to load lecturer data into the DataGridView
        private void LoadLecturerData()
        {
            try
            {
                var lecturers = _lecturerService.GetAllLecturers();
                dataGridView1.DataSource = lecturers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading lecturer data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add Lecturer Button Click Event
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    var lecturer = new Lecturer
                    {
                        LecturerId = txt_id.Text,
                        Name = txt_name.Text,
                        Phone = txt_phone.TextLength,
                        Department = comboBox2.Text
                    };

                    _lecturerService.AddLecturer(lecturer);
                    LoadLecturerData(); // Refresh the DataGridView
                    ClearInputs();
                    MessageBox.Show("Lecturer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding lecturer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Update Lecturer Button Click Event
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    var lecturer = new Lecturer
                    {
                        LecturerId = txt_id.Text,
                        Name = txt_name.Text,
                        Phone = txt_phone.TextLength,
                        Department = comboBox2.Text
                    };

                    _lecturerService.UpdateLecturer(lecturer);
                    LoadLecturerData(); // Refresh the DataGridView
                    ClearInputs();
                    MessageBox.Show("Lecturer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating lecturer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Delete Lecturer Button Click Event
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_id.Text))
            {
                MessageBox.Show("Lecturer ID cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _lecturerService.DeleteLecturer(txt_id.Text);
                LoadLecturerData(); // Refresh the DataGridView
                ClearInputs();
                MessageBox.Show("Lecturer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting lecturer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to validate inputs
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txt_id.Text))
            {
                MessageBox.Show("Lecturer ID cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                MessageBox.Show("Lecturer name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txt_phone.Text))
            {
                MessageBox.Show("Phone number cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txt_phone.Clear();
            comboBox2.Text = string.Empty;
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

        private void btn_clear_Click_1(object sender, EventArgs e)
        {
            ClearInputs();
        }
    }
}