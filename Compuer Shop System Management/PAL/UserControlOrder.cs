﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Computer;

namespace Compuer_Shop_System_Management.PAL
{
    public partial class UserControlOrder : UserControl
    {
        private string Id = "";
        public UserControlOrder()
        {
            InitializeComponent();
        }

        public void EmptyBox()
        {
            dtpDate.Value = DateTime.Now;
            txtCustomerName.Clear();
            mtbCustomerNumber.Clear();
            AddClear();
            dgvProductList.Rows.Clear();
            txtTotalAmount.Text = "0";
            nudPaidAmount.Value = 0;
            txtDueAmount.Text = "0";
            nudDiscount.Value = 0;
            txtGrandTotal.Text = "0";
            cmbPaymentStatus.SelectedIndex = 0;
        }
        private void AddClear()
        {
            cmbProduct.Items.Clear();
            cmbProduct.Items.Add("-- SELECT --");
            Computer.Computer.BrandCategoryProduct("SELECT Product_Name FROM Product WHERE Product_Status = 'Available' ORDER BY Product_Name;", cmbProduct);
            cmbProduct.SelectedIndex = 0;
            txtRate.Clear();
            nudQuantity.Value = 0;
            txtTotal.Clear();
        }
        private void EmptyBox1()
        {
            dtpDate1.Value = DateTime.Now;
            txtCustomerName1.Clear();
            mtbCustomerNumber1.Clear();
            txtTotalAmount1.Text = "0";
            nudPaidAmount1.Value = 0;
            txtDueAmount1.Text = "0";
            nudDiscount1.Value = 0;
            txtGrandTotal1.Text = "0";
            cmbPaymentStatus1.SelectedIndex = 0;
            Id = "";
        }

        RichTextBox richTextBox = new RichTextBox();

        private void Receipt()
        {
            richTextBox.Clear();
            richTextBox.Text += "\t\tCOMPUTER SHOP MANAAGEMENT SYSTEM\n";
            richTextBox.Text += "***********************************************************************************\n\n";
            richTextBox.Text += "   Date : " + dtpDate.Text + "\n";
            richTextBox.Text += "   Name : " + txtCustomerName.Text.Trim() + "\n\n";
            richTextBox.Text += "***********************************************************************************\n";
            richTextBox.Text += "Name\t\t\tRate\t\tQuantity\t\tTotal\n";
            for(int i = 0; i < dgvProductList.Rows.Count; i++)
            {
                for(int j = 0; j < dgvProductList.Columns.Count -1; j++)
                {
                    richTextBox.Text += dgvProductList.Rows[i].Cells[j].Value.ToString() + "\t\t";
                }
                richTextBox.Text += "\n";
            }
            richTextBox.Text += "***********************************************************************************\n\n";
            richTextBox.Text += "\t\t\t\t\t\tTotal                : $ " + txtTotalAmount.Text + "\n";
            richTextBox.Text += "\t\t\t\t\t\tPaid Amount   : $ " + nudPaidAmount.Text + "\n";
            richTextBox.Text += "\t\t\t\t\t\tDue Amount    : $ " + txtDueAmount.Text + "\n";
            richTextBox.Text += "\t\t\t\t\t\tDiscount          : $ " + nudDiscount.Text + "\n";
            richTextBox.Text += "\t\t\t\t\t\tGrand Total     : $ " + txtGrandTotal.Text + "\n";
        }

