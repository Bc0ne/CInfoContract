﻿namespace Contract.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Migrations;
    using System.Linq;

    public static class DbContextExtensions
    {
        public static bool AllMigrationsApplied(this ContractDbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return total.Except(applied).Any();
        }

        public static void EnsureMigrated(this ContractDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
