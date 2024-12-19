using System;
using System.Collections;

namespace Homework_Tumakov_8
{
    internal class Program
    {
        static void Task1()
        {
            BankAccount bankAccount1 = new BankAccount(10000);
            BankAccountType accountType = BankAccountType.Current;
            BankAccount bankAccount2 = new BankAccount(accountType);
            BankAccount bankAccount3 = new BankAccount(100000, accountType);

        }
        
        static void Task2()
        {
            BankAccount account = new BankAccount(1000, BankAccountType.Current);

            account.PrintAccountInfo();

            Console.WriteLine("\nВносим 500:\n");
            account.DepositMoney(500);
            Console.WriteLine("Снимаем 200:\n");
            account.WithdrawMoney(200);
            Console.WriteLine();
            Console.WriteLine("Снимаем 1500:");
            account.WithdrawMoney(1500); 

            account.PrintHistoryTransaction();

        }
        
        static void Task3()
        {
            using (BankAccount account = new BankAccount())
            {
                account.DepositMoney(500);
                account.WithdrawMoney(200);
                account.DepositMoney(1000);
            }
            Console.WriteLine("Транзакции записаны в файл.");
        }

        static void Task4()
        {
            
            Song mySong = new Song(); 
            Song song1 = new Song("Hotel California", "Eagles");
            Song song2 = new Song("Stairway to Heaven", "Led Zeppelin", song1);
            Console.WriteLine(song2.Title()); 
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 9.1\n");
            Task1();

            Console.WriteLine("Упражнение 9.2\n");
            Task2();

            Console.WriteLine("Упражнение 9.3");
            Task3();

            Console.WriteLine("\nДомашнее задание 9.1");
            Task4();

        }
    }
}
