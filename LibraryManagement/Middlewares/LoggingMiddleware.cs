using System;
using System.Text;
using Dapper;
using LibraryManagement.Models.Context;
using LibraryManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IO;

namespace LibraryManagement.Middlewares
{
	public class LoggingMiddleware
	{
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        //private readonly ILoggerRepository _segurancaRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        private readonly MyPostgreSQLContext _context;
        private string bodyResponse = string.Empty;
        private string bodyRequest = string.Empty;

        public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggingMiddleware>();
            //_segurancaRepository = segurancaRepository;
            
            _httpContextAccessor = httpContextAccessor;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
           
        }
        public async Task Invoke(HttpContext context, ILoggerRepository loggerRepository)
        {
            try
            {

                await LogRequest(context);
                await LogResponse(context);


                if (context.Request?.Method == "PUT" || context.Request?.Method == "POST" || context.Request?.Method == "DELETE")
                {
                    if (string.IsNullOrEmpty(bodyRequest)) bodyRequest = context.Request?.QueryString.ToString();
                  
                    loggerRepository.InserirLog(context.Request?.Method, bodyRequest, bodyResponse, context.Request?.Path.Value, context.Response?.StatusCode);
                }
            }
            catch { }

        }

        private async Task LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();
            var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);
            bodyRequest = ReadStreamInChunks(requestStream);

            context.Request.Body.Position = 0;
        }

        private async Task LogResponse(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;
            await _next(context);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            bodyResponse = text;
            await responseBody.CopyToAsync(originalBodyStream);

        }

        private string FormatResponse(HttpResponse response)
        {
            //We need to read the response stream from the beginning...
            //response.Body.Seek(0, SeekOrigin.Begin);

            //...and copy it into a string
            string text = new StreamReader(response.Body).ReadToEndAsync().Result;

            //We need to reset the reader for the response so that the client can read it.
            response.Body.Seek(0, SeekOrigin.Begin);

            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            return text;
        }

        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;
            stream.Seek(0, SeekOrigin.Begin);
            var textWriter = new StringWriter();
            var reader = new StreamReader(stream);
            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;
            do
            {
                readChunkLength = reader.ReadBlock(readChunk,
                                                   0,
                                                   readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);
            return textWriter.ToString();
        }
    }
    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}

