﻿using Fashionista.Core.Common;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Fashionista.Infra.Common
{
    public class DbContext :IDbContext
    {
        private DbConnection _connection;
        private readonly IConfiguration configuration;
        public DbContext(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        public DbConnection connection
        {
            get
            {
                if (_connection == null)
                {

                    _connection = new OracleConnection(configuration[("ConnectionStrings:DBConnectionString")]);
                    _connection.Open();
                }
                else if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }


    }


}

