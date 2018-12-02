using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using InventoryBusinessLogic.Factories;
using InventoryBusinessLogic.Repositories;
using Moq;


namespace InventoryUoWTest.Mocking
{
    public class MockRepositoryProvider : IRepositoryProvider
    {
        private readonly Dictionary<Type, object> _repositories;
        private readonly Dictionary<Type, object> _mockRepositories;
        private readonly Dictionary<Type, object> _lists;
        private readonly IFixture _fixture;
        public int CommitCallCount;

        public MockRepositoryProvider(IFixture fixture)
        {
            _fixture = fixture;
            _repositories = new Dictionary<Type, object>();
            _mockRepositories = new Dictionary<Type, object>();
            _lists = new Dictionary<Type, object>();
            CommitCallCount = 0;

            ConfigureFixture();
        }

        public MockRepositoryProvider()
        {
        }

        private void ConfigureFixture()
        {
            _fixture.Customize(new AutoConfiguredMoqCustomization());
            //configure fixture to generate a max of two level recursion
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(2));
            _fixture.RepeatCount = 2;
        }

        public IRepository<T> CreateRepository<T>() where T : class
        {
            //look for T dictionary cache under typeof(T)
            object repository;
            _repositories.TryGetValue(typeof(T), out repository);
            if (repository != null)
            {
                return (IRepository<T>)repository;
            }

            //if not found then create and add to dictionary cache
            return MakeRepository<T>();
        }

        public void SaveChanges()
        {
            //increase the number of times commit is called
            CommitCallCount++;
        }

        private IRepository<T> MakeRepository<T>() where T : class
        {
            var mock = new Mock<IRepository<T>>();

            //make general setup for repository
            var list = _fixture.CreateMany<T>().ToList();
            mock.Setup(r => r.GetAll()).Returns(list.AsQueryable());
            mock.Setup(r => r.GetAll(It.IsAny<string[]>())).Returns(list.AsQueryable());
            mock.Setup(r => r.Add(It.IsAny<T>())).Callback<T>(t => list.Add(t)).Returns<T>(t => t);           
            mock.Setup(r => r.Remove(It.IsAny<T>())).Callback<T>(t => list.Remove(t)).Returns<T>(t => t);

            //crete mock object
            var repositoryMock = mock.Object;

            //add to repository of repository & mocks 
            _repositories.Add(typeof(T), repositoryMock);
            _mockRepositories.Add(typeof(T), mock);
            _lists.Add(typeof(T), list);

            return repositoryMock;
        }

        public IRepository<T> CreateRepositoryWithList<T>(IEnumerable<T> list) where T : class
        {
            var repository = CreateRepository<T>();

            foreach (var item in list)
            {
                repository.Add(item);
            }

            return repository;
        }

        public Mock<IRepository<T>> Mock<T>() where T : class
        {
            object repository;
            _repositories.TryGetValue(typeof(T), out repository);
            if (repository == null)
            {
                CreateRepository<T>();
            }

            return (Mock<IRepository<T>>)_mockRepositories[typeof(T)];
        }

        public IList<T> Collection<T>() where T : class
        {
            object repository;
            _repositories.TryGetValue(typeof(T), out repository);
            if (repository == null)
            {
                CreateRepository<T>();
            }

            return (IList<T>)_lists[typeof(T)];
        }

        
        public async Task CommitAsync()
        {
            CommitCallCount++;
            await Task.Yield();
        }

        public bool CalledCommit => CommitCallCount > 0;

        public void Dispose()
        {
            //nothing to dispose just call garbage  collector
            GC.Collect();
        }
    }
}
