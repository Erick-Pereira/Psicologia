using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface ISF36Service
    {
        Task<Response> CalcularScore(FuncionarioRespostasQuestionarioSf36 sf36score);
        Task<Response> CalcularScoreCapacidadeFuncional (FuncionarioRespostasQuestionarioSf36 sf36scoreCapacidadeFuncional);
        Task<Response> CalcularScoreLimitacaoFisica (FuncionarioRespostasQuestionarioSf36 sf36scoreLimitacaoFisica);
        Task<Response> CalcularScoreDor(FuncionarioRespostasQuestionarioSf36 sf36scoreDor);
        Task<Response> CalcularScoreEstadoSaude(FuncionarioRespostasQuestionarioSf36 sf36scoreEstadoSaude);
        Task<Response> CalcularScoreVitalidade  (FuncionarioRespostasQuestionarioSf36 sf36scoreVitalidade);
        Task<Response> CalcularScoreAspectosSociais (FuncionarioRespostasQuestionarioSf36 sf36scoreAspectosSociais);
        Task<Response> CalcularScoreLimitacaoEmocional(FuncionarioRespostasQuestionarioSf36 sf36scoreLimitacaoEmocional);
        Task<Response> CalcularScoreSaudeMental (FuncionarioRespostasQuestionarioSf36 sf36scoreSaudeMental);
    } 
}
