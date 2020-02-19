using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using System.Net.Http;

namespace ClientRestWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExibirForncedores();
        }

        private async void ExibirForncedores()
        {
            var formato = new MediaTypeWithQualityHeaderValue("application/json");
            using (var cliente = new HttpClient())
            {
                //https://localhost:44338/api/exemplo
                cliente.BaseAddress = new Uri("https://localhost:44338/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(formato);
                var resposta = await cliente.GetAsync("api/exemplo");
                var conteudo = await resposta.Content.ReadAsAsync<Fornecedor[]>();

                dataGridView1.DataSource = conteudo;
            }
        }
    }
}
