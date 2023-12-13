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
    public partial class MainForm : Form
    {
        public string name = "{?}";
        public MainForm()
        {
            InitializeComponent();
        }
        private void MovePanel(Control btn)
        {
            pnlMove.Top = btn.Top;
            pnlMove.Height = btn.Height;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUsername.Text = name;
            timerDateTime.Start();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you want to log out?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (dialogResult == DialogResult.Yes)
                {
                    MovePanel(btnLogOut);
                    timerDateTime.Stop();
                    Close();
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MovePanel(btnDashboard);
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = false;
            userControlReport1.Visible = false;
            userControlUser1.Visible = false;
            userControlDashboard1.Visible = true;
            userControlDashboard1.Count();
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            MovePanel(btnBrand);
            userControlDashboard1.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = false;
            userControlReport1.Visible = false;
            userControlUser1.Visible = false;
            userControlBrand1.EmptyBox();
            userControlBrand1.Visible = true;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            MovePanel(btnCategory);
            userControlDashboard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = false;
            userControlReport1.Visible = false;
            userControlUser1.Visible = false;
            userControlCategory1.EmptyBox();
            userControlCategory1.Visible = true;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            MovePanel(btnProduct);
            userControlDashboard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
            userControlOrder1.Visible = false;
            userControlReport1.Visible = false;
            userControlUser1.Visible = false;
            userControlProduct1.EmptyBox();
            userControlProduct1.Visible = true;
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            MovePanel(btnOrders);
            userControlDashboard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlReport1.Visible = false;
            userControlUser1.Visible = false;
            userControlOrder1.EmptyBox();
            userControlOrder1.Visible = true;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            MovePanel(btnReport);
            userControlDashboard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = false;
            userControlUser1.Visible = false;
            userControlReport1.Visible = true;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            MovePanel(btnUsers);
            userControlDashboard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = false;
            userControlReport1.Visible = false;
            userControlUser1.EmptyBox();
            userControlUser1.Visible = true;
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd-MMMM-yyyy hh:mm:ss tt");
        }

        private void userControlDashboard1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlMove_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblDateTime_Click(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userControlUser1_Load(object sender, EventArgs e)
        {

        }
    }
}
