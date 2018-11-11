namespace Expm.Core.Exepense.Queries
{
    public class GetExpenseQuery
    {
        public string Id { get; set; }

        public GetExpenseQuery(string id)
        {
            Id = id;    
        }
    }
}