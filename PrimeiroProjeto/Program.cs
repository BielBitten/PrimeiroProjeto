// Shopify

using System.ComponentModel.Design;
using System.Security.AccessControl;

string mensagemDeBoasVindas = "\nBoas vindas ao Shopify";

//List<string> ListasDasBandas = new List<string> { "U2", "Beatles", "Calypso" };

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Pink floyd", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("The Beatles", new List<int>());


void ExibirLogo()
{
    Console.WriteLine(@"


░██████╗██╗░░██╗░█████╗░██████╗░██╗███████╗██╗░░░██╗
██╔════╝██║░░██║██╔══██╗██╔══██╗██║██╔════╝╚██╗░██╔╝
╚█████╗░███████║██║░░██║██████╔╝██║█████╗░░░╚████╔╝░
░╚═══██╗██╔══██║██║░░██║██╔═══╝░██║██╔══╝░░░░╚██╔╝░░
██████╔╝██║░░██║╚█████╔╝██║░░░░░██║██║░░░░░░░░██║░░░
╚═════╝░╚═╝░░╚═╝░╚════╝░╚═╝░░░░░╚═╝╚═╝░░░░░░░░╚═╝░░░");

    Console.WriteLine(mensagemDeBoasVindas);


}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar tpdas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");

    String opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidanumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidanumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            ExbirMedia();
            break;
        case -1:
            Console.WriteLine("Tchau tchau :) ");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;


    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja adicionar: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"\nA banda foi {nomeBanda} registrada com sucesso");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    /* for (int i = 0; i < ListasDasBandas.Count; i++)
        {
        Console.WriteLine($"Banda: {ListasDasBandas[i]}");
    } */

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    // digite qual banda deseja avaliar
    //se a banda existir no dicionario >> atribuir uma nota
    //se não, volta ao menu principal
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDabanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDabanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDabanda} mercece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDabanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDabanda}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    } else
    {
        Console.WriteLine($"\nA banda {nomeDabanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}



void ExbirMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média das bandas");
    Console.Write("\n digite qual banda você que ver a média: ");
    string nomeBanda = Console.ReadLine()!;
    
    if(bandasRegistradas.ContainsKey(nomeBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeBanda];
        Console.WriteLine($"\nA média da banda {nomeBanda} é {notasDaBanda.Average()}.");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    } else
    {
        Console.WriteLine("\nA banda não foi encontrada");
        Console.WriteLine("\n Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}


ExibirOpcoesDoMenu();





