using System;
using System.Collections.Generic;
using DomainLayer;
//using Microsoft.Practices.Unity;
using Unity;
using InterfaceCustomer;


namespace FactoryDomainLayer
{
    //Design Pattern - Simple Factory
    public static class Factory
    {
        //private static Dictionary<string, CustomerBase> customers = new Dictionary<string, CustomerBase>();
        private static Lazy<Dictionary<string, CustomerBase>> lcustomers = null;

        // Design Pattern - Simple Factory Pattern - Using Unity
        // We can automate, the centralized object creation by using DI frameworks
        // Examples:Unity,Nineject , Windsor
        // Install Unity using the NuGet package Manager for the Factory Class

        private static IUnityContainer customers = null;

        static Factory()
        {
            // Design Pattern - Lazy/Eager Loading using Lazy keyword
            lcustomers = new Lazy<Dictionary<string, CustomerBase>>(() => LoadCustomers());
        }

        private static Dictionary<string,CustomerBase> LoadCustomers()
        {
            var custs = new Dictionary<string, CustomerBase>();
            custs.Add("Customer", new Customer());
            custs.Add("Lead", new Lead());
            return custs;
        }

        private static CustomerBase CreateOld(string customerType )
        {
            // Design Pattern - Lazy Loading - Eager Loading
            //  if (customers.Count == 0)
            //{
            //    customers.Add("Customer", new Customer());
            //    customers.Add("Lead", new Lead());
            //}

            // IOC -  Decoupled UI to Domain Objects
            //if (customerType == "Customer")
            //    return new Customer();
            //else
            //    return new Lead();


            // Design Pattern - RIP - Replace IF with Ploymorphism
            // Design Pattern - Lazy Loading - Eager Loading

            return lcustomers.Value[customerType]; 
        }

        public static ICustomer Create(string customerType)
        {
            if (customers == null)
            {
                customers = new UnityContainer(); 
                customers.RegisterType<ICustomer, Customer>("Customer");
                customers.RegisterType<ICustomer, Lead>("Lead"); 
            }
            return customers.Resolve<ICustomer>(customerType);
        }


    }
}
