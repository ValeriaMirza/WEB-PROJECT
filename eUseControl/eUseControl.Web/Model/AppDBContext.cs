using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace eUseControl.Web.Model
{
    public class AppDBContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseMySQL("");
        }
    }
}