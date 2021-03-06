﻿using System;
using System.IO;
using System.Linq;

namespace DirectoryInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string strDir;
            strDir = @"C:\Program Files\Bandizip";  //폴더 정보 확인 경로

            Console.WriteLine($"{strDir} 디렉토리 정보");

            //LINQ
/*            var directories = (from dir in Directory.GetDirectories(strDir)
                               let info = new DirectoryInfo(dir)
                               select new
                               {
                                   Name = info.Name,
                                   Attribute = info.Attributes
                               }).ToList();
            foreach (var item in directories)
            {
                Console.WriteLine($"{item.Name}, : {item.Attribute}");
            }*/

            var directories = new DirectoryInfo(strDir).GetDirectories();
            foreach(var item in directories)
            {
                Console.WriteLine($"{item.Name} : {item.Attributes}");
            }

            Console.WriteLine("===============================================================");

            Console.WriteLine($"{strDir} 내 폴더검색");
            var files = new DirectoryInfo(strDir).GetFiles();
            foreach(var item in files)
            {
                Console.WriteLine($"{item.Name} : {item.Attributes} : {Math.Ceiling((double)item.Length / 1024):#,###}KB : {item.Extension}");
            }
            
        }
    }
}
