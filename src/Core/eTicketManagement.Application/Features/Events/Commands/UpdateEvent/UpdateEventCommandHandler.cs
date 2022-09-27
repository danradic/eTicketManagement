using AutoMapper;
using eTicketManagement.Application.Contracts.Persistence;
using eTicketManagement.Application.Exceptions;
using eTicketManagement.Domain.Entities;
using MediatR;

namespace eTicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

            if (eventToUpdate == null) 
                throw new NotFoundException(nameof(Event), request.EventId);

            var validator = new UpdateEventCommandValidator();
            var validatationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatationResult.Errors.Count > 0) 
                throw new ValidationException(validatationResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

            await _eventRepository.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
    }
}