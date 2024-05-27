using Cauculadora;

namespace TestProject2
 
{
    public class UnitTest1
    {

        public Calculadora construirClasse()
        {
            string data = "02/06/2024";
            Calculadora calc = new Calculadora("02/06/2024");
            return calc;

        }

        [Theory]
        [InlineData (1,2,3)]
        [InlineData (4,5,9)]
        public void TesteSomar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.somar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(5, 2, 3)]
        [InlineData(14, 5, 9)]
        public void TesteSubtrair(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.subtrair(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(5, 2, 10)]
        [InlineData(14, 5, 70)]
        public void TesteMultiplicar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.multiplicar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(14, 7, 2)]
        public void TesteDividir(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.dividir(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Calculadora calc = construirClasse();

            Assert.Throws<DivideByZeroException>(
                () => calc.dividir(3, 0)
            );
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = construirClasse();

            calc.multiplicar(5, 3);
            calc.somar(5, 3);
            calc.subtrair(5, 3);

            var lista = calc.historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}