using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RegistroDeJogadores.Models;

[Table("Clubes")]
public class Clube
{
    [Key]
    public int ClubeId { get; set; }

    [Required]
    public string? Nome { get; set;}

    [Required]
    public string? Sede { get; set;}

    public string? Presidente { get; set;}

    
    public ICollection<Jogador>? Jogadores { get; set; } = new Collection<Jogador>();
}
