namespace Entities.Dto;

public class BookDTO
{
    public int BookId { get; set; }
    public string BookName { get; set; }
    public int IsbnId { get; set; }
    public string NumberOfPages { get; set; }
    public string BookSummary { get; set; }
}