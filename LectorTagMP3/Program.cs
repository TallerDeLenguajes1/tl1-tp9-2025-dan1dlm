// See https://aka.ms/new-console-template for more information
using System;
using System.IO;

namespace LectorTagMP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el path de un archivo MP3: ");
            string path = Console.ReadLine();

            while (!File.Exists(path) || Path.GetExtension(path).ToLower() != ".mp3")
            {
                Console.WriteLine("El archivo no existe o no es un archivo MP3. Intente nuevamente.");
                Console.Write("Ingrese el path de un archivo MP3: ");
                path = Console.ReadLine();
            }

            try
            {
                Id3v1Tag tag = Id3v1Tag.LeerDesdeArchivo(path);

                Console.WriteLine("\nInformación del archivo:");
                Console.WriteLine($"Título  : {tag.Titulo}");
                Console.WriteLine($"Artista : {tag.Artista}");
                Console.WriteLine($"Álbum   : {tag.Album}");
                Console.WriteLine($"Año     : {tag.Año}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el tag ID3v1: {ex.Message}");
            }
        }
    }
}
