using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;

namespace MinimalApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    // O '?' informar que posso retornar NULL
    Administrador? Login(LoginDTO loginDTO);
}
