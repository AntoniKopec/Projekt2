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
            var testObject = new RepositoryTest() { Id = 1 };
            var testList = new List<RepositoryTest>() { testObject };
            var dbSetMock = new Mock<DbSet<RepositoryTest>>();
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<RepositoryTest>()).Returns(dbSetMock.Object);
            // Act
            var repository = new Repository<RepositoryTest>(context.Object);
            var result = repository.GetAll();
            // Assert
            Assert.Equal(testList, result.ToList());
        }
        [Fact]
        public void GetFirstOrDefault_RepositoryTest_CheckMethod()
        {
            // Arrange
            var testObject = new RepositoryTest() { Id = 1 };
            var testList = new List<RepositoryTest>() { testObject };
            var dbSetMock = new Mock<DbSet<RepositoryTest>>();
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<RepositoryTest>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<RepositoryTest>()).Returns(dbSetMock.Object);
            // Act
            var repository = new Repository<RepositoryTest>(context.Object);
            var result = repository.GetFirstOrDefault(x => x.Id == 1);
            // Assert
            Assert.Equal(testObject, result);
        }
        [Fact]
        public void Add_RepositoryTest_CheckMethod()
        {
            // Arrange
            var testObject = new RepositoryTest();
            var context = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<RepositoryTest>>();
            context.Setup(x => x.Set<RepositoryTest>()).Returns(dbSetMock.Object);
            // Act
            var repository = new Repository<RepositoryTest>(context.Object);
            repository.Add(testObject);
            //Assert
            context.Verify(x => x.Set<RepositoryTest>());
            dbSetMock.Verify(x => x.Add(It.Is<RepositoryTest>(y => y == testObject)));
        }
        [Fact]
        public void Remove_RepositoryTest_CheckMethod()
        {
            // Arrange
            var testObject = new RepositoryTest();
            var context = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<RepositoryTest>>();
            context.Setup(x => x.Set<RepositoryTest>()).Returns(dbSetMock.Object);
            // Act
            var repository = new Repository<RepositoryTest>(context.Object);
            repository.Remove(testObject);
            //Assert
            context.Verify(x => x.Set<RepositoryTest>());
            dbSetMock.Verify(x => x.Remove(It.Is<RepositoryTest>(y => y == testObject)));
        }
    }
}
