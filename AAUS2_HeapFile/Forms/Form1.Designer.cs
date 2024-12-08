namespace AAUS2_SemPraca
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Menu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            Exit = new ToolStripMenuItem();
            vehicleToolStripMenuItem = new ToolStripMenuItem();
            InsertParcel = new ToolStripMenuItem();
            SearchParcel = new ToolStripMenuItem();
            FindAllParcels = new ToolStripMenuItem();
            generatorToolStripMenuItem = new ToolStripMenuItem();
            generateToolStripMenuItem = new ToolStripMenuItem();
            RandomOperations = new ToolStripMenuItem();
            DataGrid = new DataGridView();
            NameColumn = new DataGridViewTextBoxColumn();
            SurnameColumn = new DataGridViewTextBoxColumn();
            IDColumn = new DataGridViewTextBoxColumn();
            LicencePlateColumn = new DataGridViewTextBoxColumn();
            Details = new DataGridViewButtonColumn();
            sequentialPrintToolStripMenuItem = new ToolStripMenuItem();
            dataHeapFileToolStripMenuItem = new ToolStripMenuItem();
            iDHashFileToolStripMenuItem = new ToolStripMenuItem();
            licencePlatesToolStripMenuItem = new ToolStripMenuItem();
            Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            SuspendLayout();
            // 
            // Menu
            // 
            Menu.ImageScalingSize = new Size(24, 24);
            Menu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, vehicleToolStripMenuItem, generatorToolStripMenuItem, sequentialPrintToolStripMenuItem });
            Menu.Location = new Point(0, 0);
            Menu.Name = "Menu";
            Menu.Padding = new Padding(4, 1, 0, 1);
            Menu.Size = new Size(1578, 24);
            Menu.TabIndex = 0;
            Menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Exit });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 22);
            fileToolStripMenuItem.Text = "File";
            // 
            // Exit
            // 
            Exit.Name = "Exit";
            Exit.Size = new Size(93, 22);
            Exit.Text = "Exit";
            Exit.Click += Exit_Click;
            // 
            // vehicleToolStripMenuItem
            // 
            vehicleToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { InsertParcel, SearchParcel, FindAllParcels });
            vehicleToolStripMenuItem.Name = "vehicleToolStripMenuItem";
            vehicleToolStripMenuItem.Size = new Size(56, 22);
            vehicleToolStripMenuItem.Text = "Vehicle";
            // 
            // InsertParcel
            // 
            InsertParcel.Name = "InsertParcel";
            InsertParcel.Size = new Size(114, 22);
            InsertParcel.Text = "Insert";
            InsertParcel.Click += InsertVehicle_Click;
            // 
            // SearchParcel
            // 
            SearchParcel.Name = "SearchParcel";
            SearchParcel.Size = new Size(114, 22);
            SearchParcel.Text = "Search";
            SearchParcel.Click += SearchVehicle_Click;
            // 
            // FindAllParcels
            // 
            FindAllParcels.Name = "FindAllParcels";
            FindAllParcels.Size = new Size(114, 22);
            FindAllParcels.Text = "Find All";
            FindAllParcels.Click += FindAllVehicles_Click;
            // 
            // generatorToolStripMenuItem
            // 
            generatorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generateToolStripMenuItem, RandomOperations });
            generatorToolStripMenuItem.Name = "generatorToolStripMenuItem";
            generatorToolStripMenuItem.Size = new Size(71, 22);
            generatorToolStripMenuItem.Text = "Generator";
            // 
            // generateToolStripMenuItem
            // 
            generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            generateToolStripMenuItem.Size = new Size(180, 22);
            generateToolStripMenuItem.Text = "Generate...";
            generateToolStripMenuItem.Click += generateToolStripMenuItem_Click;
            // 
            // RandomOperations
            // 
            RandomOperations.Name = "RandomOperations";
            RandomOperations.Size = new Size(180, 22);
            RandomOperations.Text = "Random operations";
            RandomOperations.Click += RandomOperations_Click;
            // 
            // DataGrid
            // 
            DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrid.Columns.AddRange(new DataGridViewColumn[] { NameColumn, SurnameColumn, IDColumn, LicencePlateColumn, Details });
            DataGrid.Location = new Point(8, 22);
            DataGrid.Margin = new Padding(2);
            DataGrid.MaximumSize = new Size(1565, 828);
            DataGrid.MinimumSize = new Size(1565, 828);
            DataGrid.Name = "DataGrid";
            DataGrid.RowHeadersWidth = 62;
            DataGrid.Size = new Size(1565, 828);
            DataGrid.TabIndex = 1;
            DataGrid.CellContentClick += DataGrid_CellContentClick;
            // 
            // NameColumn
            // 
            NameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            NameColumn.FillWeight = 85.9090958F;
            NameColumn.HeaderText = "Name";
            NameColumn.MinimumWidth = 150;
            NameColumn.Name = "NameColumn";
            NameColumn.ReadOnly = true;
            NameColumn.Width = 150;
            // 
            // SurnameColumn
            // 
            SurnameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            SurnameColumn.FillWeight = 85.9090958F;
            SurnameColumn.HeaderText = "Surname";
            SurnameColumn.MinimumWidth = 150;
            SurnameColumn.Name = "SurnameColumn";
            SurnameColumn.ReadOnly = true;
            SurnameColumn.Width = 150;
            // 
            // IDColumn
            // 
            IDColumn.FillWeight = 85.9090958F;
            IDColumn.HeaderText = "ID";
            IDColumn.MinimumWidth = 8;
            IDColumn.Name = "IDColumn";
            IDColumn.ReadOnly = true;
            // 
            // LicencePlateColumn
            // 
            LicencePlateColumn.FillWeight = 85.9090958F;
            LicencePlateColumn.HeaderText = "Licence Plate";
            LicencePlateColumn.MinimumWidth = 8;
            LicencePlateColumn.Name = "LicencePlateColumn";
            LicencePlateColumn.ReadOnly = true;
            // 
            // Details
            // 
            Details.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Details.FillWeight = 170.454544F;
            Details.HeaderText = "Details";
            Details.MinimumWidth = 100;
            Details.Name = "Details";
            Details.Text = "Details";
            // 
            // sequentialPrintToolStripMenuItem
            // 
            sequentialPrintToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dataHeapFileToolStripMenuItem, iDHashFileToolStripMenuItem, licencePlatesToolStripMenuItem });
            sequentialPrintToolStripMenuItem.Name = "sequentialPrintToolStripMenuItem";
            sequentialPrintToolStripMenuItem.Size = new Size(102, 22);
            sequentialPrintToolStripMenuItem.Text = "Sequential Print";
            // 
            // dataHeapFileToolStripMenuItem
            // 
            dataHeapFileToolStripMenuItem.Name = "dataHeapFileToolStripMenuItem";
            dataHeapFileToolStripMenuItem.Size = new Size(180, 22);
            dataHeapFileToolStripMenuItem.Text = "Data";
            dataHeapFileToolStripMenuItem.Click += dataHeapFileToolStripMenuItem_Click;
            // 
            // iDHashFileToolStripMenuItem
            // 
            iDHashFileToolStripMenuItem.Name = "iDHashFileToolStripMenuItem";
            iDHashFileToolStripMenuItem.Size = new Size(180, 22);
            iDHashFileToolStripMenuItem.Text = "ID";
            iDHashFileToolStripMenuItem.Click += iDHashFileToolStripMenuItem_Click;
            // 
            // licencePlatesToolStripMenuItem
            // 
            licencePlatesToolStripMenuItem.Name = "licencePlatesToolStripMenuItem";
            licencePlatesToolStripMenuItem.Size = new Size(180, 22);
            licencePlatesToolStripMenuItem.Text = "Licence Plates";
            licencePlatesToolStripMenuItem.Click += licencePlatesToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 867);
            Controls.Add(DataGrid);
            Controls.Add(Menu);
            MainMenuStrip = Menu;
            Margin = new Padding(2);
            MaximumSize = new Size(1598, 906);
            MinimumSize = new Size(1347, 634);
            Name = "Form1";
            Text = "AAUS2 SemPraca";
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DataGrid;
        private MenuStrip Menu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem vehicleToolStripMenuItem;
        private ToolStripMenuItem Exit;
        private ToolStripMenuItem InsertParcel;
        private ToolStripMenuItem SearchParcel;
        private ToolStripMenuItem generatorToolStripMenuItem;
        private ToolStripMenuItem generateToolStripMenuItem;
        private ToolStripMenuItem RandomOperations;
        private ToolStripMenuItem FindAllParcels;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn SurnameColumn;
        private DataGridViewTextBoxColumn IDColumn;
        private DataGridViewTextBoxColumn LicencePlateColumn;
        private DataGridViewButtonColumn Details;
        private ToolStripMenuItem sequentialPrintToolStripMenuItem;
        private ToolStripMenuItem dataHeapFileToolStripMenuItem;
        private ToolStripMenuItem iDHashFileToolStripMenuItem;
        private ToolStripMenuItem licencePlatesToolStripMenuItem;
    }
}
