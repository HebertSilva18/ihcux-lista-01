using System;
using System.Collections.Generic;


//Heurística #1 Usada nas etapas 1, 2 e 3(Visibilidade do Status): Manter os usuários informados sobre o que está acontecendo, fornecendo feedback apropriado dentro de um tempo razoável.
//Heurística #3 Usada nas etapas 2 e 3 (Controle e Liberdade): Permitir que os usuários tenham controle sobre suas ações, oferecendo opções para desfazer ou cancelar ações.
//Heurística #9 Usada nas etapas 1, 2 e 3 (Ajuda e Erros): Fornecer mensagens de erro claras e orientações para o usuário.

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, string> Menu = new Dictionary<int, string>()
        {
            {01, "Coca-cola Lata - R$ 5,00" },
            {02, "Guaraná - R$ 4,00" },
            {03, "Fanta - R$ 4,00" },
            {04, "Coxinha - R$ 7,00" },
            {05, "Pastel - R$ 7,00" },
            {06, "Pizza - R$ 8,00" }
        };

        // Primeira etapa: Escolha do produto

        int etapa = 1;
        int codigoDoProduto = 0;
        String nomeDoProduto = "";
        int quantidade = 0;
        while (etapa <= 3)
        {
            
            if (etapa == 1)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("     Bem-vindo a Cantina do Caos!      ");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("==Passo 1 de 3 - Escolha seu produto==");
                Console.WriteLine("Menu:");
                foreach (var item in Menu)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
                Console.WriteLine("Digite o código do produto desejado:");
                Console.WriteLine("-- ou 'Cancelar' para sair --");
                Console.Write("> ");

                String entrada = Console.ReadLine().Trim().ToLower();

                if (entrada == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado. Obrigado por visitar a Cantina do Caos!");
                    return;
                }
                int codigo;
                bool ehNumero = int.TryParse(entrada, out codigo);

                if (!ehNumero || !Menu.ContainsKey(codigo))
                {
                    //Heurística #9 (Ajuda e Erros): Fornecer mensagens de erro claras e orientações para o usuário.

                    Console.WriteLine("Código inválido. Por favor, tente novamente.");
                    Console.WriteLine("Os códigos disponíveis são: 01, 02, 03, 04, 05, 06.");
                    Console.WriteLine("Pressione qualquer 'OK' para continuar...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    codigoDoProduto = codigo;
                    nomeDoProduto = Menu[codigo];
                    etapa = 2;
                }

            }
            // Segunda etapa: Quantidade do produto
            

            else if (etapa == 2)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("     Bem-vindo a Cantina do Caos!      ");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("==Passo 2 de 3 - Quantidade do produto==");
                Console.WriteLine($"Produto escolhido: {nomeDoProduto}");
                Console.WriteLine("Digite a quantidade desejada:");
                Console.WriteLine("-- ou 'voltar' para selecionar outro produto --"); //Heurística #3 (Controle e Liberdade): Permitir que os usuários tenham controle sobre suas ações, oferecendo opções para desfazer ou cancelar ações.
                Console.WriteLine("-- ou 'Cancelar' para sair --");
                Console.Write("> ");

                String entrada = Console.ReadLine().Trim().ToLower();

                
                if (entrada == "voltar")
                {
                    etapa = 1;


                }
                else if (entrada == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado. Obrigado por visitar a Cantina do Caos!");
                    return;
                }
                else
                {
                    int qtd;
                    bool ehNumero = int.TryParse(entrada, out qtd);
                    if (!ehNumero || qtd <= 0)
                    {
                        

                        Console.WriteLine("Quantidade inválida. Por favor, tente novamente.");
                        Console.WriteLine("Pressione qualquer 'OK' para continuar...");
                        Console.ReadKey();

                    }
                    else
                    {
                        quantidade = qtd;
                        etapa = 3;
                    }
                }
            }
            // Terceira etapa: Confirmação do pedido
            
            else if (etapa == 3)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("     Bem-vindo a Cantina do Caos!      ");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("==Passo 3 de 3 - Confirmação do pedido==");
                Console.WriteLine($"Produto: {nomeDoProduto}");
                Console.WriteLine($"Quantidade: {quantidade}");
                Console.WriteLine("Deseja confirmar o pedido? (sim/não)");
                Console.Write("> ");

                String entrada = Console.ReadLine().Trim().ToLower();
                
                if (entrada == "voltar")
                {
                    etapa = 2;
                }
                else if (entrada == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado. Obrigado!");
                    return;
                }
                else if (entrada == "sim")
                {
                    Console.WriteLine("Pedido confirmado! Obrigado por visitar a Cantina do Caos!");
                    return;
                }
                else if (entrada == "não")
                {
                    Console.WriteLine("Pedido cancelado. Obrigado por visitar a Cantina do Caos!");
                    return;
                }
                else
                {
                    //Heurística #9 (Ajuda e Erros): Fornecer mensagens de erro claras e orientações para o usuário.

                    Console.WriteLine("Resposta inválida. Por favor, responda com 'sim' ou 'não'.");
                    Console.WriteLine("Pressione 'OK' para continuar...");
                    Console.ReadKey();

                }
            }
        }
    }
}