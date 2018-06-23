using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FutebolModelBiblioteca
{
    public class Time
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public DateTime DataFundacao { get; set; }

        public virtual ICollection<Jogador> Jogadores { get; set; }
        = new List<Jogador>();

      //  public Image Camisa { get; set; }
    }
}
