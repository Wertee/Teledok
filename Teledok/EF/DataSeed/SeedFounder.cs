using Teledok.Models;
using Teledok.EF;

namespace Teledok.EF.DataSeed;

public class SeedFounder
{
    public static async Task Seed(TeledokDbContext context)
    {
        if (!context.Founders.Any())
        {
            List<Founder> founders = new()
            {
                new Founder()
                {
                    Fullname = "Иванов Иван Иванович",
                    INN = "000000000001",
                    CreationDate = DateTime.Now,
                    EditDate = DateTime.Now
                    
                },
                new Founder()
                {
                    Fullname = "Петров Петр Петрович",
                    INN = "000000000002",
                    CreationDate = DateTime.Now,
                    EditDate = DateTime.Now
                }
            };
            context.Founders.AddRange(founders);
            await context.SaveChangesAsync();
        }
    }
}