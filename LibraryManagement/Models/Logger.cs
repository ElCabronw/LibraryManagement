using System;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryManagement.Models.Base;

namespace LibraryManagement.Models
{
	[Table("logger")]
	public class Logger : BaseEntity
	{
        [Column("hora_inclusao")]
        public DateTime TimeIncluded { get; set; }
        [Column("action")]
        public string Action { get; set; }
        [Column("path")]
        public string Path { get; set; }
        [Column("response_value")]
        public string ResponseValue { get; set; }
        [Column("request_value")]
        public string RequestValue { get; set; }
        [Column("status_code")]
        public string StatusCode { get; set; }

    }
}

