using System.Windows.Forms;

namespace BasisData01
{
    class KFE
    {
        public static void untukformsapta(Form formsapta, Panel panelsapta)
        {
            panelsapta.Controls.Clear();
            formsapta.FormBorderStyle = FormBorderStyle.None;
            formsapta.Dock = DockStyle.Fill;
            panelsapta.Controls.Add(formsapta);
            formsapta.Show();
        }
    }
}
