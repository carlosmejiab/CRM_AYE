using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class UsersBS
    {
        public static UsersEntity Save(UsersEntity _Entidad)
        {
            return UsersDAO.Save(_Entidad);
        }
        public static UsersEntity Update(UsersEntity _Entidad)
        {
            return UsersDAO.Update(_Entidad);
        }
        public static UsersEntity Delete(UsersEntity _Entidad)
        {
            return UsersDAO.Delete(_Entidad);
        }
    }
}
