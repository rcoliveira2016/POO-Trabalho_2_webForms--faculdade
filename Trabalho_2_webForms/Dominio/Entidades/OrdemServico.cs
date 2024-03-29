﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trabalho_2_webForms.Dominio.Infra;

namespace Trabalho_2_webForms.Dominio.Entidades
{
    public class OrdemServico : Entidade
    {
        public static OrdemServico Criar() => new OrdemServico() { Pagamento = Pagamento.Criar() };
        
        public long IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public long IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        public long IdServico { get; set; }
        public virtual Servico Servico { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        public int Unitario { get; set; }
        public DateTime DataAbertura { get; set; }


        public string ClienteDescricao => Cliente.DescricaoCombo;
        public string UsuarioDescricao => Usuario.DescricaoCombo;
        public string ServicoDescricao => Servico.DescricaoCombo;
        public string ValorTotal => CalcularValorTotal().ToString("C");

        public void SetarValorParaSalvar()
        {
            if(RegistroNovo)
                DataAbertura = DateTime.Now;


            Pagamento.ValorTotal = CalcularValorTotal();
        }

        public double CalcularValorTotal()
        {
            if(IdServico==0)
                return 0;

            if (Servico == null)
                return RepositorioSingleton.ServicoRepositorio.BuscarPorId(IdServico).ValorUnitario * Unitario;

            return Servico.ValorUnitario * Unitario;
        }

        public override bool ValidarDados(out List<string> mensagens)
        {
            if (!base.ValidarDados(out mensagens))
            {
                return false;
            }

            ValidarCampo(mensagens, IdCliente, "Cliente");

            ValidarCampo(mensagens, IdServico, "Serviço");

            ValidarCampo(mensagens, IdUsuario, "Usuario");

            ValidarCampo(mensagens, Unitario, "Valor Unitario");

            Pagamento.ValidarDados(out var mensagensPagamentos);
            mensagens.AddRange(mensagensPagamentos);

            return !mensagens.Any();
        }
    }
}