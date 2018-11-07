namespace Caterinas_Pizza
{
    partial class PlaceOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelTaxPrice = new System.Windows.Forms.Label();
            this.labelTax = new System.Windows.Forms.Label();
            this.labelSubtotalPrice = new System.Windows.Forms.Label();
            this.labelSubtotal = new System.Windows.Forms.Label();
            this.buttonOrderMore = new System.Windows.Forms.Button();
            this.buttonPlaceOrder = new System.Windows.Forms.Button();
            this.groupBoxOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Controls.Add(this.labelTotalPrice);
            this.groupBoxOrder.Controls.Add(this.labelTotal);
            this.groupBoxOrder.Controls.Add(this.labelTaxPrice);
            this.groupBoxOrder.Controls.Add(this.labelTax);
            this.groupBoxOrder.Controls.Add(this.labelSubtotalPrice);
            this.groupBoxOrder.Controls.Add(this.labelSubtotal);
            this.groupBoxOrder.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupBoxOrder.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(410, 390);
            this.groupBoxOrder.TabIndex = 8;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "Your Order:";
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPrice.Location = new System.Drawing.Point(340, 360);
            this.labelTotalPrice.MinimumSize = new System.Drawing.Size(60, 0);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(60, 19);
            this.labelTotalPrice.TabIndex = 5;
            this.labelTotalPrice.Text = "Price";
            this.labelTotalPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(10, 360);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(52, 19);
            this.labelTotal.TabIndex = 4;
            this.labelTotal.Text = "Total";
            // 
            // labelTaxPrice
            // 
            this.labelTaxPrice.AutoSize = true;
            this.labelTaxPrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaxPrice.Location = new System.Drawing.Point(340, 325);
            this.labelTaxPrice.MinimumSize = new System.Drawing.Size(60, 0);
            this.labelTaxPrice.Name = "labelTaxPrice";
            this.labelTaxPrice.Size = new System.Drawing.Size(60, 19);
            this.labelTaxPrice.TabIndex = 3;
            this.labelTaxPrice.Text = "Price";
            this.labelTaxPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTax
            // 
            this.labelTax.AutoSize = true;
            this.labelTax.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTax.Location = new System.Drawing.Point(10, 325);
            this.labelTax.Name = "labelTax";
            this.labelTax.Size = new System.Drawing.Size(35, 19);
            this.labelTax.TabIndex = 2;
            this.labelTax.Text = "Tax";
            // 
            // labelSubtotalPrice
            // 
            this.labelSubtotalPrice.AutoSize = true;
            this.labelSubtotalPrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtotalPrice.Location = new System.Drawing.Point(340, 300);
            this.labelSubtotalPrice.MinimumSize = new System.Drawing.Size(60, 0);
            this.labelSubtotalPrice.Name = "labelSubtotalPrice";
            this.labelSubtotalPrice.Size = new System.Drawing.Size(60, 19);
            this.labelSubtotalPrice.TabIndex = 1;
            this.labelSubtotalPrice.Text = "Price";
            this.labelSubtotalPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelSubtotal
            // 
            this.labelSubtotal.AutoSize = true;
            this.labelSubtotal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtotal.Location = new System.Drawing.Point(10, 300);
            this.labelSubtotal.Name = "labelSubtotal";
            this.labelSubtotal.Size = new System.Drawing.Size(67, 19);
            this.labelSubtotal.TabIndex = 0;
            this.labelSubtotal.Text = "Subtotal";
            // 
            // buttonOrderMore
            // 
            this.buttonOrderMore.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOrderMore.Location = new System.Drawing.Point(10, 410);
            this.buttonOrderMore.Name = "buttonOrderMore";
            this.buttonOrderMore.Size = new System.Drawing.Size(150, 50);
            this.buttonOrderMore.TabIndex = 9;
            this.buttonOrderMore.Text = "Order More";
            this.buttonOrderMore.UseVisualStyleBackColor = true;
            this.buttonOrderMore.Click += new System.EventHandler(this.buttonOrderMore_Click);
            // 
            // buttonPlaceOrder
            // 
            this.buttonPlaceOrder.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlaceOrder.Location = new System.Drawing.Point(272, 410);
            this.buttonPlaceOrder.Name = "buttonPlaceOrder";
            this.buttonPlaceOrder.Size = new System.Drawing.Size(150, 50);
            this.buttonPlaceOrder.TabIndex = 10;
            this.buttonPlaceOrder.Text = "Place Order";
            this.buttonPlaceOrder.UseVisualStyleBackColor = true;
            this.buttonPlaceOrder.Click += new System.EventHandler(this.buttonPlaceOrder_Click);
            // 
            // PlaceOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 472);
            this.Controls.Add(this.buttonPlaceOrder);
            this.Controls.Add(this.buttonOrderMore);
            this.Controls.Add(this.groupBoxOrder);
            this.Name = "PlaceOrder";
            this.Text = "Cart";
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOrder;
        private System.Windows.Forms.Button buttonOrderMore;
        private System.Windows.Forms.Label labelSubtotal;
        private System.Windows.Forms.Label labelSubtotalPrice;
        private System.Windows.Forms.Label labelTaxPrice;
        private System.Windows.Forms.Label labelTax;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonPlaceOrder;
    }
}