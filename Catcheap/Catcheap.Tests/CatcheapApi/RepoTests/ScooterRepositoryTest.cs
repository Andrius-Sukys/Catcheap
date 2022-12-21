using Catcheap.API.Data;
using Catcheap.API.Models.ScooterModels;
using Catcheap.API.Repositories.ScooterRepo;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap.Tests.CatcheapApi.RepoTests
{
    public class ScooterRepositoryTest
    {
        [Fact]
        public void GetScooterTest()
        {
            List<Scooter> scooters = new List<Scooter>();
            Scooter scooter = new Scooter();
            scooter.Id = 69;
            scooters.Add(scooter);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.Scooters = DbContextMock.GetQueryableMockDbSet(scooters);

            ScooterRepository repo = new ScooterRepository(myDbMoq.Object);

            Assert.Equal(scooter, repo.GetScooter(69));
        }

        [Fact]
        public void ScooterExistsTest()
        {
            List<Scooter> scooters = new List<Scooter>();
            Scooter scooter = new Scooter();
            scooter.Id = 69;
            scooters.Add(scooter);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.Scooters = DbContextMock.GetQueryableMockDbSet(scooters);

            ScooterRepository repo = new ScooterRepository(myDbMoq.Object);

            Assert.True(repo.ScooterExists(69));
        }

        [Fact]
        public void GetScootersTest()
        {
            List<Scooter> scooters = new List<Scooter>();
            Scooter scooter = new Scooter();
            scooter.Id = 69;
            scooters.Add(scooter);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.Scooters = DbContextMock.GetQueryableMockDbSet(scooters);

            ScooterRepository repo = new ScooterRepository(myDbMoq.Object);

            Assert.Equal(scooters, repo.GetScooters());
        }

        [Fact]
        public void CreateScooterTest()
        {
            List<Scooter> scooters = new List<Scooter>();
            Scooter scooter = new Scooter();
            scooter.Id = 69;
            scooters.Add(scooter);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.Scooters = DbContextMock.GetQueryableMockDbSet(scooters);

            ScooterRepository repo = new ScooterRepository(myDbMoq.Object);

            Assert.True(repo.CreateScooter(scooter));
        }

        [Fact]
        public void SaveTest()
        {
            List<Scooter> scooters = new List<Scooter>();
            Scooter scooter = new Scooter();
            scooter.Id = 69;
            scooters.Add(scooter);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.Scooters = DbContextMock.GetQueryableMockDbSet(scooters);

            ScooterRepository repo = new ScooterRepository(myDbMoq.Object);

            Assert.True(repo.Save());
        }

        [Fact]
        public void UpdateScooterTest()
        {
            List<Scooter> scooters = new List<Scooter>();
            Scooter scooter = new Scooter();
            scooter.Id = 69;
            scooters.Add(scooter);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.Scooters = DbContextMock.GetQueryableMockDbSet(scooters);

            ScooterRepository repo = new ScooterRepository(myDbMoq.Object);

            Assert.True(repo.UpdateScooter(scooter));
        }

        [Fact]
        public void DeleteScooterTest()
        {
            List<Scooter> scooters = new List<Scooter>();
            Scooter scooter = new Scooter();
            scooter.Id = 69;
            scooters.Add(scooter);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.Scooters = DbContextMock.GetQueryableMockDbSet(scooters);

            ScooterRepository repo = new ScooterRepository(myDbMoq.Object);

            Assert.True(repo.DeleteScooter(scooter));
        }
    }
}
