namespace LAB_9
{
    internal class Automat
    {
        public List<Plate> plates = new List<Plate>();
        public int end = 0;

        public void Fire_on_plates()
        {
            for (int i = 1; ; i++)
            {
                Random rand = new();
                int sector = rand.Next(1, 6);
                Plate plate = new(i, sector);
                Console.WriteLine($"Тарелка номер {plate.number} запущена в сектор {sector}.");

                if (plates.Count >= 5)
                {
                    Console.WriteLine($"Тарелка номер {plates[0].number} покинула зону поражения");
                    plates.RemoveAt(0);
                }
                plates.Add(plate);
                Thread.Sleep(200);
                if (end == 5) break;
            }
        }
    }
}
