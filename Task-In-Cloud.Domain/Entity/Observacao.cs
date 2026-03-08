namespace Task_in_Cloud.Domain.Model.Entity
{
    public class Observacao
    {
        public int IdObservacao { get; set; }
        public string Descricao { get; set; }
        public int IdTask { get; set; }

        public Observacao(int idObservacao, string descricao, int idTask)
        {
            if (string.IsNullOrEmpty(descricao))
            {
                throw new Exception("Descrição da Observação não pode ser Nula!");
            }

            IdObservacao = idObservacao;
            Descricao = descricao;
            IdTask = idTask;    
        }
    }
}
