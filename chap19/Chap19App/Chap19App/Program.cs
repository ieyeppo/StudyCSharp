using System;
using System.Threading;

namespace Chap19App
{
    class Program
    {
        static void DoSomething()
        {
            for(int i = 0; i < 50; i++)
            {
                Console.WriteLine("DoSomething : " + (i + 1));
                Thread.Sleep(10);// 1/100초 동안 멈춤
            }
        }

        static void SomethingHappened()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("SomethingHappened : "+(i + 1));
                Thread.Sleep(10);// 1/100초 동안 멈춤
            }
        }

        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(DoSomething));
            Thread thread1 = new Thread(SomethingHappened);

            try
            {
                Console.WriteLine("스레드 시작!");
                thread.Start();
                thread1.Start();

                for(int i = 0; i < 50; i++)
                {
                    Console.WriteLine("Main thread : " + (i+1));
                    Thread.Sleep(10);

                    if (i == 10) thread.Abort();
                }

                Console.WriteLine("스레드 종료 대기...");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                thread.Join();
                thread1.Join();

                Console.WriteLine("프로세스 종료...");
            }
        }
    }
}
