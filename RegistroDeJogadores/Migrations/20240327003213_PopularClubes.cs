using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDeJogadores.Migrations
{
    /// <inheritdoc />
    public partial class PopularClubes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Clubes(Nome,Sede,Presidente) Values('Vasco Da Gama', 'Rio de Janeiro', 'Pedrinho')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Clubes");
        }
    }
}
