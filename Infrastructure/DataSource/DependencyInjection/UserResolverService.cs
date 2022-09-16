#nullable enable
using System.Security.Claims;
using Application;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.DataSource;

public class UserResolverService : IUserResolverService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserResolverService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? CurrentUserId => IsAuthenticated()
        ? (Guid?)Convert.ChangeType((_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)) , typeof(Guid)) : null;
    
    public ClaimsPrincipal? GetCurrentUserContext()
   =>  IsAuthenticated()? _httpContextAccessor.HttpContext.User : null;

    public bool IsAuthenticated()
        => _httpContextAccessor.HttpContext is not null 
                                           && (_httpContextAccessor.HttpContext.User.Identity is not null) 
                                           && _httpContextAccessor.HttpContext!.User!.Identity.IsAuthenticated;
}

