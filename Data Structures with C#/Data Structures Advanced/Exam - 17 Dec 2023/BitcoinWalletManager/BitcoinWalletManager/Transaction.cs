using System;
using System.Diagnostics.CodeAnalysis;

namespace BitcoinWalletManager
{
    public class Transaction:IComparable<Transaction>
    {
        public string Hash { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public int Value { get; set; }

        public int Nonce { get; set; }

        public int CompareTo(Transaction other)
        {
            return this.Nonce.CompareTo(other.Nonce);
        }

        public override int GetHashCode()
        {
            return this.Hash.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Hash.Equals((obj as Transaction).Hash);
        }
    }
}
