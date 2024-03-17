namespace Application.Features.Commands.CategoryCommands
{
    public class RemoveCategoryCommand
    {
        public int Id { get; set; }
        public RemoveCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
