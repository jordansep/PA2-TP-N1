using System;
using TaskFlow.Services;

// Instanciar el servicio
var service = new TaskItemService();

// Obtener la lista de tareas
var tasks = service.ListTask();

Console.WriteLine("=== LISTA DE TAREAS ===");
foreach (var task in tasks)
{
    Console.WriteLine($"[{task.Id}] {(task.IsCompleted ? "[X]" : "[ ]")} {task.Title}: {task.Description}");
}
