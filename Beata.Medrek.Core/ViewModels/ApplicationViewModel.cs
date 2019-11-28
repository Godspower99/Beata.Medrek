
namespace Beata.Medrek.Core
{
   public class ApplicationViewModel:BaseViewModel
    {

        /// <summary>
        /// Current Page Of the Application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
    }
}
