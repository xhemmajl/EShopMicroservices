using MediatR;
namespace BuildingBlocks.CQRS;
// all of this is generic, to later use with different 
public interface ICommand : ICommand<Unit>
{

}
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
