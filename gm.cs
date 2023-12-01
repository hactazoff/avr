// print sha256 hash of a file
// usage: gm.exe <filename>

using System;
using System.IO;
using System.Security.Cryptography;

// run main program

class gm
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("usage: gm.exe <filename>");
            return;
        }

        string filename = args[0];

        if (!File.Exists(filename))
        {
            Console.WriteLine("file not found: " + filename);
            return;
        }

        string hash = GetHash(filename);

        Console.WriteLine("File " + filename + ":");
        Console.WriteLine("SHA256: " + hash);

        // size of file in bytes
        FileInfo info = new FileInfo(filename);
        Console.WriteLine("Size: " + info.Length + " bytes");

        // last modified date timestamp millisecond
        Console.WriteLine("Last modified: " + info.LastWriteTimeUtc.Ticks / TimeSpan.TicksPerMillisecond + " ms");
    }

    static string GetHash(string filename)
    {
        System.Security.Cryptography.SHA256 sHA256 = System.Security.Cryptography.SHA256.Create();
        byte[] hash = sHA256.ComputeHash(System.IO.File.ReadAllBytes(filename));
        string hash2 = "";
        foreach (byte b in hash)
            hash2 += b.ToString("x2");
        return hash2;
    }
}