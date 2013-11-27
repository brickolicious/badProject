﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BADProject.model
{
    class DataBase
    {


        //connectionstringssettings moet eerst een referentie hebben -->(assambely framework) system.configuration
        private static ConnectionStringSettings ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ConnectionString"]; }
        }


        private static DbConnection GetConnection()
        {

            DbConnection con = DbProviderFactories.GetFactory(ConnectionString.ProviderName).CreateConnection();
            con.ConnectionString = ConnectionString.ConnectionString;
            con.Open();
            return con;

        }



        public static void ReleaseConnection(DbConnection con)
        {

            if (con != null)
            {
                con.Close();
                con = null;
            }
        }

        //params altijd laatst argument van u parameters en is optioneel
        private static DbCommand BuildCommand(string sql, params DbParameter[] parameters)
        {

            DbCommand command = GetConnection().CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;

            if (parameters != null)
            {

                command.Parameters.AddRange(parameters);
            }
            return command;
        }

        public static DbDataReader GetData(string sql, params DbParameter[] parameters)
        {

            DbCommand command = null;
            DbDataReader reader = null;

            try
            {
                command = BuildCommand(sql, parameters);
                //dit gaat wnr je je reader sluit ook uw connectie sluit
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (reader != null)
                {
                    reader.Close();
                    if (command != null)
                    {
                        ReleaseConnection(command.Connection);
                    }
                }
                throw;
            }

        }

        //deze int zijn het aantal lijnen die de query teruggeeft/bewerkt
        public static int ModifyData(string sql, params DbParameter[] parameters)
        {

            DbCommand command = null;
            try
            {
                command = BuildCommand(sql, parameters);
                return command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (command != null)
                {
                    ReleaseConnection(command.Connection);
                    return 0;
                }
                throw;
            }
        }


        public static DbParameter AddParameter(string name, object value)
        {

            DbParameter par = DbProviderFactories.GetFactory(ConnectionString.ProviderName).CreateParameter();
            par.ParameterName = name;
            par.Value = value;
            return par;
        }





        #region Transaction

        public static DbTransaction BeginTransaction()
        {

            DbConnection con = null;
            try
            {
                con = GetConnection();
                return con.BeginTransaction();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ReleaseConnection(con);
                throw;
            }

        }



        //deze functie wordt aangeroepen in de getData of ModifyData
        private static DbCommand BuildCommand(DbTransaction trans, string sql, params DbParameter[] parameters)
        {

            DbCommand command = trans.Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;

            if (parameters != null)
            {

                command.Parameters.AddRange(parameters);
            }
            return command;
        }

        public static DbDataReader GetData(DbTransaction trans, string sql, params DbParameter[] parameters)
        {

            DbCommand command = null;
            DbDataReader reader = null;

            try
            {
                command = BuildCommand(trans, sql, parameters);
                command.Transaction = trans;
                //dit gaat wnr je je reader sluit ook uw connectie sluit
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (reader != null)
                {
                    reader.Close();
                    if (command != null)
                    {
                        ReleaseConnection(command.Connection);
                    }
                }
                throw;
            }

        }

        public static int ModifyData(DbTransaction trans, string sql, params DbParameter[] parameters)
        {

            DbCommand command = null;
            try
            {

                command = BuildCommand(trans, sql, parameters);
                command.Transaction = trans;
                return command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (command != null)
                {
                    ReleaseConnection(command.Connection);
                    return 0;
                }
                throw;
            }
        }

        #endregion


    }
}
