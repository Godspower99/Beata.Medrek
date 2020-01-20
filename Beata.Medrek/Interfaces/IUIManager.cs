
namespace Beata.Medrek
{
    ///<Summary>
    /// UIManager interface
    ///<Summary>
   public interface IUIManager
    {
        DialogBoxResult DialogBoxResult { get; set; }

        void ShowDialog(object obj);

        DialogBoxResult ShowWarningDialog(WarningDialogViewModel warningModel);

        DialogBoxResult ShowAddNewPatientOptionDialog();
    }
}
