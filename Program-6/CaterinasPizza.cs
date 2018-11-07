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
    public partial class CaterinasPizza : Form
    {
        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Default constructor.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public CaterinasPizza()
        {
            InitializeComponent();
            InitializePizza();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Resets the form.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void InitializePizza()
        {
            size = 0;
            pizzaDrawn = false;
            pizzaSize = new Rectangle();
            labelType.Text = "";
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Updates all the components of the form.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void UpdateAll()
        {
            DrawPizza();
            DrawToppings();
            UpdateCheckAll();
            UpdatePrice();
            UpdateCheckOut();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Draws pizza according to the order.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DrawPizza()
        {
            if (pizzaDrawn)
            {
                pizza.Clear(Color.WhiteSmoke);
                pizzaDrawn = false;
            }
            if (size > 0)
            {
                setPizzaSize();
                pizza = pictureBoxPizza.CreateGraphics();
                SolidBrush brush = new SolidBrush(Color.Wheat);
                pizza.FillEllipse(brush, pizzaSize);
                pizzaDrawn = true;
                DrawSauce();
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Sets the size of pizza to be drawn.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void setPizzaSize()
        {
            pizzaSize.X = 160 - size * 15;
            pizzaSize.Y = 60 - size * 10;
            pizzaSize.Width = 120 + size * 30;
            pizzaSize.Height = 80 + size * 20;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Draws sauce on top of pizza according to the order.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DrawSauce()
        {
            if (size > 0)
            {
                Rectangle sauceSize = pizzaSize;
                sauceSize.X = pizzaSize.X + 15;
                sauceSize.Y = pizzaSize.Y + 10;
                sauceSize.Width = pizzaSize.Width - 30;
                sauceSize.Height = pizzaSize.Height - 20;
                SolidBrush brush;
                if (radioButtonSauceAlfredo.Checked)
                    brush = new SolidBrush(Color.Beige);
                else if (radioButtonSauceTomato.Checked)
                    brush = new SolidBrush(Color.Tomato);
                else
                    brush = new SolidBrush(Color.Wheat);
                pizza.FillEllipse(brush, sauceSize);
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Draws all toppings on top of pizza according to the order.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DrawToppings()
        {
            if (size > 0)
            {
                DrawParmesan('l');
                DrawParmesan('r');
                DrawMozzarella('l');
                DrawMozzarella('r');
                DrawSausage('l');
                DrawSausage('r');
                DrawBacon('l');
                DrawBacon('r');
                DrawSalami('l');
                DrawSalami('r');
                DrawTomato('l');
                DrawTomato('r');
                DrawSpinach('l');
                DrawSpinach('r');
                DrawOlive('l');
                DrawOlive('r');
                DrawPineapple('l');
                DrawPineapple('r');
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Draws sausages if ordered.
        // @param: char
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DrawSausage(char direction)
        {
            if ((direction == 'l')? checkBoxSausageL.Checked : 
                checkBoxSausageR.Checked)
            {
                RectangleF[] sausages = new RectangleF[size + 2];
                SolidBrush brush = new SolidBrush(Color.BurlyWood);
                for (int i = 0; i < size + 2; i++)
                {
                    int p = Math.Abs(size + 1 - i * 2)*12 + 8;
                    sausages[i].X = (direction == 'l')? 214 - p : 214 + p;
                    sausages[i].Y = pizzaSize.Y + i * 20 + 24;
                    sausages[i].Width = 12;
                    sausages[i].Height = 12;
                }
                pizza.FillRectangles(brush, sausages);
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Draws bacons if ordered.
        // @param: char
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DrawBacon(char direction)
        {
            if ((direction == 'l') ? checkBoxBaconL.Checked :
                checkBoxBaconR.Checked)
            {
                RectangleF[] bacons = new RectangleF[6];
                SolidBrush brush = new SolidBrush(Color.Coral);
                for (int i = 0; i < 6; i++)
                {
                    int p = (int)Math.Pow(Math.Abs(5 - i * 2) - 2.5, 2) * -6
                        + 30 + size * 8;
                    int x = (direction == 'l') ? 218 - p : 222 + p;
                    int y = 85 + i * (5 + size * 3) - size * 7;
                    pizza.TranslateTransform(x, y);
                    bacons[i].Width = 24 + size * 4;
                    bacons[i].Height = 3 + size;
                    bacons[i].X = bacons[i].Width / -2;
                    bacons[i].Y = bacons[i].Height / -2;
                    if ((direction == 'l') ? i % 2 == 0 : i % 2 == 1)
                        pizza.RotateTransform(20.0F);
                    else
                        pizza.RotateTransform(160.0F);
                    pizza.FillRectangle(brush, bacons[i]);
                    if ((direction == 'l') ? i % 2 == 0 : i % 2 == 1)
                        pizza.RotateTransform(340.0F);
                    else
                        pizza.RotateTransform(200.0F);
                    pizza.TranslateTransform(-x, -y);
                }
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Draws salamis if ordered.
        // @param: char
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DrawSalami(char direction)
        {
            if ((direction == 'l') ? checkBoxSalamiL.Checked :
                checkBoxSalamiR.Checked)
            {
                RectangleF[] salamis = new RectangleF[3];
                SolidBrush brush = new SolidBrush(Color.IndianRed);
                for (int i = 0; i < 3; i++)
                {
                    int p = (i == 1) ? size * 15 + 35 : size * 3 + 15;
                    salamis[i].X = (direction == 'l') ? 205 - p : 205 + p;
                    salamis[i].Y = pizzaSize.Y + i * (18 + size * 10) + 12;
                    salamis[i].Width = 30;
                    salamis[i].Height = 20;
                    pizza.FillEllipse(brush, salamis[i]);
                }
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Draws tomatoes if ordered.
        // @param: char
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DrawTomato(char direction)
        {
            if ((direction == 'l') ? checkBoxTomatoL.Checked :
                checkBoxTomatoR.Checked)
            {
                RectangleF[] tomatoes = new RectangleF[4];
                SolidBrush brush = new SolidBrush(Color.OrangeRed);
                for (int i = 0; i < 4; i++)
                {
                    int p = 50 - Math.Abs(3 - i * 2) * 18 + size * 15;
                    tomatoes[i].X = (direction == 'l') ? 208 - p : 208 + p;
                    tomatoes[i].Y = pizzaSize.Y + i * (12 + size * 6) + 16
                        + size * 1;
                    tomatoes[i].Width = 24;
                    tomatoes[i].Height = 16;
                    pizza.FillEllipse(brush, tomatoes[i]);
                }
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Draws spinaches if ordered.
        // @param: char
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DrawSpinach(char direction)
        {
            if ((direction == 'l') ? checkBoxSpinachL.Checked :
                checkBoxSpinachR.Checked)
            {
                RectangleF[] spinaches = new RectangleF[6];
                SolidBrush brush = new SolidBrush(Color.DarkGreen);
                for (int i = 0; i < 6; i++)
                {
                    int p = (int)Math.Pow(Math.Abs(5 - i * 2) - 3.5, 2) * -6
                        + 30 + size * 8;
                    int x = (direction == 'l') ? 218 - p : 222 + p;
                    int y = 85 + i * (5 + size * 3) - size * 7;
                    pizza.TranslateTransform(x, y);
                    spinaches[i].Width = 24 + size * 4;
                    spinaches[i].Height = 3 + size;
                    spinaches[i].X = spinaches[i].Width / -2;
                    spinaches[i].Y = spinaches[i].Height / -2;
                    if ((direction == 'l') ? i % 2 == 0 : i % 2 == 1)
                        pizza.RotateTransform(170.0F);
                    else
                        pizza.RotateTransform(10.0F);
                    pizza.FillRectangle(brush, spinaches[i]);
                    if ((direction == 'l') ? i % 2 == 0 : i % 2 == 1)
                        pizza.RotateTransform(190.0F);
                    else
                        pizza.RotateTransform(350.0F);
                    pizza.TranslateTransform(-x, -y);
                }
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Draws olives if ordered.
        // @param: char
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DrawOlive(char direction)
        {
            if ((direction == 'l') ? checkBoxOliveL.Checked :
                checkBoxOliveR.Checked)
            {
                RectangleF[] olives = new RectangleF[3];
                SolidBrush brush = new SolidBrush(Color.DarkOliveGreen);
                for (int i = 0; i < 3; i++)
                {
                    int p = (i == 1) ? size * 10 + 20 : size * 2 + 10;
                    olives[i].X = (direction == 'l') ? 217 - p : 217 + p;
                    olives[i].Y = pizzaSize.Y + i * (9 + size * 5) + 27
                        + size * 5;
                    olives[i].Width = 8;
                    olives[i].Height = 8;
                    pizza.FillEllipse(brush, olives[i]);
                }
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Draws pineapples if ordered.
        // @param: char
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DrawPineapple(char direction)
        {
            if ((direction == 'l') ? checkBoxPineappleL.Checked :
                checkBoxPineappleR.Checked)
            {
                RectangleF[] sausages = new RectangleF[size + 1];
                SolidBrush brush = new SolidBrush(Color.Yellow);
                for (int i = 0; i < size + 1; i++)
                {
                    int p = (int)Math.Pow(4 - Math.Abs(size - i * 2), 2) * 3
                        + (size - 1) * 10;
                    sausages[i].X = (direction == 'l') ? 214 - p: 214 + p;
                    sausages[i].Y = pizzaSize.Y + i * 20 + 34;
                    sausages[i].Width = 12;
                    sausages[i].Height = 12;
                }
                pizza.FillRectangles(brush, sausages);
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Draws mozzarellas if ordered.
        // @param: char
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DrawMozzarella(char direction)
        {
            if ((direction == 'l') ? checkBoxMozzarellaL.Checked :
                checkBoxMozzarellaR.Checked)
            {
                RectangleF[] mozzarellas = new RectangleF[8];
                SolidBrush brush = new SolidBrush(Color.LightGoldenrodYellow);
                for (int i = 0; i < 8; i++)
                {
                    int p = (int)Math.Pow(Math.Abs(7 - i * 2) - 3.5, 2)
                        * (-1 - size) + 30 + size * 10;
                    int x = (direction == 'l') ? 218 - p : 222 + p;
                    int y = 83 + i * (5 + size * 2) - size * 7;
                    pizza.TranslateTransform(x, y);
                    mozzarellas[i].Width = 3 + size;
                    mozzarellas[i].Height = 24 + size * 4;
                    mozzarellas[i].X = mozzarellas[i].Width / -2;
                    mozzarellas[i].Y = mozzarellas[i].Height / -2;
                    if ((direction == 'l') ? i % 2 == 0 : i % 2 == 1)
                        pizza.RotateTransform(150.0F);
                    else
                        pizza.RotateTransform(30.0F);
                    pizza.FillRectangle(brush, mozzarellas[i]);
                    if ((direction == 'l') ? i % 2 == 0 : i % 2 == 1)
                        pizza.RotateTransform(210.0F);
                    else
                        pizza.RotateTransform(330.0F);
                    pizza.TranslateTransform(-x, -y);
                }
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Draws parmesans if ordered.
        // @param: char
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DrawParmesan(char direction)
        {
            if ((direction == 'l') ? checkBoxParmesanL.Checked :
                checkBoxParmesanR.Checked)
            {
                RectangleF[] parmesans = new RectangleF[size * 2];
                SolidBrush brush = new SolidBrush(Color.Gold);
                for (int i = 0; i < size * 2; i++)
                {
                    int p = (int)Math.Pow(Math.Abs(5 - i * 2) - size - 0.5, 2)
                        * -6 + 50 + size * 8;
                    parmesans[i].X = (direction == 'l') ? 214 - p : 214 + p;
                    parmesans[i].Y = 90 + i * (20 - size * 2) - size * 8;
                    parmesans[i].Width = 12;
                    parmesans[i].Height = 8;
                    pizza.FillEllipse(brush, parmesans[i]);
                }
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Disables "Build my own pizza" feature when specialties are selected.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void DisableBuild()
        {
            Disable(groupBoxSauce, buttonSauceClear);
            Disable(groupBoxMeatLeft, buttonMeatLeftClear);
            Disable(groupBoxMeatRight, buttonMeatRightClear);
            Disable(groupBoxVeggieLeft, buttonVeggieLeftClear);
            Disable(groupBoxVeggieRight, buttonVeggieRightClear);
            Disable(groupBoxCheeseLeft, buttonCheeseLeftClear);
            Disable(groupBoxCheeseRight, buttonCheeseRightClear);
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Disables a particular GroupBox and clear Button with respect to it.
        // @param: GroupBox, Button
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void Disable(GroupBox group, Button clear)
        {
            group.Enabled = false;
            foreach (Control ctrl in group.Controls)
            {
                ctrl.Enabled = false;
            }
            clear.Enabled = false;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Enables "Build my own pizza" feature when specialties are selected.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void EnableBuild()
        {
            Enable(groupBoxSauce, buttonSauceClear);
            Enable(groupBoxMeatLeft, buttonMeatLeftClear);
            Enable(groupBoxMeatRight, buttonMeatRightClear);
            Enable(groupBoxVeggieLeft, buttonVeggieLeftClear);
            Enable(groupBoxVeggieRight, buttonVeggieRightClear);
            Enable(groupBoxCheeseLeft, buttonCheeseLeftClear);
            Enable(groupBoxCheeseRight, buttonCheeseRightClear);
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Enables a particular GroupBox and clear Button with respect to it.
        // @param: GroupBox, Button
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void Enable(GroupBox group, Button clear)
        {
            group.Enabled = true;
            foreach (Control ctrl in group.Controls)
            {
                ctrl.Enabled = true;
            }
            clear.Enabled = true;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Updates all the Clear buttons which can also act as CheckAll button.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void UpdateCheckAll()
        {
            UpdateClear(groupBoxMeatLeft, buttonMeatLeftClear);
            UpdateClear(groupBoxMeatRight, buttonMeatRightClear);
            UpdateClear(groupBoxVeggieLeft, buttonVeggieLeftClear);
            UpdateClear(groupBoxVeggieRight, buttonVeggieRightClear);
            UpdateClear(groupBoxCheeseLeft, buttonCheeseLeftClear);
            UpdateClear(groupBoxCheeseRight, buttonCheeseRightClear);
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Updates a clear button according to the status of the respective
        // GroupBox.
        // @param: GroupBox, Button
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void UpdateClear(GroupBox group, Button clear)
        {
            if (!CheckedAny(group))
                clear.Text = "Check All";
            else
                clear.Text = "Clear";
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Checks whether any of the control in the GroupBox has been checked.
        // @param: GroupBox
        // @return: bool
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private bool CheckedAny(GroupBox group)
        {
            bool any = false;
            foreach (Control ctrl in group.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton radio = (RadioButton)ctrl;
                    if (radio.Checked)
                        any = true;
                }
                else if (ctrl is CheckBox)
                {
                    CheckBox check = (CheckBox)ctrl;
                    if (check.Checked)
                        any = true;
                }
            }
            return any;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Automatically switches CheckAll button and Clear Button, according
        // to the status of the respective GroupBox.
        // @param: GroupBox
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void CheckAllOrClear(GroupBox group)
        {
            if (!CheckedAny(group))
                CheckAll(group);
            else
                Clear(group);
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Checks all the Checkboxes in the given GroupBox.
        // @param: GroupBox
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void CheckAll(GroupBox group)
        {
            foreach (Control ctrl in group.Controls)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox check = (CheckBox)ctrl;
                    check.Checked = true;
                }
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Clears all the Checkboxes or Radio buttons in the given GroupBox.
        // @param: GroupBox
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void Clear(GroupBox group)
        {
            foreach (Control ctrl in group.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton radio = (RadioButton)ctrl;
                    radio.Checked = false;
                }
                else if (ctrl is CheckBox)
                {
                    CheckBox check = (CheckBox)ctrl;
                    check.Checked = false;
                }
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Selects previous tab.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void PreviousTab()
        {
            tabControlOrder.SelectedIndex = tabControlOrder.SelectedIndex - 1;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Selects next tab.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void NextTab()
        {
            tabControlOrder.SelectedIndex = tabControlOrder.SelectedIndex + 1;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Updates information in the "Your Order" GroupBox.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void UpdatePrice()
        {
            decimal tax = (decimal)0.0825;
            switch (size)
            {
                case 1:
                    UpdateBasePrice(radioButtonSizePersonal);
                    break;
                case 2:
                    UpdateBasePrice(radioButtonSizeSmall);
                    break;
                case 3:
                    UpdateBasePrice(radioButtonSizeMedium);
                    break;
                case 4:
                    UpdateBasePrice(radioButtonSizeLarge);
                    break;
                default:
                    labelItems.Text = "";
                    labelPrice.Text = "";
                    price = 0;
                    break;
            }
            if (radioButtonSauceAlfredo.Checked)
            {
                labelItems.Text += "Alfredo Sauce\n";
                labelPrice.Text += "\n";
            }
            else if (radioButtonSauceTomato.Checked)
            {
                labelItems.Text += "Tomato Sauce\n";
                labelPrice.Text += "\n";
            }
            UpdateItemPrice(checkBoxSausageL, checkBoxSausageR);
            UpdateItemPrice(checkBoxBaconL, checkBoxBaconR);
            UpdateItemPrice(checkBoxSalamiL, checkBoxSalamiR);
            UpdateItemPrice(checkBoxTomatoL, checkBoxTomatoR);
            UpdateItemPrice(checkBoxSpinachL, checkBoxSpinachR);
            UpdateItemPrice(checkBoxOliveL, checkBoxOliveR);
            UpdateItemPrice(checkBoxPineappleL, checkBoxPineappleR);
            UpdateItemPrice(checkBoxMozzarellaL, checkBoxMozzarellaR);
            UpdateItemPrice(checkBoxParmesanL, checkBoxParmesanR);
            if (price == 0)
            {
                labelSubtotalPrice.Text = "";
                labelTaxPrice.Text = "";
                labelTotalPrice.Text = "";
            }
            else
            {
                labelSubtotalPrice.Text = "$" + price;
                labelTaxPrice.Text = "$" + (price * tax).ToString("F");
                labelTotalPrice.Text = "$" + (price * (1 + tax)).ToString("F");
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Updates information about the price for size.
        // @param: RadioButton
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void UpdateBasePrice(RadioButton ctrl)
        {
            decimal unitPrice = Decimal.Parse((string)ctrl.Tag);
            labelItems.Text = ctrl.Text + " Size\n";
            labelPrice.Text = "$" + unitPrice + "\n";
            price = unitPrice;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Updates information about the price for toppings.
        // @param: CheckBox, CheckBox
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void UpdateItemPrice(CheckBox left, CheckBox right)
        {
            decimal unitPrice = 0;
            if (left.Checked && right.Checked)
            {
                unitPrice = Decimal.Parse((string)left.Tag) * 2;
                labelItems.Text += left.Text + "\n";
                labelPrice.Text += "$" + unitPrice + "\n";
            }
            else if (left.Checked || right.Checked)
            {
                unitPrice = Decimal.Parse((string)left.Tag);
                labelItems.Text += left.Text + "\n";
                labelPrice.Text += "$" + unitPrice + "\n";
            }
            price += unitPrice;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Enables CheckOut button when ready to order.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void UpdateCheckOut()
        {
            if (CheckedAny(groupBoxSize) && CheckedAny(groupBoxType)
                && CheckedAny(groupBoxSauce))
                buttonCheckOut.Enabled = true;
            else
                buttonCheckOut.Enabled = false;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the radio button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void radioButtonSizePersonal_CheckedChanged(object sender, EventArgs e)
        {
            size = 1;
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the radio button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void radioButtonSizeSmall_CheckedChanged(object sender, EventArgs e)
        {
            size = 2;
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the radio button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void radioButtonSizeMedium_CheckedChanged(object sender, EventArgs e)
        {
            size = 3;
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the radio button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void radioButtonSizeLarge_CheckedChanged(object sender, EventArgs e)
        {
            size = 4;
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonSizeClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                size = 0;
                Clear(groupBoxSize);
                UpdateAll();
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonSizeNext_Click(object sender, EventArgs e)
        {
            NextTab();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the radio button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void radioButtonTypeMeat_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonSauceAlfredo.Checked = true;
            CheckAll(groupBoxMeatLeft);
            CheckAll(groupBoxMeatRight);
            Clear(groupBoxVeggieLeft);
            Clear(groupBoxVeggieRight);
            Clear(groupBoxCheeseLeft);
            Clear(groupBoxCheeseRight);
            DisableBuild();
            labelType.Text = radioButtonTypeVeggie.Text;
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the radio button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void radioButtonTypeVeggie_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonSauceTomato.Checked = true;
            Clear(groupBoxMeatLeft);
            Clear(groupBoxMeatRight);
            CheckAll(groupBoxVeggieLeft);
            CheckAll(groupBoxVeggieRight);
            Clear(groupBoxCheeseLeft);
            Clear(groupBoxCheeseRight);
            DisableBuild();
            labelType.Text = radioButtonTypeVeggie.Text;
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the radio button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void radioButtonTypeCheese_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonSauceAlfredo.Checked = true;
            Clear(groupBoxMeatLeft);
            Clear(groupBoxMeatRight);
            Clear(groupBoxVeggieLeft);
            Clear(groupBoxVeggieRight);
            CheckAll(groupBoxCheeseLeft);
            CheckAll(groupBoxCheeseRight);
            DisableBuild();
            labelType.Text = radioButtonTypeCheese.Text;
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the radio button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void radioButtonTypeItaliano_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonSauceTomato.Checked = true;
            checkBoxSausageL.Checked = true;
            checkBoxBaconL.Checked = false;
            checkBoxSalamiL.Checked = true;
            checkBoxSausageR.Checked = true;
            checkBoxBaconR.Checked = false;
            checkBoxSalamiR.Checked = true;
            checkBoxTomatoL.Checked = true;
            checkBoxSpinachL.Checked = true;
            checkBoxOliveL.Checked = true;
            checkBoxPineappleL.Checked = false;
            checkBoxTomatoR.Checked = true;
            checkBoxSpinachR.Checked = true;
            checkBoxOliveR.Checked = true;
            checkBoxPineappleR.Checked = false;
            checkBoxMozzarellaL.Checked = true;
            checkBoxParmesanL.Checked = false;
            checkBoxMozzarellaR.Checked = true;
            checkBoxParmesanR.Checked = false;
            DisableBuild();
            labelType.Text = radioButtonTypeItaliano.Text;
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the radio button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void radioButtonTypeBuild_CheckedChanged(object sender, EventArgs e)
        {
            Clear(groupBoxSauce);
            Clear(groupBoxMeatLeft);
            Clear(groupBoxMeatRight);
            Clear(groupBoxVeggieLeft);
            Clear(groupBoxVeggieRight);
            Clear(groupBoxCheeseLeft);
            Clear(groupBoxCheeseRight);
            EnableBuild();
            labelType.Text = radioButtonTypeBuild.Text;
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonTypeClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                radioButtonTypeBuild_CheckedChanged(sender, e);
                Clear(groupBoxType);
                UpdateAll();
                labelType.Text = "";
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonTypePrevious_Click(object sender, EventArgs e)
        {
            PreviousTab();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonTypeNext_Click(object sender, EventArgs e)
        {
            NextTab();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the radio button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void radioButtonSauceAlfredo_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the radio button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void radioButtonSauceTomato_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonSauceClear_Click(object sender, EventArgs e)
        {
            Clear(groupBoxSauce);
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonSaucePrevious_Click(object sender, EventArgs e)
        {
            PreviousTab();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonSauceNext_Click(object sender, EventArgs e)
        {
            NextTab();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxSausageL_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxBaconL_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxSalamiL_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonMeatLeftClear_Click(object sender, EventArgs e)
        {
            CheckAllOrClear(groupBoxMeatLeft);
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxSausageR_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxBaconR_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxSalamiR_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonMeatRightClear_Click(object sender, EventArgs e)
        {
            CheckAllOrClear(groupBoxMeatRight);
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonMeatPrevious_Click(object sender, EventArgs e)
        {
            PreviousTab();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonMeatNext_Click(object sender, EventArgs e)
        {
            NextTab();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxTomatoL_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxSpinachL_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxOliveL_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxPineappleL_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonVeggieLeftClear_Click(object sender, EventArgs e)
        {
            CheckAllOrClear(groupBoxVeggieLeft);
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxTomatoR_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxSpinachR_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxOliveR_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxPineappleR_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonVeggieRightClear_Click(object sender, EventArgs e)
        {
            CheckAllOrClear(groupBoxVeggieRight);
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonVeggiePrevious_Click(object sender, EventArgs e)
        {
            PreviousTab();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonVeggieNext_Click(object sender, EventArgs e)
        {
            NextTab();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxMozzarellaL_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxParmesanL_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonCheeseLeftClear_Click(object sender, EventArgs e)
        {
            CheckAllOrClear(groupBoxCheeseLeft);
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxMozzarellaR_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // CheckedChanged event for the checkbox.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void checkBoxParmesanR_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonCheeseRightClear_Click(object sender, EventArgs e)
        {
            CheckAllOrClear(groupBoxCheeseRight);
            UpdateAll();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonCheesePrevious_Click(object sender, EventArgs e)
        {
            PreviousTab();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Click event for the button.
        // @param: object, EventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                PlaceOrder j = new PlaceOrder(labelType.Text, price);
                j.Show();
                this.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("This order cannot be checked out.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private int size;
        private bool pizzaDrawn;
        private decimal price;
        private Rectangle pizzaSize;
        private Graphics pizza;

    }
}
