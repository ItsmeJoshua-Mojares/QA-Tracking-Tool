﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QualityAssuranceTrackingToolV2
{
    public partial class Testingdesign : Form
    {
        public Testingdesign()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //get data form this date hanggang dun sa date na date from
            }
            catch { 
                //dito lagay ang error handling para sa startdate and end date
            }
        }
      
    }
}
