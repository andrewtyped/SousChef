using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SousChef.Data.Models
{
    public partial class SousChefDbContext : DbContext
    {
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        public virtual DbSet<RecipeInstruction> RecipeInstruction { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SousChefDbContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options to configure the context with. This allows us to, for example, inject a connection string instead of 
        /// hard-coding it or performing other gymnastics in <see cref="OnConfiguring(DbContextOptionsBuilder)"/>.
        /// </param>
        public SousChefDbContext(DbContextOptions<SousChefDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("recipe", "cook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.ToTable("recipe_ingredient", "cook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Ingredient)
                    .IsRequired()
                    .HasColumnName("ingredient")
                    .HasMaxLength(256);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal")
                    .HasDefaultValueSql("0.0");

                entity.Property(e => e.RawText)
                    .IsRequired()
                    .HasColumnName("raw_text")
                    .HasMaxLength(256);

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasColumnName("unit")
                    .HasMaxLength(32)
                    .HasDefaultValueSql("N''");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredient)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_recipe_ingredient_recipe_id");
            });

            modelBuilder.Entity<RecipeInstruction>(entity =>
            {
                entity.ToTable("recipe_instruction", "cook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Instruction)
                    .IsRequired()
                    .HasColumnName("instruction")
                    .HasMaxLength(2048);

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeInstruction)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_recipe_instruction_recipe_id");
            });
        }
    }
}