using AutoMapper;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Infrastructure
{
    public class BaseController : Controller //bazowy kontroler dla wszytkich kontrolerów
    {
        protected DataContext Db { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutomapperConfig.Instance;
            }
        }

        public BaseController()
        {
            Db = new DataContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Db != null)
                {
                    Db.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}