using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace jogoRPG
{
    internal class Batalha
    {
        Bosses ChefeSegunda = new Bosses();
        Bosses ChefeTerca = new Bosses();
        Bosses ChefeQuarta = new Bosses();

        List<Bosses> chefes = new List<Bosses>();


       //cria uma lista com todos os Bosses que o jogador podera enfrentar, existe 1 para cada dia, sendo que a medida que progride, os atributos destes se tornam maiores
        public Batalha()
        {
            int somaMax;

            //adiciona os Bosses na lista
            chefes.Add(ChefeSegunda);
            chefes.Add(ChefeTerca);
            chefes.Add(ChefeQuarta);

            
            somaMax = 5;
            Random random = new Random();

            //atributos do primeiro boss
            chefes[0].Nome = "Mercenario iniciante";
            chefes[0].Hp = 10;
            chefes[0].Atk = 3;
            chefes[0].Def = 2;
            chefes[0].Moedas = 5;


            //atributos do segundo boss
            chefes[1].Nome = "Guarda viajante";
            somaMax = 17;
            chefes[1].Hp = 19;
            chefes[1].Atk= random.Next(8, 13);
            chefes[1].Def = somaMax - chefes[1].Atk;
            chefes[1].Moedas = random.Next(1, 9) + 10;

            //atributos do terceiro boss
            chefes[2].Nome = "Guerreiro ascendido";
            somaMax = 23;
            chefes[2].Hp = 40;
            chefes[2].Atk = random.Next(9, 14);
            chefes[2].Def = somaMax - chefes[2].Atk;
            chefes[2].Moedas = random.Next(1, 9) + 10;
        }


        public void GerarBoss()
        {
           

        }
        public void CalcularBatalha(ref int dia, ref bool jogoRolando, PlayerCharacter personagemPlayer, List<Arma> armaEquipada)
        {
            //salva os atributos do player em variaveis separadas para poderem ser alterados durante o combate
            PlayerCharacter playerBatalha = personagemPlayer;


            int danoPlayer = playerBatalha.Atk ;
            int defesaPlayer = playerBatalha.Def; 
            int hpPlayer = playerBatalha.Hp;
            
          




            int escolha, rng, danoP = 0; 
            int danoC = 0;
            Random random = new Random();
            Bosses chefeAtual = chefes[0];
            bool combateRolando = true;

            //decide qual sera o Boss que o jogador ira enfrentar, fazendo isso usando o dia que ele se encontra como parametro
            switch (dia)
            {
                case 0:
chefeAtual = chefes[0];
                    Console.WriteLine("\nVoce entra na arena e ve ao seu redor a plateia, repleta de pessoas, do outro lado do campo de batalha, um oponente ja a sua espera, usando uma protecao desgastada e feita de couro de baixa qualidade e com duas facas simples em suas maos. Sem cerimonia ele assume uma postura e se prepara para o combate.");
                    break;
                case 1:
                    chefeAtual = chefes[1];
                    Console.WriteLine("\nVoce entra pela segunda vez na arena, a vista eh a mesma, a plateia repleta de pessoas gritando, provavelmente em uma onda empolgaçao apos terem presenciado todos os combates anteriores. Diante de si se encontra um oponente mais imponente que o anterior, um homem alto e com fisico avantajado, carregando uma grande maca em suas maos, assim que percebe que voce entra na arena, imediatamente avança para realizar o primeiro ataque");


                    break;
                case 2:
                    chefeAtual = chefes[2];
                    Console.WriteLine("Voce entra na arena pela ultima vez, a plateia parece imersa e ansiosa, a sua frente se encontra um homem quase de aparencia divina, chega a ser visivel o poder que exala dele, esse eh um verdadeiro guerreiro ascendido!");

                    break;
            }

            //salva os atributos do Boss em variaveis separadas para poderem ser uusadas em combate
            int danoChefe, defesaChefe, hpChefe;
            danoChefe = chefeAtual.Atk;
            defesaChefe = chefeAtual.Def;
            hpChefe = chefeAtual.Hp;

            //inicia o loop de combate, enquanto o jogador ou Boss estiverem com HP acima de 0, ele se repetira
            while (combateRolando)
            {
                //imprime os dados de ambos os competidores
            ImprimirCompetidores(playerBatalha, chefeAtual, hpPlayer, hpChefe);

                //o jogador escolhe qual acao tomara nesse turno (ataque, defesa, finta ou especial)
             escolha = EscolherAcao(personagemPlayer, chefeAtual);


                //gera o numero que decide a proxima jogada do Boss
                rng = random.Next(1, 4);
                CalcularAcoes(personagemPlayer, armaEquipada,chefeAtual, escolha, rng, ref danoP, danoPlayer, ref defesaPlayer, ref danoC, danoChefe, ref defesaChefe, ref hpPlayer,ref hpChefe);

                //imprime qual açao o jogador tomou
                switch (escolha)
                {
                    case 1:
                        Console.WriteLine($"\nVoce ataca, causando {danoP} pontos de dano");

                        break;
                    case 2:
                        Console.Write($"\nVoce defende, aumentando sua defesa para {defesaPlayer} nesse turno");
                        if (rng == 3) Console.Write(", porem foi inutil, graças a finta bem encaixada de seu oponente");
                       
                        break;
                    case 4:


                        break;
                }


                //imprime qual açao o Boss tomou
                switch (rng)
                {
                    case 1:
                        Console.WriteLine($"\nSeu oponente ataca, causando {danoC} pontos de dano");

                        break; 
                    case 2:
                        Console.Write($"\nSeu oponente defende, aumentando sua defesa para {defesaChefe} nesse turno");
                        if (escolha == 3) Console.Write(", porem foi inutil, graças a sua finta bem encaixada");

                        break;

                }




               
                //caso o player ou chefe zerem o HP, a luta termina
                if (hpPlayer < 1 || hpChefe < 1) combateRolando = false;

                //ao fim da rodada reseta a defesa do player e boss para seus valores normais, caso tenham sido alterados
                defesaPlayer = personagemPlayer.Def;
                defesaChefe = chefeAtual.Def;
                
         
            }

            //se o Player terminou o combate com HP zerado, Derrota eh declarado
            if (hpPlayer < 1)
            {
                Derrota(ref jogoRolando);
                
            }

            //se o Player terminou o combate com HP maior que 0, Vitoria eh chamada
            else { Vitoria(ref dia, ref personagemPlayer, chefeAtual);  }
             



        }

        //imprime as informacoes basicas de ambos os competidores no console
        void ImprimirCompetidores(PlayerCharacter personagemPlayer, Bosses chefeAtual, int hpPlayer, int hpChefe)
        {
            Console.WriteLine($"\n{personagemPlayer.Nome}:");
            Console.WriteLine($"Hp: {hpPlayer}");
            Console.WriteLine($"Atk: {personagemPlayer.Atk}");
            Console.WriteLine($"Def: {personagemPlayer.Def}");

            Console.WriteLine($"\n{chefeAtual.Nome}:");
            Console.WriteLine($"Hp: {hpChefe}");
            Console.WriteLine($"Atk: {chefeAtual.Atk}");
            Console.WriteLine($"Def: {chefeAtual.Def}");

        }

        //metodo para o jogador escolher qual acao tomar
        private int EscolherAcao(PlayerCharacter personagemPlayer, Bosses chefeAtual)
        {

            int escolha;
            Console.WriteLine("\nEscolha sua açao:");
            Console.WriteLine($"1 - Atacar ({personagemPlayer.Atk - chefeAtual.Def})");
            Console.WriteLine($"2 - Defender ({personagemPlayer.Def * 2})");
            Console.WriteLine($"3 - Fintar ({personagemPlayer.Atk / 2})");
            Console.WriteLine("4 - Especial");
            escolha = int.Parse(Console.ReadLine());
            while(escolha < 1 || escolha > 4) {
                Console.WriteLine("Escolha um numero valido");
                escolha = int.Parse(Console.ReadLine());
            }

            return escolha;
        }

        private void CalcularAcoes(PlayerCharacter personagemPlayer, List<Arma> armaEquipada, Bosses chefeAtual, int escolha, int rng, ref int danoP, int danoPlayer, ref int defesaPlayer, ref int danoC, int danoChefe, ref int defesaChefe, ref int hpPlayer, ref int hpChefe)
        {
            //dobra a defesa do player e chefe caso eles escolham defender
            if (rng == 2) defesaChefe = defesaChefe * 2;
            if (escolha == 2) defesaPlayer = defesaPlayer * 2;


            //caso o player ataque, ele causa dano no Boss (minimo de 1)
            if (escolha == 1)
            {
                danoP = danoPlayer - defesaChefe;
                if (danoP < 1) danoP = 1;
                hpChefe = hpChefe - danoP;
            }


                //caso o Boss escolha atacar, ele causa dano no player (minimo de 1)
                if (rng == 1)
                {
                    danoC = danoChefe - defesaPlayer;
                    if (danoC < 1) danoC = 1;
                    hpPlayer = hpPlayer - danoC;
                }

//caso o Player escolha fazer uma finta
                if(escolha == 3)
                {

                    //os resultados possiveis, dependendo de qual acao o Boss tomou
                    switch (rng)
                    {
                        case 1:
                            danoP = 0;

                            Console.WriteLine("\nVoce tentou fintar seu oponente, porem ele percebeu suas intençoes e te atacou antes que pudesse completar o movimento");

                            break;
                        case 2:
                            danoP = danoPlayer / 2;
                            hpChefe = hpChefe - danoP;

                            Console.WriteLine($"\nVoce percebeu a postura defensiva do seu oponente e partiu para uma finta, quebrando a defesa dele e encaixando um bom ataque, causando {danoP} pontos de dano");
                            break; 
                        case 3:
                            danoP = danoPlayer / 2;
                            hpChefe = hpChefe - danoP;
                            danoC = danoChefe / 2;
                            hpPlayer = hpPlayer - danoC;
                            Console.WriteLine($"\nVoce e seu oponente tentaram fintar um ao outro, nenhum dos golpes encaixou muito bem, voce causou {danoP} pontos de dano, porem sofreu {danoC}");
                            break;
                    case 4:
                        danoP = danoPlayer / 2;
                        hpChefe = hpChefe - danoP;
                        Console.WriteLine("\nseu oponente usou especial");

                        break;
                    }

             
                }

                //caso o Boss escolha fazer uma finta
                if(rng == 3)
                {
                    switch (escolha)
                    {
                        case 1:
                            danoC = 0;

                            Console.WriteLine("\nSeu oponente pensou que voce partiria para a defensiva, preparando uma finta, porem foi surpreendido por seu ataque");

                            break;
                        case 2:
                            danoC = danoChefe / 2;
                            hpPlayer = hpPlayer - danoC;

                            Console.WriteLine($"\nSeu oponente percebeu que voce adotou uma posicao defensiva, encaixando uma boa finta que te causou {danoC} pontos de dano");
                            break;
                    case 4:
                        danoC = danoChefe / 2;
                        hpPlayer = hpPlayer - danoC;
                        Console.WriteLine($"\nseu oponente fintou, causando {danoC} pontos de dano");

                        break;

                    }

                }

                //caso o player escolha usar um especial
                if(escolha == 4) armaEquipada[0].Efeito(ref personagemPlayer, ref chefeAtual, ref hpPlayer, ref hpChefe);
            
                //ao fim do turno, reseta os atributos de defesa em combate para os valores base
            defesaPlayer = personagemPlayer.Def;
            defesaChefe = chefeAtual.Def;
            
        }


        //chamado quando o jogador sai vitorioso do combate
        public void Vitoria(ref int dia, ref PlayerCharacter personagemPlayer, Bosses chefeAtual)
        {
            dia++;

            Console.WriteLine($"\nVoce saiu vitorioso em seu confronto, dando uma olhada no cadaver de seu oponente voce encontra uma bolsinha com moedas, adicionando mais {chefeAtual.Moedas} a suas economias e retornando ao vilarejo para recuperar suas forças");
            personagemPlayer.Moedas = personagemPlayer.Moedas + chefeAtual.Moedas;

        }

        //chamado quando o jogador sai derrotado do combate, resultando em fim de jogo
        public void Derrota(ref bool jogoRolando)
        {
            jogoRolando = false;

            Console.WriteLine("\nApesar de ter dado seu melhor no combate, seu oponente conseguiu desferir um golpe fatal");

        }


    }
}
