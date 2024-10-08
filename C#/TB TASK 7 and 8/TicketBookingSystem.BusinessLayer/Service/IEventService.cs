﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;

namespace TicketBookingSystem.BusinessLayer.Service
{
	public interface IEventService
	{
		decimal calculateTotalRevenue(Event eventobj);
		int getBookedNoOfTickets(Event eventobj);
		void bookTickets(int numTickets, Event eventobj);
		void cancelTickets(int numTickets, Event eventobj);
		void displayEventDetails(Event eventobj);

	}
}
