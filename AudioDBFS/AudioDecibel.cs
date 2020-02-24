using System;
using System.IO;
using NAudio.Wave;

namespace AudioDBFS
{
    public class AudioDecibel
    {
        public static double SamplingRate = 16000;
        public static double MaxVolume = 32768.0;

        public static TimeDecibel[] ReadAudioFile(string audioFile)
        {
            WaveFileReader audioFileReader = new WaveFileReader(audioFile);
            
            long length = audioFileReader.Length;
            byte[] data = new byte[length];
            audioFileReader.Read(data, 0, (int)length);
            var decibels = CaptureAudio(data);
            return decibels;
        }

        public static TimeDecibel[] CaptureAudio(byte[] data)
        {
            double samplingTime = 1000 / SamplingRate; // ms
            TimeDecibel[] decibels = new TimeDecibel[data.Length / 2];
            int j = 0;
            for (int i = 0; i < data.Length; i += 2)
            {                
                double sample = BitConverter.ToInt16(data, i);                
                double volume = Math.Abs(sample / MaxVolume);
                double decibel = 20 * Math.Log10(volume);
                TimeDecibel timeDecibel = new TimeDecibel();
                timeDecibel.decibel = decibel;
                timeDecibel.time = samplingTime * (j + 1);
                decibels[j] = timeDecibel;
                j++;
            }

            return decibels;
        }
    }

    public struct TimeDecibel
    {
        public double time; // ms
        public double decibel;
    }
}
