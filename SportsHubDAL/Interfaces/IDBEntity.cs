﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Interfaces
{
    public interface IDBEntity : NoIdDBEntity
    {
        public int Id { get; set; }
    }
}