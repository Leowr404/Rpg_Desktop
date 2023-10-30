using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace jogoRPG
{
    //como cada arma tem um efeito especial, optei pela criacao de uma classe abstrata e criar cada uma delas como uma subclasse
    internal abstract class Arma
    {
        private string nome;
        private string tipo;
        private string descricao;
        private string descricaoEspecial;

        private int bonusAtaque;
        private int bonusArmadura;
        private int bonusHp;
        private int preco;


        public string Nome
        {
            get { return nome; }
            set { nome = value;}
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value;}
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public string DescricaoEspecial
        {
            get { return descricaoEspecial; }
            set { descricaoEspecial = value; }
        }

        public int BonusAtaque
        {
            get { return bonusAtaque; }
            set { bonusAtaque = value; }
        }

        public int BonusArmadura
        {
            get { return bonusArmadura;}
            set { bonusArmadura = value; }
        }

        public int BonusHp
        {
            get { return bonusHp; }
            set { bonusHp = value; }
        }

public int Preco
        {
            get { return preco; }
            set { preco = value; }
        }


        
        public abstract void Efeito(ref PlayerCharacter player, ref Bosses boss, ref int hpPlayer, ref int hpBoss);
        public abstract void Equipar(ref PlayerCharacter player, ref List <Arma> armaEquipada);
        public abstract void Desequipar(ref PlayerCharacter player, ref List<Arma> armaEquipada);


    }
}
