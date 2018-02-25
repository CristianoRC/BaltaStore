namespace BaltaStore.Shered.Commands
{

    //Só pode ser criado um CommandHandler(Manipulador de comando)
    //a partir de um Command
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}