using BusinessLogicalLayer.Interfaces;
using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.BLL
{
    public class SF36Service : ISF36Service
    {
        public Task<Response> CalcularScore(FuncionarioRespostasQuestionarioSf36 sf36scoretotal)
        {
            double cont = 0;
            switch (sf36scoretotal.Question1)
            {
                case 1:
                    cont += 5;
                    break;
                case 2:
                    cont += 4.4;
                    break;
                case 3:
                    cont += 3.4;
                    break;
                case 4:
                    cont += 2;
                    break;
                case 5:
                    cont += 1;
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                if (sf36scoretotal.Question3 == 1)
                {
                    cont++;
                }
                else if (sf36scoretotal.Question3 == 2)
                {
                    cont += 2;
                }
                else
                {
                    cont += 3;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (sf36scoretotal.Question4 == 1)
                {
                    cont++;
                }
                else
                {
                    cont += 2;
                }

            }
            for (int i = 0; i < 3; i++)
            {
                if (sf36scoretotal.Question5 == 1)
                {
                    cont++;
                }
                else
                {
                    cont += 2;
                }

            }
            switch (sf36scoretotal.Question6)
            {
                case 1:
                    cont += 5;
                    break;
                case 2:
                    cont += 4;
                    break;
                case 3:
                    cont += 3;
                    break;
                case 4:
                    cont += 2;
                    break;
                case 5:
                    cont += 1;
                    break;
            }
            switch (sf36scoretotal.Question7)
            {
                case 1:
                    cont += 6;
                    break;
                case 2:
                    cont += 5.4;
                    break;
                case 3:
                    cont += 4.2;
                    break;
                case 4:
                    cont += 3.1;
                    break;
                case 5:
                    cont += 2;
                    break;
                case 6:
                    cont += 1;
                    break;
            }
            if (sf36scoretotal.Question7 == 1 && sf36scoretotal.Question8 == 1)
            {
                cont += 6;
            }
            else if (sf36scoretotal.Question7 == 2 || sf36scoretotal.Question7 == 3
                || sf36scoretotal.Question7 == 4 || sf36scoretotal.Question7 == 5 && sf36scoretotal.Question8 == 1)
            {
                cont += 5;
            }
            else if (sf36scoretotal.Question7 == 2 || sf36scoretotal.Question7 == 3
                || sf36scoretotal.Question7 == 4 || sf36scoretotal.Question7 == 5 && sf36scoretotal.Question8 == 2)
            {
                cont += 4;
            }
            else if (sf36scoretotal.Question7 == 2 || sf36scoretotal.Question7 == 3
                || sf36scoretotal.Question7 == 4 || sf36scoretotal.Question7 == 5 && sf36scoretotal.Question8 == 3)
            {
                cont += 3;
            }
            else if (sf36scoretotal.Question7 == 2 || sf36scoretotal.Question7 == 3
                || sf36scoretotal.Question7 == 4 || sf36scoretotal.Question7 == 5 && sf36scoretotal.Question8 == 4)
            {
                cont += 2;
            }
            else
            {
                cont++;
            }
            switch (sf36scoretotal.Question9a)
            {
                case 1:
                    cont += 6;
                    break;
                case 2:
                    cont += 5;
                    break;
                case 3:
                    cont += 4;
                    break;
                case 4:
                    cont += 3;
                    break;
                case 5:
                    cont += 2;
                    break;
                case 6:
                    cont++;
                    break;
            }
            switch (sf36scoretotal.Question9b)
            {
                case 1:
                    cont += 1;
                    break;
                case 2:
                    cont += 2;
                    break;
                case 3:
                    cont += 3;
                    break;
                case 4:
                    cont += 4;
                    break;
                case 5:
                    cont += 5;
                    break;
                case 6:
                    cont += 6;
                    break;
            }
            switch (sf36scoretotal.Question9c)
            {
                case 1:
                    cont += 1;
                    break;
                case 2:
                    cont += 2;
                    break;
                case 3:
                    cont += 3;
                    break;
                case 4:
                    cont += 4;
                    break;
                case 5:
                    cont += 5;
                    break;
                case 6:
                    cont += 6;
                    break;
            }
            switch (sf36scoretotal.Question9d)
            {
                case 1:
                    cont += 6;
                    break;
                case 2:
                    cont += 5;
                    break;
                case 3:
                    cont += 4;
                    break;
                case 4:
                    cont += 3;
                    break;
                case 5:
                    cont += 2;
                    break;
                case 6:
                    cont++;
                    break;
            }
            switch (sf36scoretotal.Question9e)
            {
                case 1:
                    cont += 6;
                    break;
                case 2:
                    cont += 5;
                    break;
                case 3:
                    cont += 4;
                    break;
                case 4:
                    cont += 3;
                    break;
                case 5:
                    cont += 2;
                    break;
                case 6:
                    cont++;
                    break;
            }
            switch (sf36scoretotal.Question9f)
            {
                case 1:
                    cont += 1;
                    break;
                case 2:
                    cont += 2;
                    break;
                case 3:
                    cont += 3;
                    break;
                case 4:
                    cont += 4;
                    break;
                case 5:
                    cont += 5;
                    break;
                case 6:
                    cont += 6;
                    break;
            }
            switch (sf36scoretotal.Question9g)
            {
                case 1:
                    cont += 1;
                    break;
                case 2:
                    cont += 2;
                    break;
                case 3:
                    cont += 3;
                    break;
                case 4:
                    cont += 4;
                    break;
                case 5:
                    cont += 5;
                    break;
                case 6:
                    cont += 6;
                    break;
            }
            switch (sf36scoretotal.Question9h)
            {
                case 1:
                    cont += 6;
                    break;
                case 2:
                    cont += 5;
                    break;
                case 3:
                    cont += 4;
                    break;
                case 4:
                    cont += 3;
                    break;
                case 5:
                    cont += 2;
                    break;
                case 6:
                    cont++;
                    break;
            }
            switch (sf36scoretotal.Question9i)
            {
                case 1:
                    cont++;
                    break;
                case 2:
                    cont += 2;
                    break;
                case 3:
                    cont += 3;
                    break;
                case 4:
                    cont += 4;
                    break;
                case 5:
                    cont += 5;
                    break;
                case 6:
                    cont += 6;
                    break;
            }
            switch (sf36scoretotal.Question10)
            {
                case 1:
                    cont += 5;
                    break;
                case 2:
                    cont += 4;
                    break;
                case 3:
                    cont += 3;
                    break;
                case 4:
                    cont += 2;
                    break;
                case 5:
                    cont += 1;
                    break;
            }
            for (int i = 0; i < 2; i++)
            {
                if (sf36scoretotal.Question11 == 1)
                {
                    cont++;
                }
                else if (sf36scoretotal.Question11 == 2)
                {
                    cont += 2;
                }
                else if (sf36scoretotal.Question11 == 3)
                {
                    cont += 3;
                }
                else if (sf36scoretotal.Question11 == 4)
                {
                    cont += 2;
                }
                else
                {
                    cont += 5;
                }




            }
            switch (sf36scoretotal.Question11b)
            {
                case 1:
                    cont += 5;
                    break;
                case 2:
                    cont += 4;
                    break;
                case 3:
                    cont += 3;
                    break;
                case 4:
                    cont += 2;
                    break;
                case 5:
                    cont += 1;
                    break;

            }
            switch (sf36scoretotal.Question11d)
            {
                case 1:
                    cont += 5;
                    break;
                case 2:
                    cont += 4;
                    break;
                case 3:
                    cont += 3;
                    break;
                case 4:
                    cont += 2;
                    break;
                case 5:
                    cont += 1;
                    break;

            }
        }

        public Task<Response> CalcularScoreAspectosSociais(FuncionarioRespostasQuestionarioSf36 sf36scoreAspectosSociais)
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
            return $"{sf36scoreAspectosSociais - limiteInferior * (100) / (variacao)}";
        }

        public Task<Response> CalcularScoreCapacidadeFuncional(FuncionarioRespostasQuestionarioSf36 sf36scoreCapacidadeFuncional)
        {
            double  capaficadeFuncional = 0;
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
                return $"{capaficadeFuncional - limiteInferior * (100) / (variacao)}";
            }
        }

        public Task<Response> CalcularScoreDor(FuncionarioRespostasQuestionarioSf36 sf36scoreDor)
        {
            double dor7 = 0;
            double dor8 = 0;;
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
            return $"{dor8+dor7 - limiteInferior * (100) / (variacao)}";

        }

        public Task<Response> CalcularScoreEstadoSaude(FuncionarioRespostasQuestionarioSf36 sf36scoreEstadoSaude)
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
            for (int i = 0; i < 2; i++)
            {
                if (sf36scoreEstadoSaude.Question11 == 1)
                {
                    estadoSaude11++;
                }
                else if (sf36scoreEstadoSaude.Question11 == 2)
                {
                    estadoSaude11 += 2;
                }
                else if (sf36scoreEstadoSaude.Question11 == 3)
                {
                    estadoSaude11 += 3;
                }
                else if (sf36scoreEstadoSaude.Question11 == 4)
                {
                    estadoSaude11 += 2;
                }
                else
                {
                    estadoSaude11 += 5;
                }




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
                    estadoSaude11 += 1;
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
            return $"{estadoSaude1 + estadoSaude11 - limiteInferior * (100) / (variacao)}";
        }

        public Task<Response> CalcularScoreLimitacaoEmocional(FuncionarioRespostasQuestionarioSf36 sf36scoreLimitacaoEmocional)
        {
            double limitacaoEmocional = 0;
            double limiteInferior = 3;
            double variacao = 3;
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

        public Task<Response> CalcularScoreLimitacaoFisica(FuncionarioRespostasQuestionarioSf36 sf36scoreLimitacaoFisica)
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
                return $"{limitacaoFisica - limiteInferior * (100) / (variacao)}";
            }
        }

        public Task<Response> CalcularScoreSaudeMental(FuncionarioRespostasQuestionarioSf36 sf36scoreSaudeMental)e
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
            return $"{saudeMental - limiteInferior * (100) / (variacao)}";
        }

        public Task<Response> CalcularScoreVitalidade(FuncionarioRespostasQuestionarioSf36 sf36scoreVitalidade)
        {
            double vitalidade = 0; ;
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
                    vitalidade += 1;
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
                    vitalidade += 6;
                    break;
            }
            switch (sf36scoreVitalidade.Question9i)
            {
                case 1:
                    vitalidade++;
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
                    vitalidade += 6;    
                    break;
            }
            return $"{vitalidade - limiteInferior * (100) / (variacao)}";

        }
    }
}
