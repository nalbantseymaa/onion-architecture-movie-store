using MediatR;

namespace MovieApi.Application.Features.Actor.Queries.GetAll;

public class GetAllActorsQueryRequest : IRequest<IList<GetAllActorsQueryResponse>>
{

}