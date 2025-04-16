using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Models;
using System.Reflection.Emit;
namespace Super_Cartes_Infinies.Data;
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public const string ADMIN_ROLE = "admin";

    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<StartingCard>()
            .HasOne(sc => sc.Card)
            .WithMany()
            .HasForeignKey(sc => sc.CardId);

        builder.Entity<CardPower>()
        .HasKey(cp => new { cp.CardId, cp.PowerId });

        builder.Entity<CardPower>()
            .HasOne(cp => cp.Card)
            .WithMany(c => c.CardPowers)
            .HasForeignKey(cp => cp.CardId);

        builder.Entity<CardPower>()
            .HasOne(cp => cp.Power)
            .WithMany()
            .HasForeignKey(cp => cp.PowerId);

        builder.Entity<Card>().HasData(Seed.SeedCards());
        builder.Entity<Power>().HasData(Seed.SeedPowers());
        builder.Entity<CardPower>().HasData(Seed.SeedCardPowers());

        builder.Entity<StartingCard>().HasData(Seed.SeedStartingCards());
        builder.Entity<GameConfig>().HasData(Seed.SeedGameConfig());

        builder.Entity<IdentityUser>().HasData(Seed.SeedUsers());
        builder.Entity<IdentityRole>().HasData(Seed.SeedRoles());
        builder.Entity<IdentityUserRole<string>>().HasData(Seed.SeedUserRoles());

        builder.Entity<IdentityUser>().HasData(Seed.SeedTestUsers());
        builder.Entity<Player>().HasData(Seed.SeedTestPlayers());

        builder.Entity<Match>()
            .HasOne(m => m.PlayerDataA)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Match>()
            .HasOne(m => m.PlayerDataB)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }

    public DbSet<Card> Cards { get; set; } = default!;

    public DbSet<Player> Players { get; set; } = default!;

    public DbSet<Match> Matches { get; set; } = default!;

    public DbSet<MatchPlayerData> MatchPlayersData { get; set; } = default!;

    public DbSet<StartingCard> StartingCards { get; set; }

    public DbSet<GameConfig> GameConfigs { get; set; }

    public DbSet<OwnedCard> OwnedCards { get; set; } = default!;

    public DbSet<Power> Powers { get; set; } = default!;

    public DbSet<CardPower> CardPowers { get; set; } = default!;

}
