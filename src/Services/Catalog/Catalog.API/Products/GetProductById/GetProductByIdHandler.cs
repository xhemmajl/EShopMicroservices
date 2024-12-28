﻿namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product product);
internal class GetProductByIdQueryHandler(IDocumentSession session,ILogger<GetProductByIdQueryHandler> logger)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        // logic to get product by id from database
        logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@Query}", query);

        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
        
        if(product is null)
        {
            throw new ProductNotFoundException();
        }
        return new GetProductByIdResult(product);
    }
}
