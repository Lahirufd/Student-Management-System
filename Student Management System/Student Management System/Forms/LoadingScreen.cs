using System;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Student_Management_System.Forms
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            // Start the timer when the form loads
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Update the progress bar and label
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
                label1.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                // Stop the timer when the progress bar reaches 100%
                timer1.Stop();

                // Hide the loading screen
                this.Hide();

                // Show the login form
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle picture box click event (if needed)
        }
    }
}