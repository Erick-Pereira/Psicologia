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

        Task<string> CopararSaude(FuncionarioRespostasQuestionarioSf36 sf36scoreSaudeComparada);
    }
}