using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommandHandlers
{
    public class CommandHelper
    {
        public static byte[] ConvertFormFileIntoBytes(IFormFile file)
        {
            byte[] stream;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                stream = ms.ToArray();
            }

            return stream;
        }

        public static IFormFile ConvertByesIntoFormFIle(string fileName, byte[] byteArray)
        {
            IFormFile file;

            using (var stream = new MemoryStream(byteArray))
            {
                file = new FormFile(stream, 0, stream.Length, "", fileName);
            }
            return file;
        }
    }
}
