using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoRPG
{
    class MachadinhaComCorrente: Arma
    {
        public MachadinhaComCorrente()
        {
            Nome = "machadinha com corrente";
            Tipo = "machado";
            Descricao = "um pequeno machado conectado em uma corrente, permitindo que seu usuario faça movimentos diversos e flexiveis";
            DescricaoEspecial = "quebra de postura: um golpe que afeta a postura que seu oponente pode usar para atacar. Pelo resto do combate, seu oponente tem -1 Atk";

            BonusAtaque = 1;
            BonusArmadura = 1;
            BonusHp = 0;
            Preco = 4;
        }

        public override void Efeito(ref PlayerCharacter player, ref Bosses boss, ref int hpPlayer, ref int hpBoss)
        {
            if(boss.Atk > 1) { 
            Console.WriteLine("Voce desfere um ataque no braco do oponente, afetando sua postura base");
            boss.Atk -= 1;
            }
            else
            {
                Console.WriteLine("O ataque do seu oponente nao pode ser mais reduzido");

            }


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
