using System.Collections.Generic;
using System.Security.Claims;

namespace JP_Devolupment.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
