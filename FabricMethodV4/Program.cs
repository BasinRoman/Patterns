namespace FabricMethodV4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создадим фабрику компании
            IFabric CompanyFabric = new ShareFabric();
            // Выпустим Анальгин
            IPill analgin =  CompanyFabric.MakePill(new Analgin(300));
            // Выпустим Парацетамол 
            IPill paracetamol = CompanyFabric.MakePill(new Paracetamol(450));
        }

        // создадим интерфейс фабрики
        interface IFabric
        {
            IPill MakePill(IPill Pill);
        }

        // Создадим интерфейс объекта
        interface IPill
        {
            string Name { get; set; } // Имя препарата
            string MadeIn { get; set; } // Страна Производства
        }

        class Analgin : IPill
        {
            public string Name { get; set; }
            public string MadeIn { get; set; }

            private int cost;
            public Analgin(int cost)
            {
                this.Name = "Analgin";
                this.MadeIn = "Izrael";
                this.cost = cost;
            }
        }

        class Paracetamol : IPill
        {
            public string Name { get; set; }
            public string MadeIn { get; set; }
            private int cost;
            public Paracetamol(int cost)
            {
                this.Name = "Paracetamol";
                this.MadeIn = "Russia";
                this.cost = cost;
            }
        }

        class ShareFabric : IFabric
        {
            public IPill MakePill(IPill Pill)
            {
                return Pill;
            }
        }

    }
}