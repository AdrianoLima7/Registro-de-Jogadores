using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RegistroDeJogadores.Models;

[Table("Jogadores")]
public class Jogador
{
    [Key]
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

    [JsonIgnore]
    public Clube? Clube { get; set; }
}
