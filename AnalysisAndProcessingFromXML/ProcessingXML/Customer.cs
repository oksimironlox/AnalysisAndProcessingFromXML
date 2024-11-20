using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAndProcessingFromXML.ProcessingXML
{
    public class Customer
    {
        public Customer(string name, int age) 
        {
            this.Name = name;
            this.Age = age;
        }
        public Customer(string name, int age, float fundsInTheAccounts)
        {
            this.Name = name;
            this.Age = age;
            this.FundsInTheAccounts = fundsInTheAccounts;
        }
        public Customer(string name, int age, float fundsInTheAccounts, bool availabilityOfLoans)
        {
            this.Name = name;
            this.Age = age;
            this.FundsInTheAccounts = fundsInTheAccounts;
            this.AvailabilityOfLoans = availabilityOfLoans;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public float FundsInTheAccounts { get; set; } = 0;
        public bool AvailabilityOfLoans { get; set; } = false;
    }
}
