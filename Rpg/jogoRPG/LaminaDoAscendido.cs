using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoRPG
{
    internal class LaminaDoAscendido: Arma
    {
        public LaminaDoAscendido() {
            Nome = "lamina do ascendido";
            Tipo = "espada";
            Descricao = "Uma grande espada uma vez portada por um guerreiro ascendido, a lamina possui uma aura azul que parece conseguir atacar por conta propria de alguma forma";
            DescricaoEspecial = "Ascencao imperfeita: A espada age por conta propria, porem parece que seu potencial esta restrito... Talvez porque voce nao seja um ascendido? Quando o especial eh usado, 50% de chance de nada acontecer e 50% de causar 10 pontos de dano ao oponente, ignorando QUALQUER defesa";

            BonusAtaque = 7;
            BonusArmadura = 3;
            BonusHp = 3;
            Preco = 17;

        }

        public override void Efeito(ref PlayerCharacter player, ref Bosses boss, ref int hpPlayer, ref int hpBoss)
        {
            Random random = new Random();
            int rng = random.Next(1, 3);

            if(rng == 1)
            {
                Console.WriteLine("Voce tentou canalizar o potencial da lamina do ascendido... mas ela nao parece ter respondido");
            }
            else
            {
                Console.WriteLine("De alguma forma voce conseguiu canalizar o potencial da lamina do ascendido, disparando um raio instantaniamente contra ele antes mesmo de ter tempo de reagir");
                hpBoss -= 10;
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
