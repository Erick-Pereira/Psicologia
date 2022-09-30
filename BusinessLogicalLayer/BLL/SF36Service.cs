using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class SF36Service : ISF36Service
    {
        private readonly ISFScoreDAL _scoreDAL;

        public SF36Service(ISFScoreDAL scoreDAL)
        {
            _scoreDAL = scoreDAL;
        }

        public async Task<Response> CalcularScore(FuncionarioRespostasQuestionarioSf36 sf36scoretotal)
        {

            double[] constructs = new double[8];
            string comparacaoSaude = "";
           
            constructs[0] = CalcularScoreAspectosSociais(sf36scoretotal).Result;
            constructs[1] = CalcularScoreCapacidadeFuncional(sf36scoretotal).Result;
            constructs[2] = CalcularScoreDor(sf36scoretotal).Result;
            constructs[3] = CalcularScoreEstadoSaude(sf36scoretotal).Result;
            constructs[4] = CalcularScoreLimitacaoEmocional(sf36scoretotal).Result;
            constructs[5] = CalcularScoreLimitacaoFisica(sf36scoretotal).Result;
            constructs[6] = CalcularScoreSaudeMental(sf36scoretotal).Result;
            constructs[7] = CalcularScoreVitalidade(sf36scoretotal).Result;
            comparacaoSaude = CopararSaude(sf36scoretotal).Result;

            SF36Score score = new SF36Score()
            {
                AspectosSociais = constructs[0],
                CapacidadeFuncional = constructs[1],
                Dor = constructs[2],
                EstadoSaude = constructs[3],
                AspectosEmocionais = constructs[4],
                LimitacaoAspectosFisicos = constructs[5],
                SaudeMental = constructs[6],
                Vitalidade = constructs[7],
            };

            return await _scoreDAL.Insert(score);
           }

        public async Task<double> CalcularScoreAspectosSociais(FuncionarioRespostasQuestionarioSf36 sf36scoreAspectosSociais)
        {
            
            double aspectosSociais = 0;
            double limiteInferior = 2;
            double variacao = 8;
            switch (sf36scoreAspectosSociais.Question6)
            {
                case 1:
                    aspectosSociais += 5;
                    break;

                case 2:
                    aspectosSociais += 4;
                    break;

                case 3:
                    aspectosSociais += 3;
                    break;

                case 4:
                    aspectosSociais += 2;
                    break;

                case 5:
                    aspectosSociais += 1;
                    break;
            }
            switch (sf36scoreAspectosSociais.Question10)
            {
                case 1:
                    aspectosSociais += 1;
                    break;

                case 2:
                    aspectosSociais += 2;
                    break;

                case 3:
                    aspectosSociais += 3;
                    break;

                case 4:
                    aspectosSociais += 4;
                    break;

                case 5:
                    aspectosSociais += 5;
                    break;
            }
            return (aspectosSociais - limiteInferior) * 100 / variacao;
        }

        public async Task<double> CalcularScoreCapacidadeFuncional(FuncionarioRespostasQuestionarioSf36 sf36scoreCapacidadeFuncional) 
        {
            double capaficadeFuncional = 0;
            double limiteInferior = 10;
            double variacao = 20;
            {
                switch (sf36scoreCapacidadeFuncional.Question3a)
                {
                    case 1:
                        capaficadeFuncional ++;
                        break;

                    case 2:
                        capaficadeFuncional+=2;
                        break;

                    case 3:
                        capaficadeFuncional += 3;
                        break;

                }
                switch (sf36scoreCapacidadeFuncional.Question3b)
                {
                    case 1:
                        capaficadeFuncional++;
                        break;

                    case 2:
                        capaficadeFuncional += 2;
                        break;

                    case 3:
                        capaficadeFuncional += 3;
                        break;

                }
                switch (sf36scoreCapacidadeFuncional.Question3c)
                {
                    case 1:
                        capaficadeFuncional++;
                        break;

                    case 2:
                        capaficadeFuncional += 2;
                        break;

                    case 3:
                        capaficadeFuncional += 3;
                        break;

                }
                switch (sf36scoreCapacidadeFuncional.Question3d)
                {
                    case 1:
                        capaficadeFuncional++;
                        break;

                    case 2:
                        capaficadeFuncional += 2;
                        break;

                    case 3:
                        capaficadeFuncional += 3;
                        break;

                }
                switch (sf36scoreCapacidadeFuncional.Question3e)
                {
                    case 1:
                        capaficadeFuncional++;
                        break;

                    case 2:
                        capaficadeFuncional += 2;
                        break;

                    case 3:
                        capaficadeFuncional += 3;
                        break;

                }
                switch (sf36scoreCapacidadeFuncional.Question3f)
                {
                    case 1:
                        capaficadeFuncional++;
                        break;

                    case 2:
                        capaficadeFuncional += 2;
                        break;

                    case 3:
                        capaficadeFuncional += 3;
                        break;

                }
                switch (sf36scoreCapacidadeFuncional.Question3g)
                {
                    case 1:
                        capaficadeFuncional++;
                        break;

                    case 2:
                        capaficadeFuncional += 2;
                        break;

                    case 3:
                        capaficadeFuncional += 3;
                        break;

                }
                switch (sf36scoreCapacidadeFuncional.Question3h)
                {
                    case 1:
                        capaficadeFuncional++;
                        break;

                    case 2:
                        capaficadeFuncional += 2;
                        break;

                    case 3:
                        capaficadeFuncional += 3;
                        break;

                }
                switch (sf36scoreCapacidadeFuncional.Question3i)
                {
                    case 1:
                        capaficadeFuncional++;
                        break;

                    case 2:
                        capaficadeFuncional += 2;
                        break;

                    case 3:
                        capaficadeFuncional += 3;
                        break;

                }
                switch (sf36scoreCapacidadeFuncional.Question3j)
                {
                    case 1:
                        capaficadeFuncional++;
                        break;

                    case 2:
                        capaficadeFuncional += 2;
                        break;

                    case 3:
                        capaficadeFuncional += 3;
                        break;

                }
            }
            return (capaficadeFuncional - limiteInferior) * 100 / variacao;
        }

        public async Task<double> CalcularScoreDor(FuncionarioRespostasQuestionarioSf36 sf36scoreDor)
        {
            double dor = 0;
            double limiteInferior = 2;
            double variacao = 10;
            switch (sf36scoreDor.Question7)
            {
                case 1:
                    dor += 6;
                    break;

                case 2:
                    dor += 5.4;
                    break;

                case 3:
                    dor+= 4.2;
                    break;

                case 4:
                    dor += 3.1;
                    break;

                case 5:
                    dor += 2;
                    break;

                case 6:
                    dor += 1;
                    break;
            }
            switch (sf36scoreDor.Question8)
            {
                case 1:
                    if (sf36scoreDor.Question7 == 1)
                    {
                        dor += 6;
                    }
                    else
                    {
                        dor+=6;
                    }
                    break;

                case 2:
                    if (sf36scoreDor.Question7 !=1)
                    {
                        dor += 4;
                    }
                    else
                    {
                        dor += 6;
                    }
                    
                    break;

                case 3:
                    if (sf36scoreDor.Question7 != 1)
                    {
                        dor += 3;
                        
                    }
                    else
                    {
                        dor += 6;
                    }

                    break;

                case 4:
                    if (sf36scoreDor.Question7 != 1)
                    {
                        dor+= 2;
                    }
                    else
                    {
                        dor += 6;
                    }

                    break;

                case 5:
                    if (sf36scoreDor.Question7 !=1)
                    {
                        dor += 1;
                    }
                    else
                    {
                        dor += 6;
                    }

                    break;

          
            }
            return (Math.Round((dor - limiteInferior) * 100 / variacao, MidpointRounding.AwayFromZero));
        }

        public async Task<double> CalcularScoreEstadoSaude(FuncionarioRespostasQuestionarioSf36 sf36scoreEstadoSaude)
        {
            double estadoSaude1 = 0;
            double estadoSaude11 = 0;
            double limiteInferior = 5;
            double variacao = 20;
            switch (sf36scoreEstadoSaude.Question1)
            {
                case 1:
                    estadoSaude1 += 5;
                    break;

                case 2:
                    estadoSaude1 += 4.4;
                    break;

                case 3:
                    estadoSaude1 += 3.4;
                    break;

                case 4:
                    estadoSaude1 += 2;
                    break;

                case 5:
                    estadoSaude1 += 1;
                    break;
            }
            switch (sf36scoreEstadoSaude.Question11a)
            {
                case 1:
                    estadoSaude11 ++;
                    break;

                case 2:
                    estadoSaude11 += 2;
                    break;

                case 3:
                    estadoSaude11 += 3;
                    break;

                case 4:
                    estadoSaude11 += 4;
                    break;

                case 5:
                    estadoSaude11 += 5;
                    break;
            }
            switch (sf36scoreEstadoSaude.Question11b)
            {
                case 1:
                    estadoSaude11 += 5;
                    break;

                case 2:
                    estadoSaude11 += 4;
                    break;

                case 3:
                    estadoSaude11 += 3;
                    break;

                case 4:
                    estadoSaude11 += 2;
                    break;

                case 5:
                    estadoSaude11 ++;
                    break;
            }
            switch (sf36scoreEstadoSaude.Question11c)
            {
                case 1:
                    estadoSaude11 ++;
                    break;

                case 2:
                    estadoSaude11 +=2;
                    break;

                case 3:
                    estadoSaude11 += 3;
                    break;

                case 4:
                    estadoSaude11 += 4;
                    break;

                case 5:
                    estadoSaude11+= 5;
                    break;
            }
            switch (sf36scoreEstadoSaude.Question11d)
            {
                case 1:
                    estadoSaude11 += 5;
                    break;

                case 2:
                    estadoSaude11 += 4;
                    break;

                case 3:
                    estadoSaude11 += 3;
                    break;

                case 4:
                    estadoSaude11 += 2;
                    break;

                case 5:
                    estadoSaude11 += 1;
                    break;
            }
            return (Math.Round((estadoSaude1+estadoSaude11 - limiteInferior) * 100 / variacao, MidpointRounding.AwayFromZero));
        }

        public async Task<double> CalcularScoreLimitacaoEmocional(FuncionarioRespostasQuestionarioSf36 sf36scoreLimitacaoEmocional)
        {
            double limitacaoEmocional = 0;
            double limiteInferior = 3;
            double variacao = 3;
            {
                switch (sf36scoreLimitacaoEmocional.Question5a)
                {
                    case 1:
                        limitacaoEmocional++;
                        break;

                    case 2:
                        limitacaoEmocional += 2;
                        break;

                }
                switch (sf36scoreLimitacaoEmocional.Question5b)
                {
                    case 1:
                        limitacaoEmocional++;
                        break;

                    case 2:
                        limitacaoEmocional+= 2;
                        break;

                }
                switch (sf36scoreLimitacaoEmocional.Question5c)
                {
                    case 1:
                        limitacaoEmocional++;
                        break;

                    case 2:
                        limitacaoEmocional += 2;
                        break;
                }
            }
            return (limitacaoEmocional - limiteInferior) * 100 / variacao;
        }

        public async Task<double> CalcularScoreLimitacaoFisica(FuncionarioRespostasQuestionarioSf36 sf36scoreLimitacaoFisica)
        {
            double limitacaoFisica = 0;
            double limiteInferior = 4;
            double variacao = 4;
                switch (sf36scoreLimitacaoFisica.Question4a)
                {
                    case 1:
                        limitacaoFisica++;
                        break;

                    case 2:
                        limitacaoFisica += 2;
                        break;


                }
                switch (sf36scoreLimitacaoFisica.Question4b)
                {
                    case 1:
                        limitacaoFisica++;
                        break;

                    case 2:
                        limitacaoFisica += 2;
                        break;


                }
                switch (sf36scoreLimitacaoFisica.Question4c)
                {
                    case 1:
                        limitacaoFisica++;
                        break;

                    case 2:
                        limitacaoFisica += 2;
                        break;



                }
                switch (sf36scoreLimitacaoFisica.Question4d)
                {
                    case 1:
                        limitacaoFisica++;
                        break;

                    case 2:
                        limitacaoFisica += 2;
                        break;



                }
            return (limitacaoFisica - limiteInferior) * 100 / variacao;
        }

        public async Task<double> CalcularScoreSaudeMental(FuncionarioRespostasQuestionarioSf36 sf36scoreSaudeMental)
        {
            double saudeMental = 0;
            double limiteInferior = 5;
            double variacao = 25;
            switch (sf36scoreSaudeMental.Question9b)
            {
                case 1:
                    saudeMental += 1;
                    break;

                case 2:
                    saudeMental += 2;
                    break;

                case 3:
                    saudeMental += 3;
                    break;

                case 4:
                    saudeMental += 4;
                    break;

                case 5:
                    saudeMental += 5;
                    break;

                case 6:
                    saudeMental += 6;
                    break;
            }
            switch (sf36scoreSaudeMental.Question9c)
            {
                case 1:
                    saudeMental += 1;
                    break;

                case 2:
                    saudeMental += 2;
                    break;

                case 3:
                    saudeMental += 3;
                    break;

                case 4:
                    saudeMental += 4;
                    break;

                case 5:
                    saudeMental += 5;
                    break;

                case 6:
                    saudeMental += 6;
                    break;
            }
            switch (sf36scoreSaudeMental.Question9d)
            {
                case 1:
                    saudeMental += 6;
                    break;

                case 2:
                    saudeMental += 5;
                    break;

                case 3:
                    saudeMental += 4;
                    break;

                case 4:
                    saudeMental += 3;
                    break;

                case 5:
                    saudeMental += 2;
                    break;

                case 6:
                    saudeMental++;
                    break;
            }
            switch (sf36scoreSaudeMental.Question9f)
            {
                case 1:
                    saudeMental ++;
                    break;

                case 2:
                    saudeMental += 2;
                    break;

                case 3:
                    saudeMental += 3;
                    break;

                case 4:
                    saudeMental += 4;
                    break;

                case 5:
                    saudeMental += 5;
                    break;

                case 6:
                    saudeMental += 6;
                    break;
            }
            switch (sf36scoreSaudeMental.Question9h)
            {
                case 1:
                    saudeMental +=6;
                    break;

                case 2:
                    saudeMental += 5;
                    break;

                case 3:
                    saudeMental += 4;
                    break;

                case 4:
                    saudeMental += 3;
                    break;

                case 5:
                    saudeMental += 2;
                    break;

                case 6:
                    saudeMental++;
                    break;
            }
            return (saudeMental - limiteInferior) * 100 / variacao;
        }

        public async Task<double> CalcularScoreVitalidade(FuncionarioRespostasQuestionarioSf36 sf36scoreVitalidade)
        {
            double vitalidade = 0;
            double limiteInferior = 4;
            double variacao = 20;
            switch (sf36scoreVitalidade.Question9a)
            {
                case 1:
                    vitalidade += 6;
                    break;

                case 2:
                    vitalidade += 5;
                    break;

                case 3:
                    vitalidade += 4;
                    break;

                case 4:
                    vitalidade += 3;
                    break;

                case 5:
                    vitalidade += 2;
                    break;

                case 6:
                    vitalidade++;
                    break;
            }
            switch (sf36scoreVitalidade.Question9e)
            {
                case 1:
                    vitalidade += 6;
                    break;

                case 2:
                    vitalidade += 5;
                    break;

                case 3:
                    vitalidade += 4;
                    break;

                case 4:
                    vitalidade += 3;
                    break;

                case 5:
                    vitalidade += 2;
                    break;

                case 6:
                    vitalidade++;
                    break;
            }
            switch (sf36scoreVitalidade.Question9g)
            {
                case 1:
                    vitalidade ++;
                    break;

                case 2:
                    vitalidade += 2;
                    break;

                case 3:
                    vitalidade += 3;
                    break;

                case 4:
                    vitalidade += 4;
                    break;

                case 5:
                    vitalidade += 5;
                    break;

                case 6:
                    vitalidade +=6;
                    break;
            }
            switch (sf36scoreVitalidade.Question9i)
            {
                case 1:
                    vitalidade ++;
                    break;

                case 2:
                    vitalidade += 2;
                    break;

                case 3:
                    vitalidade += 3;
                    break;

                case 4:
                    vitalidade += 4;
                    break;

                case 5:
                    vitalidade += 5;
                    break;

                case 6:
                    vitalidade+=6;
                    break;
            }
            return (vitalidade - limiteInferior) * 100 / variacao;
        }

        public async Task<string> CopararSaude(FuncionarioRespostasQuestionarioSf36 sf36scoreSaudeComparada)
        {
            {
                string comparacaoSaude = "";

                switch ((sf36scoreSaudeComparada.Question2)
)
                {
                    case "1":
                        comparacaoSaude = "Muito Melhor";
                        break;

                    case "2":
                        comparacaoSaude = "Um Pouco Melhor";
                        break;

                    case "3":
                        comparacaoSaude = "Quase a Mesma";
                        break;

                    case "4":
                        comparacaoSaude = "Um Pouco Pior";
                        break;

                    case "5":
                        comparacaoSaude = "Muito Pior";
                        break;
                }
                return comparacaoSaude;
            }
        }

        public async Task<Response> Delete(SF36Score score)
        {
           return await _scoreDAL.Delete(score);
        }


        public async Task<DataResponse<SF36Score>> GetAllByFuncionario(Funcionario funcionario)
        {
            return await _scoreDAL.GetAllByFuncionario(funcionario);
        }

        public async Task<DataResponse<SF36Score>> GetAllByFuncionario(int id)
        {
            return await _scoreDAL.GetAllByFuncionario(id);
        }

        public async Task<SingleResponse<SF36Score>> GetByFuncionarioAndDate(Funcionario funcionario, DateTime data)
        {
            return await _scoreDAL.GetByFuncionarioAndDate(funcionario, data);
        }

        public async Task<SingleResponse<SF36Score>> GetByFuncionarioAndDate(int id, DateTime data)
        {
            return await _scoreDAL.GetByFuncionarioAndDate(id, data);
        }

        public async Task<DataResponse<SF36Score>> GetLast3SFByFuncionario(int id)
        {
            return await _scoreDAL.GetLast3SFByFuncionario(id);
        }

        public async Task<Response> Insert(SF36Score score)
        {
            return await _scoreDAL.Insert(score);
        }

        public Task<Response> Update(SF36Score score)
        {
            return _scoreDAL.Update(score);
        }
    }
}