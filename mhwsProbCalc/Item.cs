using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mhwsProbCalc
{
    public class ItemEntry
    {
        private int index;
        private string name;
        private char nameChar;
        private int count;
        private int weightFactor;

        public ItemEntry(int index, string name, int weightFactor, int count)
        {
            this.index = index;
            this.name = name;
            this.nameChar = name[0];
            this.weightFactor = weightFactor;
            this.count = count;
        }

        public void updateEntry(int count, string name, int weightFactor)
        {
            this.count = count;
            this.name = name;
            this.nameChar = name[0];
            this.weightFactor = weightFactor;
        }

        public int getWeightFactor()
        {
            return this.weightFactor;
        }

        public int getTotalWeight()
        {
            return this.weightFactor * this.count;
        }

        public int getCount()
        {
            return this.count;
        }

        public int getIndex()
        {
            return this.index;
        }

        public string getName()
        {
            return this.name;
        }

        public char getNameChar()
        {
            return this.nameChar;
        }
        public string toString()
        {
            return this.name + " " + this.count + " " + this.weightFactor;
        }
    }

    public class Items
    {
        private ItemEntry[] items;
        private int length;
        private int maxIndex;

        public Items(ItemEntry[] items)
        {
            this.items = items;
            this.length = items.Length;
            this.maxIndex = 0;
            foreach (ItemEntry item in items)
            {
                if (item.getIndex() > this.maxIndex)
                {
                    this.maxIndex = item.getIndex();
                }
            }
        }

        public ItemEntry[] getItems()
        {
            return this.items;
        }

        public int getLength()
        {
            return this.length;
        }

        public int getMaxIndex()
        {
            return this.maxIndex;
        }

    }

    public class ResultsInfo
    {
        // 각 item별 가능한 개수
        private int[] pool;
        private char[] charas;
        private int poolLength;

        private int[] optionIndexes;
        private int optionsLength;
        private int[] poolWeights;

        public ResultsInfo(Items items)
        {
            ItemEntry[] itemEntries = items.getItems();
            int itemsLength = items.getLength();
            this.poolLength = items.getMaxIndex();
            this.pool = new int[poolLength + 1];
            this.charas = new char[poolLength + 1];
            this.poolWeights = new int[poolLength + 1];

            List<int> optionIndexes = new List<int>();
            for (int i = 0; i < itemsLength; i++)
            {
                int itemIndex = itemEntries[i].getIndex();
                int count = itemEntries[i].getCount();
                int index = itemEntries[i].getIndex();

                for (int j = 0; j < count; j++)
                {
                    optionIndexes.Add(index);
                }
                this.pool[itemIndex] = count;
                this.poolWeights[itemIndex] = itemEntries[i].getWeightFactor();
                this.charas[itemIndex] = itemEntries[i].getNameChar();
            }

            this.optionIndexes = optionIndexes.ToArray();
            this.optionsLength = this.optionIndexes.Length;
        }

        public int[] getPool()
        {
            return this.pool;
        }

        public char[] getCharas()
        {
            return this.charas;
        }

        public int getPoolLength()
        {
            return this.poolLength;
        }

        public int[] getPoolWeights()
        {
            return this.poolWeights;
        }

        public int getOptionLength()
        {
            return this.optionsLength;
        }
    }
    public class ResultEntry {
        private double rate;
        private String name;
        
        public ResultEntry(double rate, String name)
        {
            this.rate = rate;
            this.name = name;
        }

        public void addRate(double rate)
        {
            this.rate += rate;
        }

        public double getRate()
        {
            return this.rate;
        }

        public String getName()
        {
            return this.name;
        }
    }

}
