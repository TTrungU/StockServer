﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notification:BaseEntity
    {
      
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
