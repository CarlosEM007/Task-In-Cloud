using Supabase;
using Supabase.Postgrest.Responses;
using System.Reflection;
using Task_in_Cloud.Domain.Interface;
using Task_in_Cloud.Domain.Model.Entity;
using Task_in_Cloud.Infrastructure.Model;
using Task_In_Cloud.Shared;

namespace Task_in_Cloud.Infrastructure.Repository
{
    public class ObservacaoRepository : IRepository<Observacao>
    {
        protected readonly Client _client;

        public ObservacaoRepository() { }

        public ObservacaoRepository(Client client)
        {
            _client = client;
        }

        public async Task<bool> Delete(int id)
        {
            await _client.From<ObservacaoModel>()
                         .Filter($"idobservacao", Supabase.Postgrest.Constants.Operator.Equals, id)
                         .Delete();

            return true;
        }

        public async Task<Observacao> Get(int id)
        {
            ModeledResponse<ObservacaoModel> model = await _client.From<ObservacaoModel>()
                                                                  .Filter($"idobservacao", Supabase.Postgrest.Constants.Operator.Equals, id)
                                                                  .Get();

            if (model == null)
                return null;

            return MapperUtil.Map<ObservacaoModel, Observacao>(model.Models.FirstOrDefault());
            
        }

        public async Task<List<Observacao>> GetAll()
        {
            ModeledResponse<ObservacaoModel> model = await _client.From<ObservacaoModel>()
                                                                  .Get();

            if(model.Models.Count == 0)
            {
                return new List<Observacao>();
            }

            return MapperUtil.MapList<ObservacaoModel, Observacao>(model.Models);
        }

        public async Task<bool> Post(Observacao Entity)
        {
            ObservacaoModel Observacao = MapperUtil.Map<Observacao, ObservacaoModel>(Entity);

            await _client.From<ObservacaoModel>().Insert(Observacao);
            return true;
        }

        public async Task<bool> Put(Observacao Entity)
        {
            ObservacaoModel Observacao = MapperUtil.Map<Observacao, ObservacaoModel>(Entity);

            await _client.From<ObservacaoModel>().Update(Observacao);
            return true;
        }
    }
}