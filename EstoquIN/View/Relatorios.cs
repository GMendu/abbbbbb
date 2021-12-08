﻿using EstoquIN.ConfigDB;
using EstoquIN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace EstoquIN.View
{
    public partial class Relatorios : System.Windows.Forms.Form
    {
        private EstoqDBContext context;
        public Relatorios()
        {
            InitializeComponent();
            context = new EstoqDBContext();
        }

        private void btnRelatorioComp_Click(object sender, EventArgs e)
        {
            BindingSource bi = new BindingSource();
            var query = from a in context.DBcompras
                        from f in context.DBfornec
                        from g in context.DBinsumos
                        orderby a.Id descending
                        where f.Id == a.DadosFornecId & g.Id == a.DadosInsumosId
                        select new { a.Id, a.Data, a.FormPag, a.Quant, a.ValorTotal, a.ValorUnit, a.Status, a.NotaFiscal, a.Insumos, a.Fornec };
            bi.DataSource = query.ToList();
            dataRelatorio.DataSource = bi;
            dataRelatorio.Refresh();
            
        }

        private void btnRelatorioForn_Click(object sender, EventArgs e)
        {
            BindingSource bi = new BindingSource();
            var query = from b in context.DBfornec
                        orderby b.Id descending
                        select new { b.Id, b.Cnpj, b.Razao, b.Inscricao, b.NomeFantasia, b.Observ, b.ContatoNome, b.ContatoEmail, b.ContatoTelefone, b.Endereco };
            bi.DataSource = query.ToList();
            dataRelatorio.DataSource = bi;
            dataRelatorio.Refresh();
        }

        private void btnRelatorioMat_Click(object sender, EventArgs e)
        {
            BindingSource bi = new BindingSource();
            var query = from c in context.DBinsumos
                        orderby c.Id descending
                        select new { c.Id, c.Nome };
            bi.DataSource = query.ToList();
            dataRelatorio.DataSource = bi;
            dataRelatorio.Refresh();
        }

        private void btnRelatorioVend_Click(object sender, EventArgs e)
        {
            BindingSource bi = new BindingSource();
            var query = from d in context.DBvendas
                        from f in context.DBclientes
                        from g in context.DBprodutos
                        orderby d.Id descending
                        where f.Id == d.DadosClienteId & g.Id == d.DadosProdutosId
                        select new { d.Id, d.Data, d.FormPag, d.Quant, d.ValorTotal, d.ValorUnit, d.Status, d.NotaFiscal, d.cliente, d.produto };
            bi.DataSource = query.ToList();
            dataRelatorio.DataSource = bi;
            dataRelatorio.Refresh();
        }

        private void btnRelatorioClient_Click(object sender, EventArgs e)
        {
            BindingSource bi = new BindingSource();
            var query = from f in context.DBclientes
                        orderby f.Id descending
                        select new { f.Id, f.Cnpj, f.Razao, f.Inscricao, f.NomeFantasia, f.Obs, f.ContatoNome, f.ContatoEmail, f.ContatoTelefone, f.endereco, f.freq_compra };
            bi.DataSource = query.ToList();
            dataRelatorio.DataSource = bi;
            dataRelatorio.Refresh();
        }

        private void btnRelatorioProd_Click(object sender, EventArgs e)
        {
            BindingSource bi = new BindingSource();
            var query = from g in context.DBprodutos
                        orderby g.Id descending
                        select new { g.Id, g.Nome, g.Peso, g.ValorAtacado, g.ValorVarejo, g.Obs };
            bi.DataSource = query.ToList();
            dataRelatorio.DataSource = bi;
            dataRelatorio.Refresh();
        }
    }
}
