namespace Entities.Dto;

public class MemberOfBooksDTO
{
    public MemberDTO MemberDto { get; set; }
    public List<BookDTO> BookDtos { get; set; }
}