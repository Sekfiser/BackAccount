namespace Lab2
{
    /// <summary>
    /// Счёт
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Баланс счёта
        /// </summary>
        static int Balance = 0;
        /// <summary>
        /// Типы операций
        /// RECEIPT - пополнение
        /// PAYMENT - платёж
        /// WITHDRAWAL - снятие наличных
        /// </summary>
        public enum TransactionType { RECEIPT, PAYMENT, WITHDRAWAL }
        /// <summary>
        /// Список операций на счёте
        /// </summary>
        List<Transaction> Transactions = new List<Transaction>();

        /// <summary>
        /// Операция
        /// </summary>
        abstract public class Transaction
        {
            /// <summary>
            /// Идентификатор
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// Сумма операции
            /// </summary>
            public int transactionAmount { get; set; }
            /// <summary>
            /// Баланс на момент операции
            /// </summary>
            public int transactBalance { get; set; }
            /// <summary>
            /// Дата и время операции
            /// </summary>
            public DateTime date { get; set; }
            /// <summary>
            /// Тип операции
            /// </summary>
            public TransactionType type { get; set; }
            /// <summary>
            /// Класс операции
            /// </summary>
            /// <param name="id">Идентификатор</param>
            /// <param name="amount">Сумма</param>
            public Transaction(int id, int amount)
            {
                this.id = id;
                this.transactionAmount = amount;
                this.date = DateTime.Now;
            }

            override public string ToString()
            {
                return '\n' + "Transaction ID: " + this.id + '\n'
                 + "Type: " + this.type + '\n'
                 + "Date: " + this.date + '\n'
                 + "Amount: " + this.transactionAmount + '\n'
                 + "Balance after operation: " + this.transactBalance + '\n';
            }
        }
        /// <summary>
        /// Класс операции снятия
        /// </summary>
        public class Withdrawal : Transaction
        {
            /// <summary>
            /// Операция снятия
            /// </summary>
            /// <param name="id">Идентификатор</param>
            /// <param name="amount">Сумма</param>
            public Withdrawal(int id, int amount) : base(id, amount)
            {
                Balance -= amount;
                this.transactBalance = Balance;
                this.type = TransactionType.WITHDRAWAL;
            }

        }
        /// <summary>
        /// Класс операции платежа
        /// </summary>
        public class Payment : Transaction
        {
            /// <summary>
            /// Операция платежа
            /// </summary>
            /// <param name="id">Идентификатор</param>
            /// <param name="amount">Сумма</param>
            public Payment(int id, int amount) : base(id, amount)
            {
                Balance -= amount;
                this.transactBalance = Balance;
                this.type = TransactionType.PAYMENT;
            }
        }
        /// <summary>
        /// Класс операции пополнения
        /// </summary>
        public class Receipt : Transaction
        {
            /// <summary>
            /// Операция пополнения
            /// </summary>
            /// <param name="id">Идентификатор</param>
            /// <param name="amount">Сумма</param>
            public Receipt(int id, int amount) : base(id, amount)
            {
                Balance += amount;
                this.transactBalance = Balance;
                this.type = TransactionType.RECEIPT;
            }
        }
        /// <summary>
        /// Проведение операции в зависимости от типа
        /// Является фабрикой по созданию операция на счете
        /// </summary>
        /// <param name="type">Тип операции</param>
        /// <param name="amount">Сумма</param>
        /// <exception cref="ArgumentException"></exception>
        public void Transact(TransactionType type, int amount)
        {
            Transaction transaction;

            switch (type)
            {
                case TransactionType.WITHDRAWAL:
                    transaction = new Withdrawal(Transactions.Count, amount);
                    break;

                case TransactionType.PAYMENT:
                    transaction = new Payment(Transactions.Count, amount);
                    break;

                case TransactionType.RECEIPT:
                    transaction = new Receipt(Transactions.Count, amount);
                    break;
                default: throw new ArgumentException();
            }

            Transactions.Add(transaction);
        }

        public override string ToString()
        {
            string result = "";
            foreach (var transaction in Transactions)
            {
                result += transaction.ToString();
            }

            return result;
        }
    }
}
