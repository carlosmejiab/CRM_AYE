using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class ContactBS
    {
        public static ContactEntity Save(ContactEntity _Entidad)
        {
            return ContactDAO.Save(_Entidad);
        }
        public static ContactEntity Update(ContactEntity _Entidad)
        {
            return ContactDAO.Update(_Entidad);
        }
        public static ContactEntity Delete(ContactEntity _Entidad)
        {
            return ContactDAO.Delete(_Entidad);
        }
    }
}
