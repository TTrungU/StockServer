﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User:BaseEntity
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Regional { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string Password { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateAt { get; set; }
        [ForeignKey("Wallet")]
        public int? WalletId { get; set; }
        public Wallet? Wallet { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<StockHold>? StockHolds { get; set; }
        public ICollection<StockTransaction>? StockTransactions { get;}
    }
}
