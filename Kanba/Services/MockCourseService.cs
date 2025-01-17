using Kanba.Abstractions;
using Kanba.Models;


namespace Kanba.Services;

public class MockCourseService : ICourseService
{
    private readonly List<Course> courses;

    public MockCourseService()
    {
        courses = new List<Course>
        {
           new Course {Id = 1, Name = "Phonics 1", Description = "Kids kursi 1-darajasi"},
            new Course {Id = 2, Name = "Phonics 2", Description = "Kids kursi 2-darajasi"},
            new Course {Id = 3, Name = "Phonics 3", Description = "Kids kursi 3-darajasi"},
            new Course {Id = 4, Name = "Phonics 4", Description = "Kids kursi 4-darajasi"},

            // English Courses - Junior
            new Course {Id = 5, Name = "Starters", Description = "Kids bitiruvchilari uchun"},

            // English Courses - General
            new Course { Id = 6, Name = "The Spire 1", Description = "A1 darajasidagi ingliz tili kursi", },
            new Course {Id = 7, Name = "The Spire 2", Description = "A2 darajasidagi ingliz tili kursi"},
            new Course {Id = 8, Name = "The Spire 3", Description = "Pre-B1 darajasidagi ingliz tili kursi"},
            new Course {Id = 9, Name = "The Spire 4", Description = "B1 darajasidagi ingliz tili kursi"},
            new Course {Id = 10, Name = "The Spire 5", Description = "Pre-B2 darajasidagi ingliz tili kursi"},
            new Course {Id = 11, Name = "The Spire 6", Description = "B2 darajasidagi ingliz tili kursi"},

            // English Courses - Intensive
            new Course {Id = 12, Name = "Level 7", Description = "IELTS va CEFR uchun intensiv 1-bosqich"},
            new Course {Id = 13, Name = "Level 8", Description = "IELTS va CEFR uchun intensiv 2-bosqich"},
                
            // IT Courses - Bits
            new Course {Id = 14, Name = "Scratch", Description = "Scratch bilan dasturlashga kirish"},
            new Course {Id = 15, Name = "Lego Mindstorms (Begin)", Description = "Lego Mindstorms bilan robototexnikaning asoslari"},

            // IT Courses - Bytes
            new Course {Id = 16, Name = "Extended Scratch", Description = "Kengaytirilgan Scratch dasturlash"},
            new Course {Id = 17, Name = "Lego (Spike Prime)", Description = "Spike Prime bilan robototexnikaning kengaytirilgan kursi"},
            new Course {Id = 18, Name = "Savodxonlik", Description = "Raqsodxonlik kursi"},  
            new Course {Id = 19, Name = "App Inventor", Description = "Mobil ilovalar ishlab chiqish asoslari"},
            new Course {Id = 20, Name = "Robotics (Extended)", Description = "5 oylik kengaytirilgan robototexnika kursi"},
                
            // IT Courses - Junior
            new Course {Id = 21, Name = "Extended Python", Description = "Kengaytirilgan Python dasturlash"},
            new Course {Id = 22, Name = "AutoCAD", Description = "Kompyuter yordamida loyihalash kursi"},

            // IT Courses - Foundation
            new Course {Id = 23, Name = "C++", Description = "C++ dasturlash kursi"},

            // IT Courses - Professional
            new Course {Id = 24, Name = "Frontend", Description = "Frontend mutaxassisligi kursi"},
            new Course {Id = 25, Name = "Backend", Description = "Backend mutaxassisligi kursi"}
            // ... (add 10 more courses with similar Uzbek-themed information)
        };
    }

    public ValueTask<IEnumerable<Course>> GetCoursesAsync(CancellationToken cancellationToken = default) =>
        new(courses);

    public ValueTask<Course?> GetCourseByIdAsync(int id, CancellationToken cancellationToken = default) =>
        new(courses.FirstOrDefault(c => c.Id == id));

    public ValueTask<Course> CreateCourseAsync(Course course, CancellationToken cancellationToken = default)
    {
        course.Id = courses.Max(c => c.Id) + 1;
        courses.Add(course);
        return new ValueTask<Course>(course);
    }

    public ValueTask<Course> UpdateCourseAsync(Course course, CancellationToken cancellationToken = default)
    {
        var existingCourse = courses.FirstOrDefault(c => c.Id == course.Id);
        if (existingCourse != null)
        {
            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            existingCourse.Price = course.Price;
            existingCourse.DurationInWeeks = course.DurationInWeeks;
            existingCourse.Instructor = course.Instructor;
            existingCourse.StartDate = course.StartDate;
            existingCourse.IsActive = course.IsActive;
        }
        return new ValueTask<Course>(existingCourse ?? course);
    }

    public ValueTask<bool> DeleteCourseAsync(int id, CancellationToken cancellationToken = default)
    {
        var course = courses.FirstOrDefault(c => c.Id == id);
        if (course != null)
        {
            courses.Remove(course);
            return new ValueTask<bool>(true);
        }
        return new ValueTask<bool>(false);
    }
}
