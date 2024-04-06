namespace ConverterToSeconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double SEC_PER_MINUTE = 60D;
            const double SEC_PER_HOUR = 60 * SEC_PER_MINUTE;
            const double SEC_PER_DAY = 24 * SEC_PER_HOUR;
            double days;
            double hours;
            double minutes;
            double seconds;
            double totalSeconds;

            Console.Write("Εισάγετε τις μέρες: ");
            if (!double.TryParse(Console.ReadLine(), out days))
            {
                Console.WriteLine("Δεν εισαγετε μερες");
            }

            Console.Write("Εισάγετε τις ώρες: ");
            if (!double.TryParse(Console.ReadLine(), out hours))
            {
                Console.WriteLine("Δεν εισαγετε ωρες");
            }

            Console.Write("Εισάγετε τα λεπτά: ");
            if (!double.TryParse(Console.ReadLine(), out minutes))

            {
                Console.WriteLine("Δεν εισαγετε λεπτα");
            }

            Console.Write("Εισάγετε τα δευτερόλεπτα: ");
            if (!double.TryParse(Console.ReadLine(), out seconds))
            {
                Console.WriteLine("Δεν εισαγετε δευτερολεπτα");
            }

            totalSeconds = days * SEC_PER_DAY + hours * SEC_PER_HOUR + minutes * SEC_PER_MINUTE + seconds;

            Console.WriteLine("Ο συνολικός χρόνος σε δευτερόλεπτα είναι: " + totalSeconds);
        }
    }
}
