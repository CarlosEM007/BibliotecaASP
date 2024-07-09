namespace Biblioteca.Models;

public class Filtros
{
    public Filtros(int[] filtrosArray)
    {
        if (filtrosArray == null || filtrosArray.Length != 2)
        {
            filtrosArray = new int[] { 0, 0 };
        }

        IdGenero = filtrosArray[0];
        IdAutor = filtrosArray[1];
    }

    public int IdGenero { get; set; }
    public int IdAutor { get; set; }

    public bool TemGenero => IdGenero != 0;
    public bool TemAutor => IdAutor != 0;

}
