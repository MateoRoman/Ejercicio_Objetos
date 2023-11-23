using System;

// Interfaz para mostrar información
public interface IMostrarInformacion
{
    void MostrarInformacion();
}

// Clase base Empleado
public class Empleado : IMostrarInformacion
{
    // Atributos
    public string Nombre { get; set; }
    public double Salario { get; set; }

    // Constructor
    public Empleado(string nombre, double salario)
    {
        Nombre = nombre;
        Salario = salario;
    }

    // Método para calcular el salario anual
    public virtual double CalcularSalarioAnual()
    {
        return Salario * 12;
    }

    // Implementación de la interfaz
    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Salario: {Salario}");
    }
}

// Clase derivada Gerente
public class Gerente : Empleado, IMostrarInformacion
{
    // Nuevo atributo para el departamento que supervisa
    public string Departamento { get; set; }

    // Constructor
    public Gerente(string nombre, double salario, string departamento) : base(nombre, salario)
    {
        Departamento = departamento;
    }

    // Método para calcular el salario anual (sobrescribe el método de la clase base)
    public override double CalcularSalarioAnual()
    {
        // Puedes personalizar la lógica de cálculo para un gerente si es necesario
        return Salario * 12 + 5000; // Agregando un bono arbitrario para el ejemplo
    }

    // Implementación de la interfaz (sobrescribe el método de la interfaz)
    public new void MostrarInformacion()
    {
        base.MostrarInformacion(); // Llama al método de la clase base
        Console.WriteLine($"Departamento: {Departamento}");
    }
}

class Program
{
    static void Main()
    {
        // Ejemplo de uso
        Empleado empleado = new Empleado("Juan", 30000);
        Gerente gerente = new Gerente("Ana", 50000, "Ventas");

        Console.WriteLine("Información del Empleado:");
        empleado.MostrarInformacion();
        Console.WriteLine($"Salario Anual: {empleado.CalcularSalarioAnual()}");

        Console.WriteLine("\nInformación del Gerente:");
        gerente.MostrarInformacion();
        Console.WriteLine($"Salario Anual: {gerente.CalcularSalarioAnual()}");
    }
}