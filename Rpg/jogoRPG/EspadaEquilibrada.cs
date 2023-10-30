using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoRPG
{
    internal class EspadaEquilibrada: Arma
    {

        public EspadaEquilibrada() {

            Nome = "espada equilibrada";
            Tipo = "espada";
            Descricao = "uma espada simples e confiavel, seu design permite que tanto ataque quanto deseja sejam feitos de forma mais eficiente";
            DescricaoEspecial = "indo no seu tempo: Essa arma permite que seu usuario analise nao apenas as situaçoes ofensivas, como tambem as defensivas. Pelo resto do combate receba +2 em sua Def";

            BonusAtaque = 2;
            BonusArmadura = 1;
            BonusHp = 0;
            Preco = 6;

        }

        public override void Efeito(ref PlayerCharacter player, ref Bosses boss, ref int hpPlayer, ref int hpBoss)
        {
            Console.WriteLine("\nVoce reforca respira fundo e repensa sua postura, se tornando mais estavel. +2 Def pelo restante do combate");
            player.Def += 2;

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

