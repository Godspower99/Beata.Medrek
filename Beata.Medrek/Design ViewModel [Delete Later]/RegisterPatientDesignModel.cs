using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beata.Medrek
{
   public class RegisterPatientDesignModel:RegisterUserViewModel
    {
        public static RegisterPatientDesignModel Instance => new RegisterPatientDesignModel();

        public RegisterPatientDesignModel()
        {

        }
    }
}
