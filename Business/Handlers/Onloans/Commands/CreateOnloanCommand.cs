using Core.Wrappers;
using DataAccess.Abstract;
using DataAccess.Concrete.Enum;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Onloans.Commands;

public class CreateOnloanCommand:IRequest<IResponse>
{
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime LendingDate { get; set; }
    public int DeliveryTime { get; set; }
    public StateEnum StateEnum { get; set; }
    
    public class CreateOnloanCommandHandler:IRequestHandler<CreateOnloanCommand,IResponse>
    {
        private readonly IOnloanRepository _onloanRepository;

        public CreateOnloanCommandHandler(IOnloanRepository onloanRepository)
        {
            _onloanRepository = onloanRepository;
        }

        public async Task<IResponse> Handle(CreateOnloanCommand request, CancellationToken cancellationToken)
        {
            _onloanRepository.StateControl(request.BookId);
            Onloan addedOnloan = new Onloan
            {
                BookId = request.BookId,
                MemberId = request.MemberId,
                LendingDate = request.LendingDate,
                DeliveryTime = request.DeliveryTime,
                StateEnum = request.StateEnum
            };
            _onloanRepository.Add(addedOnloan);
            await _onloanRepository.SaveChangesAsync();
            return new Response<Onloan>(addedOnloan);
        }
    }
}