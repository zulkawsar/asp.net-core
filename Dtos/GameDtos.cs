using System.ComponentModel.DataAnnotations;

namespace Games.Dtos
{
    public record GameDtos
    (
        int Id,
        string Name,
        string Genre,
        decimal Price,
        DateTime ReleaseDate
    );

    public record CreateGameDtos
    (
        
        [Required] string Name,
        string Genre,
        decimal Price,
        DateTime ReleaseDate
    );
}
