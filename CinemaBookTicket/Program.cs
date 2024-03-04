using System;

namespace CinemaBookTicket
{
    class TicketModel{
        public int Seat { get; set; }
        public string MovieTitle { get; set; } = "Yeah This Is Title Movie For example"; // just for example
        public string? Name { get; set; } = "";
        public DateTime DateBuy { get; set; } = DateTime.Now;
        public DateTime MovieTime { get; set; } = DateTime.Now.AddMinutes(30); // just for example 
    }

    class Program
    {
        static string db = "./TicketList.txt"; 
        static FileStream? dbTicket;

        static int ValidationInt(string? inp){
            if(inp != null){
                try {
                    return int.Parse(inp);
                } catch {
                    Console.WriteLine("Entery it in number form");
                    return -1;
                }
            }

            return -1;
        }

        static int[] AviableSeat(){
            var db = OpenDb();
            int[] seats = new int[db.Count];
            for(int i = 0; i < db.Count; i++){
                var d = db[i].Split(";");
                seats[i] = int.Parse(d[0]);
            }

            return seats;
        }

        static void CheckDb(){
            try {
                dbTicket = new FileStream("./TicketList.txt", FileMode.Open);
            } catch {
                dbTicket = new FileStream("./TicketList.txt", FileMode.Create);
            }
            dbTicket.Close();
            Console.WriteLine("Connection To DataBase has been successfully");
        }

        static void Main(string[] args){
            CheckDb();
            bool choiceBool = true;
            do{
                string[] choice = {"buy tickets","refund tickets","check history","Exit App"};
                Console.WriteLine(Menu("Welcome to Cinema Book Ticket App",choice));
                int inp = ValidationInt(Console.ReadLine());
                if(inp > -1){
                    if(inp == 0){
                        choiceBool = false;
                        break;
                    } else if (inp == 1){
                        ShowSeats();
                        BuyTicketMenu();
                    } else if (inp == 2){
                        ShowSeats();
                        RefundTicketMenu();
                    } else if(inp == 3){
                        ShowSeats();
                        ShowHistoryMenu();
                    } else {
                        Console.WriteLine("only enter numbers 1-3 and 0");
                    }
                }
            }while(choiceBool == true);
        }
        static List<string> OpenDb(){
            var result = new List<string>();
            dbTicket = new FileStream(db, FileMode.Open);
            using (var sr = new StreamReader(dbTicket)){
                string? line;
                while((line = sr.ReadLine()) != null){
                    result.Add(line);
                }
            }

            return result;
        }

        static void AddDataToDb(TicketModel ticket){
            string dbText = $"{ticket.Seat};{ticket.MovieTitle};{ticket.Name};{ticket.DateBuy};{ticket.MovieTime}"; 
            using(var fs = new FileStream(db, FileMode.Append ,FileAccess.Write))
            using(var sw = new StreamWriter(fs)){
                sw.WriteLine(dbText);
            }
        }

        static void DeleteDataFromDB(int seat){
            var dbS = OpenDb();
            if(File.Exists(db)){
                File.Delete(db);
            }
            using(var newDb = new FileStream(db, FileMode.CreateNew))
            using(var sw = new StreamWriter(newDb)){
                foreach(var d in dbS){
                    var di = d.Split(";");
                    if(di[0].Equals(seat.ToString())){
                        continue;
                    } else {
                        sw.WriteLine(d);
                    }
                }
            }
        }

        static string Menu(string title,string[] choices){
            string choiceText = "";
            for(int i=0; i < choices.Length; i++){
                choiceText += i != (choices.Length-1) ? (i+1) + " " + choices[i]+"\n" : 0 + " " + choices[i]+"\n";
            }

            return "===================================================================\n"+
                    "\t\t"+title+"\n"+
                    "===================================================================\n"+
                    choiceText;
        }

        static void ShowSeats(){
            var arr = AviableSeat();
            for(int i = 1; i <= 60; i+=10){
                for(int j = i; j <= (i+9); j++){
                    bool isExist = arr.Contains(j);
                    if(!isExist){
                        Console.Write($"\t[{j}]");
                    } else {
                        Console.Write("\t[]");
                    }

                    if(j%5==0){
                        Console.Write("\t");
                    }
                }
                Console.WriteLine("\n");
            }
        }

        static bool BuyTicketMenu(){
            Console.WriteLine("How Much Do You Want to Buy ?");
            var inp = ValidationInt(Console.ReadLine());
            if(inp > -1){

                for(int i = 0; i < inp; i++){
                    BuyTicket();
                }
            }

            return true;
        }

        static void BuyTicket(){

            TicketModel ticket = new TicketModel();
            Console.Write("======================================================================\n"+
            "Enter Your Seat : "
            );
            ticket.Seat = ValidationInt(Console.ReadLine());
            Console.Write("Enter Your Name : ");
            ticket.Name = Console.ReadLine();
            Console.Write("======================================================================");
            AddDataToDb(ticket);
        }

        static bool RefundTicketMenu(){
            Console.Write("============================================================================\n"+
            "Enter whatever seat number you want to refund, if there is more than one seat then just put a comma");
            Console.Write("============================================================================\n"+
            "Seat Number : ");
            string? inp = Console.ReadLine();

            if(inp != null){
                string[] arr = inp.Split(",");
                foreach(var i in arr){
                    DeleteDataFromDB(int.Parse(i));
                }
            }

            return true;
        }

        static bool ShowHistoryMenu(){
            foreach (var item in OpenDb())
            {
                Console.WriteLine(item);
            }
            return true;
        }
    }
}
