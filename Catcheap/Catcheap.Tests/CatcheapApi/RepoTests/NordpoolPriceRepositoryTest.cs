using Catcheap.API.Data;
using Catcheap.API.Models.MiscModels;
using Catcheap.API.Repositories.MiscRepo;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap.Tests.CatcheapApi.RepoTests
{
    public class NordpoolPriceRepositoryTest
    {
        [Fact]
        public void NordpoolPriceExistsAnyTest()
        {
            List<NordpoolPrice> prices = new List<NordpoolPrice>();
            NordpoolPrice price = new NordpoolPrice();
            price.Id = 69;
            prices.Add(price);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.NordpoolPrices = DbContextMock.GetQueryableMockDbSet(prices);

            NordpoolPriceRepository repo = new NordpoolPriceRepository(myDbMoq.Object);

            Assert.True(repo.NordpoolPriceExistsAny());
        }

        [Fact]
        public void NordpoolPriceExistsTest()
        {
            List<NordpoolPrice> prices = new List<NordpoolPrice>();
            NordpoolPrice price = new NordpoolPrice();
            price.Id = 69;
            prices.Add(price);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.NordpoolPrices = DbContextMock.GetQueryableMockDbSet(prices);

            NordpoolPriceRepository repo = new NordpoolPriceRepository(myDbMoq.Object);

            Assert.True(repo.NordpoolPriceExists(69));
        }

        [Fact]
        public void NordpoolPriceExistsByDateTest()
        {
            List<NordpoolPrice> prices = new List<NordpoolPrice>();
            NordpoolPrice price = new NordpoolPrice();
            price.Id = 69;
            price.DateAndTime = new DateTime(2022, 12, 12, 12, 0, 0);
            prices.Add(price);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.NordpoolPrices = DbContextMock.GetQueryableMockDbSet(prices);

            NordpoolPriceRepository repo = new NordpoolPriceRepository(myDbMoq.Object);

            Assert.True(repo.NordpoolPriceExistsByDate(new DateTime(2022, 12, 12, 12, 0, 0)));
        }

        [Fact]
        public void CreateNordpoolPriceTest()
        {
            List<NordpoolPrice> prices = new List<NordpoolPrice>();
            NordpoolPrice price = new NordpoolPrice();
            price.Id = 69;
            prices.Add(price);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.NordpoolPrices = DbContextMock.GetQueryableMockDbSet(prices);

            NordpoolPriceRepository repo = new NordpoolPriceRepository(myDbMoq.Object);

            Assert.True(repo.CreateNordpoolPrice(price));
        }

        [Fact]
        public void DeleteNordpoolPriceTest()
        {
            List<NordpoolPrice> prices = new List<NordpoolPrice>();
            NordpoolPrice price = new NordpoolPrice();
            price.Id = 69;
            prices.Add(price);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.NordpoolPrices = DbContextMock.GetQueryableMockDbSet(prices);

            NordpoolPriceRepository repo = new NordpoolPriceRepository(myDbMoq.Object);

            Assert.True(repo.DeleteNordpoolPrice(price));
        }

        [Fact]
        public void GetNordpoolPriceTest()
        {
            List<NordpoolPrice> prices = new List<NordpoolPrice>();
            NordpoolPrice price = new NordpoolPrice();
            price.Id = 69;
            prices.Add(price);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.NordpoolPrices = DbContextMock.GetQueryableMockDbSet(prices);

            NordpoolPriceRepository repo = new NordpoolPriceRepository(myDbMoq.Object);

            Assert.Equal(price, repo.GetNordpoolPrice(69));
        }

        [Fact]
        public void GetNordpoolPriceByDateTest()
        {
            List<NordpoolPrice> prices = new List<NordpoolPrice>();
            NordpoolPrice price = new NordpoolPrice();
            price.Id = 69;
            price.DateAndTime = new DateTime(2022, 12, 12, 12, 0, 0);
            prices.Add(price);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.NordpoolPrices = DbContextMock.GetQueryableMockDbSet(prices);

            NordpoolPriceRepository repo = new NordpoolPriceRepository(myDbMoq.Object);

            Assert.Equal(price, repo.GetNordpoolPriceByDate(new DateTime(2022, 12, 12, 12, 0, 0)));
        }

        [Fact]
        public void GetNordpoolPricesTest()
        {
            List<NordpoolPrice> prices = new List<NordpoolPrice>();
            NordpoolPrice price = new NordpoolPrice();
            price.Id = 69;
            prices.Add(price);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.NordpoolPrices = DbContextMock.GetQueryableMockDbSet(prices);

            NordpoolPriceRepository repo = new NordpoolPriceRepository(myDbMoq.Object);

            Assert.Equal(prices, repo.GetNordpoolPrices());
        }

        [Fact]
        public void SaveTest()
        {
            List<NordpoolPrice> prices = new List<NordpoolPrice>();
            NordpoolPrice price = new NordpoolPrice();
            price.Id = 69;
            prices.Add(price);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.NordpoolPrices = DbContextMock.GetQueryableMockDbSet(prices);

            NordpoolPriceRepository repo = new NordpoolPriceRepository(myDbMoq.Object);

            Assert.True(repo.Save());
        }

        [Fact]
        public void UpdateNordpoolPriceTest()
        {
            List<NordpoolPrice> prices = new List<NordpoolPrice>();
            NordpoolPrice price = new NordpoolPrice();
            price.Id = 69;
            prices.Add(price);
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var myDbMoq = new Mock<DataContext>(options);
            myDbMoq.SetupAllProperties();
            myDbMoq.Setup(p => p.SaveChanges()).Returns(1);
            myDbMoq.Object.NordpoolPrices = DbContextMock.GetQueryableMockDbSet(prices);

            NordpoolPriceRepository repo = new NordpoolPriceRepository(myDbMoq.Object);

            Assert.True(repo.UpdateNordpoolPrice(price));
        }
    }
}
