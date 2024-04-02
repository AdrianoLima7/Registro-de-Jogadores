using System.ComponentModel.DataAnnotations;

namespace RegistroDeJogadores.DTOs;

public class ClubeDTO
{
    public int ClubeId { get; set; }

    [Required]
    public string? Nome { get; set; }

    [Required]
    public string? Sede { get; set; }

    public string? Presidente { get; set; }
}
