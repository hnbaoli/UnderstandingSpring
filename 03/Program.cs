using System;
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

        public IRepository CustomerRepo { get; set; }

        public void InitViaIOC()
        {
            Console.WriteLine($"InitViaIOC {nameof(CustomerBusinessLogic)}");
        }

        public void ValidateCustomer()
        {
            Console.WriteLine("ValidateCustomer Called");
            CustomerRepo.DoSomething();
            Console.WriteLine($"Validating the customer");
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
