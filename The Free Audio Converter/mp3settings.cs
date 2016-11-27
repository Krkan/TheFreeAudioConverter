using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Free_Audio_Converter
{
    public partial class mp3settings : Form
    {
        public mp3settings()
        {
            InitializeComponent();
        }
        public mp3settings(int min, int max)
        {
            InitializeComponent();
            this.trackBar1.Minimum = min;
            this.trackBar1.Maximum = max;
        }

        public int getTrackBarValue()
        {
            return this.trackBar1.Value;
        }
        public void setTrackBarValues(int min, int max)
        {
            this.trackBar1.Minimum = min;
            this.trackBar1.Maximum = max;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        }
    }
}
