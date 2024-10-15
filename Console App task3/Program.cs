using System;

class Converter
{
    private decimal UsdExchange;
    private decimal EurExchange;

    public Converter()
    {
        UsdExchange = 41.00M;
        EurExchange = 45.00M;
    }

    public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Сума вiд'ємна!");
        }

        if (fromCurrency == "UAH" && toCurrency == "USD")
        {
            return amount / UsdExchange;
        }
        else if (fromCurrency == "UAH" && toCurrency == "EUR")
        {
            return amount / EurExchange;
        }
        else if (fromCurrency == "USD" && toCurrency == "UAH")
        {
            return amount * UsdExchange;
        }
        else if (fromCurrency == "EUR" && toCurrency == "UAH")
        {
            return amount * EurExchange;
        }
        else if (fromCurrency == toCurrency)
        {
            return amount;
        }
        else
        {
            throw new ArgumentException("Неправильно написанi валюти.");
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Converter converter = new Converter();

            Console.WriteLine("Введiть назву валюти яку хочете конвертувати (UAH, USD, EUR): ");
            string fromCurrency = Console.ReadLine().ToUpper();

            Console.Write($"Введiть суму в {fromCurrency}: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Введiть назву валюти, в яку хочете конвертувати попередню валюту (UAH, USD, EUR): ");
            string toCurrency = Console.ReadLine().ToUpper();

            decimal result = converter.Convert(amount, fromCurrency, toCurrency);

            Console.WriteLine($"Результат конвертацiї: {result} {toCurrency}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: неправильний формат введених даних.");
        }
    }
}