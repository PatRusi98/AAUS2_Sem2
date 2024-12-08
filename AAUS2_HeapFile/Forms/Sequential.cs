using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAUS2_HeapFile.Forms
{
    public partial class Sequential : Form
    {
        public string SeqString { get; set; }
        public Sequential(string text)
        {
            InitializeComponent();
            SeqString = text;
            SeqTextBox.Text = SeqString;
        }
    }
}
