namespace SimpleFactory
{
    internal class Program
    {
        enum FanType
        {
            TableFan,
            CeilingFan,
            ExhaustFan
        }

        interface IFan
        {
            void SwitchOn();
            void SwitchOff();
        }

        //class TableFan : IFan
        class TableFan : IFan
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

        class CeilingFan : IFan
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

        class ExhaustFan : IFan
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

        interface IFanFactory
        {
            IFan CreateFan(FanType type);
        }

        class FanFactory : IFanFactory
        {
            public IFan CreateFan(FanType type)
            {
                switch (type)
                {
                    case FanType.TableFan:
                        return new TableFan();
                    case FanType.CeilingFan:
                        return new CeilingFan();
                    case FanType.ExhaustFan:
                        return new ExhaustFan();
                    default:
                        return new TableFan();
                }
            }
        }

        //The client code is as follows:
        static void Main(string[] args)
        {
            IFanFactory simpleFactory = new FanFactory();
            // Creation of a Fan using Simple Factory
            IFan fan = simpleFactory.CreateFan(FanType.TableFan);
            // Use created object
            fan.SwitchOn();

            Console.ReadLine();
        }
    }
}