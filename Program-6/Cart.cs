/*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
* This program is an online order form for Caterina's Pizza.
* @version 1.0 2018-11-07
* @course: CMPS4143 Dr. Stringfellow
* @author Yujin Yoshimura
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caterinas_Pizza
{
    public partial class PlaceOrder : Form
    {

        public struct Pizza
        {
            public Pizza(string t, int q, decimal p)
            {
                type = t;
                qty = q;
                unitPrice = p;
            }
            public string type;
            public int qty;
            public decimal unitPrice;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Default constructor.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public PlaceOrder()
        {
            InitializeComponent();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Parameterized constructor.
        // @param: string, decimal
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public PlaceOrder(string t, decimal p)
        {
            InitializeComponent();
            Pizza newOrder = new Pizza(t, 1, p);
            cart.Add(newOrder);
            UpdateOrder();
            UpdatePrice();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Static constructor.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        static PlaceOrder()
        {
            cart = new List<Pizza>();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Displays each order in list format.
        // Dynamically creates controls.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public void UpdateOrder()
        {
            decimal price;
            types = new Label[cart.Count];
            qtys = new DomainUpDown[cart.Count];
            prices = new Label[cart.Count];

            for (int i = 0; i < cart.Count; i++)
            {
                // Dynamically create LabelType
                types[i] = new Label();
                types[i].Text = cart[i].type;
                types[i].Left = 10;
                types[i].Top = 25 + i * 30;
                types[i].Width = 180;
                types[i].Font = new System.Drawing.Font("Tahoma", 10F);
                this.groupBoxOrder.Controls.Add(types[i]);

                // Dynamically create DomainUpDownQty
                qtys[i] = new DomainUpDown();
                qtys[i].Text = cart[i].qty.ToString();
                qtys[i].Left = 200;
                qtys[i].Top = 25 + i * 30;
                qtys[i].Width = 80;
                qtys[i].Font = new System.Drawing.Font("Tahoma", 10F);
                InitializeDomainUpDown(qtys[i]);
                qtys[i].SelectedItemChanged += (s, e) =>
                {
                    UpdatePrice();
                };
                this.groupBoxOrder.Controls.Add(qtys[i]);

                // Dynamically create LabelPrice
                price = cart[i].qty * cart[i].unitPrice;
                prices[i] = new Label();
                prices[i].Text = "$" + price.ToString("F");
                prices[i].Left = 300;
                prices[i].Top = 25 + i * 30;
                prices[i].Font = new System.Drawing.Font("Tahoma", 10F);
                prices[i].MinimumSize = new System.Drawing.Size(60,0);
                prices[i].TextAlign = ContentAlignment.TopRight;
                this.groupBoxOrder.Controls.Add(prices[i]);
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Initializes content of the DomainUpDown, with choices 1-10.
        // @param: DomainUpDown
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public void InitializeDomainUpDown(DomainUpDown d)
        {
            for (int i = 10; i >= 1; i--)
            {
                d.Items.Add(i.ToString());
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Recalculate the price and display them correctly.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public void UpdatePrice()
        {
            decimal tax = (decimal)0.0825;
            decimal subtotal = 0;
            for (int i = 0; i < cart.Count; i++)
            {
                Pizza newOrder = new Pizza(cart[i].type,
                    Int32.Parse(qtys[i].Text), cart[i].unitPrice);
                cart[i] = newOrder;
                decimal newPrice = cart[i].qty * cart[i].unitPrice;
                prices[i].Text = "$" + newPrice.ToString("F");
                subtotal += newPrice;
            }
            labelSubtotalPrice.Text = "$" + subtotal.ToString("F");
            labelTaxPrice.Text = "$" + (subtotal * tax).ToString("F");
            labelTotalPrice.Text = "$" + (subtotal * (1 + tax)).ToString("F");
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Goes back to the order form.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonOrderMore_Click(object sender, EventArgs e)
        {
            CaterinasPizza j = new CaterinasPizza();
            j.Show();
            this.Visible = false;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Finalizes the order and exits the program.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you! \n Your pizza will arrive soon.",
                "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Visible = false;
            System.Windows.Forms.Application.Exit();
        }

        private static List<Pizza> cart;
        Label[] types;
        DomainUpDown[] qtys;
        Label[] prices;

    }
}
