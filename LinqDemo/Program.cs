//using LinqDemo.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\windows";
            //ListFilesWithoutLinq(path);
            //Console.WriteLine("****** TOP 5 ************");
            //ListFilesWithoutLinqTopFive(path);

            //Console.WriteLine("****** First LINQ ************");
            //ListFilesWithFirstLinq(path);

            Console.WriteLine("****** Last LINQ ************");
            ListFilesWithLastLinq(path,"w"
                , x=>
                {
                    DisplayFile(x);
                    SendMail(x.Length);
                }
               );
        }

        private static void ListFilesWithLastLinq(string path, string startWith
            , Action<FileInfo> callBack)
        {
            Func<FileInfo, bool> filterStartWith =
                x => x.Name.ToLower().StartsWith(startWith)
                && x.Name.IsNulOrEmpty();

            IEnumerable<FileInfo> query = new DirectoryInfo(path)
                .GetFiles()
                .Where(filterStartWith)
                .OrderByDescending(f => f.Length);

            foreach (FileInfo file in query)
            {
                callBack(file);
            }
            Console.WriteLine($"Files ({query.Count()})");
        }

        private static void DisplayFile(FileInfo file)
        {
            Console.WriteLine($"{file.Name,-30}: {file.Length,10:0N}");
        }

        private static void SendMail(long Length)
        {
            Console.WriteLine($"{Length} bytes enviado al Correo");
        }
        private static void ListFilesWithFirstLinq(string path)
        {
            IEnumerable<FileInfo> query = from file in 
                        new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;

            foreach (FileInfo file in query.GetTop(5))
            {
                DisplayFile(file);
            }
        }

        private static void ListFilesWithoutLinqTopFive(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileinfoComparer());

            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                DisplayFile(file);
            }
        }

        private static void ListFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileinfoComparer());

            foreach (FileInfo file in files)
            {
                DisplayFile(file);
            }
        }
    }

    public class FileinfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
