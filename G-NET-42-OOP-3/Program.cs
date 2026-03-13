using System.ComponentModel;
using System.Security.AccessControl;

namespace G_NET_42_OOP_3
{
    class Ticket
    {
        private static int counter = 0;

        public string MovieName { get; set; }
        public decimal Price { get; set; }

        public int TicketId { get; }

        public decimal PriceAfterTax
        {
            get { return Price * 1.14m; }
        }

        public Ticket(string movieName, decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater than 0");

            MovieName = movieName;
            Price = price;

            counter++;
            TicketId = counter;
        }

        public static int GetTotalTickets()
        {
            return counter;
        }

        public override string ToString()
        {
            return $"Ticket #{TicketId} | {MovieName} | Price: {Price} EGP | After Tax: {PriceAfterTax:F2} EGP";
        }
    }
    class StandardTicket : Ticket
    {
        public string SeatNumber { get; set; }

        public StandardTicket(string movie, decimal price, string seat)
            : base(movie, price)
        {
            SeatNumber = seat;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Seat: {SeatNumber}";
        }
    }
    class VIPTicket : Ticket
    {
        public bool LoungeAccess { get; set; }
        public decimal ServiceFee { get; set; } = 50;

        public VIPTicket(string movie, decimal price, bool lounge)
            : base(movie, price)
        {
            LoungeAccess = lounge;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $" | Lounge: {(LoungeAccess ? "Yes" : "No")} | Service Fee: {ServiceFee} EGP";
        }
    }
    class IMAXTicket : Ticket
    {
        public bool Is3D { get; set; }

        public IMAXTicket(string movie, decimal price, bool is3D)
            : base(movie, price)
        {
            Is3D = is3D;

            if (Is3D)
                Price += 30;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $" | IMAX 3D: {(Is3D ? "Yes" : "No")}";
        }
    }
    class Projector
    {
        public void Start()
        {
            Console.WriteLine("Projector started.");
        }

        public void Stop()
        {
            Console.WriteLine("Projector stopped.");
        }
    }
    class Cinema
    {
        public string CinemaName { get; set; }
        private Ticket[] tickets = new Ticket[20];
        private Projector projector = new Projector();

        public Cinema(string name)
        {
            CinemaName = name;
        }

        public void AddTicket(Ticket ticket)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] == null)
                {
                    tickets[i] = ticket;
                    return;
                }
            }

            Console.WriteLine("Cinema is full.");
        }

        public void PrintAllTickets()
        {
            Console.WriteLine("\n======= All Tickets =======");

            foreach (var ticket in tickets)
            {
                if (ticket != null)
                    Console.WriteLine(ticket);
            }

            Console.WriteLine("\n======= Statistics =======");
            Console.WriteLine($"Total Tickets Created: {Ticket.GetTotalTickets()}");
        }

        public void OpenCinema()
        {
            Console.WriteLine("======= Cinema Opened =======");
            projector.Start();
        }

        public void CloseCinema()
        {
            Console.WriteLine("======= Cinema Closed =======");
            projector.Stop();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region part1
            //Q1 
            //    a)Composition
            //    b)Association
            //    c)Inheritance
            //    d)Aggregation
            //    e)Dependency
            //Q2
            //    a)Yes, the child class can access it even if it is in a different assembly.
            //    It cannot be accessed through an object instance from outside.
            //    b)protected internal >>Accessible from same assembly OR derived classes in other assemblies
            //    private protected >>Accessible only by derived classes AND inside the same assembly
            //    c)When applied to a class It prevents inheritance.
            //    When applied to a method It prevents further overriding.
            //    d)Yes, you can create objects from a sealed class.
            //    sealed only prevents inheritance, not instantiation
            #endregion

            Cinema cinema = new Cinema("Galaxy Cinema");

            cinema.OpenCinema();

            StandardTicket t1 = new StandardTicket("Inception", 120, "A-5");
            VIPTicket t2 = new VIPTicket("Avengers", 200, true);
            IMAXTicket t3 = new IMAXTicket("Dune", 180, true);

            cinema.AddTicket(t1);
            cinema.AddTicket(t2);
            cinema.AddTicket(t3);

            cinema.PrintAllTickets();

            cinema.CloseCinema();
        }
    }
}
