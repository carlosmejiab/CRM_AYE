using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class EmployeesBS
    {
        public static EmployeesEntity Save(EmployeesEntity _Entidad)
        {
            return EmployeesDAO.Save(_Entidad);
        }
        public static EmployeesEntity Update(EmployeesEntity _Entidad)
        {
            return EmployeesDAO.Update(_Entidad);
        }
        public static EmployeesEntity Delete(EmployeesEntity _Entidad)
        {
            return EmployeesDAO.Delete(_Entidad);
        }
        public static EmployeesEntity UpdateEmployees(EmployeesEntity _Entidad)
        {
            return EmployeesDAO.UpdateEmployees(_Entidad);
        }        
    }
}
