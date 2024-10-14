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
	class BookingUI
	{
		static void Main(string[] args)
		{
			Console.WriteLine("  Exception Handing 1)NullPointerException \n                   2)Custom Exception- Invalid Booking ");
			Console.WriteLine("");
			Console.WriteLine(" ---Main Menu---");


			BookingRepository bookingRepository = new BookingRepository();
			BookingService bookingService = new BookingService(bookingRepository);

			Customer[] customers = { new Customer { customerName = "Anisha", email = "Anisha@gmail.com" ,phone_number=1472583690},
										 new Customer { customerName = "Jazel", email = "Jazel@gmail.com" ,phone_number=1471598324 }  };
			Event eventObj = new Event { eventName = "Jonita Concert", eventDateTime = DateTime.Parse("2024-12-10 8:20"), venueName = "Chennai", totalSeats = 500, ticketPrice = 5000, availableSeats = 100, event_Type = "Concert" };


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

					case 4:
						exitProgram = true;
						Console.WriteLine("Exiting");
						continue;
					default:
						Console.WriteLine("Invalid Choice.");
						continue;
				}

				
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
							try
							{
								Console.Write("Enter Number Of Tickets To Book: ");
								string ticketInput = Console.ReadLine();

								if (string.IsNullOrEmpty(ticketInput))
								{
									throw new NullReferenceException("Number of tickets cannot be empty!");
								}

								int n = Convert.ToInt32(ticketInput);

								foreach (var customer in customers)
								{
									if (string.IsNullOrEmpty(customer.customerName) || string.IsNullOrEmpty(customer.email))
									{
										throw new NullReferenceException("Customer name or email cannot be empty!");
									}
								}

								bookingService.CreateBooking(customers, eventObj, n);
							}
							catch (NullReferenceException ex)
							{
								Console.WriteLine($"Error: {ex.Message}");
							}
							catch (InvalidBookingException ex)
							{
								Console.WriteLine($"Error: {ex.Message}");
							}
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
							Console.WriteLine("Invalid choice ");
							break;
					}
					Console.WriteLine();
				}
			}



		}
	}
}