        double oTotal = 0;
        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnAdd, "Add");
        }

        private void picSearch_MouseHover(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(picSearch, "Search");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cmbProduct.SelectedIndex == 0)
            {
                MessageBox.Show("Please select product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nudQuantity.Value == 0)
            {
                MessageBox.Show("Please enter quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if(nudQuantity.Value > 0)
                {
                    double rate, total;
                    Double.TryParse(txtRate.Text, out rate);
                    Double.TryParse(txtTotal.Text, out total);
                    if(dgvProductList.Rows.Count != 0)
                    {
                        foreach(DataGridViewRow rows in dgvProductList.Rows)
                        {
                            if (rows.Cells[0].Value.ToString() == cmbProduct.SelectedItem.ToString())
                            {
                                int quantity = Convert.ToInt32(rows.Cells[2].Value.ToString());
                                double total1 = Convert.ToDouble(rows.Cells[3].Value.ToString());
                                quantity += Convert.ToInt32(nudQuantity.Value);
                                total1 += total;
                                rows.Cells[2].Value = quantity;
                                rows.Cells[3].Value = total1;
                                AddClear();
                            }
                        }
                        if (cmbProduct.SelectedIndex != 0)
                        {
                            txtTotal.Text = (rate * Convert.ToDouble(nudQuantity.Value)).ToString();
                            string[] row =
                            {
                                        cmbProduct.SelectedItem.ToString(), txtRate.Text, nudQuantity.Value.ToString(), txtTotal.Text
                                    };
                            dgvProductList.Rows.Add(row);
                            AddClear();
                        }
                    }
                    else
                    {
                        txtTotal.Text = (rate * Convert.ToDouble(nudQuantity.Value)).ToString();
                        string[] row =
                        {
                            cmbProduct.SelectedItem.ToString(), txtRate.Text, nudQuantity.Value.ToString(), txtTotal.Text
                        };
                        dgvProductList.Rows.Add(row);
                        AddClear();
                    }
                }
                txtTotalAmount.Text = oTotal.ToString();
            }
            foreach (DataGridViewRow rows in dgvProductList.Rows)
            {
                oTotal += Convert.ToDouble(rows.Cells[3].Value.ToString());
                txtTotalAmount.Text = oTotal.ToString();
            }
            oTotal = 0;
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rate = Computer.Computer.Rate(cmbProduct.SelectedItem.ToString());
            if(rate != string.Empty)
                txtRate.Text = rate;
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            double rate;
            Double.TryParse(txtRate.Text, out rate);
            txtTotal.Text = (rate * Convert.ToDouble(nudQuantity.Value)).ToString();
        }

        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                int rowIndex = dgvProductList.CurrentCell.RowIndex;
                dgvProductList.Rows.RemoveAt(rowIndex);
                if(dgvProductList.Rows.Count !=0)
                {
                    foreach(DataGridViewRow rows in dgvProductList.Rows)
                    {
                        oTotal += Convert.ToDouble(rows.Cells[3].Value.ToString());
                        txtTotalAmount.Text = oTotal.ToString();
                    }
                }
                else
                    txtTotalAmount.Text = "0";
                oTotal = 0;
            }
        }

        private void nudPaidAmount_ValueChanged(object sender, EventArgs e)
        {
            txtDueAmount.Text = (Convert.ToDouble(nudPaidAmount.Value) - Convert.ToDouble(txtTotalAmount.Text)).ToString();
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e)
        {
            txtGrandTotal.Text = (Convert.ToDouble(txtTotalAmount.Text) - Convert.ToDouble(nudDiscount.Value)).ToString();
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            nudPaidAmount_ValueChanged(sender, e);
            nudDiscount_ValueChanged(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCustomerName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter customer name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!mtbCustomerNumber.MaskCompleted)
            {
                MessageBox.Show("Please enter valid customer number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nudPaidAmount.Value == 0)
            {
                MessageBox.Show("Please enter paid amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbPaymentStatus.SelectedIndex == 0)
            {
                MessageBox.Show("Please select payment status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Order order = new Order(dtpDate.Value.Date, txtCustomerName.Text.Trim(), mtbCustomerNumber.Text, Convert.ToInt32(txtTotalAmount.Text), Convert.ToInt32(nudPaidAmount.Value), Convert.ToInt32(txtDueAmount.Text), Convert.ToInt32(nudDiscount.Value), Convert.ToInt32(txtGrandTotal.Text), cmbPaymentStatus.SelectedItem.ToString());
                Computer.Computer.SaveOrder(order);
                EmptyBox();
            }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            Receipt();
            printPreviewDialog.Document = printDocument;
            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 370, 600);
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox.Text, new Font("Segoe UI", 7, FontStyle.Regular), Brushes.Blue, new Point(10, 10));
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            nudQuantity_ValueChanged(sender , e);
        }

        private void tpManageOrders_Enter(object sender, EventArgs e)
        {
            txtSearchCustomerName.Clear();
            dgvOrders.Columns[0].Visible = false;
            Computer.Computer.DisplayAndSearch("SELECT * FROM Orders;", dgvOrders);
            lblTotal.Text = dgvOrders.Rows.Count.ToString();
        }

        private void txtSearchCustomerName_TextChanged(object sender, EventArgs e)
        {
            Computer.Computer.DisplayAndSearch("SELECT * FROM Orders WHERE Customer_Name LIKE '%" + txtSearchCustomerName.Text + "%';", dgvOrders);
            lblTotal.Text = dgvOrders.Rows.Count.ToString();
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];
                Id = row.Cells[0].Value.ToString();
                dtpDate1.Text = row.Cells[1].Value.ToString();
                txtCustomerName1.Text = row.Cells[2].Value.ToString();
                mtbCustomerNumber1.Text = row.Cells[3].Value.ToString();
                txtTotalAmount1.Text = row.Cells[4].Value.ToString();
                nudPaidAmount1.Value = Convert.ToInt32(row.Cells[5].Value.ToString());
                txtDueAmount1.Text = row.Cells[6].Value.ToString();
                nudDiscount1.Value = Convert.ToInt32(row.Cells[7].Value.ToString());
                txtGrandTotal1.Text = row.Cells[8].Value.ToString();
                cmbPaymentStatus1.SelectedItem = row.Cells[9].Value.ToString();
                tcOrders.SelectedTab = tpOptions;
            }
        }

        private void tpOptions_Enter(object sender, EventArgs e)
        {
            if(Id == "")
                tcOrders.SelectedTab = tpManageOrders;
        }

        private void tpOptions_Leave(object sender, EventArgs e)
        {
            EmptyBox1();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(Id == "")
            {
                MessageBox.Show("First select row from table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtCustomerName1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter customer name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!mtbCustomerNumber1.MaskCompleted)
            {
                MessageBox.Show("Please enter valid customer number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nudPaidAmount1.Value == 0)
            {
                MessageBox.Show("Please enter paid amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbPaymentStatus1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select payment status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Order order = new Order(dtpDate1.Value.Date, txtCustomerName1.Text.Trim(), mtbCustomerNumber1.Text, Convert.ToInt32(txtTotalAmount1.Text), Convert.ToInt32(nudPaidAmount1.Value), Convert.ToInt32(txtDueAmount1.Text), Convert.ToInt32(nudDiscount1.Value), Convert.ToInt32(txtGrandTotal1.Text), cmbPaymentStatus1.SelectedItem.ToString());
                Computer.Computer.ChangeOrder(order, Id);
                EmptyBox1();
                tcOrders.SelectedTab = tpManageOrders;
            }
        }

        private void tpAddOrders_Enter(object sender, EventArgs e)
        {
            EmptyBox();
        }

        private void nudPaidAmount1_ValueChanged(object sender, EventArgs e)
        {
            txtDueAmount1.Text = (Convert.ToDouble(nudPaidAmount1.Value) - Convert.ToDouble(txtTotalAmount1.Text)).ToString();
        }

        private void nudDiscount1_ValueChanged(object sender, EventArgs e)
        {
            txtGrandTotal1.Text = (Convert.ToDouble(txtTotalAmount1.Text) - Convert.ToDouble(nudDiscount1.Value)).ToString();
        }

        private void txtTotalAmount1_TextChanged(object sender, EventArgs e)
        {
            nudPaidAmount1_ValueChanged(sender, e);
            nudDiscount1_ValueChanged(sender, e);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (Id == "")
            {
                MessageBox.Show("First select row from table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtCustomerName1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter customer name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!mtbCustomerNumber1.MaskCompleted)
            {
                MessageBox.Show("Please enter valid customer number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nudPaidAmount1.Value == 0)
            {
                MessageBox.Show("Please enter paid amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbPaymentStatus1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select payment status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you want to delete this order?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Computer.Computer.RemoveOrder(Id);
                    EmptyBox1();
                    tcOrders.SelectedTab = tpManageOrders;
                }
            }
        }
    }
}
