using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.API.Security
{
    public class SecurityDbContext
        : IdentityDbContext
    {
        public SecurityDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected SecurityDbContext()
        {
        }
    }
}
