using ClubDeportivoAPI.Dtos.SocioDtos;
using ClubDeportivoAPI.Helpers;
using ClubDeportivoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClubDeportivoAPI.Interfaces
{
    public interface ISocioRepository
    {
        Task<List<Socio>> GetAllSociosAsync();
        Task<Socio?> GetSocioByIdAsync(int id);
        Task<Socio?> CreateSocioAsync(Socio socio);
        Task<SocioDto?> UpdateSocioByIdAsync(int id, UpdateSocioRequestDto updateDto);
        Task<Socio?> DeletSocioByIdAsync(int id);
        Task<List<Socio>?> GetAllSociosByName(SocioQO socio);
    }
}
