using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Khamovniki4D
{
    public partial class InputBox : Form
    {
        private static InputBox newInputBox;
        private static string returnString;
        public InputBox()
        {
            InitializeComponent();
            MinimumSize = MaximumSize = Size;
        }
        public static string Show(string inputBoxText)
        {
            newInputBox = new InputBox();
            newInputBox.description.Text = inputBoxText;
            newInputBox.ShowDialog();
            return returnString;
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            returnString = uriInput.Text;
            newInputBox.Dispose();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            returnString = string.Empty;
            newInputBox.Dispose();
        }
    }
}
