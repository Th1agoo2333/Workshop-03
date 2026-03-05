char opcion;

do
{
    Console.Write("Ingrese la viga: ");
    string? viga = Console.ReadLine();

    bool malConstruida = false;
    int pesoTotal = 0;
    int contador = 0;
    int resistencia = 0;
    char anterior = ' ';

    if (string.IsNullOrEmpty(viga))
    {
        malConstruida = true;
    }
    else
    {
        char baseViga = viga[0];

        if (baseViga == '%')
            resistencia = 10;
        else if (baseViga == '&')
            resistencia = 30;
        else if (baseViga == '#')
            resistencia = 90;
        else
            malConstruida = true;

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
                    malConstruida = true;
                    break;
                }

                anterior = actual;
            }
        }
    }

    if (malConstruida)
    {
        Console.WriteLine("La viga está mal construida!");
    }
    else
    {
        if (pesoTotal <= resistencia)
            Console.WriteLine("La viga soporta el peso!");
        else
            Console.WriteLine("La viga NO soporta el peso!");
    }

    Console.Write("¿Desea salir? (Y/N): ");
    opcion = Console.ReadLine()!.ToUpper()[0];

} while (opcion != 'Y');