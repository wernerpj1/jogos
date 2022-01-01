using Jogos.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jogos.Infraestruture.Data.Mappings
{
    public class JogoMapping : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.ToTable("TB_JOGO");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome);
            builder.Property(p => p.Descricao);
            builder.Property(p => p.Image);
            builder.Property(p => p.Produtora);
            builder.HasOne(p => p.User)
            .WithMany().HasForeignKey(fk => fk.IdUser);
            builder.Property(p => p.IsExclude);
        }
    }
}