using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace The_Free_Audio_Converter
{
    class FileContainer : IEquatable<FileContainer>
    {
        private string fileLocation;
        private string fileType;

        public FileContainer(string f)
        {
            fileLocation = f;
            fileType = Path.GetExtension(fileLocation);
            fileType = fileType.Substring(1, fileType.Length-1).ToUpper().Trim();
        }


        public string getFileLocation()
        {
            return fileLocation;
        }

        public string getFileType()
        {

            return fileType;
        }

        
        public bool Equals(FileContainer f)
        {
            return f.getFileLocation().Equals(this.fileLocation);
            
        }
       
    }
}
