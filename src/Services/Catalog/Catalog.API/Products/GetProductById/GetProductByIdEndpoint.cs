
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProductById;


//public record GetProductByIdRequest();
public record GetProductByIdResponse(Product product);
public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}",async (Guid id,ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));
            //var response = result.Adapt<GetProductByIdResponse>();
            var response = new Product
            {
                Id = result.product.Id,
                Name = result.product.Name,
                Description = result.product.Description,
                Category = result.product.Category,
                Price = result.product.Price,
                ImageFile = result.product.ImageFile
            };
            return Results.Ok(response);
        }).WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Product By Id");
    }
}
