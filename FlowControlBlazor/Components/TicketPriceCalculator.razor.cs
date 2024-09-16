using FlowControlBlazor.Components.Pages;

namespace FlowControlBlazor.Components
{
    class PersonModel
    {
        public string Name;
        public int Age;
        public int Price;
    }

    /// <summary>
    /// A class for calculating ticket prices for a group of people based on their ages.
    /// </summary>
    public partial class TicketPriceCalculator
    {
        private struct TicketPrice(int price, int minimumAge, int maximumAge)
        {
            public int Price { get; set; } = price;
            public int MinimumAge { get; set; } = minimumAge;
            public int MaximumAge { get; set; } = maximumAge;

            public bool IsInAgeRange(int age)
            {
                return age >= MinimumAge && age < MaximumAge;
            }
        }

        private TicketPrice[] ticketPrices = [
            new TicketPrice(0, 0, 5),
                new TicketPrice(80, 5, 20),
                new TicketPrice(120, 20, 65),
                new TicketPrice(90, 64, 101),
                new TicketPrice(90, 101, 1000),
        ];

        private const int maxNumberOfPeople = 3;
        int NrOfPeople { get; set; }

        PersonModel[] PersonModels = new PersonModel[maxNumberOfPeople];

        int ticketPrice = 0;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            SetNumberOfPeople();
        }

        /// <summary>
        /// Reinstantiates the PersonModels array of size NrOfPeople.
        /// </summary>
        void SetNumberOfPeople()
        {
            PersonModels = new PersonModel[NrOfPeople];
            for (int i = 0; i < PersonModels.Length; i++)
            {
                PersonModels[i] = new();
            }

            CalculateTicketPrice();
        }

        void HandleValidSubmit()
        {
            CalculateTicketPrice();
        }

        void HandleInvalidSubmit()
        {

        }

        /// <summary>
        /// Prompts the user for data: number of guests and age of guests.
        /// Calculates and prints the total ticket price to the console.
        /// </summary>
        /// <param name="nrOfPeople"></param>
        public void CalculateTicketPrice()
        {
            ticketPrice = 0;

            foreach (var person in PersonModels)
            {
                if(person == null) continue;

                person.Price = GetTicketPriceFromAgeOptionC(person.Age);
                ticketPrice += person.Price;
            }
        }

        /// <summary>
        /// Alternative GetTicketPriceFromAge method using a foreach loop instead of a switch.
        /// </summary>
        /// <param name="age">The age of the guest.</param>
        /// <returns>The ticket price.</returns>
        /// <exception cref="Exception">If the age is not found in the ticketPrices list.</exception>
        private int GetTicketPriceFromAgeOptionC(int age)
        {
            foreach (TicketPrice ticketPrice in ticketPrices)
            {
                if (ticketPrice.IsInAgeRange(age)) return ticketPrice.Price;
            }

            throw new Exception("GetTicketPriceFromAgeOptionB error: Invalid age");
        }
    }
}
