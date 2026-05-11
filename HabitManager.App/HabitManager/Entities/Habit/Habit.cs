using BuildingBlocks.AbstractionDDD;
using BuildingBlocks.Exceptions;

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
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new DomainException("Title cannot be empty.");
        }
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new DomainException("Description cannot be empty.");
        }
        if (string.IsNullOrWhiteSpace(purpose))
        {
            throw new DomainException("Purposecannot be empty.");
        }
        if (!Guid.TryParse(userId, out var guid))
        {
            throw new DomainException("UserId is not a valid GUID.");
        }

        if (dayStatuses is null || !dayStatuses.Any())
        {
            throw new DomainException("DayStatuses cannot be empty.");
        }
        
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
        if (string.IsNullOrWhiteSpace(purpose))
            throw new DomainException("Purpose cannot be empty.");
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

    public void MarkAsCompleted(DateOnly date)
    {
        var status = _dayStatuses.FirstOrDefault(ds => ds.Date == date);
        if (status is null)
        {
            status = DayStatus.Create(date);
            _dayStatuses.Add(status);
        }
        status.Complete();
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