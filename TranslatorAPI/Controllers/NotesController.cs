using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslatorDataAccessLibrary.Dtos.Notes;
using TranslatorDataAccessLibrary.Models;
using TranslatorDataAccessLibrary.Services.NotesService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TranslatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService notesService;

        public NotesController(INotesService notesService)
        {
            this.notesService = notesService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetNotesDto>>>> Get()
        {
            return Ok(await notesService.GetAllNotes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetNotesDto>>> GetSingle(int id)
        {
            return Ok(await notesService.GetNotesById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetNotesDto>>>> AddNotes(AddNotesDto newNotes)
        {
            return Ok(await notesService.AddNotes(newNotes));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetNotesDto>>> UpdateNotes(UpdateNotesDto updatedNotes)
        {
            var response = await notesService.UpdateNotes(updatedNotes);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetNotesDto>>>> Delete(int id)
        {
            var response = await notesService.DeleteNotes(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}