namespace Exercise28;

class Program
{
    static void Main(string[] args)
    {
        char opcion = 'N';

        do
        {
            Console.WriteLine("\n--- BEAM WEIGHT ANALYZER ---");
            Console.Write("Enter the beam structure: ");

            // Handling potential null inputs safely
            string viga = Console.ReadLine() ?? "";

            bool malConstruida = false;
            int pesoTotal = 0;
            int contador = 0;
            int resistencia = 0;
            char anterior = ' ';

            if (string.IsNullOrWhiteSpace(viga))
            {
                malConstruida = true;
            }
            else
            {
                // Base type defines the resistance
                char baseViga = viga[0];

                if (baseViga == '%')
                    resistencia = 10;
                else if (baseViga == '&')
                    resistencia = 30;
                else if (baseViga == '#')
                    resistencia = 90;
                else
                    malConstruida = true;

                // Analyze the rest of the beam
                if (!malConstruida)
                {
                    for (int i = 1; i < viga.Length; i++)
                    {
                        char actual = viga[i];

                        if (actual == '=')
                        {
                            contador++;
                            pesoTotal += contador;
                        }
                        else if (actual == '*')
                        {
                            // Two consecutive '*' make the beam invalid
                            if (anterior == '*')
                            {
                                malConstruida = true;
                                break;
                            }

                            pesoTotal += contador * 2;
                            contador = 0;
                        }
                        else
                        {
                            // Any other character makes it invalid
                            malConstruida = true;
                            break;
                        }

                        anterior = actual;
                    }
                }
            }

            Console.WriteLine("\n--- RESULTS ---");
            if (malConstruida)
            {
                Console.WriteLine("Error: The beam is poorly constructed!");
            }
            else
            {
                Console.WriteLine($"Total Weight: {pesoTotal} | Max Resistance: {resistencia}");

                if (pesoTotal <= resistencia)
                    Console.WriteLine("Success: The beam supports the weight!");
                else
                    Console.WriteLine("Warning: The beam DOES NOT support the weight!");
            }

            // Robust validation for Y/N input to prevent crashes
            bool respuestaValida = false;
            do
            {
                Console.Write("\nDo you want to exit? (Y/N): ");
                string respuesta = (Console.ReadLine() ?? "").Trim().ToUpper();

                if (respuesta == "Y" || respuesta == "N")
                {
                    opcion = respuesta[0];
                    respuestaValida = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                }
            } while (!respuestaValida);

        } while (opcion != 'Y');

        Console.WriteLine("Program terminated.");
    }
}