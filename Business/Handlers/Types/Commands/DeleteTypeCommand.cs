using Core.Wrappers;
using DataAccess.Abstract;
using MediatR;
using Type = Entities.Concrete.Type;

namespace Business.Handlers.Types.Commands;

public class DeleteTypeCommand:IRequest<IResponse>
{
    
    public int TypeId { get; set; }
    public class DeleteTypeCommandHandler:IRequestHandler<DeleteTypeCommand,IResponse>
    {
        private readonly ITypeRepository _typeRepository;

        public DeleteTypeCommandHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<IResponse> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            var type = await _typeRepository.GetAsync(x => x.TypeId == request.TypeId);
            _typeRepository.Delete(type);
            await _typeRepository.SaveChangesAsync();
            return new Response<Type>(type);
        }
    }
}