using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment_4_c_
{
    public partial class AddTrans : Form
    {
        private int UserID;
        private ApplicationDB applicationDB;
        private int? TransactionID;
        public AddTrans(int UserID, ApplicationDB applicationDB, int? TransactionID = null)
        {
            InitializeComponent();
            this.UserID = UserID;
            this.applicationDB = applicationDB;
            this.TransactionID = TransactionID;
            if (TransactionID != null)
            {
                PopulateForm();
            }
        }

        private void PopulateForm()
        {
            var transaction = applicationDB.GetTransactionById((int)TransactionID);
            if (transaction != null)
            {
                txtID.Text = transaction.AccountId.ToString();
                txtAmount.Text = transaction.Amount.ToString();
                txtDescription.Text = transaction.Description;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Invalid amount. Please enter a valid positive number.");
                return;
            }

            string description = txtDescription.Text;

            int accountId;
            if (!int.TryParse(txtID.Text, out accountId))
            {
                MessageBox.Show("Invalid account ID. Please enter a valid number.");
                return;
            }

            if (TransactionID == null)
            {
                applicationDB.AddTransaction(accountId, amount, description);
            }
            else
            {
                applicationDB.UpdateTransaction((int)TransactionID, amount, description);
            }

            MessageBox.Show("Transaction saved successfully.");
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtAmount.Text = "";
            txtDescription.Text = "";
        }
    }
}