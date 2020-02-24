using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioDBFS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string audioFile = @"C:\Users\jingj\mydata\temp\temp_audio\2\zhangwenhong.wav";
            AudioDecibel.ReadAudioFile(audioFile);
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
