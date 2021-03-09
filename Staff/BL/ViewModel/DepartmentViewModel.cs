using Staff.BL.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using GalaSoft.MvvmLight.Views;
using Staff.BL.Infrastructure.Interfaces;

namespace Staff.BL.ViewModel
{
    public class DepartmentViewModel : BaseViewModel
    {
        public ICommand AddDepartment { get; set; }
        public ICommand EditDepartment { get; set; }
        public ICommand DeleteDepartment { get; set; }

        private readonly IDialogService _dialogService;
        private readonly IDataService _dataService;

        public DepartmentViewModel(IDialogService dialogService, IDataService dataService)
        {
            InitCommands();

            _dialogService = dialogService;
            _dataService = dataService;

            Departments = _dataService.GetDepartments();
        }

        private void InitCommands()
        {
            AddDepartment = MakeCommand(async () =>
            {
                string result = await ((MetroWindow)Application.Current.MainWindow).ShowInputAsync("Новая запись", "Введите наименование отдела",
                new MetroDialogSettings
                {
                    AffirmativeButtonText = "Ок",
                    NegativeButtonText = "Отмена"
                });
                if (!string.IsNullOrEmpty(result))
                {
                    _dataService.AddDepartment(new Department() { Name = result });
                    _dataService.Save();
                    Departments = _dataService.GetDepartments();
                }
            }, nameof(AddDepartment));

            EditDepartment = MakeCommand(async () =>
            {
                if (SelectDepartment != null)
                {
                    string result = await ((MetroWindow)Application.Current.MainWindow).ShowInputAsync("Редактирование", "Введите наименование отдела",
                                       new MetroDialogSettings
                                       {
                                           AffirmativeButtonText = "Ок",
                                           NegativeButtonText = "Отмена",
                                           DefaultText = SelectDepartment.Name
                                       });
                    if (result != SelectDepartment.Name && result != null)
                    {
                        SelectDepartment.Name = result;
                        _dataService.EditDepartment(SelectDepartment);
                        _dataService.Save();
                        Departments = _dataService.GetDepartments();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите отдел");
                }
            }, nameof(EditDepartment));

            DeleteDepartment = MakeCommand(async () =>
            {
                if (SelectDepartment != null)
                {
                    MessageDialogResult result = await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync("Предупреждение", "Вы уверены?",
                    MessageDialogStyle.AffirmativeAndNegative,
                    new MetroDialogSettings
                    {
                        AffirmativeButtonText = "Ок",
                        NegativeButtonText = "Отмена"
                    });
                    if (result == MessageDialogResult.Affirmative)
                    {
                        _dataService.DeleteDepartment(SelectDepartment);
                        _dataService.Save();
                        Departments = _dataService.GetDepartments();
                    }
                }
                else
                {
                    await _dialogService.ShowMessage("Ошибка", "Выберите отдел");
                }
            }, nameof(DeleteDepartment));
        }

        public Department SelectDepartment
        {
            get => Get<Department>();
            set => Set(value);
        }

        public ObservableCollection<Department> Departments
        {
            get => Get<ObservableCollection<Department>>();
            set => Set(value);
        }
    }
}
