using GalaSoft.MvvmLight.Views;

namespace Staff.BL.Infrastructure.Interfaces
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}
