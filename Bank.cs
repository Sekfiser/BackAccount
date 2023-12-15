namespace Lab2
{
    /// <summary>
    /// Банк содержащий счёт
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// Проведение операций с счётом
        /// </summary>
        public void Operate()
        {
            Account account = new Account();

            account.Transact(Account.TransactionType.RECEIPT, 2000);
            account.Transact(Account.TransactionType.PAYMENT, 100);
            account.Transact(Account.TransactionType.WITHDRAWAL, 1500);

            Console.WriteLine(account.ToString());
        }
    }
}
