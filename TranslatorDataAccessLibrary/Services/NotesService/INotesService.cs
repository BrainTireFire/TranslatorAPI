using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorDataAccessLibrary.Dtos.Notes;
using TranslatorDataAccessLibrary.Models;

namespace TranslatorDataAccessLibrary.Services.NotesService
{
    public interface INotesService
    {
        Task<ServiceResponse<List<GetNotesDto>>> GetAllNotes();
        Task<ServiceResponse<GetNotesDto>> GetNotesById(int id);
        Task<ServiceResponse<List<GetNotesDto>>> AddNotes(AddNotesDto newNotes);
        Task<ServiceResponse<GetNotesDto>> UpdateNotes(UpdateNotesDto updateNotes);
        Task<ServiceResponse<List<GetNotesDto>>> DeleteNotes(int id);
    }
}
