using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static public int size = 5;
        static public int[,] matrix = new int[,] {
            {0 ,4 ,5 ,0 ,0 },
            {0 ,0 ,0 ,3 ,0 },
            {0 ,0 ,0 ,4 ,0 },
            {0 ,0 ,0 ,0 ,6 },
            {0 ,0 ,0 ,0 ,0 } };

        static public bool Work()
        {
            for (int i = 0; i < size; i++)
            {
                bool tmp = true;
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                        break;
                    if (matrix[j, i] != 0)
                    {
                        tmp = true;
                        break;
                    }
                    else
                        tmp = false;
                }
                if (!tmp)
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            int[] path = new int[size];
            int[,] sive= new int[,] {
            {0 ,4 ,5 ,0 ,0 },
            {0 ,0 ,0 ,3 ,0 },
            {0 ,0 ,0 ,4 ,0 },
            {0 ,0 ,0 ,0 ,6 },
            {0 ,0 ,0 ,0 ,0 } };
            int[,] last = new int[size, size] ;
            int min = size*100;
            string tmppath;
            while (Work()) {
                for (int i = 0; i < size; i++)
                    path[i] = 0;
                tmppath = "";
                min = size*100;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (i == j)
                            break;
                        if (matrix[j, i] != 0)
                        {
                            path[i] = j;
                            break;
                        }
                    }
                }
                tmppath += Convert.ToString(size-1);
                for (int i = 0; i < size; i++)
                {
                    if (tmppath[tmppath.Length-1]-48 == 0)
                        break;
                    int len = tmppath[tmppath.Length - 1] - 48;
                    tmppath += Convert.ToString(path[len]);
                }
                for (int i = 1; i < tmppath.Length; i++)
                {
                    int point1 = Convert.ToInt32(tmppath[i])-48;
                    int point2 = Convert.ToInt32(tmppath[i-1])-48;
                    if (min > matrix[point1, point2])
                        min = matrix[point1, point2];
                }
                for (int i = 1; i < tmppath.Length; i++)
                {
                    int point1 = Convert.ToInt32(tmppath[i])-48;
                    int point2 = Convert.ToInt32(tmppath[i - 1])-48;
                    matrix[point1, point2] -= min;
                    matrix[point2, point1] += min;
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    last[i, j] = sive[i, j] - matrix[i, j];
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(last[i, j] + " ");
                }
                Console.WriteLine();
            }
            int sum = 0, sum2 = 0 ;
            for (int i = 0; i < size; i++)
            {
                sum += last[0, i];
                sum2 += last[i, size-1];
            }
            if (sum == sum2)
                Console.WriteLine(sum);
                Console.ReadKey();
        }
    }
}
