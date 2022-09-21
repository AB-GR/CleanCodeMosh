using System;

namespace CleanCode.NestedConditionals
{
    public class Customer
    {
        public int LoyaltyPoints { get; set; }
    }

    public class Reservation
    {
        public Reservation(Customer customer, DateTime dateTime)
        {
            From = dateTime;
            Customer = customer;
        }

        public DateTime From { get; set; }
        public Customer Customer { get; set; }
        public bool IsCanceled { get; set; }

        public void Cancel()
        { 
            if (IsCancellationPeriodOver())
                throw new InvalidOperationException("It's too late to cancel.");

            IsCanceled = true;
        }

        // Regular customers can cancel up to 48 hours before
        // Gold customers can cancel up to 24 hours before
        private bool IsCancellationPeriodOver()
            => IsGoldCustomer() && LessThan(24) || !IsGoldCustomer() && LessThan(48);

        private bool IsGoldCustomer() => Customer.LoyaltyPoints > 100;

        private bool LessThan(int maxHours)
		    => (From - DateTime.Now).TotalHours < maxHours;

    }
}
