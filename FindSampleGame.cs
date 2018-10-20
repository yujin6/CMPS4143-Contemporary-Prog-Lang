/*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
* This program is a game to find the evidence sample.
* @version 1.0 2018-10-03
* @course: CMPS4143 Dr. Stringfellow
* @author Yujin Yoshimura
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
using System;
using System.Windows.Forms;

namespace CSI_Find_The_Evidence_Sample
{
    public partial class FindSampleGame : Form
    {

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Default constructor.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        public FindSampleGame()
        {
            InitializeComponent();
            Initialize();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Moves to the next textbox when user hits Enter key.
        // @param: object, KeyEventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void textBoxWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl(this.ActiveControl, true, true, true,
                    true);
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Moves to the next button when user hits Enter key.
        // @param: object, KeyEventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void textBoxHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                buttonSet_Click(sender, e);
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Sets the size and changes into guessing phase.
        // @param: object, KeyEventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonSet_Click(object sender, EventArgs e)
        {
            textBoxWidth.Enabled = false;
            textBoxHeight.Enabled = false;
            buttonSet.Enabled = false;
            textBoxRow.Enabled = true;
            textBoxCol.Enabled = true;
            buttonGuess.Enabled = true;
            int w = GetInt(textBoxWidth.Text);
            int h = GetInt(textBoxHeight.Text);
            grid = new ScanAnalyzer(w, h);
            labelInstruction.Text = "Guess where the evidence sample is " + 
                "located.\nThere are two samples.";
            labelSize.Text = "Size: " + grid.Width + " x " + grid.Height;
            labelGuessCount.Text = "You made " + grid.Guesses + " guesses.";
            labelDisplay.Text = grid.DisplayGrid();
            textBoxCol.Focus();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Moves to the next textbox when user hits Enter key.
        // @param: object, KeyEventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void textBoxCol_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl(this.ActiveControl, true, true, true,
                    true);
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Moves to the next button when user hits Enter key.
        // @param: object, KeyEventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void textBoxRow_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                buttonGuess_Click(sender, e);
            }
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Guesses the location of the samples.
        // @param: object, KeyEventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonGuess_Click(object sender, EventArgs e)
        {
            int c = GetInt(textBoxCol.Text);
            int r = GetInt(textBoxRow.Text);
            bool guessed = grid.EvaluateGuess(c - 1, r - 1);
            labelDisplay.Text = grid.DisplayGrid();
            labelCoordinate.Text = grid.GetCoordinate() + " was guessed.";
            labelGuessCount.Text = "You made " + grid.Guesses + " guesses.";
            labelResult.Text = (guessed) ? "Guessed correctly!" : "Try again.";
            if (guessed) buttonPlayAgain.Enabled = true;
            textBoxRow.Text = "";
            textBoxCol.Text = "";
            textBoxCol.Focus();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Resets the entire game and changes into setting phase.
        // @param: object, KeyEventArgs
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void buttonPlayAgain_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Converts the input value into valid integer.
        // When the user enters alphabet, automatically converts into integer.
        // @param: string
        // @return: int
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private int GetInt(string str)
        {
            int num;
            int.TryParse(str, out num);
            if (str != "" && num == 0)
            {
                char[] ch = str.ToCharArray();
                if (Char.IsLetter(ch[0]))
                {
                    num = Convert.ToInt32(Char.ToLower(ch[0])) - 96;
                }
            }
            return num;
        }

        /*+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        // Resets the form for the setting phase.
        // @param: none
        +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+*/
        private void Initialize()
        {
            textBoxWidth.Enabled = true;
            textBoxHeight.Enabled = true;
            buttonSet.Enabled = true;
            textBoxRow.Enabled = false;
            textBoxCol.Enabled = false;
            buttonGuess.Enabled = false;
            buttonPlayAgain.Enabled = false;
            textBoxWidth.Text = "";
            textBoxHeight.Text = "";
            textBoxRow.Text = "";
            textBoxCol.Text = "";
            labelInstruction.Text = "Set the size of the site to investigate."
                + "\nMaximum size is 26 x 16.";
            labelSize.Text = "";
            labelCoordinate.Text = "";
            labelGuessCount.Text = "";
            labelResult.Text = "";
            labelDisplay.Text = "";
        }

        private ScanAnalyzer grid;
    }
}
