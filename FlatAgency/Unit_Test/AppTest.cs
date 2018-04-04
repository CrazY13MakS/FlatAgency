using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlatAgency.App_Data;
using FlatAgency.App_Data.DB;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FlatAgency.Unit_Test
{
    public class AppTest
    {

        [Fact]
        public void CheckCountDistrict()
        {
           // App_Data.DB.DB_A37EBA_flatagencyContext dbContext = new App_Data.DB.DB_A37EBA_flatagencyContext()
        }

    }
    public class DbTests
    {
        [Fact]
        public void Add_WhenHaveNoEmail()
        {
            IDbAction sut = GetInMemoryDbRepository();

            Assert.Equal(1, sut.GetFlats(0, 10).First().Id);
          var flat=  sut.GetFlatById(1);
            Assert.NotNull(flat);
           Assert.Equal(3500000m, flat.Price);
            Assert.Equal(2, sut.GetFlats(0,10).Count());
    
        }

        private IDbAction GetInMemoryDbRepository()
        {
            DbContextOptions<DB_A37EBA_flatagencyContext> options;
            var builder = new DbContextOptionsBuilder<DB_A37EBA_flatagencyContext>();
          //  builder.UseInMemoryDatabase("DbTest");
            builder.UseSqlServer(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=Flat_Agency_Test;Trusted_Connection=Yes;");
            options = builder.Options;
            DB_A37EBA_flatagencyContext testDbDataContext = new DB_A37EBA_flatagencyContext(options);
          //  testDbDataContext.Database.EnsureDeleted();
          //  testDbDataContext.Database.EnsureCreated();
            return new DbAction(testDbDataContext);
        }
    }
}
