using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoRPG
{
    //como as armaduras nao possuem nada de diferente entre si alem do nome e atributos, optei por usar uma classe padrao e metodos construtores
    internal class Armadura
    {
        private string nome;
        private string descricao;

        private int bonusAtaque;
        private int bonusArmadura;
        private int bonusHp;
        private int preco;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public int BonusAtaque
        {
            get { return bonusAtaque; }
            set { bonusAtaque = value; }
        }

        public int BonusArmadura
        {
            get { return bonusArmadura; }
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
        //construtor para a armadura inicial do personagem
        public Armadura(string nome, int bonusAtaque, int bonusArmadura, int bonusHp, string descricao)
        {
            Nome = nome;
            BonusAtaque = bonusAtaque;
            BonusArmadura = bonusArmadura;
            BonusHp = bonusHp;
            Descricao = descricao;

        }
        //construtor para as armaduras que o player pode encontrar na loja
public Armadura(string nome, int bonusAtaque, int bonusArmadura, int bonusHp, int preco, string descricao)
        {
            Nome = nome;
            BonusAtaque = bonusAtaque;
            BonusArmadura = bonusArmadura;
            BonusHp = bonusHp;
            Preco = preco;
            Descricao = descricao;

        }
       
        public void Equipar(ref PlayerCharacter player, ref List<Armadura> armaduraEquipada) 
        {
            player.Atk += BonusAtaque;
            player.Def += BonusArmadura;
            player.Hp += BonusHp;

            armaduraEquipada[0] = this;

        }
        public void Desequipar(ref PlayerCharacter player, ref List<Armadura> armaduraEquipada)
        {
            player.Atk -= BonusAtaque;
            player.Def -= BonusArmadura;
            player.Hp -= BonusHp;

        }


    }
}
