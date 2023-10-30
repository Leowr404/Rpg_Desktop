using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace jogoRPG
{
   
    internal class Jogo
    {


        static void Main(string[] args)
        {


            int dia = 0;


            bool finalSecreto = false;
            bool vitoria = false;   


            bool jogoRolando = true;

            //cria as listas de arma e armadura e equipa os itens iniciais no personagem
            List<Arma> armaEquipada = new List<Arma>();
            List<Armadura> armaduraEquipada = new List<Armadura>();
            EspadaEnferrujada espadaInicial = new EspadaEnferrujada();
    Armadura armaduraInicial = new Armadura("armadura improvisada",0,1,0, "Uma proteçao improvisada feita com algumas camadas de decido de baixa qualidade");
            armaEquipada.Add(espadaInicial);
            armaduraEquipada.Add(armaduraInicial);

            PlayerCharacter personagemPlayer = new PlayerCharacter();

            bool tutorialLojaDeArmas = true;
            bool tutorialArena = true;

            Intro();

        CriarPersonagem(ref personagemPlayer, armaEquipada, armaduraEquipada);

            
 
            //enquanto o jogador nao vencer ou for derrotado na arena, esse loop se mantera ativo
            while (jogoRolando) { 
            int escolha = EscolherAcao();

                if (escolha == 1)
                {
                    LojaDeArmas(ref tutorialLojaDeArmas, ref personagemPlayer, dia, ref armaEquipada);
                    ImprimirPlayer(personagemPlayer,  armaEquipada,  armaduraEquipada);
                }


            if(escolha == 2) {
                    LojaDeArmaduras(ref tutorialLojaDeArmas, ref personagemPlayer, dia, ref armaduraEquipada);

                }

            if(escolha == 3) Arena(ref dia, ref jogoRolando, tutorialArena, personagemPlayer, armaEquipada, armaduraEquipada, ref vitoria, ref finalSecreto);
            }

            if (finalSecreto)
            {
                Console.WriteLine("\n\nUAU... De alguma forma voce REALMENTE conseguiu se provar para os deuses. Quando te viram derrotando um guerreiro ascendido com as proprias maos usando uma galinha de borracha dentro de uma fanatia de pato, todos ficaram extremamente surpresos... Tanto que a atençao de divindades ate demais se voltaram para voce, nao te dando apenas o poder de um ascendido, mas sim de uma verdadeira divindadade. O futuro ainda eh incerto para as pessoas que continuam vivas, agora que um novo ser superior nasceu, mas a lenda do homem que derrotou um guerreiro ascendido fantasiado de pato e usando uma galinha de borracha jamais sera esquecida... GG!");

            }

            //caso o jogador tenha vencido o jogo normalmente, essa sera a mensagem final
            if (vitoria)
            {
                Console.WriteLine("\n\nVoce conseguiu! Derrotou um guerreiro ascendido e atraiu a atencao dos deuses para si mesmo, se tornando o mais novo ascendido. Talvez a jornada tenha sido curta demais, mas o prazo que os deuses tiveram para montar tudo isso tambem, e eles tem mais deveres pro dia 3... GG");

            }

            


        }




        public static void Intro()
        {
            Console.WriteLine("O evento mais esperado pelos gladiadores de Xamph é a 'Semana do Falso Sol', onde é acredita-se que a Terra esta em seu ponto mais proximo dos Deuses, permitindo que guerreiros verdadeiramente dignos ascendam.");
            Console.WriteLine("Pelos proximos 3 dias, gladiadores de todos os cantos se reunirao, e lutarao entre si para provar que sao dignos da maior gloria que um mortal poderia ter, sera que voce, um cidadao comum sem nenhum grande treinamento ou equipamento, tem o que necessario para superar todos os outros?");

        }



        public static void CriarPersonagem(ref PlayerCharacter personagemPlayer, List<Arma> armaEquipada, List <Armadura> armaduraEquipada) {
            int quantidade;
            Console.WriteLine("\nQual o nome do gladiador?");
            personagemPlayer.Nome = Console.ReadLine();

            Console.WriteLine("Voce tem 10 pontos para colocar, escolha quantos quer colocar em ATK, o restante vai pra defesa:");
            quantidade = int.Parse(Console.ReadLine());

            while (quantidade > 10 || quantidade <0) {
                Console.WriteLine("o numero precisa ser entre 0 e 10");
                quantidade = int.Parse(Console.ReadLine());
            }

            //gera os atributos base do personagem
            personagemPlayer.Atk = quantidade;
            personagemPlayer.Def = 10 - quantidade;
            personagemPlayer.Hp = 10;
            personagemPlayer.Moedas = 10;

            //equipa as arma e armadura basicas
            armaEquipada[0].Equipar(ref personagemPlayer, ref armaEquipada);
            armaduraEquipada[0].Equipar(ref personagemPlayer, ref armaduraEquipada);


            ImprimirPlayer(personagemPlayer, armaEquipada, armaduraEquipada); 
            
            
        }

        public static void ImprimirPlayer(PlayerCharacter personagemPlayer, List<Arma> armaEquipada, List<Armadura> armaduraEquipada)
        {
            Console.WriteLine("\n----------");

            //imprime os dados do jogador
            Console.WriteLine($"\n{personagemPlayer.Nome}: \n" +
                $"HP = {personagemPlayer.Hp}\n" +
                $"ATK = {personagemPlayer.Atk}\n" +
                $"DEF = {personagemPlayer.Def}\n" +
                $"Moedas = {personagemPlayer.Moedas}");

            //imprime os dados da arma
            Console.WriteLine($"\n{armaEquipada[0].Nome}:");
            Console.WriteLine($"{armaEquipada[0].Descricao}");
            Console.WriteLine($"Bonus de ataque: {armaEquipada[0].BonusAtaque}");
            Console.WriteLine($"Bonus de defesa: {armaEquipada[0].BonusArmadura}");
            Console.WriteLine($"Bonus de hp: {armaEquipada[0].BonusHp}");
            Console.WriteLine($"(Especial) {armaEquipada[0].DescricaoEspecial}");

            //imprime os dados da armadura
            Console.WriteLine($"\n{armaduraEquipada[0].Nome}:");
            Console.WriteLine($"{armaduraEquipada[0].Descricao}");
            Console.WriteLine($"Bonus de ataque: {armaduraEquipada[0].BonusAtaque}");
            Console.WriteLine($"Bonus de defesa: {armaduraEquipada[0].BonusArmadura}");
            Console.WriteLine($"Bonus de hp: {armaduraEquipada[0].BonusHp}");

            Console.WriteLine("\n----------");
        }



        //onde o jogador decide para onde ir
        public static int EscolherAcao() {
            int escolha;

            Console.WriteLine("\nVoce esta na aldeia e pode escolher para onde ir em seguida:");
            Console.WriteLine("1 - Loja de armas");
            Console.WriteLine("2 - Loja de armaduras");
            Console.WriteLine("3 - arena (proximo combate)");

            escolha = Escolha(3);

return escolha;

        }

        //metodo usado para detectar escolhas do jogador
        public static int Escolha(int valorMaximo)
        {
            int escolha = 0;
            escolha = int.Parse(Console.ReadLine());

            while (escolha < 1 || escolha > valorMaximo)
            {
                Console.WriteLine("escolha uma opcao valida");
                escolha = int.Parse(Console.ReadLine());
            }

            return escolha;

        }

        //caso o jogador escolha ir para a loja de armas
        public static void LojaDeArmas(ref bool tutorialLoja, ref PlayerCharacter personagemPlayer, int dia, ref List<Arma> armaEquipada)
        {
            //tutorial de como funcionam as lojas, sera mostrado apenas na primeira vez que o jogador entrar em alguma delas
            if (tutorialLoja)
            {
                Console.WriteLine("\n TUTORIAL LOJAS: Todo dia as lojas venderao 2 itens, cabe a voce decidir se ira comprar ou guardar dinheiro para gastar em outro momento. A cada dia que se passe itens de melhor qualidade podem aparecer em estoque, porem o preço tambem aumentara, ganhe dinheiro derrotando oponentes na arena");
                tutorialLoja = false;           
            }
            int escolha;

            Console.WriteLine("\nVoce entra na loja de armas, o cheiro de aço e polvora cobre o ambiente, escolha o que quer fazer:");
            Console.WriteLine("1 - Ver itens a venda");
            Console.WriteLine("2 - Sair da loja");

            escolha = Escolha(3);

            if(escolha == 1)
            {
                List<Arma> armasAvenda = new List<Arma>();

                Console.WriteLine($"moedas: {personagemPlayer.Moedas}");

                //a loja possui itens fixos, que mudam e sao exibidos de acordo com o dia que o jogador esta
                switch (dia)
                {
                    case 0: 
                        

                        EspadaEquilibrada espadaEquilibrada = new EspadaEquilibrada();
                        armasAvenda.Add(espadaEquilibrada);
                        MachadinhaComCorrente machadinhaComCorrente = new MachadinhaComCorrente();
                        armasAvenda.Add(machadinhaComCorrente);

                        break;
                    case 1:

                        LancaDesequilibrada lancaDesiquilibrada = new LancaDesequilibrada();
                        armasAvenda.Add(lancaDesiquilibrada);
                        PunhosFerais punhosFerais = new PunhosFerais();
                        armasAvenda.Add(punhosFerais);

                        break;

                    case 2:
LaminaDoAscendido laminaDoAscendido = new LaminaDoAscendido();
                        armasAvenda.Add(laminaDoAscendido);
                        GalinhaDeBorracha galinhaDeBorracha = new GalinhaDeBorracha();
                        armasAvenda.Add(galinhaDeBorracha);

                        break;

                }

                Console.WriteLine("\n----------");

                Console.WriteLine("\nEscolha o item que deseja comprar:");
                
                Console.WriteLine($"\n1 -");
                Console.WriteLine($"\nPreço: {armasAvenda[0].Preco}");
                Console.WriteLine($"\n{armasAvenda[0].Nome}:");
                Console.WriteLine($"\n{armasAvenda[0].Descricao}");
                Console.WriteLine($"\nEspecial - {armasAvenda[0].DescricaoEspecial}");
                Console.WriteLine($"bonus de Atk: {armasAvenda[0].BonusAtaque}");
                Console.WriteLine($"bonus de Def: {armasAvenda[0].BonusArmadura}");
                Console.WriteLine($"bonus de Hp: {armasAvenda[0].BonusHp}");

                Console.WriteLine("\n----------");

                Console.WriteLine($"\n2 -");
                Console.WriteLine($"\nPreço: {armasAvenda[1].Preco}");
                Console.WriteLine($"\n{armasAvenda[1].Nome}:");
                Console.WriteLine($"\n{armasAvenda[1].Descricao}");
                Console.WriteLine($"\nEspecial - {armasAvenda[1].DescricaoEspecial}");
                Console.WriteLine($"bonus de Atk: {armasAvenda[1].BonusAtaque}");
                Console.WriteLine($"bonus de Def: {armasAvenda[1].BonusArmadura}");
                Console.WriteLine($"bonus de Hp: {armasAvenda[1].BonusHp}");

                Console.WriteLine("\n----------");


                int escolhaItem = 0;

                //o jogador escolhe qual item deseja comprar
                escolhaItem = int.Parse(Console.ReadLine());

                //se tiver mais moedas que o preco, desequipa a arma anterior, equipa a nova e tira a quantidade do preco
                if (personagemPlayer.Moedas > armasAvenda[escolhaItem - 1].Preco)
                {
                    personagemPlayer.Moedas = personagemPlayer.Moedas - armasAvenda[escolhaItem - 1].Preco;

                    armaEquipada[0].Desequipar(ref personagemPlayer, ref armaEquipada);

                    armasAvenda[escolhaItem - 1].Equipar(ref personagemPlayer, ref armaEquipada);

                }

                //caso o jogador nao tenha moedas suficiente, imprime a mensagem e retorna para a aldeia
                else
                {
                    Console.WriteLine("Voce nao tem dinheiro suficiente");
                }

            }
            else if(escolha == 2)
            {
                Console.WriteLine("\nVoce sai da loja e volta para as ruas do vilarejo");
          

            }

        }



        public static void LojaDeArmaduras(ref bool tutorialLoja, ref PlayerCharacter personagemPlayer, int dia, ref List<Armadura> armaduraEquipada)
        {
            //exibe o tutorial caso seja a primeira vez do jogador na loja
            if (tutorialLoja)
            {
                Console.WriteLine("\n TUTORIAL LOJAS: Todo dia as lojas venderao 2 itens, cabe a voce decidir se ira comprar ou guardar dinheiro para gastar em outro momento. A cada dia que se passe itens de melhor qualidade pode, aparecer em estoque, porem o preço tambem aumentara, ganhe dinheiro derrotando oponentes na arena");
                tutorialLoja = false;
            }

            Console.WriteLine("\nVoce entra na loja de armaduras e ve diante de si o estoque, escolha o que fazer:");
            Console.WriteLine("1 - Ver itens a venda");
            Console.WriteLine("2 - Sair da loja");

            int escolha = Escolha(3);



          

            if (escolha == 1)
            {
                List<Armadura> armadurasAvenda = new List<Armadura>();

                Console.WriteLine($"moedas: {personagemPlayer.Moedas}");

                //a loja possui itens fixos, que mudam e sao exibidos de acordo com o dia que o jogador esta
                switch (dia)
                {
                    case 0:


                        Armadura armaduraMuitoLeve = new Armadura("armadura muito leve", 0, 2, 0, 3, "Uma armadura extremamente leve feita de tecidos de baixa qualidade, nao eh da maior qualidade, mas com certeza eh melhor do que panos envoltos no corpo");
                        armadurasAvenda.Add(armaduraMuitoLeve);
                        Armadura armaduraDeCouro = new Armadura("armadura de couro", 0, 3, 1, 6, "Uma armadura leve feita de couro, da uma resistencia surpreendentemente razoavel");
                        armadurasAvenda.Add(armaduraDeCouro);

                        break;
                    case 1:

                        Armadura armaduraPesada = new Armadura("armadura pesada", -2, 7, 4, 11, "Uma armadura feita de varios pedaços de placas, mas parece que quem quer que tenha feito se esqueceu que a pessoa usando precisa se mover, realizar ataques dentro dessa armadura nao sera tao facil");
                        armadurasAvenda.Add(armaduraPesada);
                        Armadura armaduraDeMalha = new Armadura("armadura de malha", 0, 4, 3, 10, "Uma armadura de malha, oferece uma protecao solida, provavelmente a melhor que voce encontrara por aqui sem prejudicar seus movimentos ou se envolver com equipamentos de ascendidos");
                        armadurasAvenda.Add(armaduraDeMalha);

                        break;

                    case 2:

                        Armadura fantasiaDePato = new Armadura("fantasia de pato", 1, 0, 0, 1, "Uma fantasia de pato... O que sera que acontece se vencer o proximo confronto assim?");
                        armadurasAvenda.Add(fantasiaDePato);
                        Armadura armaduraDoAscendido = new Armadura("armadura do ascendido", 2, 6, 5, 15, "Uma armadura que anteriormente pertenceu a um guerreiro ascendido, eh perceptivel que a protecao que fornece nao eh normal, considerando que eh extremamente leve e de alguma forma ate facilita seus movimentos");
                        armadurasAvenda.Add(armaduraDoAscendido);

                        break;

                }

                //imprime os atributos e custo dos dois itens a venda
                Console.WriteLine("\n----------");

                Console.WriteLine("\nEscolha o item que deseja comprar:");

                Console.WriteLine($"\n1 -");
                Console.WriteLine($"\nPreço: {armadurasAvenda[0].Preco}");
                Console.WriteLine($"\n{armadurasAvenda[0].Nome}:");
                Console.WriteLine($"\n{armadurasAvenda[0].Descricao}");
                Console.WriteLine($"bonus de Atk: {armadurasAvenda[0].BonusAtaque}");
                Console.WriteLine($"bonus de Def: {armadurasAvenda[0].BonusArmadura}");
                Console.WriteLine($"bonus de Hp: {armadurasAvenda[0].BonusHp}");

                Console.WriteLine("\n----------");

                Console.WriteLine($"\n2 -");
                Console.WriteLine($"\nPreço: {armadurasAvenda[1].Preco}");
                Console.WriteLine($"\n{armadurasAvenda[1].Nome}:");
                Console.WriteLine($"\n{armadurasAvenda[1].Descricao}");
                Console.WriteLine($"bonus de Atk: {armadurasAvenda[1].BonusAtaque}");
                Console.WriteLine($"bonus de Def: {armadurasAvenda[1].BonusArmadura}");
                Console.WriteLine($"bonus de Hp: {armadurasAvenda[1].BonusHp}");

                Console.WriteLine("\n----------");


                int escolhaItem = 0;

                //o jogador escolhe qual item deseja comprar
                escolhaItem = int.Parse(Console.ReadLine());

                //se tiver mais moedas que o preco, desequipa a arma anterior, equipa a nova e tira a quantidade do preco
                if (personagemPlayer.Moedas > armadurasAvenda[escolhaItem - 1].Preco)
                {
                    personagemPlayer.Moedas = personagemPlayer.Moedas - armadurasAvenda[escolhaItem - 1].Preco;

                    armaduraEquipada[0].Desequipar(ref personagemPlayer, ref armaduraEquipada);

                    armadurasAvenda[escolhaItem - 1].Equipar(ref personagemPlayer, ref armaduraEquipada);


                }

                //caso o jogador nao tenha moedas suficiente, imprime a mensagem e retorna para a aldeia
                else
                {
                    Console.WriteLine("Voce nao tem dinheiro suficiente");
                }
            }
            else if (escolha == 2)
            {
                Console.WriteLine("\nVoce sai da loja e volta para as ruas do vilarejo");
                EscolherAcao();

            }
        }


        

        public static void Arena(ref int dia, ref bool jogoRolando, bool tutorialArena, PlayerCharacter personagemPlayer, List<Arma> armaEquipada, List <Armadura> armaduraEquipada, ref bool vitoria, ref bool finalSecreto)
        {
            //na primeira vez que o jogador abrir a arena, o tutorial sera exibido
            if (tutorialArena) {
                Console.WriteLine("\nO combate possui 4 açoes principais: atacar, defender, fintar e especial.");
                Console.WriteLine("Atacar causa dano igual ao quanto de ATK voce tem a mais que DEF do oponente (minimo de 1)");
                Console.WriteLine("Defender dobra a sua DEF durante essa rodada, porem pode ser combatido por finta");
                Console.WriteLine("Finta causa metade apenas metade do seu ATK em dano, porem caso seu oponente escolha defender, a DEF dele eh considerada como 0 no ataque, porem caso ele te ataque, apenas voce sofrera dano");
                Console.WriteLine("Especial eh uma habilidade unica de alguns itens, tendo efeitos diversos");

                tutorialArena = false;
            }

            //cria uma instancia de batalha e comeca o combate
            Batalha batalha = new Batalha();

            batalha.CalcularBatalha(ref dia, ref jogoRolando, personagemPlayer, armaEquipada);
            
            //apos a batalha caso o jogador nao tenha derrotado o ultimo Boss ou morrido, exibe os status do personagem
            if(jogoRolando)  ImprimirPlayer(personagemPlayer, armaEquipada, armaduraEquipada);

             //caso o jogador derrote o ultimo boss, a verificacao de vitoria eh chamada
             if (dia == 3)
            {
                jogoRolando = false;
                
                //caso o jogador derrote o ultimo boss com a galinha de borracha e fantasia de patos equipados (o que eu imagino ser impossivel), acontece o final secreto
                if (armaEquipada[0].Nome == "galinha de borracha" && armaduraEquipada[0].Nome == "fantasia de pato") finalSecreto = true;
      
                else {vitoria = true;}

            }
        }



    }
}
