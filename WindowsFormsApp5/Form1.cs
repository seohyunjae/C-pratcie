using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class tboxName : Form
    {
        public tboxName()
        {
            InitializeComponent();
        }

        enum enumDay
        {
            Monday,
            Tuesday,
            wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        enum enumTime
        {
            Morning,
            Afternoon,
            evening
        }

        private void tboxName_Load(object sender, EventArgs e)
        {
            lboxDay.Items.Add(enumDay.Monday.ToString());
            lboxDay.Items.Add(enumDay.Tuesday.ToString());
            lboxDay.Items.Add(enumDay.wednesday.ToString());
            lboxDay.Items.Add(enumDay.Thursday.ToString());
            lboxDay.Items.Add(enumDay.Friday.ToString());
            lboxDay.Items.Add(enumDay.Saturday.ToString());
            lboxDay.Items.Add(enumDay.Sunday.ToString());
        }
    }
}
