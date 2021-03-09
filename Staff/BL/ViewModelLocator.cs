using System;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Staff.BL.Infrastructure.Interfaces;
using Staff.BL.Infrastructure.Services;
using Staff.BL.ViewModel;

namespace Staff.BL
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IDataService, DataService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DepartmentViewModel>();

            SetupNavigation();
        }

        public MainViewModel MainView => ServiceLocator.Current.GetInstance<MainViewModel>();
        public DepartmentViewModel DepartmentView => ServiceLocator.Current.GetInstance<DepartmentViewModel>();

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("HomePage", new Uri("../Views/HomePage.xaml", UriKind.Relative));
            navigationService.Configure("AuthView", new Uri("../Views/AuthView.xaml", UriKind.Relative));

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        public static void Cleanup()
        {
            
        }
    }
}