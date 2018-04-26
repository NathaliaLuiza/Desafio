using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MenuServicoWeb.Models;
using System.Collections;

namespace MenuServicoWeb
{
    public class PersonPersistence
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;

        public PersonPersistence()
        {
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;pwd=admin;database=db_webapi";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
            }
        }



        // RETORNAR GET: api/Cliente
        public ArrayList getClientes()
        {

            ArrayList clienteArray = new ArrayList();            
            
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM tb_clientes";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySqlReader = cmd.ExecuteReader();
            while (mySqlReader.Read())
            {
                Cliente p = new Cliente();

                p.ID = mySqlReader.GetInt32(0);
                p.Nome = mySqlReader.GetString(1);
                p.Email = mySqlReader.GetString(2);
                p.Ativo = mySqlReader.GetBoolean(3);

                clienteArray.Add(p);
            }

            return clienteArray;         

        }

        // RETORNAR GET: api/Cliente/5
        public Cliente getCliente(long ID)
        {
            Cliente p = new Cliente();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM tb_clientes WHERE ID = " + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySqlReader = cmd.ExecuteReader();
            if (mySqlReader.Read())
            {
                p.ID = mySqlReader.GetInt32(0);
                p.Nome = mySqlReader.GetString(1);
                p.Email = mySqlReader.GetString(2);
                p.Ativo = mySqlReader.GetBoolean(3);
                return p;
            }
            else
            {
                return null;
            }

        }

        // EXECUTAR PUT: api/Cliente/5
        public bool updateCliente(long ID, Cliente personToSave)
        {
            Cliente p = new Cliente();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM tb_clientes WHERE ID = " + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySqlReader = cmd.ExecuteReader();

            if (mySqlReader.Read())
            {
                mySqlReader.Close();

                sqlString = "UPDATE tb_clientes SET (Nome,Email,Ativo) VALUES ('" + personToSave.Nome + "','" + personToSave.Email + "', " + personToSave.Ativo + ")";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                cmd.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }

        }


        // EXECUTAR DELETE: api/Cliente/5
        public bool deleteCliente(long ID)
        {
            Cliente p = new Cliente();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM tb_clientes WHERE ID = " + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySqlReader = cmd.ExecuteReader();

            if (mySqlReader.Read())
            {
                mySqlReader.Close();

                sqlString = "DELETE FROM tb_clientes WHERE ID = " + ID.ToString();
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                cmd.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }

        }

        //EXECUTAR POST: api/Cliente
        public long saveCliente(Cliente personToSave)
        {
            String sqlString = "INSERT INTO tb_clientes (Nome,Email,Ativo) VALUES ('" + personToSave.Nome + "','" + personToSave.Email + "', "+ personToSave.Ativo + ")";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            long ID = cmd.LastInsertedId;
            return ID;
        }

    }
}
