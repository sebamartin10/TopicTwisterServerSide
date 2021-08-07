using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContextDB : DbContext
    {
        public ContextDB() { }
        public ContextDB(DbContextOptions<ContextDB> options): base(options) {
        
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Letter> Letters { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<PlayerSession> PlayerSessions { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<RoundCategory> RoundCategories { get; set; }
        public DbSet<WordCategory> WordCategories { get; set; }
        public DbSet<SessionResult> SessionResults { get; set; }
        public DbSet<RoundResult> RoundResults { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Player>(entity => {
                entity.ToTable("Player");
            });
            builder.Entity<Category>(entity => {
                entity.ToTable("Category");
            });
            builder.Entity<Letter>(entity => {
                entity.ToTable("Letter");
            });
            builder.Entity<Word>(entity => {
                entity.ToTable("Word");
            });
            builder.Entity<Answer>(entity => {
                entity.ToTable("Answer");
            });
            builder.Entity<PlayerSession>(entity => {
                entity.ToTable("PlayerSession");
            });
            builder.Entity<Round>(entity => {
                entity.ToTable("Round");
            });
            builder.Entity<Turn>(entity => {
                entity.ToTable("Turn");
            });
            builder.Entity<Session>(entity => {
                entity.ToTable("Session");
            });
            builder.Entity<RoundCategory>(entity => {
                entity.ToTable("RoundCategory");
            });
            builder.Entity<WordCategory>(entity => {
                entity.ToTable("WordCategory");
            });
            builder.Entity<SessionResult>(entity => {
                entity.ToTable("SessionResult");
            });
            builder.Entity<RoundResult>(entity => {
                entity.ToTable("RoundResult");
            });
        }
    }
}
