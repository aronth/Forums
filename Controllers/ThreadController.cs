using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ThreadController : ControllerBase
{

    private readonly DatabaseContext _context;

    public ThreadController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet(Routes.Threads.Get)]
    public ActionResult<Thread> GetThread(Guid id)
    {
        var thread = _context.Threads.Find(id);
        if (thread == null)
            return NotFound();
        return thread;
    }

    [HttpPost(Routes.Threads.Create)]
    public ActionResult<Thread> CreateThread(ThreadCreateRequest request)
    {
        if (request.Title == null)
            return BadRequest();
        Thread thread = new Thread
        {
            Title = request.Title
        };
        _context.Threads.Add(thread);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetThread), new { id = thread.Id }, thread);
    }
}