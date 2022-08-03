using Core.Wrappers;
using DataAccess.Abstract;
using MediatR;
using Type = Entities.Concrete.Type;

namespace Business.Handlers.Types.Commands;

public class CreateTypeCommand:IRequest<IResponse>
{
    public string TypeExplanation { get; set; }
    public class CreateTypeCommandHandler:IRequestHandler<CreateTypeCommand,IResponse>
    {
        private readonly ITypeRepository _typeRepository;

        public CreateTypeCommandHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<IResponse> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            Type addedType = new Type
            {
                TypeExplanation = request.TypeExplanation
            };
            _typeRepository.Add(addedType);
            await _typeRepository.SaveChangesAsync();
            return new Response<Type>(addedType);
        }
    }
}