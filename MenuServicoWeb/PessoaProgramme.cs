using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MenuServicoWeb.Models;

namespace MenuServicoWeb
{
    public class PessoaProgramme
    {

        private MySql.Data.MySqlClient.MySqlConnection conn;

        public PessoaProgramme()
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

        //ADICIONAR PESSOA: POST: api/Pessoa
        public long pessoaAdicionar(Pessoa pessoaSalvar)
        {
            String sqlString = "INSERT INTO tb_pessoas (nome,CPF,DataNascimento) VALUES ('" + pessoaSalvar.Nome + "','" + pessoaSalvar.CPF + "',' " + pessoaSalvar.DataNascimento.ToString("yyyy/MM/dd HH:mm:ss") + "')";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            long ID_Conta = cmd.LastInsertedId;
            return ID_Conta;
        }



        // RETORNAR PESSOA: GET: api/PEssoa
        public ArrayList getPessoa()
        {

            ArrayList contaArray = new ArrayList();

            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM tb_pessoas";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySqlReader = cmd.ExecuteReader();
            while (mySqlReader.Read())
            {
                Pessoa pess = new Pessoa();

                pess.IDPessoa = mySqlReader.GetInt32(0);
                pess.Nome = mySqlReader.GetString(1);
                pess.CPF = mySqlReader.GetString(2);
                pess.DataNascimento = mySqlReader.GetDateTime(3);

                contaArray.Add(pess);
            }

            return contaArray;

        }
    }
}