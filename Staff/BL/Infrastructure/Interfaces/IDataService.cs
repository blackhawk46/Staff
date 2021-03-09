using System.Collections.ObjectModel;
using Staff.BL.Models;

namespace Staff.BL.Infrastructure.Interfaces
{
    public interface IDataService
    {
        ObservableCollection<Department> GetDepartments();
        ObservableCollection<Position> GetPositions();

        void AddDepartment(Department department);
        void AddPosition(Position position);
        void EditDepartment(Department department);
        void EditPosition(Position position);
        void DeleteDepartment(Department department);
        void DeletePosition(Position position);
        void Save();
    }
}