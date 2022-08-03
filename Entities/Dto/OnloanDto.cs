using DataAccess.Concrete.Enum;

namespace Entities.Dto;

public class OnloanDto
{
    public int OnloanId { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime LendingDate { get; set; }
    public int DeliveryTime { get; set; }
    public StateEnum StateEnum { get; set; }
}