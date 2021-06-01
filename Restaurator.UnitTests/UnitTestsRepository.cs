using Microsoft.EntityFrameworkCore;
using Moq;
using Restaurator.DataAccess.Data.Repository;
using Restaurator.Models.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Restaurator.UnitTests
{
    public class UnitTestRepository
    {
        [Fact]
        public void Get_RepositoryTest_CheckMethod()
        {
            // Arrange
            var repositoryObject = new RepositoryTest();
            var context = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<RepositoryTest>>();
            context.Setup(x => x.Set<RepositoryTest>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(repositoryObject);
            // Act
            var repository = new Repository<RepositoryTest>(context.Object);
            repository.Get(1);
            // Assert
            context.Verify(x => x.Set<RepositoryTest>());
            dbSetMock.Verify(x => x.Find(It.IsAny<int>()));
        }
        [Fact]
        public void GetAll_RepositoryTest_CheckMethod()
        {
            // Arrange
            var repositoryObject = new RepositoryTest() { Id = 1 };
            var repositoryList = new List<RepositoryTest>() { repositoryObject };
            var dbSetMock = new Mock<DbSet<RepositoryTest>>();
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.Provider).Returns(repositoryList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.Expression).Returns(repositoryList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.ElementType).Returns(repositoryList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.GetEnumerator()).Returns(repositoryList.AsQueryable().GetEnumerator());
            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<RepositoryTest>()).Returns(dbSetMock.Object);
            // Act
            var repository = new Repository<RepositoryTest>(context.Object);
            var result = repository.GetAll();
            // Assert
            Assert.Equal(repositoryList, result.ToList());
        }
        [Fact]
        public void GetFirstOrDefault_RepositoryTest_CheckMethod()
        {
            // Arrange
            var repositoryObject = new RepositoryTest() { Id = 1 };
            var repositoryList = new List<RepositoryTest>() { repositoryObject };
            var dbSetMock = new Mock<DbSet<RepositoryTest>>();
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.Provider).Returns(repositoryList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.Expression).Returns(repositoryList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.ElementType).Returns(repositoryList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.GetEnumerator()).Returns(repositoryList.AsQueryable().GetEnumerator());
            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<RepositoryTest>()).Returns(dbSetMock.Object);
            // Act
            var repository = new Repository<RepositoryTest>(context.Object);
            var result = repository.GetFirstOrDefault(x => x.Id == 1);
            // Assert
            Assert.Equal(repositoryObject, result);
        }
        [Fact]
        public void Add_RepositoryTest_CheckMethod()
        {
            // Arrange
            var repositoryObject = new RepositoryTest();
            var context = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<RepositoryTest>>();
            context.Setup(x => x.Set<RepositoryTest>()).Returns(dbSetMock.Object);
            // Act
            var repository = new Repository<RepositoryTest>(context.Object);
            repository.Add(repositoryObject);
            //Assert
            context.Verify(x => x.Set<RepositoryTest>());
            dbSetMock.Verify(x => x.Add(It.Is<RepositoryTest>(y => y == repositoryObject)));
        }
        [Fact]
        public void Remove_RepositoryTest_CheckMethod()
        {
            // Arrange
            var repositoryObject = new RepositoryTest();
            var context = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<RepositoryTest>>();
            context.Setup(x => x.Set<RepositoryTest>()).Returns(dbSetMock.Object);
            // Act
            var repository = new Repository<RepositoryTest>(context.Object);
            repository.Remove(repositoryObject);
            //Assert
            context.Verify(x => x.Set<RepositoryTest>());
            dbSetMock.Verify(x => x.Remove(It.Is<RepositoryTest>(y => y == repositoryObject)));
        }
    }
}
