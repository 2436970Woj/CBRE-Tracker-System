using Domain.Models;

namespace Application.Interfaces.FileUploadServiceInterfaces
{
    public interface IRequestFileUploadService
    {
        Task<bool> FilesDeleteIdAsync(string requestTicketId);
        Task<List<RequestDoc>> FilesDisplayIdAsync(string requestTicketId);
        Task<bool> FilesUploadAsync(string requestTicketId, string fleName);
        Task<bool> FilesUploadSubmitAsync(string requestTicketId);
    }
}