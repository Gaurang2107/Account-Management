using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace assignment_4_c_
{
    public partial class TransHis : Form
    {
        ApplicationDB applicationDB = new ApplicationDB();
        int UserID;
        public TransHis(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
            LoadTrans();
        }

        public void LoadTrans()
        {
            var transactions = applicationDB.GetUserAccountTransactions(UserID);
            dgvHistory.DataSource = transactions;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTrans addTrans = new AddTrans(UserID, applicationDB);
            addTrans.ShowDialog();
            LoadTrans();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvHistory.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("Please select a transaction to update.");
                return;
            }
            int transactionId = (int)selectedRow.Cells["TransactionId"].Value;
            var updateTransactionForm = new AddTrans(UserID, applicationDB, transactionId);
            updateTransactionForm.ShowDialog();
            LoadTrans();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvHistory.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("Please select a transaction to delete.");
                return;
            }
            int transactionId = (int)selectedRow.Cells["TransactionId"].Value;
            applicationDB.DeleteTransaction(transactionId);
            LoadTrans();
        }
    }
}