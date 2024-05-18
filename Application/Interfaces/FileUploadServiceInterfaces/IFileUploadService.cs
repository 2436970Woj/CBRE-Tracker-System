using Microsoft.AspNetCore.Components.Forms;

namespace Application.Interfaces.FileUploadServiceInterfaces
{
    public interface IFileUploadService
    {
        Task UploadFiles(IEnumerable<IBrowserFile> files, string requestTicketId);
    }
}