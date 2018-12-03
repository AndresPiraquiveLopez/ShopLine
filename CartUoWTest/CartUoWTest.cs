using AutoFixture;
using CartBusinessLogic.Initializers;
using CartBusinessLogic.UnitOfWork;
using CartUoWTest.Mocking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CartUoWTest
{
    [TestClass]
    public class CartUoWTest
    {
        private static Fixture _fixture;

        private static ICartUoW _sut;

        private static MockRepositoryProvider _mock;


        [TestInitialize]
        public void TestMethod1()
        {
            _fixture = new Fixture { RepeatCount = 1 };
            _mock = new MockRepositoryProvider(_fixture);

            MapConfig.RegisterMapping();
            // in most cases only one item is required for tests, do not force to have the 12
            // as set in MockRepositoryProvider
            _fixture.RepeatCount = 1;

            _sut = new CartUoW(_mock);
        }
    }
}
