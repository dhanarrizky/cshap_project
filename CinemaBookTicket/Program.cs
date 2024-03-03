using System;

namespace CinemaBookTicket
{
    class Program
    {
        static void Main(string[] args){
            MainApp();
        }

        static string Menu(string title,string[] choices){
            Console.Clear();
            string choiceText = "";
            for(int i=0; i < choices.Length; i++){
                choiceText += i != (choices.Length-1) ? (i+1) + " " + choices[i]+"\n" : 0 + " " + choices[i]+"\n";
            }

            return "===================================================================\n"+
                    "\t\t"+title+"\n"+
                    "===================================================================\n"+
                    choiceText;
        }
        static void MainApp(){
            Console.WriteLine(Menu("Welcome to Cinema Book Ticket App",["buy tickets","ticket refund","check history","Exit App"]));
        }

        static string[] TicketChoices ={"One Ticket", "Multi Ticket","Back To Main Menu"};

        static void MenuBuyTicket(){
            Menu("Buy Ticket Menu", TicketChoices);
        }

        static void MenuTicketRefund(){
            Menu("Refund Ticket Menu", TicketChoices);
        }

        static void MenuHistory(){
            Menu("History Ticket Menu", ["Back To Main Menu"]);
        }
    }
}
