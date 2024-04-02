using System.ComponentModel.DataAnnotations;

namespace RegistroDeJogadores.DTOs;

public class JogadorDTO
{
    public int JogadorId { get; set; }

    [Required]
    public string? Nome { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime? Nascimento { get; set; }

    [Required]
    [StringLength(40)]
    public string? TipoDeContrato { get; set; }

    public DateTime? Publicacao { get; set; } = DateTime.Now;

    public int ClubeId { get; set; }
}
