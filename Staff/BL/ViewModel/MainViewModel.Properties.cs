using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using Staff.BL.Infrastructure.Interfaces;

namespace Staff.BL.ViewModel
{
    public partial class MainViewModel
    {
        #region Fields

        private readonly IDialogService _dialogService;
        private readonly IFrameNavigationService _navigationService;            

        #endregion

        #region Properties

        public string Login
        {
            get => Get<string>();
            set => Set(value);
        }

        #endregion

        #region Commands

        public ICommand AuthCommand { get; set; }

        #endregion
    }
}
