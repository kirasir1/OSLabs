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
      Thread brutethread1 = new Thread(new ThreadStart(Brute));
    }
    public static void Brute()
    {
      string path = "hashes.txt";
      string[] line = File.ReadAllLines(path);


    }
  }
}
