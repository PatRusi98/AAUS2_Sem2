namespace AAUS2_SemPraca
{
    partial class InsertSRForm
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
            CancelButton = new Button();
            InsertButton = new Button();
            date = new Label();
            price = new Label();
            description = new Label();
            descriptionInput = new TextBox();
            dateTimeInput = new DateTimePicker();
            priceInput = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)priceInput).BeginInit();
            SuspendLayout();
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(152, 115);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 12;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // InsertButton
            // 
            InsertButton.DialogResult = DialogResult.OK;
            InsertButton.Location = new Point(71, 115);
            InsertButton.Name = "InsertButton";
            InsertButton.Size = new Size(75, 23);
            InsertButton.TabIndex = 13;
            InsertButton.Text = "Insert";
            InsertButton.UseVisualStyleBackColor = true;
            InsertButton.Click += InsertButton_Click;
            // 
            // date
            // 
            date.AutoSize = true;
            date.Location = new Point(5, 16);
            date.Name = "date";
            date.Size = new Size(31, 15);
            date.TabIndex = 30;
            date.Text = "Date";
            // 
            // price
            // 
            price.AutoSize = true;
            price.Location = new Point(5, 45);
            price.Name = "price";
            price.Size = new Size(33, 15);
            price.TabIndex = 32;
            price.Text = "Price";
            // 
            // description
            // 
            description.AutoSize = true;
            description.Location = new Point(5, 74);
            description.Name = "description";
            description.Size = new Size(67, 15);
            description.TabIndex = 34;
            description.Text = "Description";
            // 
            // descriptionInput
            // 
            descriptionInput.Location = new Point(109, 71);
            descriptionInput.MaxLength = 210;
            descriptionInput.Name = "descriptionInput";
            descriptionInput.Size = new Size(120, 23);
            descriptionInput.TabIndex = 33;
            // 
            // dateTimeInput
            // 
            dateTimeInput.Location = new Point(109, 10);
            dateTimeInput.MaxDate = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            dateTimeInput.MinDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTimeInput.Name = "dateTimeInput";
            dateTimeInput.Size = new Size(120, 23);
            dateTimeInput.TabIndex = 35;
            dateTimeInput.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // priceInput
            // 
            priceInput.DecimalPlaces = 2;
            priceInput.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            priceInput.Location = new Point(109, 40);
            priceInput.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            priceInput.Name = "priceInput";
            priceInput.Size = new Size(120, 23);
            priceInput.TabIndex = 36;
            // 
            // InsertSRForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(238, 153);
            Controls.Add(priceInput);
            Controls.Add(dateTimeInput);
            Controls.Add(description);
            Controls.Add(descriptionInput);
            Controls.Add(price);
            Controls.Add(date);
            Controls.Add(InsertButton);
            Controls.Add(CancelButton);
            MaximizeBox = false;
            MaximumSize = new Size(254, 192);
            MinimizeBox = false;
            MinimumSize = new Size(254, 192);
            Name = "InsertSRForm";
            Text = "Insert";
            Load += InsertForm_Load;
            ((System.ComponentModel.ISupportInitialize)priceInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button CancelButton;
        private Button InsertButton;
        private Label date;
        private Label price;
        private Label description;
        private TextBox descriptionInput;
        private DateTimePicker dateTimeInput;
        private NumericUpDown priceInput;
    }
}