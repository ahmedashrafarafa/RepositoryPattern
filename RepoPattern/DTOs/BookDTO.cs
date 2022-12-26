using RepoPattern.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace RepoPattern.API.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Author Author { get; set; }

        public int AuthorId { get; set; }
    }
}
