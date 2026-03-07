namespace Excercise37;

class Program
{
    static int[,] ?tablero;
    static int[,] ?posiciones;
    static int tope;

    static void Main(string[] args)
    {
        char continuar = 'Y';

        do
        {
            tablero = new int[8, 8];
            posiciones = new int[64, 2];
            tope = 0;

            Console.WriteLine("\n--- KNIGHT CONFLICT ANALYZER ---");
            Console.Write("Enter knights' locations (e.g., B7, C5, E2): ");

            string entrada = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(entrada))
            {
                string[] ubicaciones = entrada.Split(',');
                bool datosValidos = true;

                foreach (string ubica in ubicaciones)
                {
                    string dato = ubica.Trim();

                    if (dato.Length == 2)
                    {
                        int c = EquivalenteColumna(dato[0]);
                        int f = EquivalenteFila(dato[1]);

                        if (f != -1 && c != -1)
                        {
                            tablero[f, c] = 1;
                            posiciones[tope, 0] = f;
                            posiciones[tope, 1] = c;
                            tope++;
                        }
                        else
                        {
                            datosValidos = false;
                            break;
                        }
                    }
                    else
                    {
                        datosValidos = false;
                        break;
                    }
                }

                if (!datosValidos || tope == 0)
                {
                    Console.WriteLine("Error: Invalid format.");
                }
                else
                {
                    for (int i = 0; i < tope; i++)
                    {
                        int fActual = posiciones[i, 0];
                        int cActual = posiciones[i, 1];

                        string nombre = $"{(char)EquivalenteFilaInversa(fActual)}{(char)EquivalenteColumnaInversa(cActual)}";
                        Console.Write($"Analyzing Knight at {nombre} => ");

                        // 8 possible L-shaped moves for a knight
                        int[] df = { -2, -2, -1, 1, 2, 2, 1, -1 };
                        int[] dc = { -1, 1, 2, 2, 1, -1, -2, -2 };

                        for (int m = 0; m < 8; m++)
                        {
                            int nf = fActual + df[m];
                            int nc = cActual + dc[m];

                            // Check board boundaries
                            if (nf >= 0 && nf < 8 && nc >= 0 && nc < 8)
                            {
                                if (tablero[nf, nc] == 1)
                                {
                                    string cConflicto = $"{(char)EquivalenteFilaInversa(nf)}{(char)EquivalenteColumnaInversa(nc)}";
                                    Console.Write($"Conflict with {cConflicto}   ");
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Error: Empty input.");
            }

            bool respuestaValida = false;
            do
            {
                Console.Write("\nDo you want to continue? (Y/N): ");
                string respuesta = (Console.ReadLine() ?? "").Trim().ToUpper();

                if (respuesta == "Y" || respuesta == "N")
                {
                    continuar = respuesta[0];
                    respuestaValida = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                }
            } while (!respuestaValida);

        } while (continuar == 'Y');

        Console.WriteLine("Program terminated.");
    }

    // Mapping functions

    static int EquivalenteFila(char f)
    {
        switch (f)
        {
            case '8': return 0;
            case '7': return 1;
            case '6': return 2;
            case '5': return 3;
            case '4': return 4;
            case '3': return 5;
            case '2': return 6;
            case '1': return 7;
            default: return -1;
        }
    }

    static int EquivalenteColumna(char c)
    {
        c = char.ToLower(c);
        if (c >= 'a' && c <= 'h') return c - 'a';
        return -1;
    }

    static int EquivalenteFilaInversa(int f)
    {
        switch (f)
        {
            case 0: return '8';
            case 1: return '7';
            case 2: return '6';
            case 3: return '5';
            case 4: return '4';
            case 5: return '3';
            case 6: return '2';
            case 7: return '1';
            default: return ' ';
        }
    }

    static int EquivalenteColumnaInversa(int c)
    {
        return c + 'A';
    }
}