

namespace Homework_Tumakov_8
{

    enum BankAccountType
    {
        Current,
        Savings
    }

    class BankAccount : IDisposable
    {


        #region Поля
        /// <summary>
        /// Номер счета.
        /// </summary>
        private int accountNumber;

        private readonly Queue<BankTransaction> _transactionHistory = new Queue<BankTransaction>();

        /// <summary>
        /// Статическая переменная для генерации уникальных номеров счетов.
        /// </summary>
        private static int nextAccountNumber = 0;

        /// <summary>
        /// Баланс счета.
        /// </summary>
        private decimal balance;

        /// <summary>
        /// Тип банковского счета.
        /// </summary>
        private BankAccountType accountType;
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, создающий банковский счет с заданным балансом и типом.
        /// </summary>
        /// <param name="balance">Начальный баланс счета.</param>
        /// <param name="type">Тип банковского счета.</param>
        public BankAccount(decimal balance, BankAccountType type)
        {
            this.accountNumber = AccountNumberGenerator();
            this.balance = balance;
            this.accountType = type;
        }

        /// <summary>
        /// Конструктор, создающий банковский счет с заданным балансом.
        /// </summary>
        /// <param name="balance">Начальный баланс.</param>
        public BankAccount(decimal balance)
        {
            this.accountNumber = AccountNumberGenerator();
            this.balance = balance;
        }

        /// <summary>
        /// Конструктор, создающий банковский счет с типом.
        /// </summary>
        /// <param name="type">Тип банковского счета.</param>
        public BankAccount(BankAccountType type)
        {
            this.accountNumber = AccountNumberGenerator();
            accountType = type;
        }
        /// <summary>
        /// Конструктор по умолчанию, создающий счет с нулевым балансом.
        /// </summary>
        public BankAccount()
        {
            this.accountNumber = AccountNumberGenerator();
            this.balance = 0;

        }
        #endregion


        #region Методы
        /// <summary>
        /// Метод для вывода информации о банковском счете.
        /// </summary>
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {accountNumber}\nБаланс: {balance}\nТип банковского счета: {accountType}");
        }

        /// <summary>
        /// Метод записывающий транзакции в файл.
        /// </summary>
        public void WriteTransactionsToFile()
        {
            try
            {
                
                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string filePath = Path.Combine(projectDirectory, "transactions.txt");

                
                using (StreamWriter writer = new StreamWriter(filePath, append: false))
                {
                    foreach (var transaction in _transactionHistory)
                    {
                        writer.WriteLine(transaction.ToString());
                    }
                }


                _transactionHistory.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи транзакций в файл: {ex.Message}");
            }
            finally
            {
                GC.SuppressFinalize(this);
            }


        }

       
        public void Dispose()
        {
            WriteTransactionsToFile();
            GC.SuppressFinalize(this);

        }

        private int AccountNumberGenerator()
        {
            return nextAccountNumber++;
        }

        
        public void WithdrawMoney(decimal money)
        {
            if ((this.balance - money) >= 0)
            {
                this.balance -= money;

                _transactionHistory.Enqueue(new BankTransaction(-money));
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счету");
            }
        }
        /// <summary>
        /// Метод для вывода истории транзакций.
        /// </summary>
        public void PrintHistoryTransaction()
        {
            Console.WriteLine("История транзакций: ");

            if (_transactionHistory.Count == 0)
            {
                Console.WriteLine("История транзакций пуста.");
                return;
            }

            foreach (var transaction in _transactionHistory)
            {
                Console.WriteLine(transaction);
            }


        }

        /// <summary>
        /// Пополняет сумму на счет.
        /// </summary>
        /// <param name="money">Сумма пополнения.</param>
        public void DepositMoney(decimal money)
        {
            this.balance += money;
            _transactionHistory.Enqueue(new BankTransaction(money));
        }

        public void TransferMoneyTo(BankAccount bankAccount, decimal money)
        {
            if ((this.balance - money) >= 0)
            {
                this.balance -= money;
                bankAccount.balance += money;
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счету");
            }
        }
        #endregion

    }





}
