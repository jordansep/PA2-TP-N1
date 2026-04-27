using TaskFlow.Models;
using TaskFlow.Services;

public class ConsoleHelper
{
    private readonly TaskItemService _service;

    public ConsoleHelper(TaskItemService service)
    {
        _service = service;
    }

    public static void StartApp()
    {
        
    }
    public static void EndApp(){}
    public static TaskItem CreateTaskFromConsole()=> new TaskItem();
    public static void SelectTask(){}
    public static void ShowListOfTasks(){}
    public static void UpdateTaskStatusFromConsole(){}

}