namespace Application.Features.Commands.BannerCommands
{
    public class RemoveBannerCommand
    {
        public int Id { get; set; }

        public RemoveBannerCommand(int id)
        {
            Id = id;
        }
    }
}
