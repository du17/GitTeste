﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro
{
    public partial class FrmPesquisar : Form
    {
        //campo usado para guardar uma referência para um objeto Cadastro;
        private Cadastro cadastro;

        //o construtor recebe uma referência para um objeto Cadastro;
        public FrmPesquisar(Cadastro cadastro)
        {
            InitializeComponent();

            //recebe uma referencia para um objeto cadastro;
            this.cadastro = cadastro;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //fecha a janela
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //recupera o cpf usado na pesquisa
            string cpf = txbPesquisar.Text;

            //busca uma pessoa no cadastro que possua um cpf igual ao digitado
            //pelo usuário
            Pessoa pessoa = cadastro.PesquisarCPF(cpf);

            //caso encontre uma pessoa com o cpf digitado
            if (pessoa != null)
            {

                //Mostra na tela os dados da pessoa encontrada
                txbNome.Text = pessoa.getNome();
                txbIdade.Text = pessoa.getIdade().ToString();
                txbCpf.Text = pessoa.getCpf();

            }
            //caso não encontre uma pessoa com o cpf digitado
            else
            {
                //Exibe uma mensagem informado que não encontrou a pessoa com o cpf pesquisado
                MessageBox.Show("Não foi encontrada nenhuma pessoa com o cpf informado!");

                //limpa os texbox de dados
                clearTextBox();
            }
        }

        //limpa os texbox de dados
        private void clearTextBox()
        {
            txbNome.Clear();
            txbIdade.Clear();
            txbCpf.Clear();
        }
    }
}
