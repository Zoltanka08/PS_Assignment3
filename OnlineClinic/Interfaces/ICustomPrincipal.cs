using System.Security.Principal;

namespace ElectroShopServices.Interfaces
{
    public interface ICustomPrincipal : IPrincipal
    {
        string Username { get; set; }
        string Mail { get; set; }
        string Role { get; set; }
    }
}
