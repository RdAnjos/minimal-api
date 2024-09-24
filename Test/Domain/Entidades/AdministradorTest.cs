namespace MinimalApi.Dominio.Entidades; //buscando do meu projeto API

[TestClass]
public class AdministradorTest
{
    [TestMethod]
    public void TestarGetSetPropiedades()
    {
        // Arrange
        var adm = new Administrador();

        // Act
        adm.Id = 1;
        adm.Email = "Teste@teste.com";
        adm.Senha = "Teste@123";
        adm.Perfil = "Adm";

        // Assert
        Assert.AreEqual(1,adm.Id);
        Assert.AreEqual("Teste@teste.com",adm.Email);
        Assert.AreEqual("Teste@123",adm.Senha);
        Assert.AreEqual("Adm",adm.Perfil);

    }
}