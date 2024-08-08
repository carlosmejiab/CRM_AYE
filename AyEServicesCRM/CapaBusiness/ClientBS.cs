using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class ClientBS
    {
        public static ClientEntity Save(ClientEntity _Entidad)
        {
            return ClientDAO.Save(_Entidad);
        }
        public static ClientEntity Update(ClientEntity _Entidad)
        {
            return ClientDAO.Update(_Entidad);
        }
        public static ClientEntity Delete(ClientEntity _Entidad)
        {
            return ClientDAO.Delete(_Entidad);
        }
    }
}
