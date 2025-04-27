// See https://aka.ms/new-console-template for more information
using System.IO;
using System;




Console.WriteLine("Ingrese el path del archivo que va a utilizar:");
string directoryPath = Console.ReadLine();

do
{
    if (!Directory.Exists(directoryPath))
    {
        Console.WriteLine("El directorio no existe, ingrese un path valido:");
        directoryPath = Console.ReadLine();
    }

}while(!Directory.Exists(directoryPath));

string[] subdirectorios = Directory.GetDirectories(directoryPath);

Console.WriteLine("Carpetas encontradas");

foreach (var dir in subdirectorios)
{
    Console.WriteLine($"Nombre de la carpeta: {Path.GetFileName(dir)}");
}

string[] files = Directory.GetFiles(directoryPath);

foreach(var file in files){
    FileInfo fileInfo = new FileInfo(file);
    double sizeInKB = fileInfo.Length / 1024.0;
    Console.WriteLine($"Nombre del archivo: {fileInfo.Name} - Tamaño del archivo (KBs): {sizeInKB:F2}");
}

string nombreArchivo = "reporte_archivos.csv";
string rutaOriginal = Path.Combine(directoryPath, nombreArchivo);

using (StreamWriter writer = new StreamWriter(rutaOriginal)){
    FileInfo archivoInfo = new FileInfo(nombreArchivo);
    writer.WriteLine($"{archivoInfo.FullName}");
    double tamanio = archivoInfo.Length/1024.0;
    writer.WriteLine($"{tamanio:F2}");
    writer.WriteLine($"{archivoInfo.LastWriteTime}");
}










