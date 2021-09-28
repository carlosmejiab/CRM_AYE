using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class StateBS
    {
        public static StateEntity Save(StateEntity _Entidad)
        {
            return StateDAO.Save(_Entidad);
        }
        public static StateEntity Update(StateEntity _Entidad)
        {
            return StateDAO.Update(_Entidad);
        }
        public static StateEntity Delete(StateEntity _Entidad)
        {
            return StateDAO.Delete(_Entidad);
        }
    }
}
