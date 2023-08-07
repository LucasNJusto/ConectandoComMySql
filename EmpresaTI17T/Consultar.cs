using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//ele é o responsavel por resgatar os dados do banco de dados
namespace EmpresaTI17T
{
    public partial class Consultar : Form
    {
        DAO consul;
        public Consultar()
        {
            consul = new DAO();
            InitializeComponent();
            ConfigurarDataGrid();
            NomeColunas();//Nomear os titulos das colunas
            AdicionarDados();//Adiciona os dados no dataGridView1
        }

        public void NomeColunas()
        {
            dataGridView1.Columns[0].Name = "CPF";
            dataGridView1.Columns[1].Name = "Nome";
            dataGridView1.Columns[2].Name = "Telefone";
            dataGridView1.Columns[3].Name = "Cidade";
            dataGridView1.Columns[4].Name = "UF";
        }//Fim do metodo nome das colunas

        public void ConfigurarDataGrid()
        {
            dataGridView1.AllowUserToAddRows = false; //Impede que ele adiciona linhas
            dataGridView1.AllowUserToDeleteRows = false; //Impede que o usuario apague
            dataGridView1.AllowUserToResizeColumns = false; //Impede que ele de redimensionar colunas
            dataGridView1.AllowUserToResizeRows = false; //Impede que ele de redimensionar linhas
            
            dataGridView1.ColumnCount = 5;
        }//Fim da COnfiguração do Data Grid View


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //ADICIONAR DADOS
        public void AdicionarDados()
        {
            consul.PreencherVetor(); //Primeira coisa que vai estar fazendo é preenchendo os vetores
            for (int i = 0; i < consul.QuantidadeDeDados(); i++)
            {
                dataGridView1.Rows.Add(consul.CPF[i], consul.nome[i], consul.telefone[i], consul.cidade[i], consul.UF[i]);
            }//Fim do Adicionar dados no dataGridView1
        }//Fim do Adicionar dados 

    }//Fim da classe
}//FIm do Projeto
