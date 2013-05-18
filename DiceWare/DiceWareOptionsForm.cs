using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceWare
{
    public partial class DiceWareOptionsForm : Form
    {
        private string m_CurrentOptions;

        public DiceWareOptionsForm(string strCurrentOptions)
        {
            InitializeComponent();

            this.m_CurrentOptions = strCurrentOptions;

            int n;
            if (int.TryParse(this.m_CurrentOptions, out n))
            {
                this.nudWordCount.Value = n;
            }

        }

        internal string GetOptions()
        {
            return this.m_CurrentOptions;
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            m_CurrentOptions = Convert.ToInt32(nudWordCount.Value).ToString();
        }
    }
}
