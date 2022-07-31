using InMemoryTrans.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InMemoryTrans.Operations
{
    public class Operationss : IOperations
    {
        public  Dictionary<string, int> valueStore;
        public  Dictionary<string, int> vs;
        //List<KeyValuePair<string, string>> tempMemory = new List<KeyValuePair<string, string>>();
        public readonly Dictionary<string, int> tempMemory;
        public Operationss()
        {
            valueStore = new Dictionary<string, int>();
            tempMemory = new Dictionary<string, int>();
        }
        //public Operationss(Dictionary<string, int> o)
        //{
        //    valueStore = new Dictionary<string, int>(o);
        //    vs = new Dictionary<string, int>(o);
        //}
        public void setValue(Dictionary<string, int> o)
        {
            valueStore = new Dictionary<string, int>(o);
            vs = new Dictionary<string, int>(o);
        }
        public int Get(string variable)
        {
            //if (tempMemory.Count > 0 && tempMemory.ContainsKey(variable))
            //{
            //    return tempMemory[variable];
            //}
            if (valueStore.ContainsKey(variable))
            {
                return valueStore[variable];
            }
            return -1;
        }
        public void Set(string variable, int value)
        {
            if (tempMemory.Count>0)
            {
                if (!tempMemory.ContainsKey(variable))
                {
                    tempMemory.Add(variable, value);
                }
                else 
                {
                    tempMemory[variable] = value;

                }
            }
           
                if (!valueStore.ContainsKey(variable))
                {
                    valueStore.Add(variable, value);
                }
                else
                {
                    valueStore[variable] = value;
                }
            
        }
        public int Count(int value)
        {
            int count = 0;
            foreach (var entry in valueStore)
            {
                if (entry.Value == value)
                {
                    count++;
                }

            }
            return count;
        }
        public void Delete(string field)
        {
            valueStore.Remove(field);
        }
    }
}
