using MediatR;
using MovieApi.Application.Features.Actors.Queries.GetAllActors;

namespace MovieApi.Application.Features.Actors.Queries.GetAll;

public class GetAllActorsQueryRequest : IRequest<GetAllActorsQueryResponse>
{

}