using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class SubTaskBS
    {
        public static SubTaskEntity Save(SubTaskEntity _Entidad)
        {
            return SubTaskDAO.Save(_Entidad);
        }
        public static SubTaskEntity Update(SubTaskEntity _Entidad)
        {
            return SubTaskDAO.Update(_Entidad);
        }
        public static SubTaskEntity Delete(SubTaskEntity _Entidad)
        {
            return SubTaskDAO.Delete(_Entidad);
        }
    }
}
