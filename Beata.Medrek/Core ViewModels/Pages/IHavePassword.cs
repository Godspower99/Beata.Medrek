
using System.Security;

namespace Beata.Medrek
{
    /// <summary>
    /// Interface used for fixing PasswordBox
    /// SecurePassword Property Binding Issues
    /// </summary>
  public interface IHavePassword
    {
         SecureString securePassword { get;}
    }
}
