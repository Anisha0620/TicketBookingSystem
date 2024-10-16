﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer.Repository;
using TicketBookingSystem.BusinessLayer.Service;

namespace TicketBookingSystem.UI
{
	class Booking
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Inheritance, Polymorphism And Abstraction");
			Console.WriteLine("");
			Console.WriteLine("------Main Menu------");



			TicketBookingSystemRepository tbsRepository = new TicketBookingSystemRepository();
			TicketBookingSystemService tbsService = new TicketBookingSystemService(tbsRepository);
			bool exitProgram = false;

			while (!exitProgram)
			{
			
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
						Console.WriteLine("Exiting .");
						continue;
					default:
						Console.WriteLine("Invalid choice");
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
							tbsService.bookTickets(n, obj);
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
							Console.WriteLine("Invalid choice");
							break;
					}
					Console.WriteLine();
				}
			}

		}
	}
}