﻿using Microsoft.EntityFrameworkCore;

namespace konyvtarProj.Server.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {

        }
    }
}