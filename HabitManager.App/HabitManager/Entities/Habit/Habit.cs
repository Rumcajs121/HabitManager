using BuildingBlocks.AbstractionDDD;

namespace HabitManager.Entities.Habit;

public class Habit:AggregateRoot<HabitId>
{
    public string Title { get; private set; }
    public string Description { get; set; }
    public string UserId { get; set; }
    public string Purpose { get; set; }
    private readonly List<DayStatus> _dayStatuses=new();
    public IReadOnlyList<DayStatus> DayStatuses => _dayStatuses.AsReadOnly();
}