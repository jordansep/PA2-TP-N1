using TaskFlow.Models;
using TaskFlow.Services;

public class ConsoleHelper
{
    private readonly TaskItemService _service;

    public ConsoleHelper(TaskItemService service)
    {
        _service = service;
    }
    // Todo: Implementar un metodo para evitar tantos console.writeline asi hacer mas facil su modificacion en futuro, por ejemplo un metodo que reciba un string[] con las opciones y las imprima en formato de menu
    public void StartApp()
    {
        // Inicializamos la aplicacion y mostramos el menú principal
        bool exit = false;
        while (!exit)
        {
        Console.Clear();
        Console.WriteLine("=============================");
        Console.WriteLine("       🚀 TASKFLOW 🚀      ");
        Console.WriteLine("=============================");
        Console.WriteLine("1. Ver lista de tareas");
        Console.WriteLine("2. Crear nueva tarea (Completa)");
        Console.WriteLine("3. Salir");
        Console.WriteLine("=============================");
        Console.Write("Seleccione una opción: ");
    
        string? option = Console.ReadLine();
    
    // Procesamos la opción seleccionada por el usuario
        switch (option)
        {
            case "1":
                ShowListOfTasks();
                break;
            case "2":
                CreateTaskFromConsole();
                break;
            case "3":
                exit = true;
                Console.WriteLine("Saliendo de TaskFlow... ¡Hasta luego!");
                break;
            default:
                Console.WriteLine("Opción no válida. Presione cualquier tecla para intentar de nuevo...");
                Console.ReadKey();
                break;
            }
        }
    }
    public void EndApp(){}
    private void CreateTaskFromConsole()
    {
        // Método para crear una tarea a través de la consola, solicitando título, descripción y responsable
          Console.Clear();
        Console.WriteLine("=== CREAR NUEVA TAREA ===");
    
            Console.Write("Título: ");
            string title = ValidateTaskInput(Console.ReadLine(), "título");

            Console.Write("Descripción: ");
            string description = Console.ReadLine() ?? string.Empty;

            Console.Write("Responsable: ");
            string responsible = ValidateTaskInput(Console.ReadLine(), "responsable");


        _service.CreateTask(title, description, responsible);
    
        Console.WriteLine("\n¡Tarea creada con éxito! Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }
    public string ValidateTaskInput(string input, string fieldName)
    {
        // Método para validar la entrada del usuario al crear una tarea, asegurándose de que el título no esté vacío y que el responsable sea válido
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine($"El {fieldName} no puede estar vacío. Por favor, ingrese un {fieldName} válido.");
            Console.Write($"{fieldName}: ");
            input = Console.ReadLine();
        }
        return input;

    }
    public void SelectTask()
    {
       
    }
    public void ShowListOfTasks(){
        // Método para mostrar la lista de tareas en la consola, incluyendo título, responsable y estado
         Console.Clear();
        Console.WriteLine("=== LISTA DE TAREAS ===");
        
        List<TaskItem> tasks = _service.ListTasks();
        
        // Si no hay tareas, mostramos un mensaje indicando que no hay tareas registradas
        if (tasks.Count == 0)
        {
            Console.WriteLine("No hay tareas registradas en el sistema.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"[{task.Id}] {task.Title} | Resp: {task.Responsible} | Estado: {task.Status}");
                if (!string.IsNullOrEmpty(task.Description))
                {
                    Console.WriteLine($"    Descripción: {task.Description}");
                }
                Console.WriteLine("------------------------------------------------");
            }
        }
    
        Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
        Console.ReadKey();
    }
    public static void UpdateTaskStatusFromConsole(){}

}