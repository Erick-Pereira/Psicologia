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
            double[] constructs = new double[9];
            string comparacaoSaude = "";
            switch (sf36scoretotal.Question1)
            {
                case 1:
                    constructs[0] += 5;
                    constructs[4] += 5;
                    break;

                case 2:
                    constructs[0] += 4.4;
                    constructs[4] += 4.4;
                    break;

                case 3:
                    constructs[0] += 3.4;
                    constructs[4] += 3.4;
                    break;

                case 4:
                    constructs[0] += 2;
                    constructs[4] += 2;
                    break;

                case 5:
                    constructs[0]++;
                    constructs[4]++;
                    break;
            }

            switch (sf36scoretotal.Question2)
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
            for (int i = 0; i < 10; i++)
            {
                if (sf36scoretotal.Question3 == 1)
                {
                    constructs[0]++;
                    constructs[2]++;
                }
                else if (sf36scoretotal.Question3 == 2)
                {
                    constructs[0] += 2;
                    constructs[2] += 2;
                }
                else
                {
                    constructs[0] += 3;
                    constructs[2] += 3;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (sf36scoretotal.Question4 == 1)
                {
                    constructs[0]++;
                    constructs[6]++;
                }
                else
                {
                    constructs[0] += 2;
                    constructs[6] += 2;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (sf36scoretotal.Question5 == 1)
                {
                    constructs[0]++;
                    constructs[5]++;
                }
                else
                {
                    constructs[0] += 2;
                    constructs[5] += 2;
                }
            }
            switch (sf36scoretotal.Question6)
            {
                case 1:
                    constructs[0] += 5;
                    constructs[1] += 5;
                    break;

                case 2:
                    constructs[0] += 4;
                    constructs[1] += 4;
                    break;

                case 3:
                    constructs[0] += 3;
                    constructs[1] += 3;
                    break;

                case 4:
                    constructs[0] += 2;
                    constructs[1] += 2;
                    break;

                case 5:
                    constructs[0] += 1;
                    constructs[1] += 1;
                    break;
            }
            switch (sf36scoretotal.Question7)
            {
                case 1:
                    constructs[0] += 6;
                    constructs[3] += 6;
                    break;

                case 2:
                    constructs[0] += 5.4;
                    constructs[3] += 5.4;
                    break;

                case 3:
                    constructs[0] += 4.2;
                    constructs[3] += 4.2;
                    break;

                case 4:
                    constructs[0] += 3.1;
                    constructs[3] += 3.1;
                    break;

                case 5:
                    constructs[0] += 2;
                    constructs[3] += 2;
                    break;

                case 6:
                    constructs[0]++;
                    constructs[3]++;
                    break;
            }
            if (sf36scoretotal.Question7 == 1 && sf36scoretotal.Question8 == 1)
            {
                constructs[0] += 6;
                constructs[3] += 6;
            }
            else if (sf36scoretotal.Question7 == 2 || sf36scoretotal.Question7 == 3
                || sf36scoretotal.Question7 == 4 || sf36scoretotal.Question7 == 5 && sf36scoretotal.Question8 == 1)
            {
                constructs[0] += 5;
                constructs[3] += 5;
            }
            else if (sf36scoretotal.Question7 == 2 || sf36scoretotal.Question7 == 3
                || sf36scoretotal.Question7 == 4 || sf36scoretotal.Question7 == 5 && sf36scoretotal.Question8 == 2)
            {
                constructs[0] += 4;
                constructs[3] += 4;
            }
            else if (sf36scoretotal.Question7 == 2 || sf36scoretotal.Question7 == 3
                || sf36scoretotal.Question7 == 4 || sf36scoretotal.Question7 == 5 && sf36scoretotal.Question8 == 3)
            {
                constructs[0] += 3;
                constructs[3] += 3;
            }
            else if (sf36scoretotal.Question7 == 2 || sf36scoretotal.Question7 == 3
                || sf36scoretotal.Question7 == 4 || sf36scoretotal.Question7 == 5 && sf36scoretotal.Question8 == 4)
            {
                constructs[0] += 2;
                constructs[3] += 2;
            }
            else
            {
                constructs[0]++;
                constructs[3]++;
            }
            switch (sf36scoretotal.Question9a)
            {
                case 1:
                    constructs[0] += 6;
                    constructs[8] += 6;
                    break;

                case 2:
                    constructs[0] += 5;
                    constructs[8] += 5;
                    break;

                case 3:
                    constructs[0] += 4;
                    constructs[8] += 4;
                    break;

                case 4:
                    constructs[0] += 3;
                    constructs[8] += 3;
                    break;

                case 5:
                    constructs[0] += 2;
                    constructs[8] += 2;
                    break;

                case 6:
                    constructs[0]++;
                    constructs[8]++;
                    break;
            }
            switch (sf36scoretotal.Question9b)
            {
                case 1:
                    constructs[0]++;
                    constructs[7]++;
                    break;

                case 2:
                    constructs[0] += 2;
                    constructs[7] += 2;
                    break;

                case 3:
                    constructs[0] += 3;
                    constructs[7] += 3;
                    break;

                case 4:
                    constructs[0] += 4;
                    constructs[7] += 4;
                    break;

                case 5:
                    constructs[0] += 5;
                    constructs[7] += 5;
                    break;

                case 6:
                    constructs[0] += 6;
                    constructs[7] += 6;
                    break;
            }
            switch (sf36scoretotal.Question9c)
            {
                case 1:
                    constructs[0]++;
                    constructs[7]++;
                    break;

                case 2:
                    constructs[0] += 2;
                    constructs[7] += 2;
                    break;

                case 3:
                    constructs[0] += 3;
                    constructs[7] += 3;
                    break;

                case 4:
                    constructs[0] += 4;
                    constructs[7] += 4;
                    break;

                case 5:
                    constructs[0] += 5;
                    constructs[7] += 5;
                    break;

                case 6:
                    constructs[0] += 6;
                    constructs[7] += 6;
                    break;
            }
            switch (sf36scoretotal.Question9d)
            {
                case 1:
                    constructs[0] += 6;
                    constructs[7] += 6;
                    break;

                case 2:
                    constructs[0] += 5;
                    constructs[7] += 5;
                    break;

                case 3:
                    constructs[0] += 4;
                    constructs[7] += 4;
                    break;

                case 4:
                    constructs[0] += 3;
                    constructs[7] += 3;
                    break;

                case 5:
                    constructs[0] += 2;
                    constructs[7] += 2;
                    break;

                case 6:
                    constructs[0]++;
                    constructs[7]++;
                    break;
            }
            switch (sf36scoretotal.Question9e)
            {
                case 1:
                    constructs[0] += 6;
                    constructs[8] += 6;
                    break;

                case 2:
                    constructs[0] += 5;
                    constructs[8] += 5;
                    break;

                case 3:
                    constructs[0] += 4;
                    constructs[8] += 4;
                    break;

                case 4:
                    constructs[0] += 3;
                    constructs[8] += 3;
                    break;

                case 5:
                    constructs[0] += 2;
                    constructs[8] += 2;
                    break;

                case 6:
                    constructs[0]++;
                    constructs[8]++;
                    break;
            }
            switch (sf36scoretotal.Question9f)
            {
                case 1:
                    constructs[0]++;
                    constructs[7]++;
                    break;

                case 2:
                    constructs[0] += 2;
                    constructs[7] += 2;
                    break;

                case 3:
                    constructs[0] += 3;
                    constructs[7] += 3;
                    break;

                case 4:
                    constructs[0] += 4;
                    constructs[7] += 4;
                    break;

                case 5:
                    constructs[0] += 5;
                    constructs[7] += 5;
                    break;

                case 6:
                    constructs[0] += 6;
                    constructs[7] += 6;
                    break;
            }
            switch (sf36scoretotal.Question9g)
            {
                case 1:
                    constructs[0]++;
                    constructs[8]++;
                    break;

                case 2:
                    constructs[0] += 2;
                    constructs[8] += 2;
                    break;

                case 3:
                    constructs[0] += 3;
                    constructs[8] += 3;
                    break;

                case 4:
                    constructs[0] += 4;
                    constructs[8] += 4;
                    break;

                case 5:
                    constructs[0] += 5;
                    constructs[8] += 5;
                    break;

                case 6:
                    constructs[0] += 6;
                    constructs[8] += 6;
                    break;
            }
            switch (sf36scoretotal.Question9h)
            {
                case 1:
                    constructs[0] ++;
                    constructs[7] ++;
                    break;

                case 2:
                    constructs[0] += 2;
                    constructs[7] += 2;
                    break;

                case 3:
                    constructs[0] += 3;
                    constructs[7] += 3;
                    break;

                case 4:
                    constructs[0] += 4;
                    constructs[7] += 4;
                    break;

                case 5:
                    constructs[0] += 5;
                    constructs[7] += 5;
                    break;

                case 6:
                    constructs[0]+=6;
                    constructs[7]+=6;
                    break;
            }
            switch (sf36scoretotal.Question9i)
            {
                case 1:
                    constructs[0]+=6;
                    constructs[8]+=6;
                    break;

                case 2:
                    constructs[0] += 5;
                    constructs[8] += 5;
                    break;

                case 3:
                    constructs[0] += 4;
                    constructs[8] += 4;
                    break;

                case 4:
                    constructs[0] += 5;
                    constructs[8] += 5;
                    break;

                case 5:
                    constructs[0] += 6;
                    constructs[8] += 6;
                    break;

                case 6:
                    constructs[0] ++;
                    constructs[8] ++;
                    break;
            }
            switch (sf36scoretotal.Question10)
            {
                case 1:
                    constructs[0] += 1;
                    constructs[1] += 1;
                    break;

                case 2:
                    constructs[0] += 2;
                    constructs[1] += 2;
                    break;

                case 3:
                    constructs[0] += 3;
                    constructs[1] += 3;
                    break;

                case 4:
                    constructs[0] += 4;
                    constructs[1] += 4;
                    break;

                case 5:
                    constructs[0] += 5;
                    constructs[1] += 5;
                    break;
            }
            switch (sf36scoretotal.Question11a)
            {
                case 1:
                    constructs[0] ++;
                    constructs[4] ++;
                    break;

                case 2:
                    constructs[0] += 2;
                    constructs[4] += 2;
                    break;

                case 3:
                    constructs[0] += 3;
                    constructs[4] += 3;
                    break;

                case 4:
                    constructs[0] += 4;
                    constructs[4] += 4;
                    break;

                case 5:
                    constructs[0] += 5;
                    constructs[4] += 5;
                    break;
            }
            switch (sf36scoretotal.Question11b)
            {
                case 1:
                    constructs[0] += 5;
                    constructs[4] += 5;
                    break;

                case 2:
                    constructs[0] += 4;
                    constructs[4] += 4;
                    break;

                case 3:
                    constructs[0] += 3;
                    constructs[4] += 3;
                    break;

                case 4:
                    constructs[0] += 2;
                    constructs[4] += 2;
                    break;

                case 5:
                    constructs[0] += 1;
                    constructs[4] += 1;
                    break;
            }
            switch (sf36scoretotal.Question11c)
            {
                case 1:
                    constructs[0] ++;
                    constructs[4] ++;
                    break;

                case 2:
                    constructs[0] += 2;
                    constructs[4] += 2;
                    break;

                case 3:
                    constructs[0] += 3;
                    constructs[4] += 3;
                    break;

                case 4:
                    constructs[0] += 4;
                    constructs[4] += 4;
                    break;

                case 5:
                    constructs[0] += 5;
                    constructs[4] += 5;
                    break;
            }
            switch (sf36scoretotal.Question11d)
            {
                case 1:
                    constructs[0] += 5;
                    constructs[4] += 5;
                    break;

                case 2:
                    constructs[0] += 4;
                    constructs[4] += 4;
                    break;

                case 3:
                    constructs[0] += 3;
                    constructs[4] += 3;
                    break;

                case 4:
                    constructs[0] += 2;
                    constructs[4] += 2;
                    break;

                case 5:
                    constructs[0] ++;
                    constructs[4] ++;
                    break;
            }
            constructs[1] = CalcularScoreAspectosSociais(sf36scoretotal).Result;
            constructs[2] = CalcularScoreCapacidadeFuncional(sf36scoretotal).Result;
            constructs[3] = CalcularScoreDor(sf36scoretotal).Result;
            constructs[4] = CalcularScoreEstadoSaude(sf36scoretotal).Result;
            constructs[5] = CalcularScoreLimitacaoEmocional(sf36scoretotal).Result;
            constructs[6] = CalcularScoreLimitacaoFisica(sf36scoretotal).Result;
            constructs[7] = CalcularScoreSaudeMental(sf36scoretotal).Result;
            constructs[8] = CalcularScoreVitalidade(sf36scoretotal).Result;
            comparacaoSaude = CopararSaude(sf36scoretotal).Result;

            SF36Score score = new SF36Score()
            {
                AspectosSociais = constructs[1],
                CapacidadeFuncional = constructs[2],
                Dor = constructs[3],
                EstadoSaude = constructs[4],
                AspectosEmocionais = constructs[5],
                LimitacaoAspectosFisicos = constructs[6],
                SaudeMental = constructs[7],
                Vitalidade = constructs[8],
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
            for (int i = 0; i < 10; i++)
            {
                if (sf36scoreCapacidadeFuncional.Question3 == 1)
                {
                    capaficadeFuncional++;
                }
                else if (sf36scoreCapacidadeFuncional.Question3 == 2)
                {
                    capaficadeFuncional += 2;
                }
                else
                {
                    capaficadeFuncional += 3;
                }
            }
            return (capaficadeFuncional - limiteInferior) * 100 / variacao;
        }

        public async Task<double> CalcularScoreDor(FuncionarioRespostasQuestionarioSf36 sf36scoreDor)
        {
            double dor7 = 0;
            double dor8 = 0; 
            double limiteInferior = 2;
            double variacao = 10;
            switch (sf36scoreDor.Question7)
            {
                case 1:
                    dor7 += 6;
                    break;

                case 2:
                    dor7 += 5.4;
                    break;

                case 3:
                    dor7 += 4.2;
                    break;

                case 4:
                    dor7 += 3.1;
                    break;

                case 5:
                    dor7 += 2;
                    break;

                case 6:
                    dor7 += 1;
                    break;
            }
            if (sf36scoreDor.Question7 == 1 && sf36scoreDor.Question8 == 1)
            {
                dor8 += 6;
            }
            else if (sf36scoreDor.Question7 == 2 || sf36scoreDor.Question7 == 3
                || sf36scoreDor.Question7 == 4 || sf36scoreDor.Question7 == 5 && sf36scoreDor.Question8 == 1)
            {
                dor8 += 5;
            }
            else if (sf36scoreDor.Question7 == 2 || sf36scoreDor.Question7 == 3
                || sf36scoreDor.Question7 == 4 || sf36scoreDor.Question7 == 5 && sf36scoreDor.Question8 == 2)
            {
                dor8 += 4;
            }
            else if (sf36scoreDor.Question7 == 2 || sf36scoreDor.Question7 == 3
                || sf36scoreDor.Question7 == 4 || sf36scoreDor.Question7 == 5 && sf36scoreDor.Question8 == 3)
            {
                dor8 += 3;
            }
            else if (sf36scoreDor.Question7 == 2 || sf36scoreDor.Question7 == 3
                || sf36scoreDor.Question7 == 4 || sf36scoreDor.Question7 == 5 && sf36scoreDor.Question8 == 4)
            {
                dor8 += 2;
            }
            else
            {
                dor8++;
            }
            return (dor8 + dor7 - limiteInferior) * 100 / variacao;
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
            return (estadoSaude1 + estadoSaude11 - limiteInferior) * 100 / variacao;
        }

        public async Task<double> CalcularScoreLimitacaoEmocional(FuncionarioRespostasQuestionarioSf36 sf36scoreLimitacaoEmocional)
        {
            double limitacaoEmocional = 0;
            double limiteInferior = 3;
            double variacao = 3;
            {
                for (int i = 0; i < 3; i++)
                {
                    if (sf36scoreLimitacaoEmocional.Question5 == 1)
                    {
                        limitacaoEmocional++;
                    }
                    else 
                    {
                        limitacaoEmocional += 2;
                    }
                }
               
            }
            return (limitacaoEmocional - limiteInferior) * 100 / variacao;
        }

        public async Task<double> CalcularScoreLimitacaoFisica(FuncionarioRespostasQuestionarioSf36 sf36scoreLimitacaoFisica)
        {
            double limitacaoFisica = 0;
            double limiteInferior = 4;
            double variacao = 4;
            for (int i = 0; i < 4; i++)
            {
                if (sf36scoreLimitacaoFisica.Question4 == 1)
                {
                    limitacaoFisica++;
                }
                else
                {
                    limitacaoFisica += 2;
                }
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
            switch (sf36scoreSaudeMental.Question9h)
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
                    vitalidade ++;
                    break;
            }
            switch (sf36scoreVitalidade.Question9i)
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
    }
}