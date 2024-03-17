namespace Application.Features.Commands.ContactCommands
{
    public class RemoveContactCommand
    {
        public int Id { get; set; }
        public RemoveContactCommand(int id)
        {
            Id = id;
        }
    }
}
