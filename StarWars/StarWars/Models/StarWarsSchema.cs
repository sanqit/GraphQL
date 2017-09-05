namespace StarWars.Models
{
    using GraphQL.Types;

    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(StarWarsQuery query)
        {
            Query = query;
            RegisterType<DroidType>();
        }
    }
}