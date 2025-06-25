using CS_MinimalApi_EF_Example.Application.Data;
using CS_MinimalApi_EF_Example.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CS_MinimalApi_EF_Example.Application
{
    public class TeachersHandler(DataContext dataContext)
    {
        public async Task<IResult> GetTeachers()
        {
            List<Teacher> teachers = await dataContext.Teachers.ToListAsync();

            return Results.Ok(teachers);
        }

        public async Task<IResult> InsertTeacher(Teacher teacher)
        {
            await dataContext.Teachers.AddAsync(teacher);
            await dataContext.SaveChangesAsync();

            return Results.Created($"api/teachers{teacher.Id}", teacher);
        }

        public async Task<IResult> UpdateTeacher(Teacher teacher)
        {
            var exists = await dataContext.Teachers.AnyAsync(t => t.Id == teacher.Id);
            if (!exists)
                return Results.NotFound();

            dataContext.Teachers.Update(teacher);
            await dataContext.SaveChangesAsync();

            return Results.NoContent();
        }

        public async Task<IResult> DeleteTeacher(int id)
        {
            Teacher? teacher = await dataContext.Teachers.FindAsync(id);

            if (teacher == null)
                return Results.NotFound();

            dataContext.Teachers.Remove(teacher);
            await dataContext.SaveChangesAsync();

            return Results.NoContent();
        }
    }
}
