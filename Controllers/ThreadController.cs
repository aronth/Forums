using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
public class ThreadController : ControllerBase
{

    private readonly DatabaseContext _context;

    public ThreadController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet(Routes.Threads.Base)]
    public async Task<ActionResult<Thread[]>> GetAll()
    {
        return Ok(await _context.Threads.ToArrayAsync());
    }

    [HttpGet(Routes.Threads.Get)]
    public async Task<ActionResult<Thread>> GetThread(Guid id)
    {
        var thread = await _context.Threads.FindAsync(id);
        if (thread == null)
            return NotFound();
        return Ok(thread);
    }

    [HttpPost(Routes.Threads.Create)]
    public async Task<ActionResult<Thread>> CreateThread(ThreadCreateRequest request)
    {
        if (request.Title == null)
            return BadRequest();
        Thread thread = new Thread
        {
            Title = request.Title
        };
        await _context.Threads.AddAsync(thread);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetThread), new { id = thread.Id }, thread);
    }
}