using System;

namespace Chap18App
{
    class StringApp
    {
        string temp2 = "Global Variable String";    //var불가
        static void Main(string[] args)
        {
            Console.WriteLine("문자열 연습 시작!");

            //기본선언
            string message1 = null;
            Console.WriteLine($"null문자열 : {message1}");
            string message2 = String.Empty; //""
            Console.WriteLine($"빈값문자열 : {message2}");
            string oldPath = "C:\\Program Files\\Bandizip"; //폴더 밑 파일 경로
            string newPath = @"C:\Program Files\Bandizip";  //경로 나타내기

            String greeting = "Hello World!";       //string
            var temp1 = "Local Variable String";    //지역변수에만

            char[] letters = { 'H', 'e', 'l', 'l', 'o' };
            string hello = new string(letters);
            Console.WriteLine($"{hello}");
        }
    }
}
