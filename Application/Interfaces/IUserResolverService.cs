using System.Security.Claims;

namespace Application;

public interface IUserResolverService
{ 
    Guid? CurrentUserId {get;}
    
    ClaimsPrincipal? GetCurrentUserContext();

    bool IsAuthenticated();
}