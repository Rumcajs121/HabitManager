using BuildingBlocks.AbstractionDDD;

namespace HabitManager.Entities.Habit;

public class Habit : AggregateRoot<HabitId>
{
    private Habit()
    {
    }

    public string Title { get; private set; }
    public string? Description { get; private set; }
    public string UserId { get; private set; }
    public string Purpose { get; private set; }
    private readonly List<DayStatus> _dayStatuses = new();
    public IReadOnlyList<DayStatus> DayStatuses => _dayStatuses.AsReadOnly();

    public static Habit Create(string title, string? description, string userId, string purpose,
        List<DayStatus>? dayStatuses = null)
    {
        //TODO: Create new DomainExceptions and sercure all property when we to apss on a method
        var habit = new Habit
        {
            Id = HabitId.Of(Guid.NewGuid()),
            CreateTime = DateTime.UtcNow,
            CreatedBy = "XYZ", //TODO: Read with JWTToken
            Title = title,
            Description = description,
            UserId = userId,
            Purpose = purpose
        };
        if (dayStatuses is not null)
        {
            foreach (var dayStatus in dayStatuses)
            {
                habit.AddDayStatus(dayStatus);
            }
        }
        habit.Touch();
        return habit;
    }

    public void ChangePurpose(string purpose)
    {
        Purpose = purpose;
        Touch();
    }

    public void ChangeTitle(string title)
    {
        Title = title;
        Touch();
    }

    public void ChangeDescription(string? description)
    {
        Description = description;
        Touch();
    }

    public void AddDayStatus(DayStatus dayStatus)
    {
        _dayStatuses.Add(dayStatus);
        Touch();
    }

    private void Touch()
    {
        LastModified = DateTime.UtcNow;
        LastModifiedBy = "XYZ";
    }
}