using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class V101_DML_INSERT_SEED_PRODUCTS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new string[]{ "Name", "Description", "Price", "Stock", "Image", "CategoryId" },
                values: new object[,] {
                    { "Caderno", "Caderno espiral 100 fôlhas", 7.45, 50, "caderno1.jpg", 1 },
                    { "Estojo escolar", "Estojo escola cinza", 5.56, 70, "estojo1.jpg", 1 },
                    { "Glitter", "Glitter Em Pó 500gr Branco Furta Cor Irisado Pintar Parede Branco Furta Cor Irisado Pintar Parede", 47.08, 90, "glitter.jpg", 1 },
                    { "Caderno Inteligente", "Refil Compatível Caderno Inteligente Grande 200x275mm 300fls", 89.20, 100, "refil.jpg", 2 },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumns: new string[]{"Id"},
                keyValues: new object[,]
                {
                    { "Id" }
                }
           );
        }
    }
}
