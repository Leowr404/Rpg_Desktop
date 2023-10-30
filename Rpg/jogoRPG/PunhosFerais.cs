using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoRPG
{
    internal class PunhosFerais: Arma
    {
        public PunhosFerais() {
            Nome = "punhos ferais";
            Tipo = "corpo a corpo";
            Descricao = "um par de soqueiras gravadas com um leao em cada uma, de alguma forma parece ter vontade propria, como se estivesse disposta a fazer uma troca";
            DescricaoEspecial = "troca justa: Perca 3 pontos de vida máxima permanente, em troca, realize 3 ataques";

            BonusAtaque = 4;
            BonusArmadura = 1;
            BonusHp = 0;
            Preco = 14;

        }

        public override void Efeito(ref PlayerCharacter player, ref Bosses boss, ref int hpPlayer, ref int hpBoss)
        {
            Console.WriteLine("\nVoce aceita a troca da arma, perdendo uma parte de sua vitalidade, porem conseguindo fazer o impossivel por algum tempo");

            int dano = player.Atk - boss.Def;
            if(dano < 1) dano = 1;

            hpBoss = hpBoss - dano;
            hpBoss = hpBoss - dano;
            hpBoss = hpBoss - dano;

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
