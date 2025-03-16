using System;
using System.Windows.Forms;
using Student_Management_System.Services;

namespace Student_Management_System.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthenticationService _authService;

        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthenticationService();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;

            if (_authService.ValidateCredentials(username, password))
            {
                // Login successful
                new DashboardForm().Show();
                this.Hide();
            }
            else
            {
                // Login failed
                MessageBox.Show("The username or password you entered is incorrect, try again");
                txt_username.Clear();
                txt_password.Clear();
                txt_username.Focus();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            // Clear the textboxes
            txt_username.Clear();
            txt_password.Clear();
            txt_username.Focus();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            // Close the application
            this.Close();
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            // Optional: Handle password text change if needed
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            // Optional: Handle label click if needed
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Optional: Handle form closing if needed
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Optional: Handle form load if needed
        }
    }
}