using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolModelBiblioteca
{
    public class Jogador : Pessoa
    {
     

        public int Numero { get; set; }

        public Time Time { get; set; }

        public DateTime? Nascimento { get; set; }
    }
}
