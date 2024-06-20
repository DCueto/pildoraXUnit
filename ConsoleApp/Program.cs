
using ConsoleApp.Calculator;

Console.WriteLine("Ingrese un número:");
int num1 = int.Parse( Console.ReadLine() );

Console.WriteLine("Ingrese un número:");
int num2 = int.Parse( Console.ReadLine() );

Calculator calculator = new Calculator();
Console.WriteLine($"El resultado de la suma de { num1 } y { num2 } és: ");
Console.WriteLine($"Total: { calculator.Sum(num1, num2) }");