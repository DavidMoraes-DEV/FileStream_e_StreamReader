using System;
using System.IO;

namespace FileStream_StreamReader
{
    class Program
    {
        static void Main(string[] args)
        {
            /* * FileStream: (Stream binária)
               - Disponibiliza uma stream associada a um arquivo, permitindo operações de leitura e escrita. Essa classe encapsula a associação de um objeto àh um recurso de entrada e saída nesse caso um arquivo, A classe disponibiliza vários construtores.
               - Suporte a dados binários.
               - Instanciação: ´Vários construtores, File / FileInfo

               * StreamReader: (Stream de caracteres)
               - É uma stream capaz de ler caracteres a partir de uma stream binária (ex: FileStream), é um objeto que será instânciado apartir do FileStream, o StreamReader é uma stream que na informática significa uma sequência de dados, um termo muito comum quando utilizado para a transmição de dados em sequência.
               - Suporte a dados no formato de texto.
               - Instanciação: Vários construtores, File / FileInfo
             */

            string path1 = @"C:\ProgramasCSharp\ConceitoDeFileStream_e_StreamReader\FileStream_StreamReader\File1.txt";
            string path2 = @"C:\ProgramasCSharp\ConceitoDeFileStream_e_StreamReader\FileStream_StreamReader\File2.txt";

            FileStream fs = null;
            StreamReader sr = null;

            StreamReader sr2 = null;

            try
            {
                fs = new FileStream(path1, FileMode.Open); //Esse recurso não é gerenciado pelo .NET então é preciso fecha-los.
                sr = new StreamReader(fs);

                sr2 = File.OpenText(path2); //Outra forma de instanciar sem a necessidade de se utilizar duas referencias é utilizar a classe File.OpenText

                string line = sr.ReadLine();
                Console.WriteLine(line);

                Console.WriteLine();
                while (!sr2.EndOfStream) //Para ler todas as linhas do arquivo com o .EndOfStream ou seja, enquanto !(não) chegar ao final da string faça o especificado.
                {
                    string line2 = sr2.ReadLine();
                    Console.WriteLine(line2);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error accurred");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null) sr.Close(); //Fecha de forma manual 
                if (fs != null) fs.Close();
                if (sr2 != null) sr2.Close();
            }

        }
    }
}
