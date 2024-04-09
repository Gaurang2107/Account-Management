using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace assignment_4_c_
{
    public partial class Authentication : Form
    {
        ApplicationDB applicationDB = new ApplicationDB();
        public Authentication()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int isValid = applicationDB.AuthenticateUser(txtusername.Text, txtpass.Text);
            if (isValid != 0)
            {
                TransHis transHis = new TransHis(isValid);
                transHis.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpass.Text = "";
        }
    }
}
