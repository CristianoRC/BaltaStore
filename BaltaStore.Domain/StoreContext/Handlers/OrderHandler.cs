using BaltaStore.Domain.StoreContext.OrderCommand.Inputs;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Shered.Commands;
using Flunt.Notifications;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class OrderHandler : Notifiable, ICommandHandler<PlaceOrderCommand>
    {
        IEmailService _emailService;
        IOrderRepository _repository;

        protected OrderHandler(IEmailService emailService, IOrderRepository orderRepository)
        {
            _emailService = emailService;
            _repository = orderRepository;
        }

        public ICommandResult Handle(PlaceOrderCommand command)
        {
            return null;
        }
    }
}