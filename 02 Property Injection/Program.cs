﻿using System;
using Spring.Context;
using Spring.Context.Support;

namespace UnderstandingSpring
{
    public class CustomerBusinessLogic : IBusinessLogicLayer
    {
        public CustomerBusinessLogic()
        {
            Console.WriteLine($"Constructor {nameof(CustomerBusinessLogic)} called");
        }

        private IRepository _customerRepo;
        public IRepository CustomerRepo {
            get
            {
                return _customerRepo;
                ;
            }
            set
            {
                _customerRepo = value;
                Console.WriteLine($"In {nameof(CustomerBusinessLogic)} - Customer repository set via spring DI");
            }
            
        }

        public void InitViaIOC()
        {
            Console.WriteLine($"InitViaIOC {nameof(CustomerBusinessLogic)} - is called after all deps are wired up");
        }

        public void ValidateCustomer()
        {
            Console.WriteLine("ValidateCustomer start");
            CustomerRepo.DoSomething();
            Console.WriteLine("ValidateCustomer end");

        }
    }

    public interface IBusinessLogicLayer
    {
        void ValidateCustomer();
    }

    public class CustomerRepository : IRepository
    {
        public CustomerRepository()
        {

            Console.WriteLine($"Constructed {nameof(CustomerRepository)}");
        }

        public void InitViaIOC()
        {
            Console.WriteLine($"InitViaIOC {nameof(CustomerRepository)}");
        }
        public void DoSomething()
        {
            Console.WriteLine("DoSomething in CustomerRepository");
        }
    }

    public interface IRepository
    {
        void DoSomething();
    }

    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext bootstrapContext = ContextRegistry.GetContext();
            IBusinessLogicLayer bl = bootstrapContext.GetObject("BL") as IBusinessLogicLayer;
            bl?.ValidateCustomer();

            Console.Read();
        }
    }
}
