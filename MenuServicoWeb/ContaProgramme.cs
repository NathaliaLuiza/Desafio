using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MenuServicoWeb.Models;


namespace MenuServicoWeb
{
    public class ContaProgramme
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;

        public ContaProgramme()
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

        //ADICIONAR CONTA: POST: api/Conta
        public long contaAdicionar(Conta contaSalvar)
        {
            String sqlString = "INSERT INTO tb_contas (id_pessoa,saldo,limiteSaqueDiario,flagAtivo,tipoConta,dataCriacao) VALUES (" + contaSalvar.ID_Pessoa + "," + contaSalvar.Saldo + ", " + contaSalvar.LimiteSaqueDia + ",  " + contaSalvar.FlagAtivo + ", " + contaSalvar.TipoConta + ", '" + contaSalvar.DataCriacao.ToString("yyyy/MM/dd HH:mm:ss") + "')";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            long ID_Conta = cmd.LastInsertedId;
            return ID_Conta;
        }


        // RETORNAR TODAS AS CONTAS: GET: api/Conta
        public ArrayList getConta()
        {

            ArrayList contaArray = new ArrayList();

            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM tb_contas";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySqlReader = cmd.ExecuteReader();
            while (mySqlReader.Read())
            {
                Conta c = new Conta();

                c.ID_Conta = mySqlReader.GetInt32(0);
                c.ID_Pessoa = mySqlReader.GetInt32(1);
                c.Saldo = mySqlReader.GetFloat(2);
                c.LimiteSaqueDia = mySqlReader.GetFloat(3);
                c.FlagAtivo = mySqlReader.GetBoolean(4);
                c.TipoConta = mySqlReader.GetInt32(5);
                c.DataCriacao = mySqlReader.GetDateTime(6);

                contaArray.Add(c);
            }

            return contaArray;

        }


        // RETORNAR UMA CONTA: GET: api/Conta/5
        public Conta getConta(long ID)
        {
            Conta c = new Conta();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM tb_contas WHERE id_conta = " + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySqlReader = cmd.ExecuteReader();
            if (mySqlReader.Read())
            {
                c.ID_Conta = mySqlReader.GetInt32(0);
                c.ID_Pessoa = mySqlReader.GetInt32(1);
                c.Saldo = mySqlReader.GetFloat(2);
                c.LimiteSaqueDia = mySqlReader.GetFloat(3);
                c.FlagAtivo = mySqlReader.GetBoolean(4);
                c.TipoConta = mySqlReader.GetInt32(5);
                c.DataCriacao = mySqlReader.GetDateTime(6);

                return c;
            }
            else
            {
                return null;
            }                   
                      

        }

        // ATUALIZAR BLOQUEIO CONTA: PUT: api/Conta/5
        public bool atualizarConta(long ID, Conta contaSalva)
        {            
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM tb_contas WHERE id_conta = " + ID.ToString();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySqlReader = cmd.ExecuteReader();
            if (mySqlReader.Read())
            {
                mySqlReader.Close();
                sqlString = "UPDATE tb_contas SET id_pessoa =" + contaSalva.ID_Pessoa + ",saldo =" + contaSalva.Saldo + ", limiteSaqueDiario = " + contaSalva.LimiteSaqueDia + ",flagAtivo=" + contaSalva.FlagAtivo + ",tipoConta= " + contaSalva.TipoConta + ", dataCriacao =  '" + contaSalva.DataCriacao.ToString("d/MM/dd HH:mm:ss") + "' WHERE id_conta =" + ID.ToString();
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }



        }


    }


}