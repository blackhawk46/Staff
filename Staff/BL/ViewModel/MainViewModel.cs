using System;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Views;
using Staff.BL.Infrastructure.Interfaces;

namespace Staff.BL.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        public MainViewModel(IDialogService dialogService, IFrameNavigationService navigationService)
        {
            InitCommands();

            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        ~MainViewModel()
        {
            
        }

        #region Commands

        private void InitCommands()
        {
            AuthCommand = MakeCommand((pb) =>
            {
                Auth((PasswordBox)pb);
            }, nameof(AuthCommand));
        }

        private void Auth(PasswordBox passwordBox)
        {
            string password = passwordBox.Password;
            Authorization(Login, password);
            passwordBox.Password = string.Empty;
            Login = string.Empty;
        }

        private void Authorization(string login, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                    throw new FormatException();
                LoginSuccess(login, password);
            }
            catch (FormatException)
            {
                _dialogService.ShowMessage("Неверные данные", "Пожалуйста введите корректные Логин и Пароль");
            }
            catch (Exception)
            {
                _dialogService.ShowMessage("Упс", "Что-то пошло не так!");
            }
        }

        private void LoginSuccess(string login, string password)
        {
            //TODO: Implement Authorization
            if (login == "1" && password == "1")
            {
                _navigationService.NavigateTo("HomePage");
            }
            else
                _dialogService.ShowMessage("Неверные данные", "Проверьте Логин и Пароль");

        }

        #endregion
    }
}