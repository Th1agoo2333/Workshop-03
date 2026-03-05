char opcion;

do
{
    Console.Write("Ingrese ubicación de los caballos: ");
    string? entrada = Console.ReadLine();

    if (string.IsNullOrEmpty(entrada))
    {
        Console.WriteLine("Entrada inválida");
    }
    else
    {
        string[] caballos = entrada.Split(',');

        for (int i = 0; i < caballos.Length; i++)
        {
            string caballo1 = caballos[i];

            int col1 = caballo1[0] - 'A' + 1;
            int fila1 = int.Parse(caballo1[1].ToString());

            Console.Write("Analizando Caballo en " + caballo1 + " => ");

            bool conflicto = false;

            for (int j = 0; j < caballos.Length; j++)
            {
                if (i == j) continue;

                string caballo2 = caballos[j];

                int col2 = caballo2[0] - 'A' + 1;
                int fila2 = int.Parse(caballo2[1].ToString());

                int df = Math.Abs(fila1 - fila2);
                int dc = Math.Abs(col1 - col2);

                if ((df == 2 && dc == 1) || (df == 1 && dc == 2))
                {
                    Console.Write("Conflicto con " + caballo2 + " ");
                    conflicto = true;
                }
            }

            if (!conflicto)
            {
                Console.Write("Sin conflicto");
            }

            Console.WriteLine();
        }
    }

    Console.Write("¿Desea salir? (Y/N): ");
    opcion = Console.ReadLine()!.ToUpper()[0];

} while (opcion != 'Y');