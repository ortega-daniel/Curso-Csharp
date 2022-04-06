using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Reminder
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Event myEvent = new Event();
            DateTime currentDate = DateTime.Now;
            bool isValidInput = false;
            int daysLeft;

            // get event name
            Console.Write("What's your event name?: ");
            do
            {
                myEvent.Name = Console.ReadLine();
                if (string.IsNullOrEmpty(myEvent.Name) || string.IsNullOrWhiteSpace(myEvent.Name))
                {
                    Console.Write("Please enter a valid name: ");
                }
                else 
                {
                    isValidInput = true;
                }
            } while (!isValidInput);

            isValidInput = false;

            // get event date
            Console.Write("When will it start? Valid date format (mm/dd/yyyy): ");
            do
            {
                if (DateTime.TryParseExact(Console.ReadLine(), "d", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime eventDate))
                {
                    myEvent.Date = eventDate;
                    isValidInput = true;
                }
                else 
                {
                    Console.Write("Please enter date using a valid format (mm/dd/yyyy): ");
                }
            } while (!isValidInput);

            isValidInput = false;

            // get reminder days
            Console.Write("Please indicate how many days before you want me to start reminding you: ");
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out int reminderDays))
                {
                    myEvent.ReminderDays = reminderDays;
                    isValidInput = true;
                }
                else
                {
                    Console.Write("Please enter a whole number: ");
                }
            } while (!isValidInput);
            
            isValidInput = false;

            // get current date
            Console.Write("Please indicate the current date (mm/dd/yyyy): ");
            do
            {
                if (DateTime.TryParseExact(Console.ReadLine(), "d", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    if (result > myEvent.Date)
                    {
                        Console.Write("Event is over! Please enter a different current date:");
                    }
                    else 
                    {
                        currentDate = result;
                        isValidInput = true;
                    }
                }
                else
                {
                    Console.Write("Please enter date using a valid format (mm/dd/yyyy): ");
                }
            } while (!isValidInput);

            daysLeft = (int)(myEvent.Date - currentDate).TotalDays;
            DateTime reminderDate = myEvent.Date.AddDays(-myEvent.ReminderDays);

            // simulation
            Console.Clear();
            for (int i = 0; i < daysLeft; i++)
            {
                if (currentDate >= reminderDate)
                    Console.WriteLine($"{daysLeft - i} days until {myEvent.Name}!");
                else
                    Console.WriteLine(currentDate.ToString("d"));

                currentDate = await GetNextDay(currentDate);
                Console.Clear();
            }
            Console.WriteLine($"{myEvent.Name} is today!");
        }

        public static async Task<DateTime> GetNextDay(DateTime currentDate)
        {
            await Task.Delay(1000);
            return currentDate.AddDays(1);
        }
    }

    public class Event 
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ReminderDays { get; set; }
    }
}
