using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConoceAColombia.Test
{
    [TestClass]
    public class clsPrueba
    {
        [TestMethod]
        public void verificar_suma()
        {
            //Arrange instancias de objetos
            logica.BL.clsSuma obclsSuma = new logica.BL.clsSuma();
            //Act
            int result = obclsSuma.getSuma(5,9);
            //Assert lo que espero que se cumpla
            Assert.AreEqual(14,result);
        }
        [TestMethod]
        public void verficar_TipodeArquitectura()
        {
            //Arrange 
            logica.BL.clsTipodeArquitectura obclsTipodeArquitectura = new logica.BL.clsTipodeArquitectura();
            logica.Models.clsTipodeArquitectura obclsTipodeArquitecturaModels = new logica.Models.clsTipodeArquitectura {
                lgCodigo = 5,
                stDescripcion = "Leonardo "
            
            };
            //Act 
            string mensaje = obclsTipodeArquitectura.setAdministrarTiposdeArquitectura(obclsTipodeArquitecturaModels,1);
            //Assert 
            Assert.AreEqual("Se realizo proceso con exito",mensaje);
        }
        [TestMethod]
        public void verificar_Arquitectura()
        {
            //Arrange
            logica.BL.clsArquitectura obclsArquitectura = new logica.BL.clsArquitectura();
            logica.Models.clsArquitectura obclsArquitecturaModels = new logica.Models.clsArquitectura
            {
                lgCodigo = 20,
                stNombre = "Prueba",
                stCiudad = "Cali",
                stLatitud = "121212",
                stLongitud = "1121212",
                clsDepartamentos = new logica.Models.clsDepartamentos { inCodigo=1},
                clsTipodeArquitectura = new logica.Models.clsTipodeArquitectura { lgCodigo=1}
            };
            //act
            string mensaje = obclsArquitectura.setAdministrarArquitectura(obclsArquitecturaModels, 1);
            //Assert
            Assert.AreEqual("Se realizo proceso con exito", mensaje);
        }
    }
}
