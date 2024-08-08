using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class ProfilesPermisosBS
    {
        public static ProfilesPermisosEntity Save(ProfilesPermisosEntity _Entidad)
        {
            return ProfilesPermisosDAO.Save(_Entidad);
        }
        public static ProfilesPermisosEntity Update(ProfilesPermisosEntity _Entidad)
        {
            return ProfilesPermisosDAO.Update(_Entidad);
        }
        public static ProfilesPermisosEntity Delete(ProfilesPermisosEntity _Entidad)
        {
            return ProfilesPermisosDAO.Delete(_Entidad);
        }
    }
}
