using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleDotNet.Interface;
using SampleDotNet.Models;

namespace SampleDotNet.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class VideoController : ControllerBase
    {
        private readonly AppContext _context;
        private readonly ITimeStamp _timestamp;

        public VideoController(AppContext context, ITimeStamp timestamp)
        {
            _context = context;
            _timestamp = timestamp;
        }

        // GET: api/<v>/Video
        [HttpGet, MapToApiVersion("1.0")]
        public String GetVideo()
        {
            return "This is deprecated.";
        }


        // GET: api/<v>/Video
        [HttpGet, MapToApiVersion("2.0")]
        public async Task<ActionResult<IEnumerable<Video>>> GetVideoV2()
        {
            return await _context.Video.ToListAsync();
        }

        // GET: api/<v>/Video/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(long id)
        {
            var video = await _context.Video.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // PUT: api/<v>/Video/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo(long id, Video video)
        {
            if (id != video.Id)
            {
                return BadRequest();
            }

            _context.Entry(video).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/<v>/Video
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Video>> PostVideo(VideoDTO videoDTO)
        {
            Video video = new Video();
            video.Id = videoDTO.Id;
            video.Time = videoDTO.Time;
            video.Link = videoDTO.Link;
            video.CreatedAt = _timestamp.Now;

            _context.Video.Add(video);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideo", new { id = video.Id }, video);
        }

        // DELETE: api/<v>/Video/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Video>> DeleteVideo(long id)
        {
            var video = await _context.Video.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            _context.Video.Remove(video);
            await _context.SaveChangesAsync();

            return video;
        }

        private bool VideoExists(long id)
        {
            return _context.Video.Any(e => e.Id == id);
        }
    }
}
