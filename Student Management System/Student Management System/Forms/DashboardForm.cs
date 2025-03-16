using System;
using System.Windows.Forms;
using Student_Management_System.Services;

namespace Student_Management_System.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly DashboardService _dashboardService;

        public DashboardForm()
        {
            InitializeComponent();

            // Initialize the service layer
            _dashboardService = new DashboardService();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Load data when the form loads
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                // Fetch data using the service layer
                label14.Text = _dashboardService.GetStudentCount().ToString();
                label15.Text = _dashboardService.GetDepartmentCount().ToString();
                label20.Text = _dashboardService.GetLecturerCount().ToString();
                label16.Text = _dashboardService.GetMaleStudentCount().ToString();
                label17.Text = _dashboardService.GetFemaleStudentCount().ToString();
            }
            catch (Exception ex)
            {
                // Handle errors
                MessageBox.Show($"Error loading dashboard data: {ex.Message}");
            }
        }

        private void btn_students_Click(object sender, EventArgs e)
        {
            // Open the ManageStudentForm
            this.Close();
            ManageStudentForm obj = new ManageStudentForm();
            obj.ShowDialog();
        }

        private void btn_department_Click(object sender, EventArgs e)
        {
            // Open the ManageDepartmentForm
            this.Close();
            ManageDepartmentForm obj = new ManageDepartmentForm();
            obj.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Open the LecturerForm
            this.Close();
            ManageLecturerForm obj = new ManageLecturerForm();
            obj.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Close the form
            new LoginForm().Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle picture box click event (if needed)
        }

        private void DashboardForm_Load_1(object sender, EventArgs e)
        {
            // Handle additional load logic (if needed)
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            // Handle picture box click event (if needed)
        }
    }
}