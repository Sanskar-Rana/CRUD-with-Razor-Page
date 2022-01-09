using LearningRazoPages.Data;
using LearningRazoPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LearningRazoPages.Pages.StudentPage;

public class EditModel : PageModel
{
    [BindProperty]
    public Student Student { get; set; }
    private readonly ApplicationDBContext _db;

    public EditModel(ApplicationDBContext db)
    {
        _db = db;
    }
    public void OnGet(int? id)
    {
        Student = _db.Student.Find(id);
      
    }

  
    public async Task<IActionResult> OnPost()
    {
        if(Student.studentName == Student.studentAddress)
        {
            ModelState.AddModelError("Student.studentName", "Name and Address cannot be same");
        }
        if(ModelState.IsValid)
        {
            _db.Student.Update(Student);
            await _db.SaveChangesAsync();
            TempData["success"] = "Update Successfully";
            return RedirectToPage("Index");
        }
       return Page();

    }
}
