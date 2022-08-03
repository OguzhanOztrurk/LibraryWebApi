using Entities.Concrete;

namespace Entities.Dto;

public class AuthorOfBooksDTO
{
    public AuthorDTO Author { get; set; }
    public List<BookDTO> Books { get; set; }
}