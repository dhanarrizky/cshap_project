using System;
using System.Diagnostics;
namespace FakeMailChecker;

public class Program {
    public static async Task Main(string[]args){
        Console.WriteLine(await CheckThisMail("dhanar.krisnadhy@gmail.com"));
    }

    public static async Task<string> CheckThisMail(string emailAdd){
        string[] splitMail = emailAdd.Split('@');
        string url = "https://" + ((string)splitMail[1]);
        Console.WriteLine(url);
        try {
            using HttpClient hc = new HttpClient();
            HttpResponseMessage response = await hc.GetAsync(url);

            if(response.IsSuccessStatusCode) {
                return $"email is true, this is not a fake email....";
            } else {
                return $"Failed to fetch url. Status code : {response.StatusCode}";
            }
        } catch {
            return "wrong email, this is a fake email";
        }
    }
}