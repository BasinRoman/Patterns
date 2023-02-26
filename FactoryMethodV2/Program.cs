using System;
using System.Security.Cryptography.X509Certificates;

namespace FactoryMethodV2
{
    internal class Program
    {

        public abstract class MoneyBase
        {
            // Наименование валюты
            public string name { get; set; }
            // Символ валюты
            public string symbol { get; set; }
            public MoneyBase(string name, string symbol)
            {
                if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(name); }
                if (string.IsNullOrEmpty(symbol)) { throw new ArgumentNullException(symbol); }
                this.name = name;
                this.symbol = symbol;
            }
            public override string ToString()
            {
                return this.name;
            }
        }
        public abstract class CashMachine
        {
            // Название машины
            public string name { get; set; }
            public CashMachine(string name)
            {
                if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(name); }
                this.name = name;
            }
            // Реализация печати валюты
            public abstract MoneyBase[] Create(int count);
            public override string ToString()
            {
                return name;
            }
        }
        // Опишем две валюты Рубли и Доллары
        //
        // RUB
        public class Ruble : MoneyBase
        {
            public int number { get; set;}
            public int denomination { get; set;}
            // Создание валюты Рубль
            public Ruble(int denomination): base ("Russian ruble", "Rub") 
            {
                if (denomination <= 0) { throw new ArgumentException("Номинал валюты должен быть больше нуля", nameof(denomination)); }
                this.denomination = denomination;
                var rnd = new Random();
                this.number = rnd.Next(1, 1999);
            }
            public override string ToString()
            {
                return $"{this.name} - {this.number} - {this.denomination}/{this.symbol}";
            }
        }
        // Dollar
        public class Dollar : MoneyBase
        {
            public Guid guid { get; set;}
            
            public int volume { get; set;}
            public Dollar(int volume) : base ("Dollar", "$")
            {
                if (volume <= 0) { throw new ArgumentException("Номинал валюты должен быть больше 0", nameof(volume)); }
                
                this.volume = volume;
                
                this.guid = Guid.NewGuid();
            }
            public override string ToString()
            {
                return $"{this.name} - {this.guid} - {this.volume}/{this.symbol}";
            }
        }

        // Опишем работу станка для печати рублей и долларов
        //
        // Станок для печати рублей
        public class RubleCashMachine : CashMachine
        {
            private readonly int CountOnPage = 64;
            private int denomination;
            private int[] denominationVariats = { 100, 2000, 5000 };
            public RubleCashMachine(int denomination) : base("Машина для печати российских рублей")
            {
                if (denomination <= 0) { throw new ArgumentException("Номинал купюры должен быть больше нуля", nameof(denomination)); }
                if (!denominationVariats.Contains(denomination)){ throw new ArgumentException("Некорректный номинал купюры", nameof(denomination)); }
                this.denomination = denomination;
            }
            public override MoneyBase[] Create(int pageCount)
            {
                var count = this.CountOnPage * pageCount;
                var money = new MoneyBase[count];
                for (int i = 0; i < count; i++)
                {
                    var ruble = new Ruble(this.denomination);
                    money[i] = ruble;
                }
                return money;
            }
        }
        //Станок для печати долларов
        public class DollarCashMachine : CashMachine
        {
            private readonly int CountOnPage = 90;
            private int denomination;
            private int[] denominationVariats = { 5, 10, 100, 500 };
            public DollarCashMachine(int denomination) : base ("Машина для печати долларов")
            {
                if (denomination <= 0) { throw new ArgumentException("Номинал купюры должен быть больше нуля", nameof(denomination)); }
                if (!denominationVariats.Contains(denomination)) { throw new ArgumentException("Неверно указан номинал купюры", nameof(denomination)); }
                this.denomination = denomination;
            }
            public override MoneyBase[] Create(int pageCount)
            {
                var count = CountOnPage * pageCount;
                var money = new MoneyBase[count];
                for (int i = 0; i < count; i++)
                {
                    var dollar = new Dollar(denomination);
                    money[i] = dollar;  
                }
                return money;
            }
        }

        static void Main(string[] args)
        {
            var DollarCashMachine = new DollarCashMachine(100);
            var RubleCashMachine = new RubleCashMachine(100);
            var newRubles = new List<MoneyBase>();
            var newDollars = new List<MoneyBase>();

            var rublesPageCount = 10;
            var dollarPageCount = 20;
            foreach (var newRublePage in RubleCashMachine.Create(rublesPageCount))
            {
                newRubles.Add(newRublePage);
                Console.WriteLine(newRublePage.ToString());
            }
            foreach (var newDollarPage in DollarCashMachine.Create(dollarPageCount))
            {
                newDollars.Add(newDollarPage);
                Console.WriteLine(newDollarPage.ToString());
            }
            Console.ReadLine();
        }
    }
}
