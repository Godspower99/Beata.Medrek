
using System.Collections.Generic;

namespace Beata.Medrek.Standard
{
    ///<Summary>
    /// List Of Operators registered
    ///<Summary>
    public static class Operators
    {
        public static List<OperatorModel> operators = new List<OperatorModel>()
        {
            new OperatorModel()
            {
                Name="Otiete Godspower",
                Password="qwerty12",
                ID="Daemon",
                IsAdmin=true,
                ImageSource="/Images/Samples/godspower.jpg"
            },
             new OperatorModel()
            {
                Name="George Michael",
                Password="michael12",
                ID="George12",
                IsAdmin=true,
                ImageSource="/Images/Samples/michael.jpg"
            },
              new OperatorModel()
            {
                Name="John Luch",
                Password="luch12",
                ID="Luchi",
                IsAdmin=false,
                ImageSource="/Images/Samples/luch.jpg"
            },

        };

    }
}
