using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class DocumentBS
    {
        public static DocumentEntity Save(DocumentEntity _Entidad)
        {
            return DocumentDAO.Save(_Entidad);
        }
        public static DocumentEntity Update(DocumentEntity _Entidad)
        {
            return DocumentDAO.Update(_Entidad);
        }
        public static DocumentEntity Delete(DocumentEntity _Entidad)
        {
            return DocumentDAO.Delete(_Entidad);
        }
    }
}
