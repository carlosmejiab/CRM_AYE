using CapaDAO;
using CapaEntity;
using System.Data;

namespace CapaBusiness
{
    public class ClientAccountBS
    {
        ClientAccountDAO ca = new ClientAccountDAO();
        //DataSet ds;

        public static ClientAccountEntity Save(ClientAccountEntity _Entidad)
        {
            return ClientAccountDAO.Save(_Entidad);
        }
        public static ClientAccountEntity Update(ClientAccountEntity _Entidad)
        {
            return ClientAccountDAO.Update(_Entidad);
        }
        public static ClientAccountEntity Delete(ClientAccountEntity _Entidad)
        {
            return ClientAccountDAO.Delete(_Entidad);
        }

    }
}
