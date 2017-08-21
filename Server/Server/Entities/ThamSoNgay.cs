﻿using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class ThamSoNgay : IEntity
    {
        public ThamSoNgay()
        {
        }

        public int ID { get; set; }
        public string Ten { get; set; }
        public System.DateTime GiaTri { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

		
    }
}
