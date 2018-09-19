using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceCustomer;

namespace DomainLayer
{
    // Define Entities - based on noun (Class) , pronoun(Properties of the class) and verb (Methods of the Class) Strategy
    // RelationShip between entities - "Is a" and "Has a"
    // Lead is a type of Customer


    public class CustomerBase : ICustomer
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }
        //public string type { get; set; }

        public virtual void Validate()
        {
            //Force the derived classes to implement the method
            throw new Exception("Not implemented");
        }


    }

    public class Customer : CustomerBase
    {
        public override void Validate()
        {
            //base.Validate();
            if (CustomerName.Length == 0) throw new Exception("Customer Name is Required");
            if (PhoneNumber.Length == 0) throw new Exception("Customer Phone Number is Required");
            if (BillAmount == 0) throw new Exception("Bill Amount is Required");
            if (BillDate >= DateTime.Now) throw new Exception("Bill Date is Required");
            if (Address.Length == 0) throw new Exception("Customer Address is Required");
        }
    }

    public class Lead : CustomerBase
    {
        public override void Validate()
        {
            //base.Validate();
            if (CustomerName.Length == 0) throw new Exception("Customer Name is Required");
            if (PhoneNumber.Length == 0) throw new Exception("Customer Phone Number is Required");
        }
    }
}
