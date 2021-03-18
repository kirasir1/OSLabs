using System;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
namespace Lab2
{
    class Program
{
    #region Private variables
    
    private static string password = "apple";
    private static string result;
 
    private static bool isMatched = false;
    
    private static int charactersToTestLength = 0;
    private static long computedKeys = 0;
    
    private static char[] charactersToTest =
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
        'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
        'u', 'v', 'w', 'x', 'y', 'z'
    };
 
    #endregion
 
    static void Main(string[] args)
    {
        var timeStarted = DateTime.Now;
        Console.WriteLine("Start BruteForce - {0}", timeStarted.ToString());
        charactersToTestLength = charactersToTest.Length;
        var estimatedPasswordLength = 0;
 
        while (!isMatched)
        {
          estimatedPasswordLength++;
            startBruteForce(estimatedPasswordLength);
        }
 
        Console.WriteLine("Password matched. - {0}", DateTime.Now.ToString());
        Console.WriteLine("Time passed: {0}s", DateTime.Now.Subtract(timeStarted).TotalSeconds);
        Console.WriteLine("Resolved password: {0}", result);
        Console.WriteLine("Computed keys: {0}", computedKeys);
 
        Console.ReadLine();
    }
    private static void startBruteForce(int keyLength)
    {
        var keyChars = createCharArray(keyLength, charactersToTest[0]);
        var indexOfLastChar = keyLength - 1;
        createNewKey(0, keyChars, keyLength, indexOfLastChar);
    }
  
    private static char[] createCharArray(int length, char defaultChar)
    {
        return (from c in new char[length] select defaultChar).ToArray();
    }
    
    private static void createNewKey(int currentCharPosition, char[] keyChars, int keyLength, int indexOfLastChar)
    {
        var nextCharPosition = currentCharPosition + 1;
        for (int i = 0; i < charactersToTestLength; i++)
        {
          keyChars[currentCharPosition] = charactersToTest[i];
          
            if (currentCharPosition < indexOfLastChar)
            {
                createNewKey(nextCharPosition, keyChars, keyLength, indexOfLastChar);
            }
            else
            {
              computedKeys++;
              if ((new String(keyChars)) == password)
                {
                    if (!isMatched)
                    {
                        isMatched = true;
                        result = new String(keyChars);
                    }
                    return;
                }
            }
        }
    }
}
}
  /*class Program
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
                if (hash == line[0] || hash == line[1] || hash == line[2]) return;
                }
                if (asciibytes[4] == 122)
                {
                  asciibytes[4] = 97;
                }
                asciibytes[3]+=1;
                text = Encoding.ASCII.GetString(asciibytes);
                Console.WriteLine(text);
                hash = GetHash(sha256Hash, text);
              if (hash == line[0] || hash == line[1] || hash == line[2]) return;
            }
              if (asciibytes[3] == 122)
              {
                asciibytes[3] = 97;
              }
              asciibytes[2]+=1;
              text = Encoding.ASCII.GetString(asciibytes);
              Console.WriteLine(text);
              hash = GetHash(sha256Hash, text);
            if (hash == line[0] || hash == line[1] || hash == line[2]) return;
          }
            if (asciibytes[2] == 122)
            {
              asciibytes[2] = 97;
            }
            asciibytes[1]+=1;
            text = Encoding.ASCII.GetString(asciibytes);
            Console.WriteLine(text);
            hash = GetHash(sha256Hash, text);
          if (hash == line[0] || hash == line[1] || hash == line[2]) return;
        }
          if (asciibytes[1] == 122)
          {
            asciibytes[1] = 97;
          }
          asciibytes[0]+=1;
          text = Encoding.ASCII.GetString(asciibytes);
          Console.WriteLine(text);
          hash = GetHash(sha256Hash, text);
        if (hash == line[0] || hash == line[1] || hash == line[2]) return;
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


  }*/
