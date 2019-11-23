using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjo_user_management.entities
{
    public class MstGroup
    {
        private int group_id;
        private string group_name;

        public MstGroup(int group_id, string group_name)
        {
            this.Group_id = group_id;
            this.Group_name = group_name;
        }

        public int Group_id { get => group_id; set => group_id = value; }
        public string Group_name { get => group_name; set => group_name = value; }
    }
}