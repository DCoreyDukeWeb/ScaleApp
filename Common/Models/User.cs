﻿using DCoreyDuke.CodeBase.Interfaces;

namespace Common.Models
{
    public class User : IModel
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
