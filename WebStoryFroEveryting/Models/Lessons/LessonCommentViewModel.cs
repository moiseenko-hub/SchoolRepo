using WebStoryFroEveryting.Models.SchoolAuth;

namespace WebStoryFroEveryting.Models.Lessons;

public class LessonCommentViewModel
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public SchoolUserViewModel User { get; set; }
}