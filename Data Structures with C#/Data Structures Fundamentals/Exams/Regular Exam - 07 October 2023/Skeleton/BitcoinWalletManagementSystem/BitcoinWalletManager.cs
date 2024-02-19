using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinWalletManagementSystem
{
    public class BitcoinWalletManager : IBitcoinWalletManager
    {

        private HashSet<User> users = new HashSet<User>();
        private HashSet<Wallet> wallets = new HashSet<Wallet>();
        private Dictionary<string, List<Transaction>> usersTransactions = new Dictionary<string, List<Transaction>>();
        private Dictionary<string, HashSet<Wallet>> usersWallets = new Dictionary<string, HashSet<Wallet>>();


        public void CreateUser(User user)
        {
            users.Add(user);
            usersWallets.Add(user.Id, new HashSet<Wallet>());
            usersTransactions.Add(user.Id, new List<Transaction>());
        }

        public void CreateWallet(Wallet wallet)
        {
            wallets.Add(wallet);
            usersWallets[wallet.UserId].Add(wallet);
        }

        public bool ContainsUser(User user)
        {
            return users.Contains(user);
        }

        public bool ContainsWallet(Wallet wallet)
        {
            return wallets.Contains(wallet);
        }

        public IEnumerable<Wallet> GetWalletsByUser(string userId)
        {
            return wallets
                    .Where(wallet => wallet.UserId == userId);
        }

        public void PerformTransaction(Transaction transaction)
        {
            var senderWallet = wallets.FirstOrDefault(w => w.Id == transaction.SenderWalletId);
            var receiverWallet = wallets.FirstOrDefault(w => w.Id == transaction.ReceiverWalletId);

            if (senderWallet == null || receiverWallet == null)
            {
                throw new ArgumentException();
            }

            if (senderWallet.Balance < transaction.Amount)
            {
                throw new ArgumentException();
            }

            senderWallet.Balance -= transaction.Amount;
            receiverWallet.Balance += transaction.Amount;

            usersTransactions[senderWallet.UserId].Add(transaction);
            usersTransactions[receiverWallet.UserId].Add(transaction);

        }

        public IEnumerable<Transaction> GetTransactionsByUser(string userId)
        {
            return this.usersTransactions[userId];
        }

        public IEnumerable<Wallet> GetWalletsSortedByBalanceDescending()
        {

            return wallets.
                OrderByDescending(wallet => wallet.Balance);
        }

        public IEnumerable<User> GetUsersSortedByBalanceDescending()
        {
            return users
                .OrderByDescending(u => usersWallets[u.Id].Sum(w => w.Balance));
        }

        public IEnumerable<User> GetUsersByTransactionCount()
        {
            return users
                .OrderByDescending(u => usersTransactions[u.Id].Count);
        }
    }
}