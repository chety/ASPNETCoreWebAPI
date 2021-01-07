using System.Linq;

namespace CoreWebApi.Data
{
    public static class SeedData
    {
        public static void Initialize(ContosoPetsContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new(0, "Squeaky Bone", 20.99m),
                    new(0, "Knotted Rope", 12.99m),
                    new(0, "Race Car", 55m)
                );
                
                context.SaveChanges();
            }
        }
    }
}