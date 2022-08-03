using System.Configuration;
using Core.Wrappers;
using DataAccess.Abstract;
using MediatR;
using Type = Entities.Concrete.Type;

namespace Business.Handlers.Types.Commands;

public class UpdateTypeCommand:IRequest<IResponse>
{
    public int TypeId { get; set; }
    public string TypeExplanation { get; set; }
    
    public class UpdateTypeCommandHandler:IRequestHandler<UpdateTypeCommand,IResponse>
    {
        private readonly ITypeRepository _typeRepository;

        public UpdateTypeCommandHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<IResponse> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            var typeUpdate = _typeRepository.Get(x => x.TypeId == request.TypeId);
            typeUpdate.TypeExplanation = request.TypeExplanation;
            _typeRepository.Update(typeUpdate);
            await _typeRepository.SaveChangesAsync();
            return new Response<Type>(typeUpdate);
        }
    }
}