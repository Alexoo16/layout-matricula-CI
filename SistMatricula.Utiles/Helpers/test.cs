using System;

namespace SistMatricula.Utiles.Helpers
{
    internal class test
    {
        public static void Main()
        {
            var prueba = new test();
            prueba.TestEncriptarByte();
        }

        public void TestEncriptarByte()
        {
            string textoOriginal = "Texto de prueba";

            // Encriptar el texto
            byte[] textoEncriptado = EncriptacionHelper.EncriptarByte(textoOriginal);

            // Convertir el resultado en bytes a una representación en hexadecimal para mostrarla
            string textoEncriptadoHex = BitConverter.ToString(textoEncriptado).Replace("-", " ");

            Console.WriteLine("Texto original: " + textoOriginal);
            Console.WriteLine("Texto encriptado (hex): " + textoEncriptadoHex);
        }
    }
}
