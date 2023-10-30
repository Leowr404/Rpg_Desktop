using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoRPG
{
    internal class GalinhaDeBorracha: Arma
    {
        public GalinhaDeBorracha() {
            Nome = "galinha de borracha";
            Tipo = "galinha";
            Descricao = "Uma galinha de brinquedo... Isso nao parece certo, isso nao vai ser inventado daqui alguns seculos?";
            DescricaoEspecial = "Cócó? : É uma galinha de borracha... Ela grita... É isso, esperava algo mais?";

            BonusAtaque = 0;
            BonusArmadura = 0;
            BonusHp = 1;
            Preco = 1;

        }

        public override void Efeito(ref PlayerCharacter player, ref Bosses boss, ref int hpPlayer, ref int hpBoss)
        {
            Console.WriteLine("A galinha grita... Seu oponente parece confuso por um momento, mas volta a fazer o que estava fazendo antes");

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
