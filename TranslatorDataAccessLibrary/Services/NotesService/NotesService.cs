using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorDataAccessLibrary.Data;
using TranslatorDataAccessLibrary.Dtos.Notes;
using TranslatorDataAccessLibrary.Models;

namespace TranslatorDataAccessLibrary.Services.NotesService
{
    public class NotesService : INotesService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public NotesService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        //ADD
        public async Task<ServiceResponse<List<GetNotesDto>>> AddNotes(AddNotesDto newNotes)
        {
            var serviceResponse = new ServiceResponse<List<GetNotesDto>>();
            Notes note = mapper.Map<Notes>(newNotes);
            context.Notes.Add(note);
            await context.SaveChangesAsync();
            serviceResponse.Data = await context.Notes.Select( n => mapper.Map<GetNotesDto>(n)).ToListAsync();
            return serviceResponse;
        }

        //DELETE
        public async Task<ServiceResponse<List<GetNotesDto>>> DeleteNotes(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetNotesDto>>();

            try
            {
                Notes note = await context.Notes.FirstAsync(n => n.NotesID == id);
                context.Notes.Remove(note);
                await context.SaveChangesAsync();

                serviceResponse.Data = context.Notes.Select(n => mapper.Map<GetNotesDto>(n)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        //GET ALL
        public async Task<ServiceResponse<List<GetNotesDto>>> GetAllNotes()
        {
            var serviceResponse = new ServiceResponse<List<GetNotesDto>>();
            var dbNotes = await context.Notes.ToListAsync();
            serviceResponse.Data = dbNotes.Select(n => mapper.Map<GetNotesDto>(n)).ToList();
            return serviceResponse;
        }

        //GET BY ID
        public async Task<ServiceResponse<GetNotesDto>> GetNotesById(int id)
        {
            var serviceResponse = new ServiceResponse<GetNotesDto>();
            var dbNote = await context.Notes.FirstOrDefaultAsync(n => n.NotesID == id );
            serviceResponse.Data = mapper.Map<GetNotesDto>(dbNote);
            return serviceResponse;
        }

        //UPDATE
        public async Task<ServiceResponse<GetNotesDto>> UpdateNotes(UpdateNotesDto updateNotes)
        {
            var serviceResponse = new ServiceResponse<GetNotesDto>();

            try
            {
                Notes note = await context.Notes.FirstOrDefaultAsync(n => n.NotesID == updateNotes.NotesID);
                note.NotesText = updateNotes.NotesText;

                await context.SaveChangesAsync();

                serviceResponse.Data = mapper.Map<GetNotesDto>(note);
            }catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }


            return serviceResponse;
        }
    }
}
