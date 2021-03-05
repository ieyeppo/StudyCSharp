using System;
using System.IO;

namespace TextFileApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String filePath = @"D:\IOT\GitRepository\StudyCSharp\SampleDir\SubFolder";
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(new FileStream(filePath, FileMode.OpenOrCreate));
                sw.WriteLine(int.MaxValue);
                sw.WriteLine("Hello World!");
                sw.WriteLine($"unit.MaxValue = {uint.MaxValue}");
                sw.WriteLine("안녕하세요!!");
                sw.WriteLine($"double.MaxValue = {double.MaxValue}");

                Console.WriteLine("파일생성!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"파일쓰기 예외발생 : {ex.Message}");
            }
            finally
            {
                sw.Close();
            }

            StreamReader sr = null;
            sr = new StreamReader(new FileStream(filePath, FileMode.Open));
            Console.WriteLine($"File size : {sr.BaseStream.Length}");

            while (sr.EndOfStream == false)
            {
                Console.WriteLine(sr.ReadLine());
            }
            sr.Close();
        }
    }
}
