namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<mbensaeed.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(mbensaeed.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Category.AddOrUpdate(x => x.ID,
                new Models.Category() { ID = 1, DescriptionFa = "اخبار و رسانه ها", IsActive = "1" },
                new Models.Category() { ID = 2, DescriptionFa = "رایانه و اینترنت", IsActive = "1" },
                new Models.Category() { ID = 3, DescriptionFa = "تجارت و اقتصاد", IsActive = "1" },
                new Models.Category() { ID = 4, DescriptionFa = "فرهنگ و تاریخ", IsActive = "1" },
                new Models.Category() { ID = 5, DescriptionFa = "ورزش", IsActive = "1" },
                new Models.Category() { ID = 6, DescriptionFa = "شخصی", IsActive = "1" },
                new Models.Category() { ID = 7, DescriptionFa = "سفر و توریسم", IsActive = "1" },
                new Models.Category() { ID = 8, DescriptionFa = "آموزش", IsActive = "1" },
                new Models.Category() { ID = 9, DescriptionFa = "هنر و ادبیات", IsActive = "1" },
                new Models.Category() { ID = 10, DescriptionFa = "علم و فن آوری", IsActive = "1" },
                new Models.Category() { ID = 11, DescriptionFa = "اندیشه و مذهب", IsActive = "1" },
                new Models.Category() { ID = 12, DescriptionFa = "سرگرمی و طنز", IsActive = "1" },
                new Models.Category() { ID = 13, DescriptionFa = "خانواده و زندگی", IsActive = "1" },
                new Models.Category() { ID = 14, DescriptionFa = "سبک زندگی", IsActive = "1" }
                );
            context.ActivityTypes.AddOrUpdate(x => x.ID,
                new Models.ActivityType() {ID=1,Title= "view",Description="بازديد" },
                new Models.ActivityType() {ID=2,Title= "like",Description="پسنديدن" });
                }
    }
}
