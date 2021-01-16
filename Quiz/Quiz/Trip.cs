using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    // Custom defined exception here.
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string msg)
            : base($"Invalid Data Exception {msg}")
        {

        }
    }
    class Trip
    {
        private string _name;
        private string _destination;
        
        // Name and Destination fields with restrictions and throw exception. Line 24-57
        public string Name
        {
            get => _name;
            set
            {
                char[] Input = value.ToCharArray();
                foreach (char c in Input)
                {
                    if (c == ';')
                    {
                        throw new InvalidDataException("Name cannot contain ; ");
                    }
                }

                _name = value;
            }
        }
        public string Destination
        {
            get => _destination;
            set
            {
                char[] Input = value.ToCharArray();
                foreach (char c in Input)
                {
                    if (c == ';')
                    {
                        throw new InvalidDataException("Destination cannot contain ; ");
                    }
                }

                _destination = value;
            }
        }
        public string Passport { get; set; }
        public string Departure { get; set; }
        public string Return { get; set; }

        // 2 Constructors 1 with 5 parameters and 1 with 1 string parameter. Line 63-79
        public Trip(string destination, string name, string passport, string departure, string returnDate)
        {
            Name = name;
            Destination = destination;
            Passport = passport;
            Departure = departure;
            Return = returnDate;
        }
        public Trip(string InputStr)
        {
            string[] Input = InputStr.Split(';');
            Destination = Input[0];
            Name = Input[1];
            Passport = Input[2];
            Departure = Input[3];
            Return = Input[4];
        }

        // Write to file with semi-column separate string.
        public string ToDataString()
        {
            return $"{Destination};{Name};{Passport};{Departure};{Return}";
        }
        
        // Custom methods for self usage. Line 87-END
        public bool IsSameTrip(Trip t)
        {
            if (t.Destination == Destination && t.Name == Name && t.Passport == Passport && t.Departure == Departure && t.Return == Return)
            {
                return true;
            }

            return false;
        }
        public void MakeCopyOf(Trip t)
        {
            Name = t.Name;
            Destination = t.Destination;
            Passport = t.Passport;
            Departure = t.Departure;
            Return = t.Return;
        }
    }
}
