using System;
using System.IO;

namespace GenDirFileApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string strDir = @"D:\IOT\GitRepository\StudyCSharp\SampleDir\";  //폴더/파일 생성 테스트 폴더
            string strTargetDir = "SubFolder";      //생성하고자 하는 폴더명
            string strTargetFile = "ReadMe.txt";    //생성하고자 하는 파일명

            string targetPath = strDir + strTargetDir;

            if(Directory.Exists(strTargetDir))
            {
                Console.WriteLine("이미 폴더가 존재합니다.");
            }
            else
            {
                Directory.CreateDirectory(targetPath);
                Console.WriteLine("폴더 생성 성공!");
            }

            targetPath = strDir + strTargetFile;

            if (Directory.Exists(strTargetFile))
            {
                Console.WriteLine("이미 파일이 존재합니다.");
            }
            else
            {
                File.Create(targetPath).Close();
                Console.WriteLine("파일 생성 성공!");
            }
        }
    }
}
