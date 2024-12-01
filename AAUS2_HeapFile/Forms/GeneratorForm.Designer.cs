namespace AAUS2_SemPraca.Forms
{
    partial class GeneratorForm
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
            number = new Label();
            NumberInput = new NumericUpDown();
            IntersectionInput = new NumericUpDown();
            Intersection = new Label();
            GenerateButton = new Button();
            CancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)NumberInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IntersectionInput).BeginInit();
            SuspendLayout();
            // 
            // number
            // 
            number.AutoSize = true;
            number.Location = new Point(10, 23);
            number.Margin = new Padding(4, 0, 4, 0);
            number.Name = "number";
            number.Size = new Size(160, 25);
            number.TabIndex = 16;
            number.Text = "Number of entities";
            // 
            // NumberInput
            // 
            NumberInput.Location = new Point(196, 20);
            NumberInput.Margin = new Padding(4, 5, 4, 5);
            NumberInput.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            NumberInput.Name = "NumberInput";
            NumberInput.Size = new Size(171, 31);
            NumberInput.TabIndex = 15;
            // 
            // IntersectionInput
            // 
            IntersectionInput.Location = new Point(196, 68);
            IntersectionInput.Margin = new Padding(4, 5, 4, 5);
            IntersectionInput.Name = "IntersectionInput";
            IntersectionInput.Size = new Size(171, 31);
            IntersectionInput.TabIndex = 17;
            // 
            // Intersection
            // 
            Intersection.AutoSize = true;
            Intersection.Location = new Point(10, 72);
            Intersection.Margin = new Padding(4, 0, 4, 0);
            Intersection.Name = "Intersection";
            Intersection.Size = new Size(134, 25);
            Intersection.TabIndex = 18;
            Intersection.Text = "Intersection (%)";
            // 
            // GenerateButton
            // 
            GenerateButton.DialogResult = DialogResult.OK;
            GenerateButton.Location = new Point(77, 128);
            GenerateButton.Margin = new Padding(4, 5, 4, 5);
            GenerateButton.Name = "GenerateButton";
            GenerateButton.Size = new Size(107, 38);
            GenerateButton.TabIndex = 33;
            GenerateButton.Text = "Generate";
            GenerateButton.UseVisualStyleBackColor = true;
            GenerateButton.Click += GenerateButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(207, 128);
            CancelButton.Margin = new Padding(4, 5, 4, 5);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(107, 38);
            CancelButton.TabIndex = 32;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // GeneratorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 175);
            Controls.Add(GenerateButton);
            Controls.Add(CancelButton);
            Controls.Add(Intersection);
            Controls.Add(IntersectionInput);
            Controls.Add(number);
            Controls.Add(NumberInput);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MaximumSize = new Size(398, 231);
            MinimizeBox = false;
            MinimumSize = new Size(398, 231);
            Name = "GeneratorForm";
            Text = "Generator";
            ((System.ComponentModel.ISupportInitialize)NumberInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)IntersectionInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label number;
        private NumericUpDown NumberInput;
        private NumericUpDown IntersectionInput;
        private Label Intersection;
        private Button GenerateButton;
        private Button CancelButton;
    }
}