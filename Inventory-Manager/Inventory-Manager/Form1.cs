using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Manager
{

    //public class Item
    //{   
    //    public int qty { get; set; }
    //    public int price { get; set; }
    //    public int name { get; set; }
    //    public int sku { get; set; }
    //}

    public partial class Form1 : Form
    {

        
        DataTable inventory = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            char[] strOne, strTwo = new char[5];
            //add columns to out datatable
            inventory.Columns.Add("SKU");
            inventory.Columns.Add("Name");
            inventory.Columns.Add("Price");
            inventory.Columns.Add("Quantity");

            //connect gridview to our datatable
            inventoryGridView.DataSource = inventory;

        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            //clear all text boxes
            skuBox.Text = "";
            nameBox.Text = "";
            qtyBox.Text = "";
            priceBox.Text = "";



        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //save text box entries to variables
            string sku = skuBox.Text;
            string name = nameBox.Text;
            string qty = qtyBox.Text;
            string price = priceBox.Text;

            //add values to datatable
            inventory.Rows.Add(sku, name, price, qty);
            //clears fields after saving
            newBtn_Click(sender, e); 
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                inventory.Rows[inventoryGridView.CurrentCell.RowIndex].Delete();

            }
            catch (Exception err)
            {
                Console.WriteLine("Error: " + err);
                throw;
            }
            //deleted selected row item
            inventory.Rows[inventoryGridView.CurrentCell.RowIndex].Delete();
        }

        private void inventoryGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                skuBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
                nameBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
                qtyBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[2].ToString();
                priceBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
