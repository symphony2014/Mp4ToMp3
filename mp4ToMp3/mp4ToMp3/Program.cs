using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Diagnostics.Contracts;
namespace mp4ToMp3
{
    class Program
    {
        static void Main(string[] args)
        { 

            Console.WriteLine("请输入Mp4 文件的路径：");
            string mp4Directory = Console.ReadLine();
            Console.WriteLine("请输入Mp3 文件的路径：");
            string mp3Directory = Console.ReadLine();
            Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            HandleMp4(mp4Directory, mp3Directory);
            Console.WriteLine(sw.ElapsedMilliseconds/1000);
        }

        static void HandleMp4(string directories, string mp3Directory)
        {

            foreach (var item in Directory.GetFiles(directories))
            {
                Mp4ToMp3(item, mp3Directory);
            }
            foreach (var directory in Directory.GetDirectories(directories))
            {
                HandleMp4(directory, mp3Directory);
            }
        }
        static void Mp4ToMp3(string fileName, string mp3Directory)
        {
            var process = new Process();
            process.StartInfo.FileName = "ffmpeg";
            process.StartInfo.Arguments = string.Format(@" -i {0} -vn -f mp3 -ab 192k {1}.mp3", fileName,
                Path.Combine(mp3Directory, DateTime.Now.ToString("yyyymmhhss")+Guid.NewGuid())
                );
            process.Start();
        }
    }
}
