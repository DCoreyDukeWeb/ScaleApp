using DCoreyDuke.CodeBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Scale : IModel
    {
        
        
        public string Name { get; }








        public bool IsValid { get; }
        public List<string> ValidationErrors { get; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
