namespace HabitManager.Entities.Habit;
 
 public record HabitId
 {
     private Guid Value { get;}
 
     private HabitId(Guid value)
     {
         if (value == Guid.Empty)
         {
             throw new Exception("Id cannot be empty");
         }
         Value = value;
     }
     public static HabitId Of(Guid value)=> new (value);
 }