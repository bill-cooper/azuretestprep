using Microsoft.Azure.WebJobs;
using System.Net;
using System.IO;
using ImageProcessor;
using System.Drawing;
using ImageProcessor.Imaging.Formats;

namespace QueueProcessorWebJob
{
    public class Functions
    {
        public static void DownloadImage([QueueTrigger("imageurl")] string imageUrl, IBinder binder)
        {
            var fileName = Path.GetFileName(imageUrl);
            var writer = binder.Bind<Stream>(new BlobAttribute($"images/{fileName}", FileAccess.Write));
            
            var image = new WebClient().DownloadData(imageUrl);
            writer.Write(image,0,image.Length);
        }

        public static void Create240x([BlobTrigger("images/{name}.{ext}")] Stream input, string name, string ext, [Blob("images-240/{name}_240x.{ext}", FileAccess.Write)] Stream output, TextWriter log)
        {
            log.WriteLine($"Resizing {name}.{ext} to 240x");
            Resize(240, input, output);
        }

        private static void Resize(int width, Stream input, Stream output)
        {
            using (var factory = new ImageFactory(preserveExifData: true))
            using (var memory = new MemoryStream())
            {
                factory.Load(input)
                  .Resize(new Size(width, 0))
                  .Format(new JpegFormat { Quality = 75 })
                  .Save(memory);

                memory.CopyTo(output);
            }
        }
    }
}
