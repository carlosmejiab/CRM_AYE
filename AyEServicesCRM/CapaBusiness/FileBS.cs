using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class FileBS
    {
        public static FileEntity Save(FileEntity _Entidad)
        {
            return FileDAO.Save(_Entidad);
        }
        public static FileEntity Update(FileEntity _Entidad)
        {
            return FileDAO.Update(_Entidad);
        }
        public static FileEntity Delete(FileEntity _Entidad)
        {
            return FileDAO.Delete(_Entidad);
        }
    }
}
