using assignment_4_c_.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_4_c_
{
    public class ApplicationDB
    {
        MMABooksContext mMABooksContext;

        public ApplicationDB()
        {
            mMABooksContext = new MMABooksContext();
        }

        public int AuthenticateUser(string username, string password)
        {
            var user = mMABooksContext.Users.FirstOrDefault(u => u.Email == username && u.Password == password);
            return user != null ? user.Id : 0;
        }

        public Account GetAccountDetails(int userId)
        {
            return mMABooksContext.Accounts.FirstOrDefault(acc => acc.UserId == userId);
        }

        public void AddTransaction(int accountId, decimal amount, string description)
        {
            var account = mMABooksContext.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            if (account != null)
            {
                account.CurrentBalance = ((double)(account.CurrentBalance ?? 0) - (double)amount);
                var transaction = new TransactionHistory
                {
                    AccountId = accountId,
                    Amount = amount,
                    Description = description
                };

                mMABooksContext.TransactionHistories.Add(transaction);
                mMABooksContext.SaveChanges();
            }
        }
        public TransactionHistory GetTransactionById(int transactionId)
        {
            return mMABooksContext.TransactionHistories.FirstOrDefault(tran => tran.TransactionId == transactionId);
        }
        public void UpdateTransaction(int transactionId, decimal newAmount, string newDescription)
        {
            var transaction = mMABooksContext.TransactionHistories.FirstOrDefault(tran => tran.TransactionId == transactionId);
            if (transaction != null)
            {
                transaction.Amount = newAmount;
                transaction.Description = newDescription;
                mMABooksContext.SaveChanges();
            }
        }

        public void DeleteTransaction(int transactionId)
        {
            var transaction = mMABooksContext.TransactionHistories.FirstOrDefault(t => t.TransactionId == transactionId);
            if (transaction != null)
            {
                var account = mMABooksContext.Accounts.FirstOrDefault(acc => acc.AccountId == transaction.AccountId);
                if (account != null)
                {
                    account.CurrentBalance += (double)transaction.Amount;
                }
                mMABooksContext.TransactionHistories.Remove(transaction);
                mMABooksContext.SaveChanges();
            }
        }
        public List<object> GetUserAccountTransactions(int userId)
        {
            var query = from transaction in mMABooksContext.TransactionHistories
                        join account in mMABooksContext.Accounts on transaction.AccountId equals account.AccountId
                        join user in mMABooksContext.Users on account.UserId equals user.Id
                        where account.UserId == userId
                        select new
                        {
                            TransactionId = transaction.TransactionId,
                            AccountId = transaction.AccountId,
                            FirstName = user.Firstname,
                            LastName = user.Lastname,
                            Amount = transaction.Amount,
                            CurrentBalance = account.CurrentBalance,
                            Description = transaction.Description,
                            TransactionDate = transaction.TransactionDate,
                        };

            return query.ToList<object>();
        }
    }
}