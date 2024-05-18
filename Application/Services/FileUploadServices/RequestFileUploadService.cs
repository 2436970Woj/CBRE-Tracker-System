using Application.Interfaces.FileUploadServiceInterfaces;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Application.Services.FileUploadServices
{
    public class RequestFileUploadService : IRequestFileUploadService
    {
        private readonly IRequestDocRepository _fileRepo;
        public RequestFileUploadService(IRequestDocRepository fileRepo)
        {
            _fileRepo = fileRepo;
        }

        public async Task<bool> FilesDeleteIdAsync(string requestTicketId)
        {
            return await _fileRepo.FilesDeleteIdAsync(requestTicketId);
        }

        public async Task<List<RequestDoc>> FilesDisplayIdAsync(string requestTicketId)
        {
            return await _fileRepo.FilesDisplayIdAsync(requestTicketId);
        }

        public async Task<bool> FilesUploadAsync(string requestTicketId, string fleName)
        {
            return await _fileRepo.FilesUploadAsync(requestTicketId, fleName);
        }
        public async Task<bool> FilesUploadSubmitAsync(string requestTicketId)
        { 
            return await _fileRepo.FilesUploadSubmitAsync(requestTicketId);
        }
            
    }
}
