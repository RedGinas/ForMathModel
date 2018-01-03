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
            int[,] sive= matrix;
            int min = 0;
            while (Work()) {
                for (int i = 0; i < size; i++)
                    path[i] = 0;
                min = 0;
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

            }
        }
    }
}
