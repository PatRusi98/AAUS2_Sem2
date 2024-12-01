namespace AAUS2_SemPraca.Forms
{
    partial class SearchForm
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
            id = new Label();
            SearchByInput = new ComboBox();
            SearchIDInput = new NumericUpDown();
            SearchButton = new Button();
            CancelButton = new Button();
            licencePlate = new Label();
            SearchLicencePlate = new TextBox();
            searchLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)SearchIDInput).BeginInit();
            SuspendLayout();
            // 
            // id
            // 
            id.AutoSize = true;
            id.Location = new Point(7, 57);
            id.Name = "id";
            id.Size = new Size(18, 15);
            id.TabIndex = 26;
            id.Text = "ID";
            // 
            // SearchByInput
            // 
            SearchByInput.FormattingEnabled = true;
            SearchByInput.Location = new Point(110, 6);
            SearchByInput.Name = "SearchByInput";
            SearchByInput.Size = new Size(121, 23);
            SearchByInput.TabIndex = 22;
            // 
            // SearchIDInput
            // 
            SearchIDInput.Location = new Point(111, 55);
            SearchIDInput.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            SearchIDInput.Name = "SearchIDInput";
            SearchIDInput.Size = new Size(120, 23);
            SearchIDInput.TabIndex = 21;
            // 
            // SearchButton
            // 
            SearchButton.DialogResult = DialogResult.OK;
            SearchButton.Location = new Point(39, 139);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 29;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(130, 139);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 28;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // licencePlate
            // 
            licencePlate.AutoSize = true;
            licencePlate.Location = new Point(7, 86);
            licencePlate.Name = "licencePlate";
            licencePlate.Size = new Size(76, 15);
            licencePlate.TabIndex = 31;
            licencePlate.Text = "Licence Plate";
            // 
            // SearchLicencePlate
            // 
            SearchLicencePlate.Location = new Point(111, 86);
            SearchLicencePlate.MaxLength = 10;
            SearchLicencePlate.Name = "SearchLicencePlate";
            SearchLicencePlate.Size = new Size(119, 23);
            SearchLicencePlate.TabIndex = 32;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(7, 9);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(55, 15);
            searchLabel.TabIndex = 33;
            searchLabel.Text = "SearchBy";
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(242, 180);
            Controls.Add(searchLabel);
            Controls.Add(SearchLicencePlate);
            Controls.Add(licencePlate);
            Controls.Add(SearchButton);
            Controls.Add(CancelButton);
            Controls.Add(id);
            Controls.Add(SearchByInput);
            Controls.Add(SearchIDInput);
            MaximizeBox = false;
            MaximumSize = new Size(258, 219);
            MinimizeBox = false;
            MinimumSize = new Size(258, 219);
            Name = "SearchForm";
            Text = "Search";
            ((System.ComponentModel.ISupportInitialize)SearchIDInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label longitudeCoord;
        private Label id;
        private Label latitudeCoord;
        private Label latitude;
        private ComboBox LongCoordInput;
        private ComboBox SearchByInput;
        private NumericUpDown SearchIDInput;
        private NumericUpDown LatitudeInput;
        private Button SearchButton;
        private Button CancelButton;
        private Label licencePlate;
        private TextBox SearchLicencePlate;
        private Label searchLabel;
    }
}