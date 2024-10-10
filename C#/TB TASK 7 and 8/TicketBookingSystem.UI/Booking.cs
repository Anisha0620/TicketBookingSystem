using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer.Repository;
using TicketBookingSystem.BusinessLayer.Service;

namespace TicketBookingSystem.UI
{
	class BookingUI //represe
	{
		static void Main(string[] args)
		{
			Console.WriteLine("----------    Task 7 n 8  --------");
			Console.WriteLine("   Relation  / Asosciation + Interface Implementation  ");
			Console.WriteLine("");
			Console.WriteLine("    ---Main Menu---");

			BookingRepository bookingRepository = new BookingRepository();
			BookingService bookingService = new BookingService(bookingRepository);

			// Create customers and event
			Customer[] customers = { new Customer { customerName = "Anisha", email = "anishak@gmail.com" ,phone_number=1472583690},
										 new Customer { customerName = "Jazel", email = "Jazel@gmail.com" ,phone_number=1459875632 }  };
			Event eventObj = new Event { eventName = "Jonita Concert", eventDateTime = DateTime.Parse("2024-12-10 8:20"), venueName = "Chennai", totalSeats = 500, ticketPrice = 5000, availableSeats = 100, event_Type = "Concert" };

			// Retrieve and display booking details
			//Booking booking =bookingService.GetBooking(1);
			//bookingService.DisplayBookingDetails(booking);

			TicketBookingSystemRepository tbsRepository = new TicketBookingSystemRepository();
			TicketBookingSystemService tbsService = new TicketBookingSystemService(tbsRepository);
			bool exitProgram = false;

			while (!exitProgram)
			{
				// Outer Menu
				Console.WriteLine("Select An Event:");
				Console.WriteLine("1. Movie Event ");
				Console.WriteLine("2. Sports Event ");
				Console.WriteLine("3. Concert Event");
				Console.WriteLine("4. Exit");
				Console.Write("Enter Your Choice: ");
				int ch = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine();

				Event obj = null;

				switch (ch)
				{
					case 1:
						obj = tbsService.createEvent("Inception", DateTime.Parse("2024-11-05 07:00"), 500, 150, 200, "Movie", "INOX, Delhi", "Sci-Fi", "Leonardo DiCaprio", "Ellen Page");
						break;
					case 2:
						obj = tbsService.createEvent("FIFA World Cup 2026", DateTime.Parse("2024-12-10 20:00"), 2000, 300, 700, "Sports", "Lusail Stadium, Qatar", "Football", "Brazil vs Argentina");
						break;
					case 3:
						obj = tbsService.createEvent("Tomorrowland Festival", DateTime.Parse("2024-12-20 18:00"), 3000, 500, 1000, "Concert", "Boom, Belgium", "David Guetta", "EDM");
						break;
						;
					case 4:
						exitProgram = true;
						Console.WriteLine("Exiting the Program...");
						continue;
					default:
						Console.WriteLine("Invalid Option. Try Again.");
						continue;
				}

				// Inner Menu for Event Actions
				bool exitInnerLoop = false;

				while (!exitInnerLoop)
				{
					Console.WriteLine("\nMenu For Selected Event");
					Console.WriteLine("1. Display EventDetails");
					Console.WriteLine("2. Book Tickets");
					Console.WriteLine("3. Cancel Tickets");
					Console.WriteLine("4. Back to Main Menu");
					Console.Write("Select an action: ");
					int choice = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine();

					switch (choice)
					{
						case 1:
							tbsService.displayEventDetails(obj);
							break;
						case 2:
							Console.Write("Enter Number Of Tickets To Book: ");
							int n = Convert.ToInt32(Console.ReadLine());
							//tbsService.bookTickets(n, obj);
							bookingService.CreateBooking(customers, eventObj, n);
							//Booking booking = bookingService.GetBooking(1);
							//bookingService.DisplayBookingDetails(booking);
							break;
						case 3:
							Console.Write("Enter Number Of Tickets To Cancel: ");
							int num = Convert.ToInt32(Console.ReadLine());
							tbsService.cancelTickets(num, obj);
							break;
						case 4:
							exitInnerLoop = true;
							break;
						default:
							Console.WriteLine("Invalid Action. Try Again.");
							break;
					}
					Console.WriteLine();
				}
			}

		}
	}
}