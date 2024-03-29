﻿using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.Middlewares
{
    public static class UseCustomeExceptionHandler
    {
        public static void UseCustomeExceptio(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(x =>
            {

                x.Run(async context =>
                {

                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideExeption => 400,
                        NotFoundException=> 404,
                        _=> 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomResposeDto<NoContentDto>.Fail(statusCode,exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });


            });
        
        }
    }
}
