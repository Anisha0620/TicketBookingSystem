using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer;
using TicketBookingSystem.BusinessLayer.Repository;
//using TicketBookingSystem.Businesslayer.Service;

namespace TicketBookingSystem.BusinessLayer.Service
{
	public class CustomerService : ICustomerService
	{
		ICustomerRepository _customerRepository;
		public CustomerService(CustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}
		public void displayCustomerDetails(Customer customer)
		{
			_customerRepository.displayCustomerDetails(customer);
		}


	}
}
