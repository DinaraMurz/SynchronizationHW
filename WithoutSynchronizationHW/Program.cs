using System;
using System.Threading;

namespace WithoutSynchronizationHW
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User
            {
                FullName = "Ванёк",
                BankAccountInUsd = new Money
                {
                    Сurrency = "USD",
                    Column = 10000
                }
            };

            object lockObject = new object();
            var threads = new Thread[20];
            int randomNumber;

            for (int i = 0; i < threads.Length; i++)
            {
                var thread = new Thread(nullArgument =>
                {
                    lock (lockObject)
                    {
                        Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} начал работу(текущее значение: {(user as User).BankAccountInUsd.Column})\n");
                        Thread.Sleep(5 * new Random().Next(500));
                        randomNumber = /*new Random().Next(1000) - 500;*/-100; //временно для сравнени конечного результата
                        user.BankAccountInUsd.Column += randomNumber;
                        Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}(изменения {randomNumber})\n");
                        Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} конечный результат: {(user as User).BankAccountInUsd.Column}\n");
                }
                });
            threads[i] = thread;
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            Console.ReadLine();
            Console.WriteLine($"{user.FullName} получил увидомление о счете его банковского аккаунта со счётом: {user.BankAccountInUsd.Column}");
            Console.ReadLine();
        }
    }
}
