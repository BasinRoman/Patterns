using System;

namespace FactoryMethod
{
    internal class Program
    {
        class Fan1 : IFan
        {
            public void SwitchOff()
            {
                throw new NotImplementedException();
            }

            public void SwitchOn()
            {
                throw new NotImplementedException();
            }
        }
        class Fan2 : IFan
        {
            public void SwitchOff()
            {
                throw new NotImplementedException();
            }

            public void SwitchOn()
            {
                throw new NotImplementedException();
            }
        }
        class Fan3 : IFan
        {
            public void SwitchOff()
            {
                throw new NotImplementedException();
            }

            public void SwitchOn()
            {
                throw new NotImplementedException();
            }
        }
        class Fan4 : IFan
        {
            public void SwitchOff()
            {
                throw new NotImplementedException();
            }

            public void SwitchOn()
            {
                throw new NotImplementedException();
            }
        }

        interface IFan
        {
            void SwitchOn();
            void SwitchOff();
        }
        interface IFanFactory
        {
            IFan CreateFan();
        }
        class Fan1Factory : IFanFactory
        {
            public IFan CreateFan()
            {
                return new Fan1();
            }
        }
        class Fan2Factory : IFanFactory
        {
            public IFan CreateFan()
            {
                return new Fan2();
            }
        }
        // etc for 3,4, fans. 

        static void Main(string[] args)
        {
            IFanFactory fan1Factory = new Fan1Factory();
            var fan1 = fan1Factory.CreateFan();
            IFanFactory fan2Factory = new Fan2Factory();
            var fan2 = fan2Factory.CreateFan();
            Console.WriteLine($"Созданы{fan1.GetType()}и {fan2.GetType()} вентилятора");

        }
    }
}