using MultiThreading_Assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading_Assignment.Business_Logic
{
    public class CreateCustomers
    {
        List<Customer> customersList;
        Random random = new Random();


        public CreateCustomers()
        {
            customersList = new List<Customer>();
        }

        public List<Customer> CustomerCreation(int totalCust)
        {
            
            for (int i = 1; i <= totalCust; i++)
            {                
                customersList.Add(new Customer(RndId(), RndTime()));
            }
            return customersList;
        }

        private int RndId()
        {
            int? rnd;
            while ((rnd = GetAndCheck()) == null){}
            return rnd.Value;
        }

        private int RndTime()
        {
            return random.Next(1, 5)*1000;
        }

        private int? GetAndCheck()
        {
            int rnd = random.Next(1000, 9999);
        
            foreach (Customer c in customersList)
            {
                if (c.ID == rnd) return null;
            }
            return rnd;
        }
    }
}
