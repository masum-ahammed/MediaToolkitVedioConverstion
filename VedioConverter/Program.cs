using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VedioConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            
                    var inputFile = new MediaFile { Filename = @"C:\Users\masuma\Videos\problemFile\input.mp4" };
               // var inputFile = new MediaFile { Filename = @"C:\Users\masuma\Videos\small.mp4" };
                var outputFile = new MediaFile { Filename = @"C:\temp\output.mp4" };

                var conversionOptions = new ConversionOptions
                {
                    MaxVideoDuration = TimeSpan.FromSeconds(30),
                    VideoAspectRatio = VideoAspectRatio.R16_9,
                    VideoSize = VideoSize.Hd1080,
                    AudioSampleRate = AudioSampleRate.Hz44100
                };

                using (var engine = new Engine(@"C:\temp\ffmpeg-new\ffmpeg.exe"))
                {
                    engine.ConvertProgressEvent += ConvertProgressEvent;
                    engine.ConversionCompleteEvent += engine_ConversionCompleteEvent;
                    engine.Convert(inputFile, outputFile, conversionOptions);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            Console.WriteLine("Press any key to Exit...");
           Console.ReadLine();
        }

        private static void ConvertProgressEvent(object sender, ConvertProgressEventArgs e)
        {
            Console.WriteLine("\n------------\nConverting...\n------------");
            Console.WriteLine("Bitrate: {0}", e.Bitrate);
            Console.WriteLine("Fps: {0}", e.Fps);
            Console.WriteLine("Frame: {0}", e.Frame);
            Console.WriteLine("ProcessedDuration: {0}", e.ProcessedDuration);
            Console.WriteLine("SizeKb: {0}", e.SizeKb);
            Console.WriteLine("TotalDuration: {0}\n", e.TotalDuration);
        }

        private static void engine_ConversionCompleteEvent(object sender, ConversionCompleteEventArgs e)
        {
            Console.WriteLine("\n------------\nConversion complete!\n------------");
            Console.WriteLine("Bitrate: {0}", e.Bitrate);
            Console.WriteLine("Fps: {0}", e.Fps);
            Console.WriteLine("Frame: {0}", e.Frame);
            Console.WriteLine("ProcessedDuration: {0}", e.ProcessedDuration);
            Console.WriteLine("SizeKb: {0}", e.SizeKb);
            Console.WriteLine("TotalDuration: {0}\n", e.TotalDuration);
        }
    }
}
