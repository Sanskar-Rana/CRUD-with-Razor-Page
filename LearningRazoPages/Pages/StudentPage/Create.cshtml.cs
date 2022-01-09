using LearningRazoPages.Data;
using LearningRazoPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LearningRazoPages.Pages.StudentPage;

public class CreateModel : PageModel
{
    [BindProperty]
    public Student Student { get; set; }
    private readonly ApplicationDBContext _db;

    public CreateModel(ApplicationDBContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
    }

  
    public async Task<IActionResult> OnPost()
    {
        if(Student.studentName == Student.studentAddress)
        {
            ModelState.AddModelError("Student.studentName", "Name and Address cannot be same");
        }
        if(ModelState.IsValid)
        {
            await _db.Student.AddAsync(Student);
            await _db.SaveChangesAsync();
            TempData["success"] = "Created Successfully";
            return RedirectToPage("Index");
        }
       return Page();

    }
}
