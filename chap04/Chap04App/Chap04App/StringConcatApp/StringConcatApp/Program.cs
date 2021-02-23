using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringConcatApp
{
    class Program
    {
        static void Main(string[] args)
        {
			int space, star, lines;

			Console.Write("몇 줄 : ");
			lines = int.Parse(Console.ReadLine());

			if(lines % 2 == 0)
            {
				lines++;
			}

			space = 1;									//공백의 초기값
			star = lines / 2 +1;						//별의 초기값
			Console.WriteLine();
			for (int i = 0; i < lines; i++)		// 별 , 공백 순서대로 정해진 수만큼 출력
			{
				for (int j = 0; j < star; j++)
					Console.Write("*");
				for (int j = 0; j < space; j++)
					Console.Write(" ");
				for (int j = 0; j < star; j++)
					Console.Write("*");
				Console.WriteLine();

				if (i < lines / 2)				//줄수의 중간까지 별과 공백의 증감값
				{
					space += 2;
					star--;
				}
				else							//줄수 중간 넘어서부터 별과 공백의 증감값
				{
					space -= 2;
					star++;
				}
			}
		}
    }
}
