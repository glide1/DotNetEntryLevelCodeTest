namespace DevTestA
{
    public interface IZoo
    {
        /// <summary>
        /// Add the animal to the zoo
        /// </summary>
        /// <param name="animal">The animal to add to the zoo.</param>
        void AddAnimal(IAnimal animal);

        /// <summary>
        /// Sees if the zoo contains an animal
        /// </summary>
        /// <typeparam name="T">The type of animal</typeparam>
        /// <param name="atLeastThisamount">The amount of the type of animal it should at least have</param>
        /// <returns>True if it has at least that amount of animal, false otherwise</returns>
        bool ContainsAnimal<T>(int atLeastThisamount) where T : IAnimal;

        double TotalDailyUpkeep { get; }
        IAnimal MostExpensiveAnimal { get; }
    }
}