using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface ISF36Service
    {
        /// <summary>
        /// Calcula o Resultado do SF36 e Insere no banco de dados chamando o metodo Insert do SF36ScoreDAL
        /// </summary>
        /// <param name="sf36scoretotal"></param>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> CalcularScore(FuncionarioRespostasQuestionarioSf36 sf36score, Funcionario funcionario);

        /// <summary>
        /// Calcula o resultado de Aspectos Sociais do Questionario SF36
        /// </summary>
        /// <param name="sf36scoreAspectosSociais"></param>
        /// <returns>Retorna a pontuação de Aspectos Sociais</returns>
        Task<double> CalcularScoreAspectosSociais(FuncionarioRespostasQuestionarioSf36 sf36scoreAspectosSociais);

        /// <summary>
        /// Calcula o resultado de Capacidade Funcional do Questionario SF36
        /// </summary>
        /// <param name="sf36scoreCapacidadeFuncional"></param>
        /// <returns>Retorna a pontuação de Capacidade Funcional</returns>
        Task<double> CalcularScoreCapacidadeFuncional(FuncionarioRespostasQuestionarioSf36 sf36scoreCapacidadeFuncional);

        /// <summary>
        /// Calcula o resultado de Dor do Questionario SF36
        /// </summary>
        /// <param name="sf36scoreDor"></param>
        /// <returns>Retorna a pontuação de Dor</returns>
        Task<double> CalcularScoreDor(FuncionarioRespostasQuestionarioSf36 sf36scoreDor);

        /// <summary>
        /// Calcula o resultado de Estado Saude do Questionario SF36
        /// </summary>
        /// <param name="sf36scoreEstadoSaude"></param>
        /// <returns>Retorna a pontuação de Estado Saude</returns>
        Task<double> CalcularScoreEstadoSaude(FuncionarioRespostasQuestionarioSf36 sf36scoreEstadoSaude);

        /// <summary>
        /// Calcula o resultado de Limitação Emocional do Questionario SF36
        /// </summary>
        /// <param name="sf36scoreLimitacaoEmocional"></param>
        /// <returns>Retorna a pontuação de Limitação Emocional</returns>
        Task<double> CalcularScoreLimitacaoEmocional(FuncionarioRespostasQuestionarioSf36 sf36scoreLimitacaoEmocional);

        /// <summary>
        /// Calcula o resultado de Limitação Fisica do Questionario SF36
        /// </summary>
        /// <param name="sf36scoreLimitacaoFisica"></param>
        /// <returns>Retorna a pontuação de Limitação Fisica</returns>
        Task<double> CalcularScoreLimitacaoFisica(FuncionarioRespostasQuestionarioSf36 sf36scoreLimitacaoFisica);

        /// <summary>
        /// Calcula o resultado de Saude Mental do Questionario SF36
        /// </summary>
        /// <param name="sf36scoreSaudeMental"></param>
        /// <returns>Retorna a pontuação de Saude Mental</returns>
        Task<double> CalcularScoreSaudeMental(FuncionarioRespostasQuestionarioSf36 sf36scoreSaudeMental);

        /// <summary>
        /// Calcula o resultado de Vitalidade do Questionario SF36
        /// </summary>
        /// <param name="sf36scoreVitalidade"></param>
        /// <returns>Retorna a pontuação de Vitalidade</returns>
        Task<double> CalcularScoreVitalidade(FuncionarioRespostasQuestionarioSf36 sf36scoreVitalidade);

        /// <summary>
        /// Calcula o resultado de Comparação Saude do Questionario SF36
        /// </summary>
        /// <param name="sf36scoreSaudeComparada"></param>
        /// <returns>Retorna a alternativa de Comparação Saude</returns>
        Task<string> CopararSaude(FuncionarioRespostasQuestionarioSf36 sf36scoreSaudeComparada);

        /// <summary>
        /// Recebe um SF36Score e Chama o metodo Delete do SF36ScoreDAL
        /// </summary>
        /// <param name="score"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(SF36Score score);

        /// <summary>
        /// Recebe um Funcionario e chama o metodo GetAllByFuncionario do SF36ScoreDAL
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um DataResponse contendo todos os SF36 ligados a um Funcionario</returns>
        Task<DataResponse<SF36Score>> GetAllByFuncionario(Funcionario funcionario);

        /// <summary>
        /// Recebe um id de Funcionario e chama o metodo GetAllByFuncionario do SF36ScoreDAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um DataResponse contendo todos os SF36 ligados a um Funcionario</returns>
        Task<DataResponse<SF36Score>> GetAllByFuncionario(int id);

        /// <summary>
        /// Recebe um Funcionario e uma data e chama o metodo GetByFuncionarioAndDate do SF36ScoreDAL
        /// </summary>
        /// <param name="funcionario"></param>
        /// <param name="data"></param>
        /// <returns>Retorna um SingleResponse contendo todos os SF36 ligados a um Funcionario que foram feitos na data informada</returns>
        Task<SingleResponse<SF36Score>> GetByFuncionarioAndDate(Funcionario funcionario, DateTime data);

        /// <summary>
        /// Recebe um ID de Funcionario e uma data e chama o metodo GetByFuncionarioAndDate do SF36ScoreDAL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna um SingleResponse contendo todos os SF36 ligados a um Funcionario que foram feitos na data informada</returns>
        Task<SingleResponse<SF36Score>> GetByFuncionarioAndDate(int id, DateTime data);

        /// <summary>
        /// Recebe um ID de Funcionario e chama o metodo GetLast3SFByFuncionario do SF36ScoreDAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um DataResponse contendo os ultimos 3 SF36 ligados ao Funcionario informado</returns>
        Task<DataResponse<SF36Score>> GetLast3SFByFuncionario(int id);

        /// <summary>
        /// Recebe um SF36Score e chama o metodo Insert do SF36ScoreDAL
        /// </summary>
        /// <param name="score"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Insert(SF36Score score);

        /// <summary>
        /// Recebe um SF36Score e chama o metodo Update do SF36ScoreDAL
        /// </summary>
        /// <param name="score"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Update(SF36Score score);
    }
}