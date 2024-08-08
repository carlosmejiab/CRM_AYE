using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class TablaMaestraBS
    {
        public static TablaMaestraEntity Save(TablaMaestraEntity _Entidad)
        {
            return TablaMaestraDAO.Save(_Entidad);
        }
        public static TablaMaestraEntity Update(TablaMaestraEntity _Entidad)
        {
            return TablaMaestraDAO.Update(_Entidad);
        }
        public static TablaMaestraEntity Delete(TablaMaestraEntity _Entidad)
        {
            return TablaMaestraDAO.Delete(_Entidad);
        }
    }
}
