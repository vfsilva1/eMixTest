using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCandidatoTriangulo
{
    public class Triangulo
    {
        /// <summary>
        ///    6
        ///   3 5
        ///  9 7 1
        /// 4 6 8 4
        /// Um elemento somente pode ser somado com um dos dois elementos da próxima linha. 
        /// Como o elemento 5 na Linha 2 pode ser somado com 7 e 1, mas não com o 9.
        /// Neste triangulo o total máximo é 6 + 5 + 7 + 8 = 26
        /// 
        /// Seu código deverá receber uma matriz (multidimensional) como entrada. O triângulo acima seria: [[6],[3,5],[9,7,1],[4,6,8,4]]
        /// </summary>
        /// <param name="dadosTriangulo"></param>
        /// <returns>Retorna o resultado do calculo conforme regra acima</returns>
        public int ResultadoTriangulo(string dadosTriangulo)
        {
            if (dadosTriangulo == string.Empty)
                return 0;

            List<List<int>> niveisTriangulo = ConverterMatriz(dadosTriangulo);

            int soma = 0;
            int index = 0;
            for (int i = 0; i < niveisTriangulo.Count; i++)
            {
                if (i == 0)
                    soma += niveisTriangulo[i][i];
                else
                {
                    if (niveisTriangulo[i][index] > niveisTriangulo[i][index + 1])
                    {
                        soma += niveisTriangulo[i][index];
                    }
                    else
                    {
                        soma += niveisTriangulo[i][index + 1];
                        index += 1;
                    }
                }
            }

            return soma;
        }

        private List<List<int>> ConverterMatriz(string dadosTriangulo)
        {
            var dadosDivididos = dadosTriangulo.Split(']');
            List<List<int>> niveisTriangulo = new List<List<int>>();

            foreach (var item in dadosDivididos)
            {
                if (item == string.Empty)
                    break;

                string level = item.Remove(0, 2);
                List<int> levelList = level.Split(',').Select(Int32.Parse).ToList<int>();
                niveisTriangulo.Add(levelList);
            }

            return niveisTriangulo;
        }
    }
}
