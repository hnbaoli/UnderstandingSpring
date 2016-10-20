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

        public void InitViaIOC()
        {
            Console.WriteLine($"InitViaIOC {nameof(CustomerBusinessLogic)}");
        }

        public void ValidateCustomer()
        {
            Console.WriteLine($"Validating the customer");
        }
    }

    public interface IBusinessLogicLayer
    {
        void ValidateCustomer();
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
