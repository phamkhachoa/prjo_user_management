using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjo_user_management.Data;
using prjo_user_management.entities;
using prjo_user_management.Models;

namespace prjo_user_management.dao.impl
{
    public class MstJapanDaoImpl : IMstJapanDao
    {
        DatabaseContext context;

        public MstJapanDaoImpl()
        {
            context = new DatabaseContext();
        }

        public List<MstJapan> GetAllMstJapan()
        {
            List<MstJapan> listMstJapan = new List<MstJapan>();
            var query = context.MstJapans.Select(a => new { CodeLevel = a.code_level, NameLevel = a.name_level});
            foreach (var el in query) { 

                listMstJapan.Add(new MstJapan(el.CodeLevel, el.NameLevel));
            }
            return listMstJapan;
        }
    }
}