namespace AAUS2_HeapFile.Forms
{
    partial class Sequential
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
            SeqTextBox = new TextBox();
            SuspendLayout();
            // 
            // SeqTextBox
            // 
            SeqTextBox.Location = new Point(14, 18);
            SeqTextBox.MaxLength = 99999999;
            SeqTextBox.Multiline = true;
            SeqTextBox.Name = "SeqTextBox";
            SeqTextBox.ScrollBars = ScrollBars.Vertical;
            SeqTextBox.Size = new Size(774, 407);
            SeqTextBox.TabIndex = 0;
            // 
            // Sequential
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SeqTextBox);
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "Sequential";
            Text = "Sequential";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SeqTextBox;
    }
}