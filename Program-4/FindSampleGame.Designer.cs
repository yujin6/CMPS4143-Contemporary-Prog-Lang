namespace CSI_Find_The_Evidence_Sample
{
    partial class FindSampleGame
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
            this.labelInstruction = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelCol = new System.Windows.Forms.Label();
            this.labelRow = new System.Windows.Forms.Label();
            this.labelCoordinate = new System.Windows.Forms.Label();
            this.labelGuessCount = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelDisplay = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.buttonSet = new System.Windows.Forms.Button();
            this.textBoxCol = new System.Windows.Forms.TextBox();
            this.textBoxRow = new System.Windows.Forms.TextBox();
            this.buttonGuess = new System.Windows.Forms.Button();
            this.buttonPlayAgain = new System.Windows.Forms.Button();
            this.groupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.groupBoxDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInstruction
            // 
            this.labelInstruction.AutoSize = true;
            this.labelInstruction.Location = new System.Drawing.Point(14, 16);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(73, 17);
            this.labelInstruction.TabIndex = 1;
            this.labelInstruction.Text = "Instruction";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(14, 75);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(44, 17);
            this.labelWidth.TabIndex = 2;
            this.labelWidth.Text = "Width";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(14, 105);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(49, 17);
            this.labelHeight.TabIndex = 3;
            this.labelHeight.Text = "Height";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(14, 135);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(35, 17);
            this.labelSize.TabIndex = 4;
            this.labelSize.Text = "Size";
            // 
            // labelCol
            // 
            this.labelCol.AutoSize = true;
            this.labelCol.Location = new System.Drawing.Point(14, 165);
            this.labelCol.Name = "labelCol";
            this.labelCol.Size = new System.Drawing.Size(55, 17);
            this.labelCol.TabIndex = 5;
            this.labelCol.Text = "Column";
            // 
            // labelRow
            // 
            this.labelRow.AutoSize = true;
            this.labelRow.Location = new System.Drawing.Point(14, 195);
            this.labelRow.Name = "labelRow";
            this.labelRow.Size = new System.Drawing.Size(35, 17);
            this.labelRow.TabIndex = 6;
            this.labelRow.Text = "Row";
            // 
            // labelCoordinate
            // 
            this.labelCoordinate.AutoSize = true;
            this.labelCoordinate.Location = new System.Drawing.Point(14, 225);
            this.labelCoordinate.Name = "labelCoordinate";
            this.labelCoordinate.Size = new System.Drawing.Size(77, 17);
            this.labelCoordinate.TabIndex = 7;
            this.labelCoordinate.Text = "Coordinate";
            // 
            // labelGuessCount
            // 
            this.labelGuessCount.AutoSize = true;
            this.labelGuessCount.Location = new System.Drawing.Point(14, 255);
            this.labelGuessCount.Name = "labelGuessCount";
            this.labelGuessCount.Size = new System.Drawing.Size(90, 17);
            this.labelGuessCount.TabIndex = 8;
            this.labelGuessCount.Text = "Guess Count";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(14, 285);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(48, 17);
            this.labelResult.TabIndex = 9;
            this.labelResult.Text = "Result";
            // 
            // labelDisplay
            // 
            this.labelDisplay.AutoSize = true;
            this.labelDisplay.Font = new System.Drawing.Font("Lucida Sans Typewriter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplay.Location = new System.Drawing.Point(6, 20);
            this.labelDisplay.Name = "labelDisplay";
            this.labelDisplay.Size = new System.Drawing.Size(64, 16);
            this.labelDisplay.TabIndex = 10;
            this.labelDisplay.Text = "Display";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(77, 72);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(112, 22);
            this.textBoxWidth.TabIndex = 11;
            this.textBoxWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxWidth_KeyDown);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(77, 102);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(112, 22);
            this.textBoxHeight.TabIndex = 12;
            this.textBoxHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxHeight_KeyDown);
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(195, 72);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(112, 52);
            this.buttonSet.TabIndex = 13;
            this.buttonSet.Text = "Set Dimension";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // textBoxCol
            // 
            this.textBoxCol.Location = new System.Drawing.Point(77, 162);
            this.textBoxCol.Name = "textBoxCol";
            this.textBoxCol.Size = new System.Drawing.Size(112, 22);
            this.textBoxCol.TabIndex = 14;
            this.textBoxCol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCol_KeyDown);
            // 
            // textBoxRow
            // 
            this.textBoxRow.Location = new System.Drawing.Point(77, 192);
            this.textBoxRow.Name = "textBoxRow";
            this.textBoxRow.Size = new System.Drawing.Size(112, 22);
            this.textBoxRow.TabIndex = 15;
            this.textBoxRow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRow_KeyDown);
            // 
            // buttonGuess
            // 
            this.buttonGuess.Location = new System.Drawing.Point(195, 162);
            this.buttonGuess.Name = "buttonGuess";
            this.buttonGuess.Size = new System.Drawing.Size(112, 52);
            this.buttonGuess.TabIndex = 16;
            this.buttonGuess.Text = "Guess";
            this.buttonGuess.UseVisualStyleBackColor = true;
            this.buttonGuess.Click += new System.EventHandler(this.buttonGuess_Click);
            // 
            // buttonPlayAgain
            // 
            this.buttonPlayAgain.Location = new System.Drawing.Point(195, 257);
            this.buttonPlayAgain.Name = "buttonPlayAgain";
            this.buttonPlayAgain.Size = new System.Drawing.Size(112, 52);
            this.buttonPlayAgain.TabIndex = 17;
            this.buttonPlayAgain.Text = "Play Again";
            this.buttonPlayAgain.UseVisualStyleBackColor = true;
            this.buttonPlayAgain.Click += new System.EventHandler(this.buttonPlayAgain_Click);
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.Controls.Add(this.labelDisplay);
            this.groupBoxDisplay.Location = new System.Drawing.Point(327, 16);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(300, 300);
            this.groupBoxDisplay.TabIndex = 18;
            this.groupBoxDisplay.TabStop = false;
            this.groupBoxDisplay.Text = "Site";
            // 
            // FindSampleGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 325);
            this.Controls.Add(this.labelCoordinate);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.buttonPlayAgain);
            this.Controls.Add(this.labelInstruction);
            this.Controls.Add(this.labelGuessCount);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonGuess);
            this.Controls.Add(this.textBoxRow);
            this.Controls.Add(this.textBoxCol);
            this.Controls.Add(this.labelRow);
            this.Controls.Add(this.labelCol);
            this.Controls.Add(this.groupBoxDisplay);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.labelWidth);
            this.Name = "FindSampleGame";
            this.Text = "CSI Find The Evidence Sample";
            this.groupBoxDisplay.ResumeLayout(false);
            this.groupBoxDisplay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelInstruction;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelCol;
        private System.Windows.Forms.Label labelRow;
        private System.Windows.Forms.Label labelCoordinate;
        private System.Windows.Forms.Label labelGuessCount;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelDisplay;
        private System.Windows.Forms.GroupBox groupBoxDisplay;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.TextBox textBoxCol;
        private System.Windows.Forms.TextBox textBoxRow;
        private System.Windows.Forms.Button buttonGuess;
        private System.Windows.Forms.Button buttonPlayAgain;
    }
}

