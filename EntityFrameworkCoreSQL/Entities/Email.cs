using Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EntityFrameworkCoreSQL.Entities
{
    public  class Email:BaseEntity<Email>
    {
        public int RegisterId { get; set; }
        public Register Register { get; set; }
    }
}
