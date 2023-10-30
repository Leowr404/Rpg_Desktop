using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoRPG
{
    internal class EspadaEnferrujada: Arma
    {

        public EspadaEnferrujada() {
            Nome = "espada enferrujada";
            Tipo = "espada";
            Descricao = "uma arma velha e pouco eficiente, mas pelo menos vem com alguns curativos";
            DescricaoEspecial = "curativo: dar uma lambida nas feridas sempre ajuda. Recupera 1HP";

            BonusAtaque = 1;
            BonusArmadura = 0;
            BonusHp = 0;
            Preco = 0;
        }


        public override void Efeito(ref PlayerCharacter player, ref Bosses boss, ref int hpPlayer, ref int hpBoss)
        {
            Console.WriteLine("\nVoce usa algumas vantagens para tentar fechar algumas feridas, nao eh muito efetivo, mas eh melhor que nada");
            hpPlayer += 1;

        }
        public override void Equipar(ref PlayerCharacter player, ref List<Arma> armaEquipada)
        {
            player.Atk += BonusAtaque;
            player.Def += BonusArmadura;
            player.Hp += BonusHp;

armaEquipada[0] = this;

        }

        public override void Desequipar(ref PlayerCharacter player, ref List<Arma> armaEquipada)
        {
            player.Atk -= BonusAtaque;
            player.Def -= BonusArmadura;
            player.Hp -= BonusHp;



        }
    }
}
