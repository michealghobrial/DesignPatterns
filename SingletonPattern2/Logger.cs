using System.Diagnostics.Metrics;

namespace SingletonPattern2
{
    public  sealed class Logger
    {
        private static int counter = 0;
        private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());

        private Logger(){
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }

        public static Logger GetInstance() => instance.Value;

        public void Log(string message) => Console.WriteLine("Log " + message);
    }
}
