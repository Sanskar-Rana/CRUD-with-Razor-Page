using LearningRazoPages.Data;
using LearningRazoPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LearningRazoPages.Pages.StudentPage;

public class DeleteModel : PageModel
{
    [BindProperty]
    public Student Student { get; set; }
    private readonly ApplicationDBContext _db;

    public DeleteModel(ApplicationDBContext db)
    {
        _db = db;
    }
    public void OnGet(int? id)
    {
        Student = _db.Student.Find(id);
      
    }

  
    public async Task<IActionResult> OnPost(int? id)
    {
            var studentFromDb = _db.Student.Find(id);
            if(studentFromDb != null)
            {
                 _db.Student.Remove(studentFromDb);
                 await _db.SaveChangesAsync();
                TempData["success"] = "Deleted Successfully";
                return RedirectToPage("Index");
            }
        return Page();
    }
}
