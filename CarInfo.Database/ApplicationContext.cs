using CarInfo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car {CarId = 1, Produccer = "Chevrolet", Model = "Cobalt", Color = "Oq", Price = 10000 },
                new Car {CarId = 2, Produccer = "Mersedenz", Model = "BMW", Color = "Oq", Price = 12000 },
                new Car {CarId = 3, Produccer = "Chevrolet", Model = "Matiz", Color = "Qora", Price = 8600 },
                new Car {CarId = 4, Produccer = "Daewo", Model = "Damasa", Color = "Yashil", Price = 4000 },
                new Car {CarId = 5, Produccer = "Chevrolet", Model = "Lasetti", Color = "Oq", Price = 5000 },
                new Car {CarId = 6, Produccer = "Chevrolet", Model = "Trikker", Color = "Qora", Price = 10000 }
                );
        }
        public DbSet<Car> Cars { get; set; }
    }
}
