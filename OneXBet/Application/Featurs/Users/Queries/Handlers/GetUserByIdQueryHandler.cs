using AutoMapper;

using OneXBet.Infrastructure.Specifications.Users;

namespace OneXBet.Application.Featurs.Users.Queries.Handlers;

public sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, (bool status, string message, GetUserVM model)>
{
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUnitOfWork context, IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
    }

    public async Task<(bool status, string message, GetUserVM model)> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
            return (false, _stringLocalizer[ResourcesKeys.Shared.BadRequest], null);
        try
        {
            var getUserByIdSpec = GetUserByIdSpecification.Create(request.UserId);

            if (!await _context.Users.AnyAsync(getUserByIdSpec))
                return (false, _stringLocalizer[ResourcesKeys.User.UserByEmailNotFound], null);

            var user = await _context.Users.RetrieveAsync(getUserByIdSpec, cancellationToken);

            var model = _mapper.Map<GetUserVM>(user);

            return (true, _stringLocalizer[ResourcesKeys.User.UserByIdSuccess], model);
        }
        catch
        {
            return (false, _stringLocalizer[ResourcesKeys.Shared.ServerError], null);
        }
    }
}
