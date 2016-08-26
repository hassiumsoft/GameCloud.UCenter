﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using GameCloud.UCenter.Common.Portable.Contracts;
using MongoDB.Driver;
using GameCloud.UCenter.Common.Portable.Exceptions;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GameCloud.UCenter.Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public ExceptionFilter()
        {
        }

        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            context.Result = new JsonResult(exception.Message);

            if (context.Exception != null)
            {
                //CustomTrace.TraceError(
                //    context.Exception,
                //    "Execute request exception: url:{0}, arguments: {1}",
                //    context.Request.RequestUri,
                //    context.ActionContext.ActionArguments);

                var errorCode = UCenterErrorCode.InternalHttpServerError;

                if (context.Exception is UCenterException)
                {
                    errorCode = (context.Exception as UCenterException).ErrorCode;
                }
                else if (context.Exception is MongoException)
                {
                    errorCode = UCenterErrorCode.InternalDatabaseError;
                }

                string errorMessage = context.Exception.Message;

                var content = new UCenterResponse<UCenterError>
                {
                    Status = UCenterResponseStatus.Error,
                    Error = new UCenterError { ErrorCode = errorCode, Message = errorMessage }
                };

                context.Result = new JsonResult(content);
            }
        }
    }
}
