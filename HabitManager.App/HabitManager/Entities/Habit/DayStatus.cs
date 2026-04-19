namespace HabitManager.Entities.Habit;

public class DayStatus
{
    public DateOnly Date { get; private set; }
    public bool Completed { get; private set; }
    public string? Note { get; private set; }
}