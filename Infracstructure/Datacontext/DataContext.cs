using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Datacontext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications {get;set;}
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletHistory> walletHistories { get; set; }
        public DbSet<StockHold> StockHolds { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }
        public DbSet<StockInfor> StockInfors { get; set; }
        public DbSet<StockData> StockDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
