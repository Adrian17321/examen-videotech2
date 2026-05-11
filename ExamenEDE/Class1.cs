using System;

public class Class1
{
	public Class1()
	{
        static void Main(string[] args)
        {

            List<Pelicula> lista = new List<Pelicula>();
            lista.Add(new Pelicula("Interstellar", "Christopher Nolan", 2014, true));
            lista.Add(new Pelicula("El Padrino", "Francis Ford Coppola", 1972, false));
            lista.Add(new Pelicula("Origen", "Christopher Nolan", 2010, true));

            Console.WriteLine("--- TODAS LAS PELÍCULAS ---");
            [cite_start] foreach (Pelicula p in lista) 
            
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("\n--- PELÍCULAS DE NOLAN ---");
            foreach (Pelicula p in lista)
            {
                [cite_start] if (p.getDirector().Contains("Nolan"))
                {
                    Console.WriteLine(p.ToString());
                }
            }

            Console.WriteLine("\n--- FECHA DE REGISTRO ---");
        Console.WriteLine(DateTime.Now.ToShortDateString());

            GuardarPeliculas(lista, "videoteca.txt");

            Console.WriteLine("\nProceso terminado. Presione una tecla...");
            Console.ReadKey();
        }

        static void GuardarPeliculas(List<Pelicula> lista, string ruta)
        {
            StreamWriter salida = File.CreateText(ruta); 

            foreach (Pelicula p in lista)
            {
                salida.WriteLine(p.getTitulo() + ";" + p.getDirector() + ";" + p.getAnyo() + ";" + p.isDisponible());
            }

            salida.Close();
        }
    }
}

}
