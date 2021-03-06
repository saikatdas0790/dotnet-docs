﻿using System;
using System.Threading;

namespace LockKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10];
            Account acc = new Account(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }

            // block main thread until all other threads have ran to completion
            foreach (var t in threads)
            {
                t.Join();
            }
        }
    }

    class Account
    {
        private Object thisLock = new object();
        int balance;

        Random r = new Random();

        public Account(int initial)
        {
            balance = initial;
        }

        int Withdraw(int amount)
        {
            // This condition never is true unless the lock statement
            // is commented out.
            if (balance < 0)
            {
                throw new Exception("Negative balance");
            }

            // Comment out the next line to see the effect of leaving out
            // the lock keyword
            lock (thisLock)
            {
                if (balance >= amount)
                {
                    Console.WriteLine($"Balance before Withdrawal :  {balance}");
                    Console.WriteLine($"Amount to Withdraw        : -{amount}");
                    balance -= amount;
                    Console.WriteLine($"Balance after Withdrawal  :  {balance}");
                    return amount;
                }
                else
                {
                    return 0;  // transaction rejected
                }
            }
        }

        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }
}
