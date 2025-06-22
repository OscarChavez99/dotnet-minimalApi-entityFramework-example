using CS_MinimalApi_EF_Example.Application;
using CS_MinimalApi_EF_Example.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CS_MinimalApi_EF_Example.Routes
{
    public static class Routes
    {
        public static void MapEndpoints(WebApplication app)
        {
            MapStudents(app);
            MapTeachers(app);
        }

        private static void MapStudents(WebApplication app)
        {
            app.MapGet("api/students", async (
                [FromServices] StudentsHandler handler) => await handler.GetStudents());
            app.MapPost("api/students", async (
                [FromServices] StudentsHandler handler,
                [FromBody] Student student) => await handler.InsertStudent(student));
            app.MapPut("api/students", async (
                [FromServices] StudentsHandler handler,
                [FromBody] Student student) => await handler.UpdateStudent(student));
            app.MapDelete("api/students/{id:int}", async (
                int id, [FromServices] StudentsHandler handler) => await handler.DeleteStudent(id));
        }

        private static void MapTeachers(WebApplication app)
        {
            app.MapGet("api/teachers", async (
                [FromServices] TeachersHandler handler) => await handler.GetTeachers());
            app.MapPost("api/teachers", async (
                [FromServices] TeachersHandler handler,
                [FromBody] Teacher teacher) => await handler.InsertTeacher(teacher));
            app.MapPut("api/teachers", async (
                [FromServices] TeachersHandler handler,
                [FromBody] Teacher teacher) => await handler.UpdateTeacher(teacher));
            app.MapDelete("api/teachers/{id:int}", async (
                int id, [FromServices] TeachersHandler handler) => await handler.DeleteTeacher(id));
        }
    }
}
