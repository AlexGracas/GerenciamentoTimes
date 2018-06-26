using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolModelBiblioteca
{
    public class ServiceClosedXML
    {
        public static void CriarPlanilhaJogadoresTimes(IEnumerable<Time> times, String caminho)
        {
            var workbook = new XLWorkbook();
            foreach (Time t in times)
            {
                var worksheet = workbook.Worksheets.Add(t.Nome);
                worksheet.Cell("A1").Value = "Jogador";
                var columnNome = worksheet.Column("A");
                var columnNumero = worksheet.Column("B");
                var columnDataDeNascimento = worksheet.Column("C");
                var columnIdade = worksheet.Column("D");
                int ListaJogadoresLinhaInicio = 4;
                columnNome.Cell(ListaJogadoresLinhaInicio).
                    Value = "Nome";
                columnNumero.Cell(ListaJogadoresLinhaInicio).
                    Value = "Número";
                columnDataDeNascimento.Cell(ListaJogadoresLinhaInicio).
                    Value = "Data de Nascimento";
                columnIdade.Cell(ListaJogadoresLinhaInicio).
                    Value = "Idade";
                worksheet.Row(1).Style.Fill.BackgroundColor = XLColor.Gray;
                worksheet.Row(1).Style.Font.Bold = true;
                foreach(Jogador j in t.Jogadores)
                {
                    columnNome.Cell(ListaJogadoresLinhaInicio).Value = j.Nome;
                    columnNumero.Cell(ListaJogadoresLinhaInicio).Value = j.Numero;
                    columnDataDeNascimento.Cell(ListaJogadoresLinhaInicio).Value = j.Nascimento;
                    string calcularIdade =
                        "= =ARREDMULTB(FRAÇÃOANO(HOJE();C" + ListaJogadoresLinhaInicio + ");1) ";
                    columnIdade.Cell(ListaJogadoresLinhaInicio).Value =
                        calcularIdade;
                    ListaJogadoresLinhaInicio++;
                }
            }

            workbook.SaveAs(caminho);
        }
    }
}
