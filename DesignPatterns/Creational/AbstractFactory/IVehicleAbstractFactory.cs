using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Creational.AbstractFactory
{
    public interface IPhoneAbstractFactory
    {
        SmartPhone GetSmartPhone(string phoneType);
    }

    public interface SmartPhone
    {
        string Name();

        decimal Weight(); 
    }

    public class Lumia720 : SmartPhone
    {
        public string Name() {  return "Lumia 720"; }

        public decimal Weight() { return 120.56m; }
    }

    public class Lumia830 : SmartPhone
    {
        public string Name() {  return "Lumia 830"; }

        public decimal Weight() { return 134.67m; }

    }

    public class HTC8 : SmartPhone
    {
        public string Name() { return "HTC 8"; }

        public decimal Weight() { return 127.5m; }
    }

    public class HTCOne : SmartPhone
    {
        public string Name() { return "HTC One"; }

        public decimal Weight() { return 114.7m; }

    }

    public class NokiaFactory : IPhoneAbstractFactory
    {

        public SmartPhone GetSmartPhone(string smartPhoneName)
        {
            switch (smartPhoneName)
            {
                case "Lumia720":
                    return new Lumia720();
                case "Lumia830":
                    return new Lumia830();
                default:
                    throw new ApplicationException(string.Format("{0} Smart phone not available", smartPhoneName));
            };
        }
    }

    public class HTCFactory : IPhoneAbstractFactory
    {

        public SmartPhone GetSmartPhone(string smartPhoneName)
        {
            switch (smartPhoneName)
            {
                case "HTC 8":
                    return new HTC8();
                case "HTC One":
                    return new HTCOne();
                default:
                    throw new ApplicationException(string.Format("{0} Smart phone not available", smartPhoneName));
            };
        }
    }

    public class PhoneCustomer
    {
        SmartPhone smartPhone;

        public PhoneCustomer(IPhoneAbstractFactory factory, string phoneType)
        {
            smartPhone = factory.GetSmartPhone(phoneType);
        }

        public string GetPhoneName()
        {
            return smartPhone.Name();
        }
    }

    public class AbstractFactoryProgram
    {
        public static void Execute() 
        {
            IPhoneAbstractFactory phoneFactory = new NokiaFactory();
            PhoneCustomer phoneCustomer = new PhoneCustomer(phoneFactory, "Lumia720");
            Console.WriteLine(phoneCustomer.GetPhoneName());

            phoneFactory = new HTCFactory();
            phoneCustomer = new PhoneCustomer(phoneFactory, "HTC One");

            Console.WriteLine(phoneCustomer.GetPhoneName());
        }
    }
}
