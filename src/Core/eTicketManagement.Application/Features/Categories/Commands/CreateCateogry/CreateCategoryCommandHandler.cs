using AutoMapper;
using eTicketManagement.Application.Contracts.Persistence;
using eTicketManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace eTicketManagement.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();

            var validator = new CreateCategoryCommandValidator();
            var validationResponse = await validator.ValidateAsync(request);

            if (validationResponse.Errors.Count > 0)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResponse.Errors)
                {
                    createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCategoryCommandResponse.Success)
            {
                var category = new Category() { Name = request.Name };
                category = await _categoryRepository.AddAsync(category);
                createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
            }

            return createCategoryCommandResponse;
        }
    }
}
