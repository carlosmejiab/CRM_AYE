using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class CityBS
    {
        public static CityEntity Save(CityEntity _Entidad)
        {
            return CityDAO.Save(_Entidad);
        }
        public static CityEntity Update(CityEntity _Entidad)
        {
            return CityDAO.Update(_Entidad);
        }
        public static CityEntity Delete(CityEntity _Entidad)
        {
            return CityDAO.Delete(_Entidad);
        }
    }
}
