using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Desafio1();
        Desafio2();
        static void Desafio1(){
            while (true)
            {   
                Console.WriteLine("----------------------------------");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Olá bem-vindo ao programa que faz um Ranking dos caracteres de um arquivo de texto!");
                Console.WriteLine("Por favor, digite o caminho do arquivo de texto no modelo:");
                Console.WriteLine("-------------");
                Console.WriteLine("C:/path/file");
                Console.WriteLine("-------------");
                string filePath = Console.ReadLine() + ".txt";

                
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("O arquivo não existe. Certifique-se de digitar o caminho correto.");
                    Console.WriteLine("Pressione Enter para tentar novamente...");
                    Console.ReadLine();
                    continue;
                }

                string texto = File.ReadAllText(filePath);
                string upperText = texto.ToUpper();
                string lowerText = texto.ToLower();
                int lengthText = texto.Count(c => char.IsLetter(c));

                
                Console.WriteLine("Analisando o arquivo de texto...");
                
                Random random = new Random();
                int randomNumber = random.Next(2);
                if (randomNumber == 0)
                {
                    Console.WriteLine("O programa está demorando um pouquinho, aguarde por favor...");
                }

                Console.WriteLine("Pronto! O arquivo de texto foi Rankeado!");
                Console.WriteLine($"O texto no arquivo é:\n{texto}");
                Console.WriteLine($"O texto em letras maiúsculas é:\n--> {upperText}");
                Console.WriteLine($"O texto em letras minúsculas é:\n--> {lowerText}");
                Console.WriteLine($"O número de letras no texto é:\n-->  {lengthText}");

                Dictionary<char, int> caracteresContagem = new Dictionary<char, int>();
                foreach (char caractere in texto)
                {
                    if (char.IsLetter(caractere))
                    {
                        if (caracteresContagem.ContainsKey(caractere))
                        {
                            caracteresContagem[caractere]++;
                        }
                        else
                        {
                            caracteresContagem[caractere] = 1;
                        }
                    }
                }

                Console.WriteLine("Caracteres encontrados no arquivo de texto e suas contagens:");
                // Ordenação manual do dicionário com base nas contagens dos caracteres (função Sort)
                List<KeyValuePair<char, int>> listaOrdenada = new List<KeyValuePair<char, int>>(caracteresContagem);
                for (int i = 0; i < listaOrdenada.Count - 1; i++)
                {
                    int menorIndex = i;
                    for (int j = i + 1; j < listaOrdenada.Count; j++)
                    {
                        if (listaOrdenada[j].Value < listaOrdenada[menorIndex].Value ||
                            (listaOrdenada[j].Value == listaOrdenada[menorIndex].Value && listaOrdenada[j].Key < listaOrdenada[menorIndex].Key))
                        {
                            menorIndex = j;
                        }
                    }
                    var temp = listaOrdenada[i];
                    listaOrdenada[i] = listaOrdenada[menorIndex];
                    listaOrdenada[menorIndex] = temp;
                }

                foreach (var item in listaOrdenada)
                {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }

                Console.WriteLine("Deseja analisar outro arquivo? (s/n)");
                string resposta = Console.ReadLine();
                if (resposta.ToLower() != "s")
                {
                    break;
                }
            }

            Console.WriteLine("Obrigado por testar o Programa!");
        }
        static void Desafio2(){
        Console.WriteLine("----------------------------------");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Olá bem-vindo ao programa que gera a intersecção de dois arquivos em um novo arquivo!");
        Console.WriteLine("Por favor, digite o caminho do primeiro arquivo nesse modelo:");
        Console.WriteLine("-------------");
        Console.WriteLine("C:/path/file");
        Console.WriteLine("-------------");
        string filePath1 = Console.ReadLine() + ".txt";

        Console.WriteLine("Agora, digite o caminho do segundo arquivo nese modelo:");
        Console.WriteLine("-------------");
        Console.WriteLine("C:/path/file");
        Console.WriteLine("-------------");
        string filePath2 = Console.ReadLine() + ".txt";

        if (!File.Exists(filePath1) || !File.Exists(filePath2))
        {
            Console.WriteLine("Pelo menos um dos arquivos não existe. Certifique-se de digitar os caminhos corretos.");
            return;
        }

        string[] lines1 = File.ReadAllLines(filePath1);
        string[] lines2 = File.ReadAllLines(filePath2);

        HashSet<string> words1 = new HashSet<string>(lines1.SelectMany(line => line.Split()));
        HashSet<string> words2 = new HashSet<string>(lines2.SelectMany(line => line.Split()));

        List<string> intersection = new List<string>();

        foreach (string word in words1)
        {
            if (words2.Contains(word))
            {
                intersection.Add(word);
            }
        }

        if (intersection.Count == 0)
        {
            Console.WriteLine("Não há interseção de palavras entre os arquivos.");
            return;
        }

        string outputFile = "terceiro_arquivo.txt";
        File.WriteAllLines(outputFile, intersection);

        Console.WriteLine($"A interseção das palavras foi salva no arquivo: {outputFile}");
        Console.WriteLine("Obrigado por utilizar o Programa!");
        Console.WriteLine("Fim dos desafios.");
        }
    }
}


    

