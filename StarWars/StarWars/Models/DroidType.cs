namespace StarWars.Models
{
    using GraphQL.Types;
    using Core.Models;

    public class DroidType : ObjectGraphType<Droid>
    {
        public DroidType()
        {
            Field(x => x.Id).Description("The Id of the Droid.");
            Field(x => x.Name, true).Description("The name of the Droid.");
        }
    }
}
