namespace LAB_9
{
    internal class Shooter
    {
        public int score = 0;
        public int pass = 0;
        public int sector;
        public Automat auto = new();
        public Shooter(Automat auto, int sector) { this.auto = auto; this.sector = sector; }
        public void Shoot()
        {
            do
            {
                Random rand = new();
                Thread.Sleep(rand.Next(1000, 1501));
                while (auto.plates.Count == 0) { Thread.Sleep(130); Console.WriteLine("Стрелок " + sector + " ожидает"); }
                int plate_number = rand.Next(auto.plates.Count);
                lock (new object())
                {
                    if (sector == auto.plates[plate_number].sector || rand.Next(100) < 30)
                    {
                        Console.WriteLine($"Стрелок {sector} сбил тарелку {auto.plates[plate_number].number} в секторе {auto.plates[plate_number].sector}. Сбито {score + 1}. Промахов {pass}");
                        auto.plates.Remove(auto.plates[plate_number]);
                        score += 1;
                    }
                    else
                    {
                        Console.WriteLine($"Стрелок {sector} промазал по тарелке {auto.plates[plate_number].number} в секторе {auto.plates[plate_number].sector}. Сбито {score}. Промахов {pass + 1}");
                        pass += 1;
                    }
                }
            } while (score < 10);
            Console.WriteLine($"Стрелок {sector} завершил стрельбу. Сбито {score}. Промахов {pass}");
            auto.end += 1;
        }
    }
}

