using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOListDDD.Infra.Data.Context;

namespace TODOListDDD.Infra.Data.Config
{
    public static class ContextConfig
    {
        const string STRCONN = "Server=192.168.1.67;Database=desafio;Uid=root;Pwd=3006;default command timeout=20;";

        public static string StrConn {
            get { return STRCONN; } }
        public static DbContextOptions<ApplicationContext> GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
                .UseMySql(STRCONN, ServerVersion.AutoDetect(STRCONN));

            return optionsBuilder.Options;
        }
    }
}


