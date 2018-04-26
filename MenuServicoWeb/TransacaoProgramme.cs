using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MenuServicoWeb.Models;
using System.Collections;

namespace MenuServicoWeb
{
 
    public class TransacaoProgramme
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;

        public TransacaoProgramme()
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

        //REALIZAR DEPOSITO: POST: api/Transacao
        public long realizarTransacao(Transacao transacaoSalvar)
        {
            String sqlString = "INSERT INTO tb_transacoes (idConta,valorTransacao,dataTransacao) VALUES (" + transacaoSalvar.IDConta + "," + transacaoSalvar.valorTransacao + ", '" + transacaoSalvar.dataTransacao.ToString("yyyy/MM/dd HH:mm:ss") + "')";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            long ID_Transacao = cmd.LastInsertedId;
            return ID_Transacao;
        }


    }
}