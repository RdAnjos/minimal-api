using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Entidades; //buscando do meu projeto API

[TestClass]
public class VeiculoServicoTest
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
    public void TestandoIncluirVeiculo()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE veiculos");

        var vei = new Veiculo();
        vei.Marca= "Hyundai";
        vei.Nome= "Tucson";
        vei.Ano= 2022;

        var veiculoServico = new VeiculoServico(context);

        // Act
        veiculoServico.Incluir(vei);

        // Assert
        Assert.AreEqual(1, veiculoServico.Todos(1).Count());
    }

    
    [TestMethod]
    public void TestandoBuscaPorId()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE veiculos");

        var veiculo = new Veiculo();
        veiculo.Nome = "Logan";
        veiculo.Marca = "Renault";
        veiculo.Ano = 2018;

        var veiculoServico = new VeiculoServico(context);

        // Act
        veiculoServico.Incluir(veiculo);
        var admDoBanco = veiculoServico.BuscaPorId(veiculo.Id);

        // Assert
        Assert.AreEqual(1, admDoBanco?.Id);
    }
    

}