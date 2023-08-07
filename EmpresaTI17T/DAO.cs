using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Importando classe de dados do banco de dados
using Org.BouncyCastle.Math.EC;

namespace EmpresaTI17T
{
    internal class DAO
    {
        public MySqlConnection conexao;
        public long[] CPF;
        public string[] nome;
        public string[] telefone;
        public string[] cidade;
        public string[] UF;
        public int i;
        public int contador;
        public DAO()
        { 
            conexao = new MySqlConnection("server=localhost;DataBase=empresaTI17T;Uid=root;password=");
            try //Ele ajuda a nao cair o projeto ele trato os erros(Mostra pra voce onde esta o erro)
            {
                conexao.Open();//Abrir a conexão com o banco de dados
                MessageBox.Show("Conectado!");
            }
            catch(Exception erro) 
            { 
                MessageBox.Show("Algo deu errado!\n\n" + erro.Message);
            }
        }//Fim do Construtor

        //Metodos de inserçao de dados
        public string Inserir(long CPF, string nome, string telefone, string cidade, string UF, string nomeTabela)
        {  
            string inserir = $"Insert into {nomeTabela}(CPF, nome, telefone, cidade, UF) values('{CPF}', '{nome}', '{telefone}', '{cidade}', '{UF}')";//Serve para ser global atender todas as tabelas
            MySqlCommand sql = new MySqlCommand(inserir, conexao); //aqui ele começa a inserir o dados que foi escrito acima
            string resultado = sql.ExecuteNonQuery() + " Executado!";//Ele que da o cntr enter(que fazemos no MySql)
            return resultado;
        }//Fim do metodo

        public void PreencherVetor()
        {
            string query = "Select * from pessoa";

            //Instanciar
            this.CPF = new long[100];
            this.nome = new string[100];
            this.telefone = new string[100];
            this.cidade = new string[100];
            this.UF = new string[100];

            //Preparar o comando 
            MySqlCommand sql = new MySqlCommand(query, conexao);

            //Leitor
            MySqlDataReader leitura = sql.ExecuteReader();  //ExecuteReader Retorna 0 ou 1

            i = 0;
            contador = 0;
            while(leitura.Read())
            {
                CPF[i] = Convert.ToInt64(leitura["CPF"]);
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                cidade[i] = leitura["cidade"] + "";
                UF[i] = leitura["UF"] + "";
                i++;  //esta definindo onde serao armazenados
                contador++;  //ele conta uantos dados sao armazenados
            }//Fim do while

            //Encerro a comunicação com o banco de dados
            leitura.Close();

        }//Fim do Metodo de Preencher vetores

        public int QuantidadeDeDados()
        {
            return contador;    
        }

        public string AtualizarNome(long CPF, string nomeTabela, string campo, string dado)
        {
            string query = $"update {nomeTabela} set nome = '{campo}' = '{dado}' where CPF = '{CPF}'";
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string resultado = sql.ExecuteNonQuery() + " Atualizado!";
            return resultado;
        }//Fim do metodo

        public string Excluir(long CPF, string nomeTabela)
        {
            string query = $"delete from {nomeTabela} where CPF = '{CPF}'";
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string resultado = sql.ExecuteNonQuery() + " Excluido!";
            return resultado;
        }//Fim do metodo

    }//Fim da classe
}//FIm do Projeto 
