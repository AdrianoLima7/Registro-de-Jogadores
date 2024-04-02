using RegistroDeJogadores.Models;

namespace RegistroDeJogadores.DTOs.Mappings;

public static class ClubeDTOMappingExtensions
{
    public static ClubeDTO? ToClubeDTO(this Clube clube)
    {
        if (clube is null)
        {
            return null;
        }

        return new ClubeDTO
        {
            ClubeId = clube.ClubeId,
            Nome = clube.Nome,
            Sede = clube.Sede,
            Presidente = clube.Presidente
        };
    }

    public static Clube? ToClube(this ClubeDTO clubeDto)
    {
        if (clubeDto is null)
        {
            return null;
        }

        return new Clube
        {
            ClubeId = clubeDto.ClubeId,
            Nome = clubeDto.Nome,
            Sede = clubeDto.Sede,
            Presidente = clubeDto.Presidente
        };
    }

    public static IEnumerable<ClubeDTO> ToClubeDTOList(this IEnumerable<Clube> clubes)
    {
        if (clubes is null || !clubes.Any())
        {
            return new List<ClubeDTO>();
        }

        return clubes.Select(clube => new ClubeDTO
        {
            ClubeId = clube.ClubeId,
            Nome = clube.Nome,
            Sede = clube.Sede,
            Presidente= clube.Presidente
        }).ToList();
    }
}
