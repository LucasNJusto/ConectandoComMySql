using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaTI17T
{
    public partial class Atualizar : Form
    {
        DAO atu;
        public Atualizar()
        {
            InitializeComponent();
            atu = new DAO();
        }//Fim do costrutor

        private void Atualizar_Load(object sender, EventArgs e)
        {

        }

        //Atualizar
        private void button1_Click(object sender, EventArgs e)
        {
            atu.AtualizarNome(Convert.ToInt64(CPF.Text), "pessoa", "nome", nome.Text); //Atualizar o nome
            atu.AtualizarNome(Convert.ToInt64(CPF.Text), "pessoa", "telefone", telefone.Text); //Atualizar o telefone
            atu.AtualizarNome(Convert.ToInt64(CPF.Text), "pessoa", "cidade", cidade.Text); //Atualizar a cidade
            atu.AtualizarNome(Convert.ToInt64(CPF.Text), "pessoa", "UF", UF.Text); //Atualizar o UF
            MessageBox.Show("Dados Atualizados com Sucesso!");
        }//FIm Do ATUALIZAR

        private void CPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//Fim do CPF

        private void nome_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//Fim do NOME

        private void telefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//Fim do TELEFONE

        private void cidade_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//CIDADE

        private void UF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//UF

    }//FIm da classe
}//FIm do projeto
