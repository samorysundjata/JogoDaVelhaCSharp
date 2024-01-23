using System.Runtime.CompilerServices;

namespace JogoDaVelhaCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {

            JogoDaVelha();            
        }


        private static void JogoDaVelha()
        {
            var parada = new Jogo();
            parada.Jogada();
        }
    }
}