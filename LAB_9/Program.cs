namespace LAB_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Automat auto = new();
            Shooter[] shooters = new Shooter[5];
            Thread[] threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                Shooter shooter = new(auto, i + 1);
                shooters[i] = shooter;
                threads[i] = new Thread(delegate () { shooter.Shoot(); });
            }
            Thread automat = new Thread(() => auto.Fire_on_plates());
            automat.Start();
            foreach (var thread in threads)
            {
                thread.Start();
            }
        }
    }
}






