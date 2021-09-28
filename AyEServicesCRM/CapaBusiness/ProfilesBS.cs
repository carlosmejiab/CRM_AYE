using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class ProfilesBS
    {
        public static ProfilesEntity Save(ProfilesEntity _Entidad)
        {
            return ProfilesDAO.Save(_Entidad);
        }
        public static ProfilesEntity Update(ProfilesEntity _Entidad)
        {
            return ProfilesDAO.Update(_Entidad);
        }
        public static ProfilesEntity Delete(ProfilesEntity _Entidad)
        {
            return ProfilesDAO.Delete(_Entidad);
        }
    }
}
