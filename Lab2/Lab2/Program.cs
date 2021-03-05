using System;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
namespace Lab2
{
  class Program
  {
    static void Main(string[] args)
    {
      Brute();
    }
    public static void Brute()
    {
      SHA256 sha256Hash = SHA256.Create();
      string path = "hashes.txt";
      var asciibytes = new byte []{ 97, 97, 97, 97, 97};
      string[] line = File.ReadAllLines(path);
      var text = Encoding.ASCII.GetString(asciibytes);
      Console.WriteLine(text);
      string hash = GetHash(sha256Hash, text);
      while (hash!=line[0]|| hash != line[1] || hash != line[2])
      {
        for (int i=0; i<25; i++)
        {
          for (int j = 0; j < 25; j++)
          {
            for (int k = 0; k < 25; k++)
            {
              for (int l= 0; l < 25; l++)
              {
                for (int g = 0; g < 25; g++)
                {
                  asciibytes[4]+=1;
                  text = Encoding.ASCII.GetString(asciibytes);
                  Console.WriteLine(text);
                  hash = GetHash(sha256Hash, text);
                }
                if (asciibytes[4] == 122)
                {
                  asciibytes[4] = 97;
                }
                asciibytes[3]+=1;
                text = Encoding.ASCII.GetString(asciibytes);
                Console.WriteLine(text);
                hash = GetHash(sha256Hash, text);
              }
              if (asciibytes[3] == 122)
              {
                asciibytes[3] = 97;
              }
              asciibytes[2]+=1;
              text = Encoding.ASCII.GetString(asciibytes);
              Console.WriteLine(text);
              hash = GetHash(sha256Hash, text);
            }
            if (asciibytes[2] == 122)
            {
              asciibytes[2] = 97;
            }
            asciibytes[1]+=1;
            text = Encoding.ASCII.GetString(asciibytes);
            Console.WriteLine(text);
            hash = GetHash(sha256Hash, text);
          }
          if (asciibytes[1] == 122)
          {
            asciibytes[1] = 97;
          }
          asciibytes[0]+=1;
          text = Encoding.ASCII.GetString(asciibytes);
          Console.WriteLine(text);
          hash = GetHash(sha256Hash, text);
        }

      }
    }
    private static string GetHash(HashAlgorithm hashAlgorithm, string input)
    {
      byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
      var sBuilder = new StringBuilder();
      for (int i = 0; i < data.Length; i++)
      {
        sBuilder.Append(data[i].ToString("x2"));
      }
      return sBuilder.ToString();
    }


  }
}
