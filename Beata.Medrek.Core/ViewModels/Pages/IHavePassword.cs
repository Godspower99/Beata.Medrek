
using System.Security;

namespace Beata.Medrek.Core
{
  public interface IHavePassword
    {
         SecureString securePassword { get;}
    }
}
