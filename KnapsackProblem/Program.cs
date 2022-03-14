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
            // 0/1 Get Max Value
            //var result = solution.Recursive(weightMapping.Count - 1, totalWeight);
            //var result = solution.Exhaustive();

            // 0/1 Get Max Value item Combination
            //var result = solution.GetCombination();
            var result = solution.RecursiveGetCombination(weightMapping.Count - 1, totalWeight);
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


        public ZeroOneKnapsackProblem(Dictionary<int, (int, int)> mapping, int totalWeight)
        {
            Mapping = mapping;
            TotalWeight = totalWeight;
            DPTable = new int[mapping.Count, totalWeight + 1];
            Keys = mapping.Keys.ToList();
            Values = mapping.Values.ToList();
            PutTable = new PutLabel[Mapping.Count, TotalWeight + 1];
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
            return DPTable[Keys.Count - 1, TotalWeight];
        }


        enum PutLabel
        {
            Exclue = 0,
            Include = 1,
            BothEqual = 2
        }
       
        PutLabel[,] PutTable;
        private List<string> Combination = new List<string>();

        /// <summary>
        /// Exhaustive Get Combination
        /// </summary>
        /// <returns></returns>
        public List<string> GetCombination()
        {
            var tempCatch = new int[TotalWeight + 1];
            for (var i = 0; i < Mapping.Count; i++)
            {
                for(var j = TotalWeight; j >= Values[i].weight; j-- )
                {
                    var include = tempCatch[j - Values[i].weight] + Values[i].val;
                    var exclude = tempCatch[j];
                    if (include < exclude)
                    {
                        PutTable[i, j] = PutLabel.Exclue;
                    }
                    else if (include > exclude)
                    {
                        tempCatch[j] = include;
                        PutTable[i, j] = PutLabel.Include;
                    }
                    else if(include == exclude)
                    {
                        PutTable[i, j] = PutLabel.BothEqual;
                    }
                }
            }


            RecursiveGetCombination(Values.Count - 1, TotalWeight, "");
            return Combination;
        }

        public List<string> SubsetGetCombination()
        {
            return default;
        }

        public List<string> RecursiveGetCombination(int itemIndex, int weight)
        {
            ResursiveSetPutTable(itemIndex, weight);
            RecursiveGetCombination(Values.Count - 1, TotalWeight, "");

            return Combination;
        }

        public int ResursiveSetPutTable(int itemIndex, int weight)
        {
            if (weight < 0) return int.MinValue;
            if (itemIndex < 0) return 0;

            var include = ResursiveSetPutTable(itemIndex - 1, weight - Values[itemIndex].weight) + Values[itemIndex].val;
            var exclude = ResursiveSetPutTable(itemIndex - 1, weight);
            if(include > exclude)
            {
                PutTable[itemIndex, weight] = PutLabel.Include;
                return include;
            } else if( include < exclude)
            {
                return exclude;
            } else if(include == exclude)
            {
                PutTable[itemIndex, weight] = PutLabel.BothEqual;
                return include;
            }

            return default;
        }

        private void RecursiveGetCombination(int itemIndex, int weight, string roat)
        {
            //finish
            if(itemIndex < 0)
            {
                Combination.Add(roat);
                return;
            }

            if(PutTable[itemIndex, weight] == PutLabel.Exclue)
            {
                RecursiveGetCombination(itemIndex - 1, weight, roat);
            }else if(PutTable[itemIndex, weight] == PutLabel.Include){
                RecursiveGetCombination(itemIndex - 1, weight - Values[itemIndex].weight, roat += $"{Values[itemIndex].val} ");
            }
            else if (PutTable[itemIndex, weight] == PutLabel.BothEqual)
            {
                var addRoat = roat + $"{Values[itemIndex].val} ";
                RecursiveGetCombination(itemIndex - 1, weight - Values[itemIndex].weight, addRoat);
                RecursiveGetCombination(itemIndex - 1, weight, roat);
            }
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
