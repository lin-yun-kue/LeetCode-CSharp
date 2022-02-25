using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem
{
    class Program
    {
        static void Main(string[] args)
        {


            var weightMapping = new Dictionary<int, (int weight, int value)>()
            {
                //{0, (0, 0)},
                //{1, (1, 1)},
                {2, (2, 2)},
                {3, (3, 3)},
                {5, (5, 5)},
                //{4, (4, 4)},
                {6, (6, 6)},
                //{7, (7, 7)},
                //{8, (8, 8)},
                //{9, (9, 9)},
                //{10, (10, 10)}
            };
            var totalWeight = 8;
            var solution = new ZeroOneKnapsackProblem(weightMapping, totalWeight);
            //var result = solution.Recursive(weightMapping.Count - 1, totalWeight);
            //var result = solution.Exhaustive();
            var result = solution.GetCombination(weightMapping.Count - 1, totalWeight);
            solution.DisplayDataTable();
            Console.WriteLine(result);
        }


    }

    /// <summary>
    /// 此演算法處理0/1淚的背包演算法
    /// </summary>
    class ZeroOneKnapsackProblem {

        private Dictionary<int, (int weight, int val)> Mapping;

        private int TotalWeight;

        private int[,] DPTable;

        private List<int> Keys;

        private List<(int weight, int val)> Values;

        public NTree<int> Root;

        public NTree<int> Temp;

        public ZeroOneKnapsackProblem(Dictionary<int, (int, int)> mapping, int totalWeight)
        {
            Mapping = mapping;
            TotalWeight = totalWeight;
            DPTable = new int[mapping.Count, totalWeight + 1];
            Keys = mapping.Keys.ToList();
            Values = mapping.Values.ToList();

            Root = new NTree<int>(-1);
            Temp = Root;
        }

        public int Recursive(int index, int w)
        {
            //Console.WriteLine($"index: {index}");
            //Console.WriteLine($"weight: {w}");
            //Console.WriteLine("----------------");
            if (w < 0) return int.MinValue;
            if (index < 0) return 0;
            if (DPTable[index, w] > 0) return DPTable[index, w];

            DPTable[index, w] = Recursive(index - 1, w) > Recursive(index - 1, w - Values[index].weight) + Values[index].val
                ? Recursive(index - 1, w)
                : Recursive(index - 1, w - Values[index].weight) + Values[index].val;
            return DPTable[index, w];
        }

        public int Exhaustive()
        {
            for (var i = 0; i < Mapping.Count; i++)
            {
                for (var j = 0; j <= TotalWeight; j++)
                {
                    if (i == 0)
                    {
                        DPTable[i, j] = j < Values[i].weight ? 0 : Values[i].val;
                        continue;
                    }

                    if (j < Values[i].weight)
                    {
                        DPTable[i, j] = DPTable[i - 1, j];
                    }
                    else
                    {
                        DPTable[i, j] = DPTable[i - 1, j] > DPTable[i - 1, j - Values[i].weight] + Values[i].val
                            ? DPTable[i - 1, j]
                            : DPTable[i - 1, j - Values[i].weight] + Values[i].val;
                    }
                }
            }
            return 0;
        }


       
        public List<string> GetCombination(int index, int w)
        {
            Recursive_GetCombination(index, w);
            return null;
        }


        private int Recursive_GetCombination(int index, int w)
        {

            if (w < 0) return int.MinValue;
            if (index < 0) return 0;
            if (DPTable[index, w] > 0) return DPTable[index, w];

            var nextWeight = w - Values[index].weight;
            var nextIndex = index - 1;


            var contain = Recursive_GetCombination(nextIndex, nextWeight) + Values[index].val;
            var noContain = Recursive_GetCombination(nextIndex, w);
            

            //if (contain == noContain)
            //{

            //}

            if(contain >= noContain)
            {
                DPTable[index, w] = contain;
                var node = new NTree<int>(Values[index].val);
                Temp.AddChild(node);
                Temp = node;
            }
            else
            {
                DPTable[index, w] = noContain;
            }
            return DPTable[index, w];
        }

        public void DisplayDataTable()
        {
            for(var i = 0; i < Mapping.Count; i++)
            {
                for(var y = 0; y < TotalWeight + 1; y++)
                {
                    Console.Write($"{DPTable[i, y]}  |");
                }
                Console.WriteLine();
            }
        }
    }

    class NTree<T>
    {
        public T Value { get; set; }

        public List<NTree<T>> Next { get; set; }

        public bool isLast => Next.Count() == 0;

        public NTree(T value)
        {
            Value = value;
            Next = new List<NTree<T>>();
        }

        public void AddChild(NTree<T> node)
        {
            Next.Add(node);
        }
    }

}
