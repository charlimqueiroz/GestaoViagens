using AutoMapper;
using Noventa.Dominio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajante.Dominio.Dominio;
using Viajante.Dominio.Fabrica;
using Viajante.Exceptions;
using Viajante.Transporte.Cadastros;
using Viajante.Transporte.IControles;

namespace Viajante.Negocio.Controles
{
    public class CCliente : ICCliente
    {
        public IList<TCliente> BuscarTosdos()
        {
            IList<TCliente> tCliente = Mapper.Map<List<TCliente>>(FabricaDeRepositorios<IClienteRepositorio>.Instancia.BuscarTodos());

            return tCliente;
        }

        public void Salvar(TCliente tCliente)
        {
            if (tCliente.Codigo.Count() == 0)
            {
                throw new BusinessException("Código do cliente deve ser informado.");
            }

            var tVeic = FabricaDeRepositorios<IClienteRepositorio>.Instancia.BuscarPeloCodigo(tCliente.Codigo);
            if (tVeic != null)
                tCliente.Id = tVeic.Id;
            Cliente cliente = Mapper.Map<Cliente>(tCliente); //TVeiculoParaVeiculo(tVeiculo);

            try
            {
                FabricaDeRepositorios<IClienteRepositorio>.Instancia.SalvarOuAtualizar(cliente);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        public void Excluir(long idCliente)
        {
            var tCliente = FabricaDeRepositorios<IClienteRepositorio>.Instancia.BuscarPorId(idCliente);
            FabricaDeRepositorios<IClienteRepositorio>.Instancia.Excluir(tCliente);
        }
    }
}
