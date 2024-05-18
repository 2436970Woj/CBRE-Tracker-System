//namespace Application.Services.FileUploadServices;

//using Application.Interfaces.FileUploadServiceInterfaces;
//using Microsoft.AspNetCore.Components.Forms;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;
//public class FileUploadService : IFileUploadService
//{    
//    public async Task UploadFiles(IEnumerable<IBrowserFile> files)
//    {
//        foreach (var file in files)
//        {
//            // Save the file to a location on the server or process it as needed
//            using var stream = new FileStream("//EP1APPL139v/D$/CbreFiles/" + file.Name, FileMode.Create);
//            await file.OpenReadStream().CopyToAsync(stream);
//        }
//    }
//}
using Application.Interfaces.FileUploadServiceInterfaces;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services.FileUploadServices
{
    public class FileUploadService : IFileUploadService
    {
        public async Task UploadFiles(IEnumerable<IBrowserFile> files, string requestTicketId)
        {
            string folderPath = Path.Combine("//EP1APPL139v/D$/CbreFiles/", requestTicketId);

            // Check if the folder exists, if not, create it
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            foreach (var file in files)
            {
                // Save the file to the folder
                using var stream = new FileStream(Path.Combine(folderPath, file.Name), FileMode.Create);
                await file.OpenReadStream().CopyToAsync(stream);
            }
        }
    }
}

