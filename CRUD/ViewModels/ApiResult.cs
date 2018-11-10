using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.ViewModels
{
    public class ApiResult
    {
        public bool Success { get; set; }

        public IEnumerable<ApiResultErrorMessage> Errors { get; set; }

        public object Value { get; set; }
    }

    public class ApiResultErrorMessage
    {
        public string PropertyName { get; set; }

        public string Error { get; set; }
    }
}