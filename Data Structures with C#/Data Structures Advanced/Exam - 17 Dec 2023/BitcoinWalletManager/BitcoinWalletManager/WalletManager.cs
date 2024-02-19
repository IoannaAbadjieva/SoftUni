using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinWalletManager
{
    public class WalletManager : IWalletManager
    {
        private Dictionary<string, Transaction> transactions = new Dictionary<string, Transaction>();
        private Dictionary<string, SortedSet<Transaction>> pendingByUser = new Dictionary<string, SortedSet<Transaction>>();
        private Dictionary<string, HashSet<Transaction>> executedTransactions = new Dictionary<string, HashSet<Transaction>>();


        public void AddTransaction(Transaction transaction)
        {
            this.transactions[transaction.Hash]= transaction;

            if (!this.executedTransactions.ContainsKey(transaction.From))
            {
                this.executedTransactions.Add(transaction.From, new HashSet<Transaction>());
            }

            if (!this.pendingByUser.ContainsKey(transaction.From))
            {
                this.pendingByUser.Add(transaction.From, new SortedSet<Transaction>());
            }

            this.pendingByUser[transaction.From].Add(transaction);
        }

        public Transaction BroadcastTransaction(string txHash)
        {
            if (!this.transactions.ContainsKey(txHash))
            {
                throw new ArgumentException();
            }

            var transaction = this.transactions[txHash];
            this.transactions.Remove(txHash);
            this.pendingByUser[transaction.From].Remove(transaction);
            this.executedTransactions[transaction.From].Add(transaction);


            return transaction;
        }

        public Transaction CancelTransaction(string txHash)
        {
            if (!this.transactions.ContainsKey(txHash))
            {
                throw new ArgumentException();
            }

            var transaction = this.transactions[txHash];
            this.transactions.Remove(txHash);
            this.pendingByUser[transaction.From].Remove(transaction);

            return transaction;
        }

        public bool Contains(string txHash)
        {
            return this.transactions.ContainsKey(txHash);
        }

        public int GetEarliestNonceByUser(string user)
        {
            return this.pendingByUser[user].First().Nonce;
        }

        public IEnumerable<Transaction> GetHistoryTransactionsByUser(string user)
        {
            return this.executedTransactions[user];
        }

        public IEnumerable<Transaction> GetPendingTransactionsByUser(string user)
        {
            return this.pendingByUser[user];
              
        }
    }
}
