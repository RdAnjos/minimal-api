using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Entidades; //buscando do meu projeto API

[TestClass]
public class AdministradorServicoTest
{

    private DbContexto CriarContextoDeTeste()
    {

        //Fizemos isso pois, no momento de execucao esta pegando o appsettings.json da pasta de Prod.
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", "..")); 

        var builder = new ConfigurationBuilder()
        .SetBasePath(path ?? Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }

    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // Act
        administradorServico.Incluir(adm);

        // Assert
        Assert.AreEqual(1, administradorServico.Todos(1).Count());
    }


    [TestMethod]
    public void TestandoBuscaPorId()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // Act
        administradorServico.Incluir(adm);
        var admDoBanco = administradorServico.BuscaPorId(adm.Id);

        // Assert
        Assert.AreEqual(1, admDoBanco?.Id);
    }

}