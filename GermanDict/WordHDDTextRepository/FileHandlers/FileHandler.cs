using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanDict.WordHDDTextRepository.FileHandlers
{
    internal class FileHandler
    {
        private string _nounFilePath;
        private string _verbFilePath;
        private string _adjFilePath;

        public FileHandler(string nounFilePath, string verbFilePath, string adjFilePath)
        {
            _nounFilePath = nounFilePath;
            _verbFilePath = verbFilePath;
            _adjFilePath = adjFilePath;
        }


        
    }
}
