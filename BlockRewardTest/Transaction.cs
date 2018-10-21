using System;
using System.Collections.Generic;
using System.Text;

namespace BlockRewardTest
{
    class Transaction
    {
        private int _id;
        private int _size;
        private Double _fee;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public Double Fee
        {
            get { return _fee; }
            set { _fee = value; }
        }

        public Transaction(int id1, int size1, Double fee1) => (ID, Size, Fee) = (id1, size1, fee1);
    }

    class ItemEqualityComparer : IEqualityComparer<Transaction>
    {
        public bool Equals(Transaction x, Transaction y)
        {
            // Two items are equal if their keys are equal.
            return x.ID == y.ID;
        }

        public int GetHashCode(Transaction obj)
        {
            return obj.ID.GetHashCode();
        }
    }
}
