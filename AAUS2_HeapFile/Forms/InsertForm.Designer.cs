namespace AAUS2_SemPraca
{
    partial class InsertForm
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
            surnameInput = new TextBox();
            CancelButton = new Button();
            InsertButton = new Button();
            name = new Label();
            surname = new Label();
            nameInput = new TextBox();
            licencePlate = new Label();
            licencePlateInput = new TextBox();
            date = new Label();
            price = new Label();
            description = new Label();
            descriptionInput = new TextBox();
            dateTimeInput = new DateTimePicker();
            priceInput = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)priceInput).BeginInit();
            SuspendLayout();
            // 
            // surnameInput
            // 
            surnameInput.Location = new Point(108, 41);
            surnameInput.MaxLength = 20;
            surnameInput.Name = "surnameInput";
            surnameInput.Size = new Size(120, 23);
            surnameInput.TabIndex = 1;
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(151, 249);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 12;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // InsertButton
            // 
            InsertButton.DialogResult = DialogResult.OK;
            InsertButton.Location = new Point(70, 249);
            InsertButton.Name = "InsertButton";
            InsertButton.Size = new Size(75, 23);
            InsertButton.TabIndex = 13;
            InsertButton.Text = "Insert";
            InsertButton.UseVisualStyleBackColor = true;
            InsertButton.Click += InsertButton_Click;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(4, 14);
            name.Name = "name";
            name.Size = new Size(39, 15);
            name.TabIndex = 14;
            name.Text = "Name";
            name.Click += label1_Click;
            // 
            // surname
            // 
            surname.AutoSize = true;
            surname.Location = new Point(4, 44);
            surname.Name = "surname";
            surname.Size = new Size(54, 15);
            surname.TabIndex = 15;
            surname.Text = "Surname";
            // 
            // nameInput
            // 
            nameInput.Location = new Point(108, 11);
            nameInput.MaxLength = 15;
            nameInput.Name = "nameInput";
            nameInput.Size = new Size(120, 23);
            nameInput.TabIndex = 26;
            // 
            // licencePlate
            // 
            licencePlate.AutoSize = true;
            licencePlate.Location = new Point(4, 74);
            licencePlate.Name = "licencePlate";
            licencePlate.Size = new Size(76, 15);
            licencePlate.TabIndex = 28;
            licencePlate.Text = "Licence Plate";
            // 
            // licencePlateInput
            // 
            licencePlateInput.Location = new Point(108, 71);
            licencePlateInput.MaxLength = 10;
            licencePlateInput.Name = "licencePlateInput";
            licencePlateInput.Size = new Size(120, 23);
            licencePlateInput.TabIndex = 27;
            // 
            // date
            // 
            date.AutoSize = true;
            date.Location = new Point(4, 150);
            date.Name = "date";
            date.Size = new Size(31, 15);
            date.TabIndex = 30;
            date.Text = "Date";
            // 
            // price
            // 
            price.AutoSize = true;
            price.Location = new Point(4, 179);
            price.Name = "price";
            price.Size = new Size(33, 15);
            price.TabIndex = 32;
            price.Text = "Price";
            // 
            // description
            // 
            description.AutoSize = true;
            description.Location = new Point(4, 208);
            description.Name = "description";
            description.Size = new Size(67, 15);
            description.TabIndex = 34;
            description.Text = "Description";
            // 
            // descriptionInput
            // 
            descriptionInput.Location = new Point(108, 205);
            descriptionInput.MaxLength = 210;
            descriptionInput.Name = "descriptionInput";
            descriptionInput.Size = new Size(120, 23);
            descriptionInput.TabIndex = 33;
            // 
            // dateTimeInput
            // 
            dateTimeInput.Location = new Point(108, 144);
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
            priceInput.Location = new Point(108, 174);
            priceInput.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            priceInput.Name = "priceInput";
            priceInput.Size = new Size(120, 23);
            priceInput.TabIndex = 36;
            // 
            // InsertForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(238, 299);
            Controls.Add(priceInput);
            Controls.Add(dateTimeInput);
            Controls.Add(description);
            Controls.Add(descriptionInput);
            Controls.Add(price);
            Controls.Add(date);
            Controls.Add(licencePlate);
            Controls.Add(licencePlateInput);
            Controls.Add(nameInput);
            Controls.Add(surname);
            Controls.Add(name);
            Controls.Add(InsertButton);
            Controls.Add(CancelButton);
            Controls.Add(surnameInput);
            MaximizeBox = false;
            MaximumSize = new Size(254, 338);
            MinimizeBox = false;
            MinimumSize = new Size(254, 338);
            Name = "InsertForm";
            Text = "Insert";
            Load += InsertForm_Load;
            ((System.ComponentModel.ISupportInitialize)priceInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox surnameInput;
        private Button CancelButton;
        private Button InsertButton;
        private Label name;
        private Label surname;
        private TextBox nameInput;
        private Label licencePlate;
        private TextBox licencePlateInput;
        private Label date;
        private Label price;
        private Label description;
        private TextBox descriptionInput;
        private DateTimePicker dateTimeInput;
        private NumericUpDown priceInput;
    }
}