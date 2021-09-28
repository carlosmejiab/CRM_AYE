using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class ServicesBS
    {
        public static ServicesEntity Save(ServicesEntity _Entidad)
        {
            return ServicesDAO.Save(_Entidad);
        }
        public static ServicesEntity Update(ServicesEntity _Entidad)
        {
            return ServicesDAO.Update(_Entidad);
        }
        public static ServicesEntity Delete(ServicesEntity _Entidad)
        {
            return ServicesDAO.Delete(_Entidad);
        }
    }
}
