
namespace Catalog.API.Products.CreateProduct
{

	public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
	public record CreateProductResponse(Guid Id);

	public class CreateProductEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapPost("/Products", 
				async (CreateProductRequest request, ISender sedner) =>
			{
				// using Adapt method from Mapster to convert the request obj to  CreateProductCommand obj
				var command = request.Adapt<CreateProductCommand>();
				var result = await sedner.Send(command);
				// using Adapt method from Mapster to convert the result obj to  CreateProductResponse obj
				var response = result.Adapt<CreateProductResponse>();
				return Results.Created($"/Products / {response.Id}",response);


			}).WithName("CreateProduct")
		.Produces<CreateProductResponse>(StatusCodes.Status201Created)
		.ProducesProblem(StatusCodes.Status400BadRequest)
		.WithSummary("Create Product")
		.WithDescription("Create Product");
		}
	}
}
