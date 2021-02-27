using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string AddAsync(IFormFile file)
        {
           // https://docs.microsoft.com/tr-tr/dotnet/api/system.io.path.gettempfilename?view=net-5.0
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create)) //https://docs.microsoft.com/tr-tr/dotnet/api/system.io.filestream.-ctor?view=net-5.0#System_IO_FileStream__ctor_System_String_System_IO_FileMode_
                {
                    file.CopyTo(stream); //https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iformfile.copyto?view=aspnetcore-5.0
                }
                    
            }
                

            var result = newPath(file); 

            File.Move(sourcepath, result); // https://docs.microsoft.com/tr-tr/dotnet/api/system.io.file.move?view=net-5.0#System_IO_File_Move_System_String_System_String_

            return result;
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var result = newPath(file);

            File.Copy(sourcePath, result); // https://docs.microsoft.com/tr-tr/dotnet/api/system.io.file.copy?view=net-5.0#System_IO_File_Copy_System_String_System_String_

            File.Delete(sourcePath); // https://docs.microsoft.com/tr-tr/dotnet/api/system.io.file.delete?view=net-5.0

            return result;
        }

        public static string newPath(IFormFile file)
        {
            System.IO.FileInfo ff = new System.IO.FileInfo(file.FileName); // https://docs.microsoft.com/tr-tr/dotnet/api/system.io.fileinfo.-ctor?view=net-5.0
            string fileExtension = ff.Extension; // https://docs.microsoft.com/tr-tr/dotnet/api/system.io.filesysteminfo.extension?view=net-5.0

            //GUID+TOSTRING=> https://docs.microsoft.com/tr-tr/dotnet/api/system.guid.newguid?view=net-5.0 // https://docs.microsoft.com/tr-tr/dotnet/api/system.double.tostring?view=net-5.0#System_Double_ToString_System_String

            var creatingUniqueFilename = Guid.NewGuid().ToString("N")
               + "-" + DateTime.Now.Month + "-"
               + DateTime.Now.Day + "-"
               + DateTime.Now.Year + fileExtension;
            //Path => https://docs.microsoft.com/tr-tr/dotnet/api/system.io.path.combine?view=net-5.0#System_IO_Path_Combine_System_String_System_String_
            //Environment=> https://docs.microsoft.com/tr-tr/dotnet/api/system.environment.currentdirectory?view=net-5.0
            string path = Path.Combine(Environment.CurrentDirectory + @"/wwwroot/ImagesRepos");
            //@=> https://stackoverflow.com/questions/556133/whats-the-in-front-of-a-string-in-c
            //$=> https://stackoverflow.com/questions/31014869/what-does-mean-before-a-string
            string result = $@"{path}\{creatingUniqueFilename}";

            return result;
        }


    }
}
