namespace HabitManager.Entities.Habit;

public class DayStatus
{
    public DateOnly Date { get; private set; }
    public DateTime? Time { get; private set; }
    public bool Completed { get; private set; }
    public string? Note { get; private set; }

    public static DayStatus Create(DateOnly date, DateTime? time = null, string? note = null)
    {
        var addDayStatus = new DayStatus
        {
            Date = date,
            Time = time,
            Completed = false,
            Note = string.Empty
        };
        return addDayStatus;
    }

    public void Complete()
    {
        Completed = true;
    }
    public void UnComplete()
    {
        Completed = false;
    }
    
}