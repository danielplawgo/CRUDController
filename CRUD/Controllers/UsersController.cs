using CRUD.Infrastructure;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CRUD.ViewModels.Users;

namespace CRUD.Controllers
{
    public class UsersController : BaseApiController<User, UserViewModel>, ICRUDOperation<User, UserViewModel>
    {
        protected override DbSet<User> DbSet
        {
            get
            {
                return Db.Users;
            }
        }
    }
}