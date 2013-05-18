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
        private DiceWareOptions m_Options = new DiceWareOptions();

        public DiceWareOptionsForm()
        {
            InitializeComponent();

        }

        public DiceWareOptionsForm(string strCurrentOptions)
            : this()
        {

            m_Options.Load(strCurrentOptions);

            this.nudWordCount.Value = m_Options.WordCount;

        }

        internal string GetOptions()
        {
            return m_Options.Save();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            m_Options.WordCount = Convert.ToInt32(this.nudWordCount.Value);
        }
    }
}
