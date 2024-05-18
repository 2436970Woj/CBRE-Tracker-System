using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IRequestDocRepository
    {
        Task<bool> FilesDeleteIdAsync(string requestTicketId);
        Task<List<RequestDoc>> FilesDisplayIdAsync(string requestTicketId);
        Task<bool> FilesUploadAsync(string requestTicketId, string fleName);
        Task<bool> FilesUploadSubmitAsync(string requestTicketId);
    }
}