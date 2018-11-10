using CRUD.Models;
using CRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Infrastructure
{
    public abstract class BaseApiController<TModel, TViewModel> : BaseController, ICRUDOperation<TModel, TViewModel>
        where TModel : BaseObject
        where TViewModel : BaseObjectViewModel //bazowy kontroler dla api - czyli to co leci do frontend
    {
        protected abstract DbSet<TModel> DbSet
        {
            get;
        }

        protected ActionResult SuccessResult(object value = null)
        {
            var result = new ViewModels.ApiResult()
            {
                Success = true,
                Value = value
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected ActionResult ErrorResult(string message)
        {
            var result = new ViewModels.ApiResult()
            {
                Success = false,
                Errors = new List<ViewModels.ApiResultErrorMessage>()
                {
                    new ViewModels.ApiResultErrorMessage()
                    {
                        PropertyName = string.Empty,
                        Error = message
                    }
                }
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(TViewModel viewModel)
        {
            var entity = Mapper.Map<TModel>(viewModel);

            //validacja

            DbSet.Add(entity);
            Db.SaveChanges();

            return SuccessResult(Mapper.Map<TViewModel>(entity));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var entity = DbSet.FirstOrDefault(e => e.Id == id);

            if(entity == null)
            {
                return ErrorResult("obiekt nie istnieje");
            }

            DbSet.Remove(entity);
            Db.SaveChanges();

            return SuccessResult();
        }

        [HttpPost]
        public ActionResult Edit(TViewModel viewModel)
        {
            var entity = DbSet.FirstOrDefault(e => e.Id == viewModel.Id);

            if (entity == null)
            {
                return ErrorResult("obiekt nie istnieje");
            }

            Mapper.Map(viewModel, entity);

            Db.SaveChanges();

            return SuccessResult(Mapper.Map<TViewModel>(entity));
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            var entity = DbSet.FirstOrDefault(e => e.Id == id);

            if (entity == null)
            {
                return ErrorResult("obiekt nie istnieje");
            }

            return SuccessResult(Mapper.Map<TViewModel>(entity));
        }

        [HttpGet]
        public ActionResult GetList()
        {
            return SuccessResult(DbSet);
        }
    }
}