using System;


// Concept for Dependency Injection

// someone from outside will inject it here
// I am not responsible for creating the object now, someone will
// DI makes system more flexible
// no impact on ui, but alot of impact internally / structurally inside.

namespace DependencyInjectionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Customer with Validator2
            Customer x = new Customer(new Validator2()); 
            x.Validate();
            // Customr with Validator
            Customer x1 = new Customer(new Validator());
            x1.Validate();
            Console.WriteLine("Hello World!");

        }
    }

    //Bridge decouples an abstraction from its implementation 
    //so that the two can vary independently.
    // Its the validation which are different and not the customer
    class Customer
    {
        IValidator validator = null;
        public Customer(IValidator _v)
        {
            validator = _v;
        }
        public string name { get; set; }
        public string address { get; set; }

        public virtual bool Validate()
        {
            return validator.Validate(this);
        }
    }

    interface IValidator
    {
        bool Validate(Customer obj);
    }


    class Validator : IValidator
    {
        public virtual bool Validate(Customer obj)
        {
            if (obj.name.Length == 0)
            {
                return false;
            }
            return true;
        }
    }
    class Validator2 : Validator
    {
        public override bool Validate(Customer obj)
        {
            if (obj.name.Length == 0)
            {
                return false;
            }
            if (obj.address.Length == 0)
            {
                return false;
            }
            return true;
        }
    }

}
