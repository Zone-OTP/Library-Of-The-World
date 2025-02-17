using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryOfTheWorld.Forms
{
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();
        }
        private static Library instance;
        public static Library Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new Library();
                return instance;
            }
        }
        private void Library_Load(object sender, EventArgs e)
        {

        }

        private void Library_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
