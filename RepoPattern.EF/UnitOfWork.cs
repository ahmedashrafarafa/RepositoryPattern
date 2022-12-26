using RepoPattern.Core;
using RepoPattern.Core.Interfaces;
using RepoPattern.Core.Models;
using RepoPattern.EF.Models;
using RepoPattern.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MVCContext _context;

        public IBaseRepository<Author> Authors { get; private set; }
        public IBooksRepository Books { get; private set; }
        public UnitOfWork(MVCContext context)
        {
            _context = context;

            Authors = new BaseRepository<Author>(_context);
            Books = new BooksRepository(_context);
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
