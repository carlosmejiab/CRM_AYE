using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class FolderBS
    {
        public static FolderEntity Save(FolderEntity _Entidad)
        {
            return FolderDAO.Save(_Entidad);
        }
        public static FolderEntity Update(FolderEntity _Entidad)
        {
            return FolderDAO.Update(_Entidad);
        }
    }
}
