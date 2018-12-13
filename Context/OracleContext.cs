using Microsoft.EntityFrameworkCore;

using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using OracleInternal.Common;
using OracleInternal.NetCore;
using OracleInternal.NetStandard;
using Oracle.ManagedDataAccess.Types;
using OracleInternal.Secure;
using OracleInternal.Secure.Network;
using OracleInternal.ServiceObjects;

namespace InfraBook.Context
{
    public class OracleContext : DbContext
    {
        public OracleContext (){}

        
        // ("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");

        // public OracleContext( DbContextOptions<OracleContext> options ) : base(options) {
        //     options.
        // }//END constructor

    }
}