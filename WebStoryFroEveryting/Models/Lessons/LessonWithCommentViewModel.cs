namespace WebStoryFroEveryting.Models.Lessons;

public class LessonWithCommentViewModel : LessonViewModel
{
    public List<LessonCommentViewModel> Comments { get; set; } = [];
}