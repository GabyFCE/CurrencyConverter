using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    internal static class Selector
    {
        public static string monedaOrigen;
        public static string monedaDestino;
        public static string cantidad;
        public static decimal valOri;
        public static decimal valDest;
        public static decimal convers;
        public static void seleccion()
        {
            while (true)
            {
                Console.WriteLine("Eleja entre las siguientes monedas para realizar una conversion:");
                Console.WriteLine("CLP (peso chileno), ARS(peso argentino), USD (dolar), EUR (euro), TRY (lira turca), GBP (lira esterlina)");

                Console.WriteLine("Elija moneda origen");
                monedaOrigen = Console.ReadLine();
                if(monedaOrigen != "CLP" && monedaOrigen != "ARS" && monedaOrigen != "USD" && monedaOrigen != "TRY" && monedaOrigen != "GBP")
                {
                    Console.WriteLine("Moneda incorrecta");
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("Elija moneda destino");
                monedaDestino = Console.ReadLine();
                if (monedaDestino != "CLP" && monedaDestino != "ARS" && monedaDestino != "USD" && monedaDestino != "TRY" && monedaDestino != "GBP")
                {
                    Console.WriteLine("Moneda incorrecta");
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("Elija cantidad");
                cantidad = Console.ReadLine();

                if (!decimal.TryParse(cantidad, out decimal cant))
                {
                    Console.WriteLine("Ingrese un número correcto");
                    Console.Clear();
                    continue;
                }
                conversion(monedaOrigen, monedaDestino, cant, out convers);
                bool resp = Consulta(convers);
                if (resp)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }

        private static void conversion(string monOri, string monDest, decimal cant, out decimal convers)
        {
            switch(monOri)
            {
                case "CLP":
                    valOri = 884;
                    break;
                case "ARS":
                    valOri = 1000;
                    break;
                case "USD":
                    valOri = 1;
                    break;
                case "TRY":
                    valOri = 30;
                    break;
                case "GBP":
                    valOri = 0.80M;
                    break;
            }

            switch (monDest)
            {
                case "CLP":
                    valDest = 884;
                    break;
                case "ARS":
                    valDest = 1000;
                    break;
                case "USD":
                    valDest = 1;
                    break;
                case "TRY":
                    valDest = 30;
                    break;
                case "GBP":
                    valDest = 0.80M;
                    break;
            }

            
            
            convers = (valDest / valOri) * cant;
            Console.WriteLine(convers);

            if (monDest == "CLP" && convers > 884000|| monDest == "CLP" && convers < 884000/2)
            {
                Console.WriteLine("Solo puede operar entre un mínimo equivalente a 500 USD y un máximo equivalente a 1000 USD");
            }
            else if (monDest == "ARS" && convers > 1000000 || monDest == "ARS" && convers < (1000000 / 2))
            {
                Console.WriteLine("Solo puede operar entre un mínimo equivalente a 500 USD y un máximo equivalente a 1000 USD");
            }
            else if (monDest == "USD" && convers > 1000 || monDest == "USD" && convers < (1000 / 2))
            {
                Console.WriteLine("Solo puede operar entre un mínimo equivalente a 500 USD y un máximo equivalente a 1000 USD");
            }
            else if (monDest == "TRY" && convers > 30000 || monDest == "TRY" && convers < 30000 / 2)
            {
                Console.WriteLine("Solo puede operar entre un mínimo equivalente a 500 USD y un máximo equivalente a 1000 USD");
            }
            else if (monDest == "GBP" && convers > 800 || monDest == "GBP" && convers < 800 / 2)
            {
                Console.WriteLine("Solo puede operar entre un mínimo equivalente a 500 USD y un máximo equivalente a 1000 USD");
            }
            else
            {
                Console.WriteLine($"Se ha cambiado {convers} " + monDest);
            }


        }
        private static bool Consulta(decimal convers)
        {
            Console.WriteLine("Desea retirar el dinero? (s/n)");
            string rsp = Console.ReadLine();
            if (rsp == "s")
            {
                Console.Clear();
                Console.WriteLine("Su retiro luego de la comisión es " + (convers - (convers * 0.01M)));
            }

            Console.WriteLine("Desea realizar otra operación de cambio? (s/n)");

            string respuesta = Console.ReadLine();
            if (respuesta == "s")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
