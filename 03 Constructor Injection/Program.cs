using System;
using Spring.Context;
using Spring.Context.Support;

namespace UnderstandingSpring
{
    public class CustomerBusinessLogic : IBusinessLogicLayer
    {
        private IRepository _customerRepo;

        public CustomerBusinessLogic(IRepository customerRepo)
        {
             _customerRepo = customerRepo;

            Console.WriteLine($"Constructor {nameof(CustomerBusinessLogic)} called");
        }

      public void InitViaIOC()
        {
            Console.WriteLine($"InitViaIOC {nameof(CustomerBusinessLogic)}");
        }

        public void ValidateCustomer()
        {
            Console.WriteLine("ValidateCustomer Called");
            _customerRepo.DoSomething();
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
