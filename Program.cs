namespace CottrellA1_TicketingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "ticketingSystem.txt";
            string choice;
            do
            {
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    //logic to read
                    StreamReader sr = new StreamReader(file);
                    sr.ReadLine(); //read in the header and throw it away
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        string[] arr = line.Split(',');
                        Console.WriteLine($"{arr[0]},{arr[1]},{arr[2]},{arr[3]},{arr[4]},{arr[5]}, {arr[6]}");
                    }
                }
                else if (choice == "2")
                {
                    //logic to write
                    StreamWriter sw = new StreamWriter(file);

                    Console.WriteLine("Create new ticket? (Y/N)?");
                    string resp = Console.ReadLine().ToUpper();
                    if (resp != "Y") { break; }

                    Console.WriteLine("Enter the TicketID #.");
                    string ticketID = Console.ReadLine();

                    Console.WriteLine("Enter brief summary.");
                    string summary = Console.ReadLine();

                    Console.WriteLine("Enter status (Open/Pending/Closed).");
                    string status = Console.ReadLine();

                    Console.WriteLine("Enter priority level (High/Medium/Low).");
                    string priority = Console.ReadLine();

                    Console.WriteLine("Enter submitter name.");
                    string submitName = Console.ReadLine();

                    Console.WriteLine("Who is assigned to ticket?");
                    string assignName = Console.ReadLine();



                    List<string> myWatchers = new List<string>();
                    string resp2 = "Y";

                    //loop to ask if more watchers want to be added 
                    do
                    {
                        Console.WriteLine("Watcher name: ");
                        string watcherName = Console.ReadLine();
                        myWatchers.Add(watcherName);
                        Console.WriteLine("Add another watcher? (Y/N)");
                        string done = Console.ReadLine().ToUpper();
                        if (done != "Y")
                        {
                            resp2 = "Y";
                        } else
                        {
                            resp2 = "N";
                        }
                    } while (resp2 != "Y");

                    int i;
                    sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                    sw.Write($"{ticketID}, {summary}, {status}, {priority}, {submitName}, {assignName}, ");
                    
                    //printing out the watchers that were added to list
                    for (i = 0; i < myWatchers.Count; i++)
                    {
                        sw.Write(myWatchers[i] + "|");
                    }
                    

                    sw.Close(); //always close!
                }
            } while (choice == "1" || choice == "2");


        }
    }
}