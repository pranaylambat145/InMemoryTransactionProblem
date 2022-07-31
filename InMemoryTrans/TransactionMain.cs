
using InMemoryTrans.Operations;
using InMemoryTrans.Store;
using InMemoryTrans.Transactions;

public class TransactionMain
{
    private Operationss m;
    Transaction t;
    public TransactionMain()
    {
        m =  new Operationss();
        t = new Transaction();
    }

    public void getUserInput()
    {
        Console.WriteLine("Hello user, Please Enter the command");
        string inputLine = "";
        while ((inputLine = Console.ReadLine()) != null)
        {
            if (inputLine == "END")
                break;
            else
            {
                HandleUserInput(inputLine);
            }
        }
    }
    private void HandleUserInput(string inputLine)
    {

        string[] parameters = inputLine.Split(' ');
        string cmd = parameters[0];
        string field;
        int value;
       
        if ((inputLine.Contains("SET") || inputLine.Contains("DELETE"))) 
        {
            t._stack.Push(inputLine);
        }
           
        switch (cmd.ToUpper())
        {
            case "GET":
                field = parameters[1];
                Console.WriteLine(m.Get(field) == -1 ? "NULL" : m.Get(field));
                break;

            case "SET":
                field = parameters[1];
                value = int.Parse(parameters[2]);
                m.Set(field, value);
                break;

            case "DELETE":
                field = parameters[1];
                m.Delete(field);
                break;

            case "COUNT":
                value = int.Parse(parameters[1]);
                Console.WriteLine(m.Count(value));

                break;

            case "BEGIN":
                 t.Begin(m);
                break;

            case "ROLLBACK":
                t.Rollback(m);
                break;

            case "COMMIT":
               t.Commit(m.tempMemory,m);
                break;

            default:
                Console.WriteLine("Invalid operation: " + cmd + "\nTry again.");
                break;
        }
    }

    public static void Main(string[] args)
    {
        TransactionMain transaction = new TransactionMain();
        transaction.getUserInput();

    }
}