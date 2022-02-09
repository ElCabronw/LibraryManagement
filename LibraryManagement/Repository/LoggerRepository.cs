using System;
using System.Text;
using AutoMapper;
using Dapper;
using LibraryManagement.Models.Context;
using LibraryManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repository
{
	public class LoggerRepository : ILoggerRepository
	{
		private readonly MyPostgreSQLContext _context;
		public LoggerRepository(MyPostgreSQLContext context)
		{
			_context = context;
		}

		public void InserirLog(string action, string request, string response, string path, int? statusCode)
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendLine("		INSERT INTO public.logger(											  ");
			sql.AppendLine("action,hora_inclusao, request_value,response_value, path, status_code)  ");
			sql.Append($"  VALUES('{action}', NOW(), '{request}', '{response}', '{path}','{statusCode.ToString()}')");
			try
			{
				_context.Database.GetDbConnection().ExecuteScalar(sql.ToString(), null);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}

