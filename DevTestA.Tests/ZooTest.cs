using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DevTestA.Tests
{
    [TestClass]
    public class ZooTest
    {

        #region Container Configuration

        private static IContainer _container;

        [ClassInitialize]
        public static void SetUpClass(TestContext context)
        {
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IZoo)))
                .Where(x => x.Namespace.Contains("Implementations"))
                .AsImplementedInterfaces();
            _container = builder.Build();
        }

        [ClassCleanup]
        public static void TearDownClass()
        {
            _container.Dispose();
        }

        #endregion End Container Configuration

        [TestMethod]
        public void Can_add_animals_to_zoo()
        {
            var zoo = _container.Resolve<IZoo>();
            var newLion = _container.Resolve<ILion>();

            zoo.AddAnimal(newLion);
        }

        [TestMethod]
        public void Zoo_does_contain_a_lion()
        {
            var zoo = _container.Resolve<IZoo>();
            var newLion = _container.Resolve<ILion>();

            zoo.AddAnimal(newLion);
            Assert.IsTrue(zoo.ContainsAnimal<ILion>(1));
        }

        [TestMethod]
        public void Zoo_can_calculate_upkeep()
        {
            var zoo = _container.Resolve<IZoo>();

            var firstMockAnimal = new Mock<IAnimal>();
            var secondMockAnimal = new Mock<IAnimal>();

            firstMockAnimal.SetupGet(x => x.DailyUpkeep).Returns(35.0);
            secondMockAnimal.SetupGet(x => x.DailyUpkeep).Returns(65.0);

            zoo.AddAnimal(firstMockAnimal.Object);
            zoo.AddAnimal(secondMockAnimal.Object);

            Assert.AreEqual(100.0, zoo.TotalDailyUpkeep, .01);

        }

        [TestMethod]
        public void Zoo_can_find_most_expensive_animal()
        {
            var zoo = _container.Resolve<IZoo>();

            var firstMockAnimal = new Mock<IAnimal>();
            var secondMockAnimal = new Mock<IAnimal>();

            firstMockAnimal.SetupGet(x => x.DailyUpkeep).Returns(35.0);
            secondMockAnimal.SetupGet(x => x.DailyUpkeep).Returns(65.0);

            var cheaperAnimal = firstMockAnimal.Object;
            var expensiveAnimal = secondMockAnimal.Object;


            zoo.AddAnimal(cheaperAnimal);
            zoo.AddAnimal(expensiveAnimal);

            var result = zoo.MostExpensiveAnimal;

            Assert.AreSame(expensiveAnimal, result);
        }

    }

}
