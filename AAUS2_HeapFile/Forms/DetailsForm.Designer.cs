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
            details.Location = new Point(103, 76);
            details.Name = "details";
            details.Size = new Size(42, 15);
            details.TabIndex = 46;
            details.Text = "Details";
            // 
            // surname
            // 
            surname.AutoSize = true;
            surname.Location = new Point(12, 149);
            surname.Name = "surname";
            surname.Size = new Size(54, 15);
            surname.TabIndex = 40;
            surname.Text = "Surname";
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(12, 118);
            name.Name = "name";
            name.Size = new Size(39, 15);
            name.TabIndex = 39;
            name.Text = "Name";
            // 
            // licencePlate
            // 
            licencePlate.AutoSize = true;
            licencePlate.Location = new Point(8, 44);
            licencePlate.Name = "licencePlate";
            licencePlate.Size = new Size(76, 15);
            licencePlate.TabIndex = 37;
            licencePlate.Text = "Licence Plate";
            // 
            // id
            // 
            id.AutoSize = true;
            id.Location = new Point(8, 14);
            id.Name = "id";
            id.Size = new Size(18, 15);
            id.TabIndex = 36;
            id.Text = "ID";
            // 
            // DescriptionInput
            // 
            DescriptionInput.Location = new Point(112, 41);
            DescriptionInput.Name = "DescriptionInput";
            DescriptionInput.ReadOnly = true;
            DescriptionInput.Size = new Size(120, 23);
            DescriptionInput.TabIndex = 27;
            // 
            // NumberInput
            // 
            NumberInput.Location = new Point(112, 12);
            NumberInput.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            NumberInput.Name = "NumberInput";
            NumberInput.ReadOnly = true;
            NumberInput.Size = new Size(120, 23);
            NumberInput.TabIndex = 26;
            NumberInput.TabStop = false;
            // 
            // EditCheckBox
            // 
            EditCheckBox.AutoSize = true;
            EditCheckBox.Location = new Point(15, 217);
            EditCheckBox.Name = "EditCheckBox";
            EditCheckBox.Size = new Size(51, 19);
            EditCheckBox.TabIndex = 48;
            EditCheckBox.Text = "Edit?";
            EditCheckBox.UseVisualStyleBackColor = true;
            EditCheckBox.CheckedChanged += EditCheckBox_CheckedChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(290, 14);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(498, 169);
            listBox1.TabIndex = 49;
            // 
            // EditButton
            // 
            EditButton.DialogResult = DialogResult.OK;
            EditButton.Enabled = false;
            EditButton.Location = new Point(620, 217);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(75, 23);
            EditButton.TabIndex = 51;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(711, 217);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 50;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // NameInput
            // 
            NameInput.Location = new Point(112, 115);
            NameInput.Name = "textBox1";
            NameInput.ReadOnly = true;
            NameInput.Size = new Size(120, 23);
            NameInput.TabIndex = 52;
            // 
            // SurnameInput
            // 
            SurnameInput.Location = new Point(112, 146);
            SurnameInput.Name = "textBox2";
            SurnameInput.ReadOnly = true;
            SurnameInput.Size = new Size(120, 23);
            SurnameInput.TabIndex = 53;
            // 
            // DetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 268);
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
            MaximizeBox = false;
            MaximumSize = new Size(814, 307);
            MinimizeBox = false;
            MinimumSize = new Size(814, 307);
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