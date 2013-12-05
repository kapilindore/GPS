using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Server
{
    public class PubEvent
    {
        /// <summary>
        ///  ˝◊÷ ‰»Î 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void KeyPress_NumInput(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.KeyChar = (char)0;
        }
    }
}
