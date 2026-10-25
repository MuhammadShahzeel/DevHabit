using DevHabit.Api.Database;
using DevHabit.Api.Dtos.Habits;
using DevHabit.Api.QueryObjects.Habits;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHabit.Api.Controllers;

[ApiController]
[Route("habits")]
public sealed class HabitsController(ApplicationDbContext dbContext) : ControllerBase
{
 

    [HttpGet]
    public async Task<ActionResult<HabitDto>> GetHabits()
    {
    List<HabitDto> habits = await dbContext.Habits.AsNoTracking().MapHabitToDto()
 
 .ToListAsync();

        var habitsCollectionDto = new HabitsCollectionDto(habits);

        return Ok(habitsCollectionDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HabitDto>> GetHabit(string id)
    {
        HabitDto? habit = await dbContext.Habits
            .AsNoTracking()
            .Where(h => h.Id == id)
            .MapHabitToDto()
            .SingleOrDefaultAsync();

        if (habit is null)
        {
            return NotFound();
        }

        return Ok(habit);
    }
}
