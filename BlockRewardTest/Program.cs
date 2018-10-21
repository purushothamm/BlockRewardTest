using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockRewardTest
{
    class Program
    {
        //Transaction nTrans = new Transaction();
        List<Transaction> lTrans = new List<Transaction>();

        static void Main(string[] args)
        {
            Program PR = new Program();
            Console.WriteLine("Inserting transactions");
            PR.InsertTransactions();
            PR.lTrans.ForEach(Console.WriteLine);
            Console.WriteLine("");
            Console.WriteLine("Max Reward on transactions = ", PR.CalculateMaxReward());
            Console.Read();
        }

        public void InsertTransactions()
        {
            lTrans.AddRange(new List<Transaction>
            {
                new Transaction(1,57247,0.0887),
                new Transaction(2,98732,0.1856),
                new Transaction(3,134928,0.2307),
                new Transaction(4,77275,0.1522),
                //new Transaction(5,29240,0.0532),
                new Transaction(6,15440,0.025),
                //new Transaction(7,70820,0.1409),
                new Transaction(8,139603,0.2541),
                //new Transaction(9,63718,0.1147),
                //new Transaction(10,143807,0.266),
                //new Transaction(11,190457,0.2933),
                //new Transaction(12,40572,0.0686),
            });
        }

        public double CalculateMaxReward()
        {
            double TranReward = 0;
            int MaxSize = 1000000;
            int nSize = 0;
            double BlockReward = 12.5;
            double TotalReward = 0;
            //HashSet<Transaction> hTrans = new HashSet<Transaction>(lTrans);
            List<Transaction> nTrans = lTrans.Distinct(new ItemEqualityComparer()).OrderByDescending(t => t.Fee).ToList();

            foreach(Transaction nt in nTrans)
            {
                if (nSize + nt.Size <= MaxSize)
                {
                    nSize = nSize + nt.Size;
                    TranReward = TranReward + nt.Fee;
                }
                else
                    break;
            }
            TotalReward = BlockReward + TranReward;
            Console.WriteLine("Max Reward =", TotalReward);
            return TotalReward;
        }
    }
}
