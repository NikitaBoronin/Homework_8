

namespace Homework_Tumakov_8
{

    internal class BankTransaction
    {
        #region Поля
        private readonly decimal _amount;
        private readonly DateTime _transactionDate;
        private string _operation;
        #endregion

        #region Конструктор
        public BankTransaction(decimal amount)
        {
            _amount = amount;
            _transactionDate = DateTime.Now;
        }
        #endregion

        #region Свойства
        public decimal Amount { 
            get
            {
                return _amount;
            }
                
            }
        public DateTime TransactionDate { 
            get
            {
                return _transactionDate;
            }
                
            }
        #endregion

        #region Метод
        public override string ToString()
        {
            return $"Сумма транзакции: {_amount}. Дата и время транзакции: {_transactionDate}";
        }
        #endregion

    }
}
