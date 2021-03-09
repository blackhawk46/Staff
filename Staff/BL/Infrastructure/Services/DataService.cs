using System.Collections.ObjectModel;
using Staff.BL.Infrastructure.Interfaces;
using Staff.BL.Models;

namespace Staff.BL.Infrastructure.Services
{
    public class DataService : IDataService
    {
        private readonly DataContext _data = new DataContext();

        public ObservableCollection<Department> GetDepartments()
        {
            return new ObservableCollection<Department>(_data.Departments);
        }

        public ObservableCollection<Position> GetPositions()
        {
            return new ObservableCollection<Position>(_data.Positions);
        }

        public void AddDepartment(Department department)
        {
            _data.Departments.Add(department);
        }

        public void AddPosition(Position position)
        {
            _data.Positions.Add(position);
        }

        public void EditDepartment(Department department)
        {
            _data.Departments.Update(department);
        }

        public void EditPosition(Position position)
        {
            _data.Positions.Update(position);
        }

        public void DeleteDepartment(Department department)
        {
            _data.Departments.Remove(department);
        }

        public void DeletePosition(Position position)
        {
            _data.Positions.Remove(position);
        }

        public void Save()
        {
            _data.SaveChanges();
        }
    }
}
