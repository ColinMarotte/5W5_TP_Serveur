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

        builder.Entity<Card>().HasData(Seed.SeedCards());
        builder.Entity<GameConfig>().HasData(Seed.SeedGameConfig());

        builder.Entity<IdentityUser>().HasData(Seed.SeedUsers());
        builder.Entity<IdentityRole>().HasData(Seed.SeedRoles());
        builder.Entity<IdentityUserRole<string>>().HasData(Seed.SeedUserRoles());

        builder.Entity<IdentityUser>().HasData(Seed.SeedTestUsers());
        builder.Entity<Player>().HasData(Seed.SeedTestPlayers());


        builder.Entity<CardPower>()
    .HasKey(cp => new { cp.CardPowerId });

        builder.Entity<CardPower>()
            .HasOne(cp => cp.Card)
            .WithMany(c => c.CardPowers)
            .HasForeignKey(cp => cp.CardId)
            .OnDelete(DeleteBehavior.NoAction);

        //builder.Entity<CardPower>()
        //    .HasOne(cp => cp.Power)
        //    .WithMany() 
        //    .HasForeignKey(cp => cp.PowerId)
        //    .OnDelete(DeleteBehavior.NoAction);


        builder.Entity<Power>().HasData(Seed.SeedPowers());

        builder.Entity<CardPower>().HasData(Seed.SeedCardPowers());


        // Lorsque le modèle de données se complexifient, il faut éventuellement utiliser Fluent API
        // https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties
        // pour préciser certaines relations.
        // Nous allons couvrir ce sujet plus tard dans la session
        builder.Entity<Match>()
            .HasOne(m => m.PlayerDataA)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Match>()
            .HasOne(m => m.PlayerDataB)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);


        builder.Entity<StartingCard>()
            .HasOne(s => s.Card)
            .WithMany()
            .HasForeignKey(s => s.CardId);

        builder.Entity<Card>()
            .HasMany<StartingCard>()
            .WithOne(s => s.Card)
            .HasForeignKey(c => c.CardId);

        builder.Entity<StartingCard>().HasData(Seed.SeedStartingCards());

        builder.Entity<DeckOwnedCard>()
            .HasOne(d => d.Deck)
            .WithMany()
            .HasForeignKey(d => d.DeckId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<DeckOwnedCard>()
            .HasOne(d => d.OwnedCard)
            .WithMany()
            .HasForeignKey(d => d.OwnedCardId)
            .OnDelete(DeleteBehavior.NoAction);

        // Fin de Fluent API
    //    builder.Entity<Power>().HasData(Seed.SeedPowers());
    //    builder.Entity<CardPower>()
    //.HasOne(cp => cp.Card)
    //.WithMany()
    //.HasForeignKey(cp => cp.CardId)
    //.OnDelete(DeleteBehavior.NoAction);

    //    builder.Entity<CardPower>()
    //        .HasOne(cp => cp.Power)
    //        .WithMany()
    //        .HasForeignKey(cp => cp.PowerId)
    //        .OnDelete(DeleteBehavior.NoAction);

    //    builder.Entity<CardPower>().HasKey(cp => cp.Id);
    //    builder.Entity<CardPower>().HasData(Seed.SeedCardPowers());






    }

    public DbSet<Card> Cards { get; set; } = default!;

    public DbSet<Player> Players { get; set; } = default!;

    public DbSet<Match> Matches { get; set; } = default!;

    public DbSet<MatchPlayerData> MatchPlayersData { get; set; } = default!;

    public DbSet<StartingCard> StartingCards { get; set; } = default!;

    public DbSet<GameConfig> GameConfigs { get; set; } = default!;

    public DbSet<OwnedCard> OwnedCards { get; set; } = default!;

    public DbSet<Power> Powers { get; set; } = default!;

    public DbSet<CardPower> CardPowers { get; set; } = default!;

    public DbSet<Deck> Decks { get; set; } = default!;

    public DbSet<DeckOwnedCard> DeckOwnedCards { get; set; } = default!;
}

