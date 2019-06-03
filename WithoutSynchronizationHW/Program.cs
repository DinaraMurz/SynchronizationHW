using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WithoutSynchronizationHW
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User
            {
                FullName = "IlanMask",
                BankAccountInUsd = new Money
                {
                    Сurrency = "USD",
                    Column = 10000
                }
            }; 

            var threads = new Thread[20];

            for(int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(ChangeMoneyRandomly));
            }

            foreach (Thread thread in threads)
            {
                Thread.Sleep(200);
                thread.Start(user);
            }

            Console.ReadLine();
        }

        static private void ChangeMoneyRandomly(object user)
        {
            var currentThread = Thread.CurrentThread;
            //Thread.Sleep(300);
            Console.WriteLine($"Поток {currentThread.ManagedThreadId} начал работу ");

            var userAccount = user as User;
            //int position;
            //if (new Random().Next(1) == 1) position = 1;
            //else position = -1;
            userAccount.BankAccountChange(/*position * */ -100);

            Console.WriteLine($"Поток {currentThread.ManagedThreadId} -----Текущий счет аккаунта {userAccount.BankAccountInUsd.Column} ");

            Console.WriteLine($"Поток {currentThread.ManagedThreadId} звкончил работу" );
        }
    }
}
