using AutoMapper;
using eTicketManagement.Application.Contracts.Infrastructure.Services.Mail;
using eTicketManagement.Application.Contracts.Persistence;
using eTicketManagement.Application.Models.Mail;
using eTicketManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eTicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateEventCommandHandler> _logger;

        public CreateEventCommandHandler(
            IMapper mapper,
            IEventRepository eventRepository,
            IEmailService emailService,
            ILogger<CreateEventCommandHandler> logger)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @event = _mapper.Map<Event>(request);

            @event = await _eventRepository.AddAsync(@event);

            //send email to admin 
            var email = new Email 
            { 
                Body = $"A new event has been created: {request}", 
                Subject = "New event", 
                To = "danradic@gmail.com" 
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                // this shouldn't stop the API, so this can be logged
                _logger.LogError($"Mailing about event {@event.EventId} failed due to an error with the mail service: {ex.Message}");
            }

            return @event.EventId;
        }
    }
}