using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface ISF36Service
    {
        Task<Response> CalcularScore(FuncionarioRespostasQuestionarioSf36 sf36score);

        Task<double> CalcularScoreCapacidadeFuncional(FuncionarioRespostasQuestionarioSf36 sf36scoreCapacidadeFuncional);

        Task<double> CalcularScoreLimitacaoFisica(FuncionarioRespostasQuestionarioSf36 sf36scoreLimitacaoFisica);

        Task<double> CalcularScoreDor(FuncionarioRespostasQuestionarioSf36 sf36scoreDor);

        Task<double> CalcularScoreEstadoSaude(FuncionarioRespostasQuestionarioSf36 sf36scoreEstadoSaude);

        Task<double> CalcularScoreVitalidade(FuncionarioRespostasQuestionarioSf36 sf36scoreVitalidade);

        Task<double> CalcularScoreAspectosSociais(FuncionarioRespostasQuestionarioSf36 sf36scoreAspectosSociais);

        Task<double> CalcularScoreLimitacaoEmocional(FuncionarioRespostasQuestionarioSf36 sf36scoreLimitacaoEmocional);

        Task<double> CalcularScoreSaudeMental(FuncionarioRespostasQuestionarioSf36 sf36scoreSaudeMental);
        Task<DataResponse<SF36Score>> GetLast3SFByFuncionario(int id);
        Task<string> CopararSaude(FuncionarioRespostasQuestionarioSf36 sf36scoreSaudeComparada);
        Task<Response> Insert(SF36Score score);
        Task<DataResponse<SF36Score>> GetAllByFuncionario(Funcionario funcionario);
        Task<DataResponse<SF36Score>> GetAllByFuncionario(int id);
        Task<SingleResponse<SF36Score>> GetByFuncionarioAndDate(Funcionario funcionario,DateTime data);
        Task<SingleResponse<SF36Score>> GetByFuncionarioAndDate(int id, DateTime data);
        Task<Response> Update(SF36Score score);
        Task<Response> Delete(SF36Score score);
    }
}