using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
//using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.EFCore
{
    //TODO: Common.EFCore Construir una Interceptor par Inyecciones
    public class CreateDatabaseCollationInterceptor //: DbCommandInterceptor
    {
        //private readonly string _collation;

        //public CreateDatabaseCollationInterceptor(string collation)
        //{
        //    _collation = collation;
        //}

        //public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        //{
        //    // Works for SQL Server
        //    if (Regex.IsMatch(command.CommandText, @"^create database \[.*]$"))
        //    {
        //        command.CommandText += " COLLATE " + _collation;
        //    }
        //}
    }
}
