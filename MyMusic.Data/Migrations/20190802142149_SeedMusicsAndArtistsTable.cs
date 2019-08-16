using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMusic.Data.Migrations
{
    public partial class SeedMusicsAndArtistsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Linkin Park')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Iron Maiden')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Flogging Molly')");
            migrationBuilder
                .Sql("INSERT INTO Artists (Name) Values ('Red Hot Chilli Peppers')");
                
            migrationBuilder
                .Sql("INSERT INTO Musics (Name, ArtistId) Values ('In The End', (SELECT Id FROM Artists WHERE Name = 'Linkin Park'))");
            migrationBuilder
                .Sql("INSERT INTO Musics (Name, ArtistId) Values ('Numb', (SELECT Id FROM Artists WHERE Name = 'Linkin Park'))");
            migrationBuilder
                .Sql("INSERT INTO Musics (Name, ArtistId) Values ('Breaking The Habit', (SELECT Id FROM Artists WHERE Name = 'Linkin Park'))");
            migrationBuilder
                .Sql("INSERT INTO Musics (Name, ArtistId) Values ('Fear of the dark', (SELECT Id FROM Artists WHERE Name = 'Iron Maiden'))");
            migrationBuilder
                .Sql("INSERT INTO Musics (Name, ArtistId) Values ('Number of the beast', (SELECT Id FROM Artists WHERE Name = 'Iron Maiden'))");
            migrationBuilder
                .Sql("INSERT INTO Musics (Name, ArtistId) Values ('The Trooper', (SELECT Id FROM Artists WHERE Name = 'Iron Maiden'))");
            migrationBuilder
                .Sql("INSERT INTO Musics (Name, ArtistId) Values ('What''s left of the flag', (SELECT Id FROM Artists WHERE Name = 'Flogging Molly'))");
            migrationBuilder
                .Sql("INSERT INTO Musics (Name, ArtistId) Values ('Drunken Lullabies', (SELECT Id FROM Artists WHERE Name = 'Flogging Molly'))");
            migrationBuilder
                .Sql("INSERT INTO Musics (Name, ArtistId) Values ('If I Ever Leave this World Alive', (SELECT Id FROM Artists WHERE Name = 'Flogging Molly'))");
            migrationBuilder
                .Sql("INSERT INTO Musics (Name, ArtistId) Values ('Californication', (SELECT Id FROM Artists WHERE Name = 'Red Hot Chilli Peppers'))");
            migrationBuilder
                .Sql("INSERT INTO Musics (Name, ArtistId) Values ('Tell Me Baby', (SELECT Id FROM Artists WHERE Name = 'Red Hot Chilli Peppers'))");
            migrationBuilder
                .Sql("INSERT INTO Musics (Name, ArtistId) Values ('Parallel Universe', (SELECT Id FROM Artists WHERE Name = 'Red Hot Chilli Peppers'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM Musics");

            migrationBuilder
                .Sql("DELETE FROM Artists");
        }
    }
}
