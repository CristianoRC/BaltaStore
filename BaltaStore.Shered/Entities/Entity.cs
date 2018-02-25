using Flunt.Notifications;

namespace BaltaStore.Shered.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = System.Guid.NewGuid();
        }

        public System.Guid Id { get; set; }
    }
}