namespace MinimalApi.Dominio.Entidades; //buscando do meu projeto API

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropiedades()
    {
        // Arrange
        var veiculos = new Veiculo();

        // Act
        veiculos.Id = 1;
        veiculos.Nome = "308";
        veiculos.Marca = "Peugeot";
        veiculos.Ano = 2014;

        // Assert
        Assert.AreEqual(1,veiculos.Id);
        Assert.AreEqual("308",veiculos.Nome);
        Assert.AreEqual("Peugeot",veiculos.Marca);
        Assert.AreEqual(2014,veiculos.Ano);

    }
}