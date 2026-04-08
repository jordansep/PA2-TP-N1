using System.Collections.Generic;
using TaskFlow.Models;

namespace TaskFlow.Services;

public class TaskItemService
{
    public void CreateTask(string title, string description, string responsible)
    {
        var newTask = new TaskItem
        {
            Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1,
            Title = title,
            Description = description,
            Responsible = responsible,
            Status = TaskStatus.ToDo,
            CreatedAt = DateTime.UtcNow
        };
    }

    private readonly List<TaskItem> _tasks = new List<TaskItem>
    {
        new TaskItem { Id = 1, Title = "Aprender GitFlow", Description = "Comprender cómo usar ramas de feature, develop y main", IsCompleted = false },
        new TaskItem { Id = 2, Title = "Crear la feature de listar", Description = "Implementar ListTask en TaskItemService", IsCompleted = true }
    };

    public IEnumerable<TaskItem> ListTask()
    {
        return _tasks;
    }
}
