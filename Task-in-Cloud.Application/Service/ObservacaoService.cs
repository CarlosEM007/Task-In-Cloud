using System.Reflection;
using Task_in_Cloud.Application.Model.DTO;
using Task_in_Cloud.Domain.Model.Entity;
using Task_in_Cloud.Domain.Model.Interface;
using Task_in_Cloud.Infrastructure.Repository;
using Task_In_Cloud.Shared.Utils;

namespace Task_in_Cloud.Application.Service
{
    public class ObservacaoService: IService<ObservacaoDTO>
    {
        protected ObservacaoRepository _repository;

        public ObservacaoService(ObservacaoRepository Repository)
        {
            _repository = Repository;
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public virtual async Task<ObservacaoDTO> Get(int id)
        {
            Observacao Entity = await _repository.Get(id);

            if (Entity == null)
                return null;

            return Mapper.Map<ObservacaoDTO>(Entity);
        }

        public virtual async Task<List<ObservacaoDTO>> GetAll()
        {
            List<Observacao> Entitys = await _repository.GetAll();

            if (Entitys.Count == 0)
            {
                return new List<ObservacaoDTO>();
            }

            return Mapper.Map<List<ObservacaoDTO>>(Entitys);
        }

        public virtual async Task<bool> Post(ObservacaoDTO Observacao)
        {
            try
            {
                Observacao Entity = new Observacao(
                    Observacao.IdObservacao,
                    Observacao.Descricao,
                    Observacao.IdTask
                );

                return await _repository.Post(Entity);
            }
            catch
            {
                return false;
            }
        }

        public virtual async Task<bool> Put(ObservacaoDTO Observacao)
        {
            try
            {
                Observacao Entity = new Observacao(
                    Observacao.IdObservacao,
                    Observacao.Descricao,
                    Observacao.IdTask
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
