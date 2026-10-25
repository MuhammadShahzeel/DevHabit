

using DevHabit.Api.Dtos.Habits;
using DevHabit.Api.Entities;

namespace DevHabit.Api.QueryObjects.Habits;

public static class HabitDtoSelect
{
    public static IQueryable<HabitDto> MapHabitToDto(this IQueryable<Habit> habits)
    {
        return habits.Select(h => new HabitDto(
     h.Id,
     h.Name,
     h.Description,
     h.Type,
     new FrequencyDto(
         h.Frequency.Type,
         h.Frequency.TimesPerPeriod),
     new TargetDto(
         h.Target.Value,
         h.Target.Unit),
     h.Status,
     h.IsArchived,
     h.EndDate,
     h.Milestone == null
         ? null
         : new MilestoneDto(
             h.Milestone.Target,
             h.Milestone.Current),
     h.CreatedAtUtc,
     h.UpdatedAtUtc,
     h.LastCompletedAtUtc));
    }

}
