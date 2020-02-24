using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioDBFS
{
    public class AudioDecibel
    {
        public static int SamplingRate = 16000;
        public static double MaxVolume = 32768.0;

        public static void ReadAudioFile(string audioFile)
        {
            WaveFileReader audioFileReader = new WaveFileReader(audioFile);
            
            long length = audioFileReader.Length;
            byte[] data = new byte[length];
            audioFileReader.Read(data, 0, (int)length);
            double[] decibels = CaptureAudio(data);
            string fileName = Path.Combine(Path.GetDirectoryName(audioFile), "decibels.txt");
            
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (double db in decibels)
                {
                    sw.WriteLine(db);
                }
            }
        }

        public static double[] CaptureAudio(byte[] data)
        {
            double[] decibels = new double[data.Length / 2];
            int j = 0;
            for (int i = 0; i < data.Length; i += 2)
            {                
                double sample = BitConverter.ToInt16(data, i);
                double volume = Math.Abs(sample / MaxVolume);
                double decibel = 20 * Math.Log10(volume);                
                decibels[j] = decibel;
                j++;
            }

            return decibels;
        }
    }
}
