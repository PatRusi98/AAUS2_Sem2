namespace AAUS2_SemPraca.Forms
{
    partial class TesterForm
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
            insert = new Label();
            InsertInput = new NumericUpDown();
            search = new Label();
            SearchInput = new NumericUpDown();
            TestButton = new Button();
            CancelButton = new Button();
            number = new Label();
            NumberInput = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)InsertInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SearchInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumberInput).BeginInit();
            SuspendLayout();
            // 
            // insert
            // 
            insert.AutoSize = true;
            insert.Location = new Point(9, 43);
            insert.Name = "insert";
            insert.Size = new Size(96, 15);
            insert.TabIndex = 16;
            insert.Text = "Insert probability";
            // 
            // InsertInput
            // 
            InsertInput.DecimalPlaces = 2;
            InsertInput.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            InsertInput.Location = new Point(138, 41);
            InsertInput.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            InsertInput.Name = "InsertInput";
            InsertInput.Size = new Size(120, 23);
            InsertInput.TabIndex = 15;
            // 
            // search
            // 
            search.AutoSize = true;
            search.Location = new Point(9, 72);
            search.Name = "search";
            search.Size = new Size(102, 15);
            search.TabIndex = 18;
            search.Text = "Search probability";
            // 
            // SearchInput
            // 
            SearchInput.DecimalPlaces = 2;
            SearchInput.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            SearchInput.Location = new Point(138, 70);
            SearchInput.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            SearchInput.Name = "SearchInput";
            SearchInput.Size = new Size(120, 23);
            SearchInput.TabIndex = 21;
            // 
            // TestButton
            // 
            TestButton.DialogResult = DialogResult.OK;
            TestButton.Location = new Point(47, 138);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(75, 23);
            TestButton.TabIndex = 31;
            TestButton.Text = "Test";
            TestButton.UseVisualStyleBackColor = true;
            TestButton.Click += TestButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(138, 138);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 30;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // number
            // 
            number.AutoSize = true;
            number.Location = new Point(8, 14);
            number.Name = "number";
            number.Size = new Size(124, 15);
            number.TabIndex = 33;
            number.Text = "Number of operations";
            // 
            // NumberInput
            // 
            NumberInput.Location = new Point(138, 12);
            NumberInput.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            NumberInput.Name = "NumberInput";
            NumberInput.Size = new Size(120, 23);
            NumberInput.TabIndex = 32;
            // 
            // TesterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(268, 177);
            Controls.Add(number);
            Controls.Add(NumberInput);
            Controls.Add(TestButton);
            Controls.Add(CancelButton);
            Controls.Add(SearchInput);
            Controls.Add(search);
            Controls.Add(insert);
            Controls.Add(InsertInput);
            MaximizeBox = false;
            MaximumSize = new Size(284, 216);
            MinimizeBox = false;
            MinimumSize = new Size(284, 216);
            Name = "TesterForm";
            Text = "Tester";
            ((System.ComponentModel.ISupportInitialize)InsertInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)SearchInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumberInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label insert;
        private NumericUpDown InsertInput;
        private Label search;
        private NumericUpDown SearchInput;
        private Button TestButton;
        private Button CancelButton;
        private Label number;
        private NumericUpDown NumberInput;
    }
}