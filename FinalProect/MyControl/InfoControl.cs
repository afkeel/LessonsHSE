using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyControl
{   
    public partial class InfoControl : UserControl
    {
        private int playerScore = 0;
        private int playerLvl = 1;
        public int PlayerScore
        {
            get
            {
                return playerScore;
            }
            set
            {
                playerScore += value;
                labelScore.Text = playerScore.ToString();
            }
        }
        public int PlayerLvl
        {
            get
            {
                return playerLvl;
            }
            set
            {
                playerLvl += value;
                labelLvl.Text = playerLvl.ToString();
            }
        }
        public InfoControl()
        {
            InitializeComponent();
        }
    }
}
