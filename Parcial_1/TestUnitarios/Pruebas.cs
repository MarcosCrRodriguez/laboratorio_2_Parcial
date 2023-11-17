using Entidades;
using ExcepcionesPropias;
using Archivos;
using System.Diagnostics;

namespace TestUnitarios
{
    [TestClass]
    public class Pruebas
    {
        [TestMethod]
        [ExpectedException(typeof(SqlExceptionDuplicateUserDB))]
        public void GuardarRegistro_CuandoRegistroUnOperarioConUnDNIExistente_DeberiaLanzarSqlExceptionDuplicateUserDB()
        {
            IUsuario<Operario> manejadorUsuario = new OperarioDAO<Operario>();

            //Arrange
            Operario operario = new Operario("Escalabrini", "Ortiz", 0, "Operario", 42225555, "esc_ortiz@gmail.com", 45, DateTime.Now, "Calle None 123", "4123-1234");

            //Act
            bool actual = manejadorUsuario.GuardarRegistro(operario);
        }

        [TestMethod]
        [ExpectedException(typeof(SqlExceptionDuplicateUserDB))]
        public void GuardarRegistro_CuandoRegistroUnSupervisorConUnDNIExistente_DeberiaLanzarSqlExceptionDuplicateUserDB()
        {
            IUsuario<Supervisor> manejadorUsuario = new SupervisorDAO<Supervisor>();

            //Arrange
            Supervisor supervisor = new Supervisor("Napoleon", "Bonaparte", 0, "Supervisor", 42225555, "napoleon_b@gmail.com", 57, DateTime.Now, "Calle None 456", "7890-4567");

            //Act
            bool actual = manejadorUsuario.GuardarRegistro(supervisor);
        }

        [TestMethod]
        public void VerificarExisteSupervisor_CuandoIngresoUnSupervisorEnElSistema_DeberiaDevolverUnTrue()
        {
            //Arrange
            bool expected = true;
            Supervisor supervisor = new Supervisor("Marcos", "Rodriguez", 1000, "Supervisor", 42225555);

            //Act
            bool actual = supervisor.VerificarExisteSupervisor(SupervisorDAO<Supervisor>.LeerSupervisores("Supervisor"), supervisor);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void ValidarPasswordOperario_PasamosElPasswordIngresadoYElOperario_DeberiaLanzarInvalidPasswordException()
        {
            //Arrange
            Operario operario = new Operario("Brandon", "Sanderson", 1001, "Operario", 12121212);

            //Act
            operario.ValidarPasswordOperario("password", operario);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void ValidarPasswordSupervisor_PasamosElPasswordIngresadoYElSupervisor_DeberiaLanzarInvalidPasswordException()
        {
            //Arrange
            Supervisor supervisor = new Supervisor("Marcos", "Rodriguez", 1000, "Supervisor", 42225555);

            //Act
            supervisor.ValidarPasswordSupervisor("password", supervisor);
        }

        [TestMethod]
        public void Modificar_ModificamosLosDatosDeUnOperario_DeberiaDevolverUnTrue()
        {
            //Arrange
            bool expected = true;
            Operario operario = new Operario("Brandon", "Sanderson", 1056, "Operario", 12121313, "brandonsanderson@gmail.com", new Random().Next(18, 60), DateTime.Now, $"Calle None {new Random().Next(100, 2700)}", $"{new Random().Next(1000, 9999)}-{new Random().Next(1000, 9999)}");

            //Act
            bool actual = SupervisorDAO<Supervisor>.ModificarUsuario(operario);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(9)]
        [DataRow(99)]
        [DataRow(999)]
        public void VerificarExisteID_VerificamosQueElOperarioExistaEnLaDB_DeberiaDevolverUnFalse(int id)
        {
            //Arrange
            bool expected = false;

            //Act
            bool actual = Operario.VerificarExisteID(OperarioDAO<Operario>.LeerOperariosDatosCompletos("Operario"), id);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(9)]
        [DataRow(99)]
        [DataRow(999)]
        public void Eliminar_CuandoQuieroEliminarUnOperarioDeLaDBQueNoExiste_DeberiaDevolverUnFalse(int id)
        {
            //Arrange
            bool expected = false;

            //Act
            bool actual = SupervisorDAO<Supervisor>.Eliminar("Operario", id);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("CIRCUITO_ELECTRONICO")]
        [DataRow("CIRCUITO_ELECTRONICO_AVANZADO")]
        [DataRow("UNIDAD_PROCESAMIENTO")]
        [DataRow("BARRA_PLASTICA")]
        [DataRow("CABLE_VERDE")]
        [DataRow("CABLE_ROJO")]
        [DataRow("BARA_HIERRO")]
        [DataRow("ENGRANAJE_HIERRO")]
        [DataRow("FIBRAS_VIDRIO")]
        [DataRow("CONDENSADOR")]
        [DataRow("VENTILADOR")]
        public void ModificarStock_ModificamosLosDatosDelStock_DeberiaDevolverUnTrue(string material)
        {
            //Arrange
            IMateriales gestorMateriales = new StockDAO();
            bool expected = true;
            int id = 1077;

            //Act
            int cantidadAgregar = Stock.VerificarValorPositivo(1500, id, material);
            bool actual = gestorMateriales.Modificar(material, cantidadAgregar, id);

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}