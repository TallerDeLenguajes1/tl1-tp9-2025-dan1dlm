using System;
using System.Text;

public class Id3v1Tag
{
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public string Album { get; set; }
    public string Año { get; set; }

    public static Id3v1Tag LeerDesdeArchivo(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            if (fs.Length < 128)
            {
                throw new Exception("El archivo es demasiado pequeño para contener un tag ID3v1.");
            }

            fs.Seek(-128, SeekOrigin.End); // Nos posicionamos 128 bytes antes del final
            byte[] buffer = new byte[128];
            fs.Read(buffer, 0, 128); // Leemos esos 128 bytes

            string header = Encoding.ASCII.GetString(buffer, 0, 3); // Los primeros 3 deben ser "TAG"
            if (header != "TAG")
            {
                throw new Exception("El archivo no contiene un tag ID3v1 válido.");
            }

            Id3v1Tag tag = new Id3v1Tag
            {
                Titulo = Encoding.GetEncoding("latin1").GetString(buffer, 3, 30).TrimEnd('\0', ' '),
                Artista = Encoding.GetEncoding("latin1").GetString(buffer, 33, 30).TrimEnd('\0', ' '),
                Album = Encoding.GetEncoding("latin1").GetString(buffer, 63, 30).TrimEnd('\0', ' '),
                Año = Encoding.GetEncoding("latin1").GetString(buffer, 93, 4).TrimEnd('\0', ' ')
            };

            return tag;
        }
    }
}