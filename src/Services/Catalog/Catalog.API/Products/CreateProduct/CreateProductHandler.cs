﻿namespace Catalog.API.Products.CreateProduct;
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) :
    ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Business logic to create a product
        //create Product entity from command object

        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        //save to db
        session.Store(product);
        await session.SaveChangesAsync();

        //return CreateProductResult result

        return new CreateProductResult(product.Id);
        throw new NotImplementedException();
    }
}
