using CapaDAO;
using CapaEntity;

namespace CapaBusiness
{
    public class TaskBS
    {
        public static TaskEntity Save(TaskEntity _Entidad)
        {
            return TaskDAO.Save(_Entidad);
        }
        public static TaskEntity Update(TaskEntity _Entidad)
        {
            return TaskDAO.Update(_Entidad);
        }
        public static TaskEntity Delete(TaskEntity _Entidad)
        {
            return TaskDAO.Delete(_Entidad);
        }
        public static TaskEntity SaveTaskSubTask(TaskEntity _Entidad)
        {
            return TaskDAO.SaveTaskSubTask(_Entidad);
        }
    }
}
