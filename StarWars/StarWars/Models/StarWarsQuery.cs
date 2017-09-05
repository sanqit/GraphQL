namespace StarWars.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Data;
    using Core.Models;
    using GraphQL.Types;

    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery(IDroidRepository droidRepository)
        {
            Field<ListGraphType<DroidType>>("hero",

                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "name" }),

                resolve: context =>
                {
                    var id = context.GetArgument<int?>("id");
                    if (id.HasValue)
                    {
                        return Task.FromResult(new List<Droid> { droidRepository.Get(id.Value).Result });
                    }

                    var name = context.GetArgument<string>("name");
                    if (!string.IsNullOrEmpty(name))
                    {
                        return droidRepository.GetByName(name);
                    }

                    return null;
                });
        }
    }
}