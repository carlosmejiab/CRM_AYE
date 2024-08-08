using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class TypeClientBS
    {
        public static TypeClientEntity Save(TypeClientEntity _Entidad)
        {
            return TypeClientDAO.Save(_Entidad);
        }
        public static TypeClientEntity Update(TypeClientEntity _Entidad)
        {
            return TypeClientDAO.Update(_Entidad);
        }
        public static TypeClientEntity Delete(TypeClientEntity _Entidad)
        {
            return TypeClientDAO.Delete(_Entidad);
        }
    }
}
