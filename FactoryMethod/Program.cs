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

        static void Main(string[] args)
        {
            IFanFactory fanFactory = new Fan1Factory();
            var fan1 = fanFactory.CreateFan();
            Console.WriteLine("Hello, World!");
        }
    }
}