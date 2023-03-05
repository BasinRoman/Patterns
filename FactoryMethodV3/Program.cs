namespace FactoryMethodV3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создадим фабрику по выпуску анальгина
            IFabric analginFabric = new AnalginFabric();
            // Создадим фабрику по выпуску парацетамола
            IFabric paracetamolFabric = new ParacetamolFabric();
            // Создадим анальгин
            IPill analginPill = analginFabric.MakePill();
            // Создадим Парацетамол
            IPill paracetamolPill = paracetamolFabric.MakePill();            
        }

        // создадим интерфейс фабрики
        interface IFabric
        {
            IPill MakePill (); 
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

        class AnalginFabric : IFabric
        {
            public IPill MakePill()
            {
                return new Analgin(350);
            }
        }
        class ParacetamolFabric : IFabric
        {
            public IPill MakePill()
            {
                return new Paracetamol(400);
            }
        }
    }
}