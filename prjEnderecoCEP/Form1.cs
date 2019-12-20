using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjEnderecoCEP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCEP_Click(object sender, EventArgs e)
        {
            try
            {
                // Alinha baixo cria um objeto de nome ds usando a classe DataSet
                // DataSet usada para conexão de banco de dados 
                DataSet ds = new DataSet();

                // A linha abaixo cria uma variável de nome xml do tipo String, esta variável armazena a string de conexão do serviço web que iremos utilizar
                // .Replace @cep -> substitui o que foi digitado na caixa de texto txtCEP pelo campo cep do servidor WEB 
                // .Replace("-","") substitui o hífen por nada caso o cliente digite - no campo txtCEP 
                String xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep",txtCEP.Text.Replace("-",""));

                // A linha abaixo faz a leitura dos campos da tabela de CEP do servidor web 
                ds.ReadXml(xml);

                // As linhas abaixo preenchem os campos de acordo com oo dados recebidos (banco de dados de CEP free - "republica virtual")

                txtTipoLogradouro.Text = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString();

                txtLogradouro.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();

                txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();

                txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString();

                txtUF.Text = ds.Tables[0].Rows[0]["uf"].ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Serviço indisponível");
            }
        }
    }
}
