using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Free_Audio_Converter
{

 
    class FileController
    {
        private List<FileContainer> listOfFiles = new List<FileContainer>();

        public void insert(FileContainer f)
        {
            if (listOfFiles.Contains(f))
            {
                return;
            }
            listOfFiles.Add(f);
        }

        public void remove(FileContainer f)
        {
            if (listOfFiles.Contains(f))
            {
                listOfFiles.Remove(f);
            }
          
        }

        public List<FileContainer> getList()
        {
            return listOfFiles;
        }


    }
}
