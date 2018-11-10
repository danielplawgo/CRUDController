using CRUD.Models;
using CRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CRUD.Infrastructure
{
    interface ICRUDOperation<TModel, TViewModel> 
        where TModel : BaseObject 
        where TViewModel : BaseObjectViewModel
    {
        ActionResult GetList();

        ActionResult GetById(int id);

        ActionResult Add(TViewModel viewModel);

        ActionResult Edit(TViewModel viewModel);

        ActionResult Delete(int id);
    }
}
