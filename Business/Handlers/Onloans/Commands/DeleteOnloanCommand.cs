using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;


namespace Business.Handlers.Onloans.Commands;

public class DeleteOnloanCommand:IRequest<IResponse>
{
    public int OnloanId { get; set; }
    public class DeleteOnloanCommandHandler:IRequestHandler<DeleteOnloanCommand,IResponse>
    {
        private readonly IOnloanRepository _onloanRepository;

        public DeleteOnloanCommandHandler(IOnloanRepository onloanRepository)
        {
            _onloanRepository = onloanRepository;
        }

        public async Task<IResponse> Handle(DeleteOnloanCommand request, CancellationToken cancellationToken)
        {
            var onloan = await _onloanRepository.GetAsync(x => x.OnloanId == request.OnloanId);
            _onloanRepository.Delete(onloan);
            await _onloanRepository.SaveChangesAsync();
            return new Response<Onloan>(onloan);
        }
    }
}