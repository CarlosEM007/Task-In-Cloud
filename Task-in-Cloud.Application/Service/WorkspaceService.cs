using Task_in_Cloud.Application.Model.DTO;
using Task_in_Cloud.Domain.Model.Entity;
using Task_in_Cloud.Domain.Model.Interface;
using Task_in_Cloud.Infrastructure.Repository;
using Task_In_Cloud.Shared;
using Task_In_Cloud.Shared.Model.DTO;

namespace Task_in_Cloud.Domain.Service
{
    public class WorkspaceService : IService<WorkspaceDTO>
    {
        protected WorkspaceRepository _repository;

        public WorkspaceService(WorkspaceRepository Repository)
        {
            _repository = Repository;
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public virtual async Task<WorkspaceDTO> Get(int id)
        {
            Workspace Entity = await _repository.Get(id);

            if (Entity == null)
                return null;

            return MapperUtil.Map<Workspace, WorkspaceDTO>(Entity);
        }

        public virtual async Task<List<WorkspaceDTO>> GetAll()
        {
            List<Workspace> Entitys = await _repository.GetAll();

            if (Entitys.Count == 0)
            {
                return new List<WorkspaceDTO>();
            }

            return MapperUtil.MapList<Workspace, WorkspaceDTO>(Entitys);
        }

        public virtual async Task<bool> Post(WorkspaceDTO Workspace)
        {
            try
            {
                Workspace Entity = new Workspace(
                    Workspace.IdWorkspace,
                    Workspace.Titulo,
                    Workspace.Descricao
                );

                return await _repository.Post(Entity);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public virtual async Task<bool> Put(WorkspaceDTO Workspace)
        {
            try
            {
                Workspace Entity = new Workspace(
                    Workspace.IdWorkspace,
                    Workspace.Titulo,
                    Workspace.Descricao
                );

                return await _repository.Put(Entity);
            }
            catch
            {
                return false;
            }
        }
    }
}
