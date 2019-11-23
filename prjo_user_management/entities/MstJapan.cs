using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjo_user_management.entities
{
    public class MstJapan
    {
        private string code_level;
        private string name_level;

        public MstJapan(string code_level, string name_level)
        {
            this.code_level = code_level;
            this.name_level = name_level;
        }

        public string Code_level { get => code_level; set => code_level = value; }
        public string Name_level { get => name_level; set => name_level = value; }
    }
}