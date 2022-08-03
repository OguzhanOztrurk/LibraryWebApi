using Core.Wrappers;
using DataAccess.Abstract;
using DataAccess.Concrete.Enum;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Onloans.Commands;

public class UpdateOnloanCommand:IRequest<IResponse>
{
    public int OnloanId { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime LendingDate { get; set; }
    public int DeliveryTime { get; set; }
    public StateEnum StateEnum { get; set; }
    public class UpdateOnloanCommandHandler:IRequestHandler<UpdateOnloanCommand,IResponse>
    {
        private readonly IOnloanRepository _onloanRepository;

        public UpdateOnloanCommandHandler(IOnloanRepository onloanRepository)
        {
            _onloanRepository = onloanRepository;
        }

        public async Task<IResponse> Handle(UpdateOnloanCommand request, CancellationToken cancellationToken)
        {
            var onloanUpdate = _onloanRepository.Get(x => x.OnloanId == request.OnloanId);
            onloanUpdate.BookId = request.BookId;
            onloanUpdate.MemberId = request.MemberId;
            onloanUpdate.LendingDate = request.LendingDate;
            onloanUpdate.DeliveryTime = request.DeliveryTime;
            onloanUpdate.StateEnum = request.StateEnum;
            _onloanRepository.Update(onloanUpdate);
            await _onloanRepository.SaveChangesAsync();
            return new Response<Onloan>(onloanUpdate);
        }
    }
}