
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Beata.Medrek.Core
{
   public static class SecurityStringHelpers
    {
       
        public static string Unsecure(this SecureString secureString)
        {
            var unSecureString = IntPtr.Zero;
            if (secureString == null)
                return string.Empty;
            try
            {
                unSecureString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unSecureString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unSecureString);

            }
        }
    }
    
}
