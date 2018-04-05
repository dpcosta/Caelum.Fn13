using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Fn13.Collections
{
    public class RepositorioDeCarros
    {
        private List<Carro> lista = new List<Carro>();
        private Dictionary<Modelo, List<Carro>> carrosDoModelo = new Dictionary<Modelo, List<Carro>>();
        private Dictionary<int, List<Carro>> carrosDoAno = new Dictionary<int, List<Carro>>();
        private Dictionary<Cor, List<Carro>> carrosDaCor = new Dictionary<Cor, List<Carro>>();
        private Dictionary<Marca, List<Carro>> carrosDaMarca = new Dictionary<Marca, List<Carro>>();

        public RepositorioDeCarros()
        {
            //criando estrutura auxiliar para pesquisa de modelos
            foreach(var modelo in Modelo.Modelos)
            {
                carrosDoModelo.Add(modelo, new List<Carro>());
            }
            //criando estrutura auxiliar para pesquisa de anos
            for (int i = 1970; i <= 2018; i++)
            {
                carrosDoAno.Add(i, new List<Carro>());
            }
            //criando estrutura auxiliar para pesquisa de cores
            var cores = Enum.GetValues(typeof(Cor)).Cast<Cor>().ToList();
            foreach (var cor in cores)
            {
                carrosDaCor.Add(cor, new List<Carro>());
            }
            //criando estrutura auxiliar para pesquisa de marcas
            var marcas = Enum.GetValues(typeof(Marca)).Cast<Marca>().ToList();
            foreach (var marca in marcas)
            {
                carrosDaMarca.Add(marca, new List<Carro>());
            }
        }

        public IReadOnlyList<Carro> Todos
        {
            get { return lista.AsReadOnly(); }
        }

        public void Incluir(Carro carro)
        {
            lista.Add(carro);
            //adicionando na lista de modelos para ajudar na pesquisa
            carrosDoModelo[carro.Modelo].Add(carro);
            //adicionando na lista de anos para ajudar na pesquisa
            carrosDoAno[carro.Ano].Add(carro);
            //adicionando na lista de cores para ajudar na pesquisa
            carrosDaCor[carro.Cor].Add(carro);
            //adicionando na lista de marcas para ajudar na pesq
            carrosDaMarca[carro.Modelo.Marca].Add(carro);
        }

        public void Excluir(Carro carro)
        {
            //removendo da lista principal...
            lista.Remove(carro);
            //...e removendo dos dicionários também...
            carrosDoModelo[carro.Modelo].Remove(carro);
            carrosDoAno[carro.Ano].Remove(carro);
            carrosDaCor[carro.Cor].Remove(carro);
            carrosDaMarca[carro.Modelo.Marca].Remove(carro);
        }

        //formato de gravação (CSV, XML, JSON, outro separador qualquer)
        public void Gravar(ISerializador<Carro> serializer)
        {
            var nomeArquivo = Path.Combine(Environment.CurrentDirectory, $"carros.{serializer.Extensao}");

            //abrir o arquivo para escrita e associar um escritor a ele
            using (var file = File.OpenWrite(nomeArquivo))
            using (var escritor = new StreamWriter(file))
            {
                //percorrer a lista, serializar o item e colocar no arquivo
                foreach (var carro in Todos)
                {
                    escritor.WriteLine(serializer.Serialize(carro));
                }
            } //chama implicitamente escritor.Dispose() e file.Dispose(), nesta ordem!
        }

        public IEnumerable<Carro> CarrosComModelo(Modelo modelo)
        {
            return carrosDoModelo[modelo];
        }

        public IEnumerable<Carro> CarrosDoAno(int ano)
        {
            return carrosDoAno[ano];
        }

        public IEnumerable<Carro> CarrosDaCor(Cor cor)
        {
            return carrosDaCor[cor];
        }

        public IEnumerable<Carro> CarrosDaMarca(Marca marca)
        {
            return carrosDaMarca[marca];
        }
    }
}
