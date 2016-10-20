using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingSpring
{
    public class MyFactory
    {
        public MyFactory()
        {

        }
        public  CustomerBusinessLogic CreateInstance()
        {
            return new CustomerBusinessLogic();
        }
    }
}
