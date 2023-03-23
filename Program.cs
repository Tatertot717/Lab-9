namespace Lab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter time 1 in 24hr format as follows (HH:MM:SS)");
            int[] time1 = TimeConvert(Console.ReadLine());
            if (time1 == null) System.Environment.Exit(1);
            Console.WriteLine("Enter time 2 in 24hr format as follows (HH:MM:SS)");
            int[] time2 = TimeConvert(Console.ReadLine());
            if (time2 == null) System.Environment.Exit(1);


            Console.WriteLine("Difference in seconds: " + TimeCompare(time1, time2));
        }

        private static int TimeCompare(int[] time1, int[] time2)
        {
            int sec1 = 60 * 60 * time1[0] + 60 * time1[1] + time1[2];
            int sec2 = 60 * 60 * time2[0] + 60 * time2[1] + time2[2];
            return (Math.Abs(sec1 - sec2));
        }

        static int[] TimeConvert(string time)
        {
            int[]? arr = null;
            try
            {
                string[] timearray = new string[3];
                timearray = time.Split(":", 3);

                int hour = int.Parse(timearray[0]);
                int min = int.Parse(timearray[1]);
                int sec = int.Parse(timearray[2]);

                arr = new int[3];
                if (hour > 23)
                {
                    throw new InvalidTimeException("Hour must be below 24");
                }
                arr[0] = hour;
                if (min > 59)
                {
                    throw new InvalidTimeException("Minutes must be less than 60");
                }
                arr[1] = min;
                if (sec > 59)
                {
                    throw new InvalidTimeException("Seconds must be less than 60");
                }
                arr[2] = sec;
                return arr;

            }

            catch (InvalidTimeException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Exception: Enter a valid time");
            }
            arr = null;
            return arr;
        }
    }

    class InvalidTimeException : Exception
    {
        public InvalidTimeException() { }

        public InvalidTimeException(string name)
            : base(String.Format("Invalid Time: {0}", name))
        {

        }


    }
}