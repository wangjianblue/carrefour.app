using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ImageMagick;

namespace Carrefour.ConsoleTask
{
    class Program
    {
        static void Main(string[] args)
        { 
         
            string path = @"D:\EC\code\08Branchs_Phase_CLPEAndSSO_20200628\SourceCode\CarrefourEC\Presentation\Carrefour.WebHost\Content\Images\Thumbs";
            MagickReadSettings settings = new MagickReadSettings();

            settings.Density = new Density(300, 300); //设置质量
            using (MagickImageCollection images = new MagickImageCollection())
            {
                try
                {
                    images.Read(path, settings);
                    for (int i = 0; i < images.Count; i++)
                    {
                        MagickImage image = (MagickImage)images[i];
                        image.Format = MagickFormat.Png;
                        image.Write(path.Replace(Path.GetExtension(path), "") + "-" + i + ".png");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadKey();
            Console.WriteLine("arg");
        }
    }
}
