namespace StarWars.Models
{
    public class GraphQLQuery
    {
        public string OperaionName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public string Variables { get; set; }
    }
}