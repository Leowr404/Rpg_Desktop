using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoRPG
{
    internal class LancaDesequilibrada: Arma
    {

        public LancaDesequilibrada()
        {

            Nome = "lança desequilibrada";
            Tipo = "lança";
            Descricao = "uma lança com enorme potencial de ataque, os movimentos agressivos com ela sao variados, porem seu tamanho dificulta a defesa";
            DescricaoEspecial = "estocada instavel: Um ataque perfurante poderoso, capaz de atravessar a defesa ate dos melhores guerreiros. Realiza um ataque que causa 6 pontos extra de dano, porem voce perde 3 de Hp";

            BonusAtaque = 8;
            BonusArmadura = -3;
            BonusHp = 0;
            Preco = 11;

        }
        public override void Efeito(ref PlayerCharacter player, ref Bosses boss, ref int hpPlayer, ref int hpBoss)
        {
            Console.WriteLine("\nvoce desfere uma estocada poderosa, porem fica vulneravel no processo, seu oponente te da uma cotovelada durante seu golpe");
            hpBoss -= player.Atk + 6;
            hpPlayer -= 3;

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
