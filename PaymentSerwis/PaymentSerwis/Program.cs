using PaymentSerwis.BankCore;
using PaymentSerwis.PaymentMean;
using PaymentSerwis.PaymentMean.PaymentCard;

try
{
    var number1 = new CardNumber(1234989067865675);
    var number2 = new CardNumber(1234567812345678);
    var number3 = new CardNumber(9999999999999999);
    var number4 = new CardNumber(1111111111111111);
    var number5 = new CardNumber(1000000000000000);
    var number6 = new CardNumber(2222222222222222);
    var number7 = new CardNumber(9898878776766565);
    var number8 = new CardNumber(9812872376345667);
    var number9 = new CardNumber(1267239847624987);
    var number10 = new CardNumber(2479187497928794);
    var number11 = new CardNumber(4567384593854234);
    var number12 = new CardNumber(1234029384930292);
    var number13 = new CardNumber(1234342508329879);
    var number14 = new CardNumber(1234432428798798);
    var number15 = new CardNumber(1234528953057986);

    var validity1 = new Validity(02, 2023);
    var validity2 = new Validity(12, 2026);
    var validity3 = new Validity(01, 2027);
    var validity4 = new Validity(07, 2023);
    var validity5 = new Validity(10, 2028);
    var validity6 = new Validity(05, 2024);
    var validity7 = new Validity(01, 2030);
    var validity8 = new Validity(11, 2040);
    var validity9 = new Validity(03, 2050);
    var validity10 = new Validity(10, 2029);
    var validity11 = new Validity(11, 2031);
    var validity12 = new Validity(01, 2023);
    var validity13 = new Validity(04, 2025);
    var validity14 = new Validity(06, 2067);
    var validity15 = new Validity(08, 2023);

    var bankClient1 = new BankClient("Kate", "Bayok", "Goreckogo 9");
    var bankClient2 = new BankClient("Artyom", "Vasilyev", "Minskaya 1");
    var bankClient3 = new BankClient("Anna", "Antonova", "Pragskaya 123");
    var bankClient4 = new BankClient("Kirill", "Kirkorov", "lotnicza 18");
    var bankClient5 = new BankClient("Anton", "Gigros", "Koszykarska 983");

    var bankClients = new List<BankClient> { bankClient1, bankClient2, bankClient3, bankClient4, bankClient5 };

    bankClient1.AddPaymentMethod(new Cash(100000f));
    bankClient1.AddPaymentMethod(new CashBackCard(number1, validity1, 1000f, 12f));
    bankClient1.AddPaymentMethod(new CreditCard(number6, validity6, 13f, 2000f));
    bankClient1.AddPaymentMethod(new DebetCard(number11, validity11, 100f));
    //bankClient1.AddPaymentMethod(new BitCoin(100f));

    bankClient2.AddPaymentMethod(new Cash(10f));
    bankClient2.AddPaymentMethod(new CashBackCard(number2, validity2, 100f, 2f));
    bankClient2.AddPaymentMethod(new CreditCard(number7, validity7, 22f, 100f));
    bankClient2.AddPaymentMethod(new DebetCard(number12, validity12, 999f));
    bankClient2.AddPaymentMethod(new BitCoin(100f));

    bankClient3.AddPaymentMethod(new Cash(1000f));
    bankClient3.AddPaymentMethod(new CashBackCard(number3, validity3, 300f, 5f));
    bankClient3.AddPaymentMethod(new CreditCard(number8, validity8, 1f, 150f));
    bankClient3.AddPaymentMethod(new DebetCard(number13, validity13, 10f));
    bankClient3.AddPaymentMethod(new BitCoin(100f));

    bankClient4.AddPaymentMethod(new Cash(5000f));
    bankClient4.AddPaymentMethod(new CashBackCard(number4, validity4, 2200f, 20f));
    bankClient4.AddPaymentMethod(new CreditCard(number9, validity9, 30f, 1000f));
    bankClient4.AddPaymentMethod(new DebetCard(number14, validity14, 68543f));
    bankClient4.AddPaymentMethod(new BitCoin(100f));

    bankClient5.AddPaymentMethod(new Cash(10f));
    bankClient5.AddPaymentMethod(new CashBackCard(number5, validity5, 500f, 25f));
    bankClient5.AddPaymentMethod(new CreditCard(number10, validity10, 90f, 5555f));
    bankClient5.AddPaymentMethod(new DebetCard(number15, validity15, 9999f));
    bankClient5.AddPaymentMethod(new BitCoin(100f));

    var sortedName = bankClients.OrderBy(x => x.Name).ToList();

    var sortAddres = bankClients.OrderBy(x => x.Addres).ToList();

    var sortAmountCards = bankClients.OrderBy(x => x.PaymentMethods.Count).ToList();

    Console.WriteLine("Sort by the total amount of money available:");
    var filteredClients = bankClients
        .Select(bankClient => new {bankClient.Name, bankClient.Surname, Balance = bankClient.PaymentMethods
        .Sum(x => x.GetBalance())})
        .OrderBy(x => x.Balance);
    foreach (var x in filteredClients)
    {
        Console.WriteLine($"{x.Balance} - {x.Name} {x.Surname}");
    }

    Console.WriteLine("\nList of all debet cards for the client:");
    var sumDebet = bankClients
        .SelectMany(bankClient => bankClient.PaymentMethods
        .OfType<DebetCard>(), (bankClient, debetCard) => new { bankClient.Name, bankClient.Surname, debetCard.Validity, debetCard.BalanceDebet });
    foreach (var x in sumDebet)
    {
        Console.WriteLine($"{x.Name} {x.Surname}: Validity-{x.Validity.ValidityMonth}/{x.Validity.ValidityYear}, Balance:{x.BalanceDebet} ");
    }

    Console.WriteLine("\nThe richest client:");
    var richestClient = bankClients
        .Select(bankClient => new {BankClient = bankClient, TotalBalance = bankClient.PaymentMethods
        .Sum(paymentMethod => paymentMethod.GetBalance())})
        .OrderByDescending(x => x.TotalBalance)
        .First();
    Console.WriteLine($"{richestClient.BankClient.Name} {richestClient.BankClient.Surname}: {richestClient.TotalBalance}");

    Console.WriteLine("\nClients with BitCoin:");
    var bitCoinClients = bankClients
        .Where(bankClient => bankClient.PaymentMethods
        .Any(x => x is BitCoin))
        .Select(bankClient => new {bankClient.Name, bankClient.Surname, Balance = bankClient.PaymentMethods
        .Sum(paymentMethod => paymentMethod.GetBalance())})
        .OrderByDescending(x => x.Balance);
    foreach (var x in bitCoinClients)
    {
        Console.WriteLine($"{x.Name} {x.Surname}");
    }

    bankClient1.Pay(1000);
    Console.WriteLine(bankClient1.DisplayBalances(bankClient1.PaymentMethods));

    bankClient2.Pay(100);
    Console.WriteLine(bankClient2.DisplayBalances(bankClient2.PaymentMethods));

    bankClient3.Pay(50000);
    Console.WriteLine(bankClient3.DisplayBalances(bankClient3.PaymentMethods));

    bankClient4.Pay(10000);
    Console.WriteLine(bankClient4.DisplayBalances(bankClient4.PaymentMethods));

    bankClient5.Pay(9999);
    Console.WriteLine(bankClient5.DisplayBalances(bankClient5.PaymentMethods));
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
}
