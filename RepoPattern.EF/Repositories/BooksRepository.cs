using RepoPattern.Core.Interfaces;
using RepoPattern.Core.Models;
using RepoPattern.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.EF.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        private readonly MVCContext _context;
        public BooksRepository(MVCContext context) : base(context)
        {
        }

        public IEnumerable<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }
    }
}
