using System;

namespace AudioDBFS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string audioFile = @"sample.wav";
            AudioDecibel.ReadAudioFile(audioFile);
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
