﻿using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.UnitOfWorks
{
    public class UnitOfWorkscs : IUnitOfWorks
    {

        protected readonly AppDbContext _context;

        public UnitOfWorkscs(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();

        }

        public async Task CommitAsync()
        {

            await _context.SaveChangesAsync();
        }
    }

 
}
