using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;


using System.Configuration;


namespace ConoceAColombia.logica.BL
{
    public class clsConexion
    {
        /// <summary>
        /// Obtiene Conexion  a base de datos
        /// </summary>
        /// <returns>Cadena de conexion</returns>
        public String getConexion()
        {
            return ConfigurationManager.ConnectionStrings["CAC"].ToString();

        }


        public ISessionFactory getConexionn()
        {
            return
                Fluently.Configure().Database(MsSqlConfiguration.MsSql2005.ConnectionString(ConfigurationManager.ConnectionStrings["CAC"].ToString()).ShowSql())
                .Mappings(m =>
                m.FluentMappings.AddFromAssemblyOf<Models.clsEquipo>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true)).BuildSessionFactory();
        }

    }
}