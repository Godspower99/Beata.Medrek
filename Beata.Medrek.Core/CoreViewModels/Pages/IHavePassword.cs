
using System.Security;

namespace Beata.Medrek.Core
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
