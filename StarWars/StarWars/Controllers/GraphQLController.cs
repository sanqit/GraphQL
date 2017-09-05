namespace StarWars.Controllers
{
    using System.Threading.Tasks;
    using GraphQL;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Produces("application/json")]
    [Route("graphQL")]
    public class GraphQLController : Controller
    {
        private readonly StarWarsSchema _starWarsSchema;

        public GraphQLController(StarWarsSchema starWarsSchema)
        {
            _starWarsSchema = starWarsSchema;
        }

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = _starWarsSchema;
                x.Query = query.Query;

            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }
    }
}