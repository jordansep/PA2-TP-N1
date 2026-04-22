using FluentAssertions;
using TaskFlow.Models;
using TaskFlow.Services;
using Xunit;

namespace TaskFlow.Tests;

/// <summary>
/// Proporciona pruebas unitarias para la clase <see cref="TaskItemService"/>.
/// </summary>
public class TaskServiceTests
{
    private readonly TaskItemService _service;

    public TaskServiceTests()
    {
        _service = new TaskItemService();
    }

    /// <summary>
    /// Valida que una tarea se cree correctamente y se agregue a la lista.
    /// </summary>
    [Fact]
    public void CreateTask_ShouldAddTaskToList_WhenDataIsValid()
    {
        // Arrange
        var title = "Test Task";
        var description = "Description";
        var responsible = "QA";

        // Act
        _service.CreateTask(title, description, responsible);
        var tasks = _service.ListTasks();

        // Assert
        tasks.Should().HaveCount(1);
        tasks[0].Title.Should().Be(title);
        tasks[0].Description.Should().Be(description);
        tasks[0].Responsible.Should().Be(responsible);
        tasks[0].Status.Should().Be(TaskStatus.ToDo);
    }

    /// <summary>
    /// Valida que el estado de una tarea se actualice correctamente.
    /// </summary>
    [Fact]
    public void UpdateTaskStatus_ShouldUpdateStatusAndUpdatedAt_WhenTaskExists()
    {
        // Arrange
        _service.CreateTask("Task 1", "Responsible 1");
        var task = _service.ListTasks()[0];
        var newStatus = TaskStatus.InProgress;

        // Act
        _service.UpdateTaskStatus(task.Id, newStatus);

        // Assert
        task.Status.Should().Be(newStatus);
        task.UpdatedAt.Should().NotBeNull();
    }

    /// <summary>
    /// Valida que se lance una excepción cuando se intenta actualizar una tarea inexistente.
    /// </summary>
    [Fact]
    public void UpdateTaskStatus_ShouldThrowArgumentException_WhenTaskDoesNotExist()
    {
        // Arrange
        var invalidId = 999;

        // Act
        var action = () => _service.UpdateTaskStatus(invalidId, TaskStatus.Done);

        // Assert
        action.Should().Throw<ArgumentException>().WithMessage("Tarea no encontrada.");
    }
}
