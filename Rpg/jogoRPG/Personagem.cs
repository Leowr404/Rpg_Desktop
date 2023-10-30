using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoRPG
{
    internal abstract class Personagem
    {
        private string nome;
        private int hp;
        private int atk;
        private int def;
        private int moedas;

        public string Nome
        {
            get { return nome; }
            set { nome = value;}
        }

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public int Atk
        {
            get { return atk;}
            set { atk = value;}
        }

        public int Def
        {
            get { return def; }
            set { def = value; }
        }

        public int Moedas
        {
            get { return moedas; }
            set { moedas = value; }
        }

  


    }
}
