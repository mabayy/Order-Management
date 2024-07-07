namespace Order_Management
{
    public class DBInit
    {
        public static async Task Initialize(AppDBContext context)
        {
            context.Database.EnsureCreated();

            //check for users
            if (context.ApplicationUser.Any())
            {
                return; //if user is not empty, DB has been seed
            }
        }
    }
}
