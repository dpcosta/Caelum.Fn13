using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Caelum.Fn13.SystemIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //vocês conhecem o comando DIR disponível no terminal?
            //vamos simular uma coisa assim no C#? 

            //primeiro temos que pegar a pasta que desejo listar os arquivos

            //posso pegar a pasta onde o programa está executando...
            var pastaAListar1 = Environment.CurrentDirectory;

            //...ou então pegar uma pasta que o usuário passar como argumento (igual o DIR)
            var pastaAListar2 = args[0];

            //mas como testo essa opção? Uso Propriedades do projeto, aba Debug, campo Command line arguments


            //pronto, agora preciso pegar a lista de arquivos nessa pasta
            //pra isso vou usar a biblioteca de classes para trabalhar com arquivos
            //essa biblioteca está disponível a partir do namespace System.IO

            //começando por obter um objeto que representa as informações de uma pasta
            var dirInfo = new DirectoryInfo(pastaAListar2);


            //var linha = "dasdkajsd";
            //linha.Split(';');

            //será que essa pasta existe?
            if (!dirInfo.Exists)
            {
                TextWriter error = Console.Error;
                error.WriteLine("O diretório não foi encontrado.");
                Environment.Exit(-1); //sair do programa com código específico
            }

            //nesse momento já sabemos que a pasta existe. Vamos explorá-la!
            //quais são os arquivos existentes nela?
            var arquivos = dirInfo.GetFiles();
            foreach (var arquivo in arquivos)
            {
                Console.WriteLine(arquivo.FullName);
                //mas e se eu quisesse explorar o conteúdo de um arquivo? Ié, LER
                //depende do conteúdo! Temos vários tipos de arquivo, certo?
                //Música, vídeo, documentos, planilhas, etc., cada um com seu formato
                //mas existe um conjunto de arquivos cujo conteúdo é texto puro
                //ou seja, ele pode ser aberto no Notepad, por exemplo

                if (arquivo.Extension == "txt")
                {
                    //para LER um arquivo TEXTO eu devo ter uma classe no .NET né?
                    //não! Então como é?

                    //Stream bytes = new Stream(); //é abstrato, não posso criar diretamente
                    //isso pq a informação vem de várias fontes: arquivos, rede, internet, dispositivos E/S, etc.

                    //pra pegar a informação de um arquivo faço:
                    Stream bytes = File.Open(arquivo.FullName, FileMode.Open); //repare que ele retorna um FileStream

                    //mas oq vou fazer com essa info? Ler!
                    //primeiro crio um objeto do tipo StreamReader passando os bytes no construtor
                    StreamReader leitor = new StreamReader(bytes);

                    //e depois executo as operações desejadas, por exemplo
                    var linha = leitor.ReadLine();

                    while (linha != null)
                    {
                        Console.WriteLine(linha);
                        linha = leitor.ReadLine();
                    }

                    //importantíssimo fechar o arquivo!
                    leitor.Close();
                    bytes.Close();
                }

            }

            //e a operação de escrita?
            var info = File.OpenWrite("teste.txt");
            var escritor = new StreamWriter(info);
            escritor.WriteLine("teste");



        }
    }
}
