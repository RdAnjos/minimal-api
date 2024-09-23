using System.Data.Common;
using MinimalApi.DTOs;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.Db;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;

    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }
    public Administrador? Login(LoginDTO loginDTO)
    {
        return _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
    }

}
