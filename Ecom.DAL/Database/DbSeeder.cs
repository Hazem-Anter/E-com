
namespace Ecom.DAL.Database
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            // --- 1. Create Migrations (If they don't exist) ---
            // This will create the database and all tables
            // if they don't exist.
            await context.Database.MigrateAsync();

            // --- 2. Seed Admin User ---
            if (!await userManager.Users.AnyAsync(u => u.Email == "admin@ecom.com"))
            {
                var adminUser = new AppUser(
                    email: "admin@ecom.com",
                    displayName: "Admin User",
                    profileImageUrl: null,
                    createdBy: "System",
                    phoneNumber: "123456789"
                );
                await userManager.CreateAsync(adminUser, "P@ssword123");
                // Note: You would also add to "Admin" role here
            }

            // --- 3. Seed a Test Brand ---
            // We check if any brands exist before adding one
            if (!await context.Brands.AnyAsync())
            {
                var brand = new Brand(
                    name: "Test Brand",
                    imageUrl: null,
                    createdBy: "System"
                );
                await context.Brands.AddAsync(brand);
            }

            // --- 4. Seed a Test Category ---
            if (!await context.Categories.AnyAsync())
            {
                var category = new Category(
                    name: "Test Category",
                    imageUrl: null,
                    createdBy: "System"
                );
                await context.Categories.AddAsync(category);
            }

            // --- 5. Save all changes ---
            await context.SaveChangesAsync();
        }
    }
}
