using System;

namespace DevTestA.Implementations
{
    public class Zoo : IZoo
    {
        public void AddAnimal(IAnimal animal)
        {
            throw new NotImplementedException();
        }

        public bool ContainsAnimal<T>(int atLeastThisamount) where T : IAnimal
        {
            throw new NotImplementedException();
        }

        public double TotalDailyUpkeep
        {
            get { throw new NotImplementedException(); }
        }

        public IAnimal MostExpensiveAnimal
        {
            get { throw new NotImplementedException(); }
        }
    }
}