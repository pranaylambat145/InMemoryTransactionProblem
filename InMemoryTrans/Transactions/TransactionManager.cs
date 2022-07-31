using InMemoryTrans.Operations;
using InMemoryTrans.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryTrans.Transactions
{
    public class Transaction
    {
        private readonly Stack<Operationss> transactions;
       
        public readonly Stack<string> _stack;
       
        public Transaction()
        {
            ;
            transactions = new Stack<Operationss>();
            //tempMemory = new Dictionary<string, int>();
            _stack = new Stack<string>();
        }

        public void Begin(Operationss o)
        {
            // transactions.Push(new Operationss());
            // store = new InMemoryStore();
            if (o.valueStore.Count > 0)
            {
                foreach (var entry in o.valueStore)
                {
                    if(o.tempMemory.Count == 0)
                    o.tempMemory.Add(entry.Key, entry.Value);

                }
            }
            else
            {
                o.tempMemory.Add("BEGIN",0);
            }

        }

        internal void Commit(Dictionary<string,int> tempMemory, Operationss o)
        {
            //transactions.Clear();
            _stack.Clear();
            
            o.setValue(tempMemory);
            o.tempMemory.Clear();
            //transactions.Push(operation);
            //new Operationss(tempMemory);
        }

        internal void Rollback(Operationss operation)
        {
            if (operation.tempMemory.Count != 0)
            {
                string lastValue = "";
                string lastCommand = _stack.Pop();
                if(_stack.Count != 0)
                lastValue = _stack.Pop();
                _stack.Push(lastValue);
                string[] parameters = lastCommand.Split(' ');

                string[] value = new string[4-1];
               
                value= lastValue.Split(' ');
                //string[] parameters = lastCommand.Split(' ');
                string cmd = parameters[0];
                
                switch (cmd.ToUpper())
                {
                    case "SET":
                        if (value[0] !="" && parameters[1] == value[1])
                        {
                            operation.tempMemory[parameters[1]] = int.Parse(value[2]);
                            operation.valueStore[parameters[1]] = int.Parse(value[2]);
                        }
                        else
                        {
                            operation.valueStore.Remove(parameters[1]);
                            operation.tempMemory.Remove(parameters[1]);
                        }
                       
                        break;
                   
                }
                if (operation.tempMemory.ContainsKey("BEGIN"))
                {
                    operation.tempMemory.Remove("BEGIN");
                }
                operation.setValue(operation.tempMemory);
            }
            else
            {
                Console.WriteLine("NO TRANSACTION");
                //return operation;
            }
        }
    }
}

