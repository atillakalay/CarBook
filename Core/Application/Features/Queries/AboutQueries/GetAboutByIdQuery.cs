namespace Application.Features.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public GetAboutByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
