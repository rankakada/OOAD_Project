using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compuer_Shop_System_Management.PAL
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void EmptyBox()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picShow_Click(object sender, EventArgs e)
        {
            if (picShow.Visible == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                picShow.Visible = false;
                picHide.Visible = true;
            }
        }

        private void picHide_Click(object sender, EventArgs e)
        {
            if (picHide.Visible == true)
            {
                txtPassword.UseSystemPasswordChar = true;
                picShow.Visible = true;
                picHide.Visible = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter username.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                bool check = Computer.Computer.IsValidNamePass(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                if (check)
                {
                    MainForm mainForm = new MainForm();
                    mainForm.name = txtUsername.Text;
                    mainForm.ShowDialog();
                    EmptyBox();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lblForgorPassword_Click(object sender, EventArgs e)
        {
            ForgotPasswordForm forgetPasswordForm = new ForgotPasswordForm();
            forgetPasswordForm.ShowDialog();
        }
    }
}
