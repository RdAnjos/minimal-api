using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Entidades; //buscando do meu projeto API

[TestClass]
public class AdministradorServicoTest
{

    private DbContexto CriarContextoDeTeste()
    {
        var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables();

        var configuration = builder.Build();

        //Obter a string de conexao
        var connectionString = configuration.GetConnectionString("MySql");

        //Configurar o DbcontextOptionsBuilder
        var options = new DbContextOptionsBuilder<DbContexto>()
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .Options;

        return new DbContexto(options);
    }

    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        // Arrange
        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "Teste@teste.com";
        adm.Senha = "Teste@123";
        adm.Perfil = "Adm";

        // Act

        var context = CriarContextoDeTeste();

        // Assert
        Assert.AreEqual(1,adm.Id);
        Assert.AreEqual("Teste@teste.com",adm.Email);
        Assert.AreEqual("Teste@123",adm.Senha);
        Assert.AreEqual("Adm",adm.Perfil);

    }
}