namespace AAUS2_SemPraca
{
    partial class DetailsForm
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
            details = new Label();
            surname = new Label();
            name = new Label();
            licencePlate = new Label();
            id = new Label();
            DescriptionInput = new TextBox();
            NumberInput = new NumericUpDown();
            EditCheckBox = new CheckBox();
            listBox1 = new ListBox();
            EditButton = new Button();
            CancelButton = new Button();
            NameInput = new TextBox();
            SurnameInput = new TextBox();
            ((System.ComponentModel.ISupportInitialize)NumberInput).BeginInit();
            SuspendLayout();
            // 
            // details
            // 
            details.AutoSize = true;
            details.Location = new Point(147, 127);
            details.Margin = new Padding(4, 0, 4, 0);
            details.Name = "details";
            details.Size = new Size(65, 25);
            details.TabIndex = 46;
            details.Text = "Details";
            // 
            // surname
            // 
            surname.AutoSize = true;
            surname.Location = new Point(17, 248);
            surname.Margin = new Padding(4, 0, 4, 0);
            surname.Name = "surname";
            surname.Size = new Size(82, 25);
            surname.TabIndex = 40;
            surname.Text = "Surname";
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(17, 197);
            name.Margin = new Padding(4, 0, 4, 0);
            name.Name = "name";
            name.Size = new Size(59, 25);
            name.TabIndex = 39;
            name.Text = "Name";
            // 
            // licencePlate
            // 
            licencePlate.AutoSize = true;
            licencePlate.Location = new Point(11, 73);
            licencePlate.Margin = new Padding(4, 0, 4, 0);
            licencePlate.Name = "licencePlate";
            licencePlate.Size = new Size(111, 25);
            licencePlate.TabIndex = 37;
            licencePlate.Text = "Licence Plate";
            // 
            // id
            // 
            id.AutoSize = true;
            id.Location = new Point(11, 23);
            id.Margin = new Padding(4, 0, 4, 0);
            id.Name = "id";
            id.Size = new Size(30, 25);
            id.TabIndex = 36;
            id.Text = "ID";
            // 
            // DescriptionInput
            // 
            DescriptionInput.Location = new Point(160, 68);
            DescriptionInput.Margin = new Padding(4, 5, 4, 5);
            DescriptionInput.Name = "DescriptionInput";
            DescriptionInput.ReadOnly = true;
            DescriptionInput.Size = new Size(170, 31);
            DescriptionInput.TabIndex = 27;
            // 
            // NumberInput
            // 
            NumberInput.Location = new Point(160, 20);
            NumberInput.Margin = new Padding(4, 5, 4, 5);
            NumberInput.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            NumberInput.Name = "NumberInput";
            NumberInput.ReadOnly = true;
            NumberInput.Size = new Size(171, 31);
            NumberInput.TabIndex = 26;
            NumberInput.TabStop = false;
            // 
            // EditCheckBox
            // 
            EditCheckBox.AutoSize = true;
            EditCheckBox.Location = new Point(21, 362);
            EditCheckBox.Margin = new Padding(4, 5, 4, 5);
            EditCheckBox.Name = "EditCheckBox";
            EditCheckBox.Size = new Size(76, 29);
            EditCheckBox.TabIndex = 48;
            EditCheckBox.Text = "Edit?";
            EditCheckBox.UseVisualStyleBackColor = true;
            EditCheckBox.CheckedChanged += EditCheckBox_CheckedChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(414, 23);
            listBox1.Margin = new Padding(4, 5, 4, 5);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(710, 279);
            listBox1.TabIndex = 49;
            // 
            // EditButton
            // 
            EditButton.DialogResult = DialogResult.OK;
            EditButton.Enabled = false;
            EditButton.Location = new Point(886, 362);
            EditButton.Margin = new Padding(4, 5, 4, 5);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(107, 38);
            EditButton.TabIndex = 51;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(1016, 362);
            CancelButton.Margin = new Padding(4, 5, 4, 5);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(107, 38);
            CancelButton.TabIndex = 50;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // NameInput
            // 
            NameInput.Location = new Point(160, 192);
            NameInput.Margin = new Padding(4, 5, 4, 5);
            NameInput.Name = "NameInput";
            NameInput.ReadOnly = true;
            NameInput.Size = new Size(170, 31);
            NameInput.TabIndex = 52;
            // 
            // SurnameInput
            // 
            SurnameInput.Location = new Point(160, 243);
            SurnameInput.Margin = new Padding(4, 5, 4, 5);
            SurnameInput.Name = "SurnameInput";
            SurnameInput.ReadOnly = true;
            SurnameInput.Size = new Size(170, 31);
            SurnameInput.TabIndex = 53;
            // 
            // DetailsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 418);
            Controls.Add(SurnameInput);
            Controls.Add(NameInput);
            Controls.Add(EditButton);
            Controls.Add(CancelButton);
            Controls.Add(listBox1);
            Controls.Add(EditCheckBox);
            Controls.Add(details);
            Controls.Add(surname);
            Controls.Add(name);
            Controls.Add(licencePlate);
            Controls.Add(id);
            Controls.Add(DescriptionInput);
            Controls.Add(NumberInput);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MaximumSize = new Size(1153, 474);
            MinimizeBox = false;
            MinimumSize = new Size(1153, 474);
            Name = "DetailsForm";
            Text = "Details";
            ((System.ComponentModel.ISupportInitialize)NumberInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label point2;
        private Label details;
        private Label longitudeCoord2;
        private Label longitude2;
        private Label latitudeCoord2;
        private Label latitude2;
        private Label longitudeCoord1;
        private Label longitude1;
        private Label name;
        private Label latitude1;
        private Label licencePlate;
        private Label surname;
        private Label id;
        private ComboBox Long2CoordInput;
        private ComboBox Lat2CoordInput;
        private NumericUpDown Longitude2Input;
        private NumericUpDown Latitude2Input;
        private ComboBox Long1CoordInput;
        private ComboBox Lat1CoordInput;
        private NumericUpDown Longitude1Input;
        private NumericUpDown Latitude1Input;
        private TextBox DescriptionInput;
        private NumericUpDown NumberInput;
        private CheckBox EditCheckBox;
        private ListBox listBox1;
        private Button EditButton;
        private Button CancelButton;
        private TextBox NameInput;
        private TextBox SurnameInput;
        private Button DeleteButton;
    }
}