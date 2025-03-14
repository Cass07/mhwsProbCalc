using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mhwsProbCalc
{
    public abstract class AbstractCalculator
    {

        // 항목별 계산 결과 반환
        public ResultEntry[] Calculate(Items items, int r)
        {
            // 컴비네이션을 구한다
            // 각 항목별 확률을 구한다
            // resultEntry를 만든다

            ResultsInfo results = new ResultsInfo(items);

            if (results.getOptionLength() < r)
            {
                throw new Exception("뽑는 숫자는 전체 풀 개수 이하여야 합니다.");
            }
            List<int[]> combinations = this.getCombination(items, r);
            return this.getResults(results, combinations);
        }

        // items 객체에서 option index array를 만든다
        protected int[] MakeOptionArray(Items items)
        {
            List<int> opt = new List<int>();
            ItemEntry[] itemEntries = items.getItems();
            foreach (ItemEntry item in itemEntries)
            {
                int index = item.getIndex();
                int count = item.getCount();
                for (int i = 0; i < count; i++)
                {
                    opt.Add(index);
                }
            }

            return opt.ToArray();
        }

        protected string makeItemKey(int[] combination)
        {
            string key = "";
            // combination sort
            Array.Sort(combination);

            foreach (int i in combination)
            {
                key += (i.ToString() + "#");
            }
            return key;
        }

        protected string makeItemName(int[] combination, ResultsInfo results)
        {
            string name = "";
            char[] itemChars = results.getCharas();
            foreach (int i in combination)
            {
                name += itemChars[i];
            }
            return name;
        }

        protected abstract List<int[]> getCombination(Items items, int r);

        protected abstract ResultEntry[] getResults(ResultsInfo results, List<int[]> combinations);

    }

    public class IndependentTrialsCalc: AbstractCalculator
    {        
        // items 객체의 리스트에서 r개만큼 조합 구하기
        protected override List<int[]> getCombination(Items items, int r)
        {
            int[] options = this.MakeOptionArray(items);
            Boolean[] visited = new Boolean[options.Length];
            int[] result = new int[r];
            List<int[]> results = new List<int[]>();
            this.makeCombinationRec(0, r, options, visited, result, results);
            return results;
        }

        protected override ResultEntry[] getResults(ResultsInfo results, List<int[]> combinations)
        {
            Dictionary<string, ResultEntry> resultDict = new Dictionary<string, ResultEntry>();

            foreach (int[] combination in combinations)
            {
                double rate = this.calcItemRate(combination, results);
                string key = makeItemKey(combination);
                if (resultDict.ContainsKey(key))
                {
                    resultDict[key].addRate(rate);
                }
                else
                {
                    string name = makeItemName(combination, results);
                    resultDict[key] = new ResultEntry(rate, name);
                }
            }

            return resultDict.Values.ToArray();
        }

        private double calcItemRate(int[] combination, ResultsInfo results)
        {
            double rate = 1;
            int len = combination.Length;
            int poolsLen = results.getPoolLength() + 1;
            int[] toPools = new int[poolsLen];
            int[] pools = results.getPool();
            int[] poolsWeight = results.getPoolWeights();

            for (int i = 0; i < len; i++)
            {
                int nowTotalWeight = 0;
                for(int j = 0; j < poolsLen; j++)
                {
                    if (pools[j] != 0 && toPools[j] < pools[j])
                    {
                        nowTotalWeight += poolsWeight[j];
                    }
                }

                toPools[combination[i]]++;
                rate *= (double)poolsWeight[combination[i]] / nowTotalWeight;
            }

            return rate;
        }

        // recursive combination algorithm
        private void makeCombinationRec(int count, int r, int[] options, Boolean[] visited, int[] result, List<int[]> results)
        {
            if(count >= r)
            {
                results.Add((int[])result.Clone());
                return;
            }

            int current = -1;
            int len = options.Length;
            for (int i = 0; i < len; i++)
            {
                if (!visited[i] && current != options[i])
                {
                    result[count] = options[i];
                    visited[i] = true;
                    makeCombinationRec(count + 1, r, options, visited, result, results);
                    visited[i] = false;
                    current = options[i];
                }
            }

        }
    }

    public class DependentTrialsCalc : AbstractCalculator
    {
        protected override List<int[]> getCombination(Items items, int r)
        {
            int[] options = this.MakeOptionArray(items);
            Boolean[] visited = new Boolean[options.Length];
            int[] result = new int[r];
            List<int[]> results = new List<int[]>();
            this.makeCombinationRec(0, r, options, visited, result, results);
            return results;
        }


        protected override ResultEntry[] getResults(ResultsInfo results, List<int[]> combinations)
        {
            int combLen = combinations.Count;

            Dictionary<string, int> resultCounts = new Dictionary<string, int>();
            Dictionary<string, string> resultNames = new Dictionary<string, string>();

            foreach (int[] combination in combinations)
            {
                string key = makeItemKey(combination);
                if (resultCounts.ContainsKey(key))
                {
                    resultCounts[key]++;
                }
                else
                {
                    resultCounts[key] = 1;
                    resultNames[key] = makeItemName(combination, results); ;
                }
            }

            List<ResultEntry> resultEntries = new List<ResultEntry>();

            foreach (String key in resultCounts.Keys)
            {
                resultEntries.Add(new ResultEntry((double)resultCounts[key] / combLen, resultNames[key]));
            }

            return resultEntries.ToArray();
        }

        private void makeCombinationRec(int count, int r, int[] options, Boolean[] visited, int[] result, List<int[]> results)
        {
            if (count >= r)
            {
                results.Add((int[])result.Clone());
                return;
            }

            int len = options.Length;
            for (int i = 0; i < len; i++)
            {
                if (!visited[i])
                {
                    result[count] = options[i];
                    visited[i] = true;
                    makeCombinationRec(count + 1, r, options, visited, result, results);
                    visited[i] = false;
                }
            }

        }
    }
}
