using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{

	public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
	:ICommand<CreateProductResult>;
	public record CreateProductResult(Guid Id);


	internal class CreateProductCommandHandler (IDocumentSession session)
		: ICommandHandler<CreateProductCommand, CreateProductResult>
	{
		public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
		{
			// create product entity from command object
			Product product = new Product {
				Name = command.Name,
				Category = command.Category,
				Description = command.Description,
				ImageFile = command.ImageFile,
				Price = command.Price
			};
			

			// save in database 
			// return result 
			// business logic to create product
			throw new NotImplementedException();
		}
	}
}
