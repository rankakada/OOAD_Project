using Computer;
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
    public partial class UserControlDashboard : UserControl
    {
        public UserControlDashboard()
        {
            InitializeComponent();
        }

        public void Count()
        {
            lblTotalProduct.Text = Computer.Computer.Count("SELECT COUNT(*) FROM Product;").ToString();
            lblTotalOrders.Text = Computer.Computer.Count("SELECT COUNT(*) FROM Orders WHERE Payment_Status = 'Not Paid';").ToString();
            lblOutStock.Text = Computer.Computer.Count("SELECT COUNT(*) FROM Product WHERE Product_Status = 'Not Available';").ToString();
            lblTotalRevenue.Text = Computer.Computer.Count("SELECT SUM(Grand_Total) FROM Orders;").ToString() ;
        }

        private void UserControlDashboard_Load(object sender, EventArgs e)
        {
            Count();
        }
    }
}
