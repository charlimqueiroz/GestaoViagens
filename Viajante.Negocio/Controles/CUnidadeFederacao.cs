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
    public class CUnidadeFederacao : ICUnidadeFederacao
    {
        public IList<TUnidadeFederacao> BuscarTodos()
        {
            IList<TUnidadeFederacao> tUF = Mapper.Map<List<TUnidadeFederacao>>(FabricaDeRepositorios<IUnidadeFederacaoRepositorio>.Instancia.BuscarTodos());

            return tUF;
        }

        public TUnidadeFederacao BuscarPeloId(long Id)
        {
            TUnidadeFederacao tUF = Mapper.Map<TUnidadeFederacao>(FabricaDeRepositorios<IUnidadeFederacaoRepositorio>.Instancia.BuscarPorId(Id));

            return tUF;
        }


        public void Salvar(TUnidadeFederacao tUnidadeFederacao)
        {
            if (tUnidadeFederacao.Sigla.Count() == 0)
            {
                throw new BusinessException("A placa do veículo deve possuir 7 caracteres.");
            }

            var tUF = FabricaDeRepositorios<IUnidadeFederacaoRepositorio>.Instancia.BuscarPelaSigla(tUnidadeFederacao.Sigla);
            if (tUF != null)
                tUnidadeFederacao.Id = tUF.Id;
            UnidadeFederacao uf = Mapper.Map<UnidadeFederacao>(tUnidadeFederacao); //TVeiculoParaVeiculo(tVeiculo);

            try
            {
                FabricaDeRepositorios<IUnidadeFederacaoRepositorio>.Instancia.SalvarOuAtualizar(uf);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        public void Excluir(long idUnidadeFederacao)
        {
            var tUnidadeFederacao = FabricaDeRepositorios<IUnidadeFederacaoRepositorio>.Instancia.BuscarPorId(idUnidadeFederacao);
            FabricaDeRepositorios<IUnidadeFederacaoRepositorio>.Instancia.Excluir(tUnidadeFederacao);
        }

        private IList<TVeiculo> VeiculoparaTVeiculo(IList<Veiculo> veiculos)
        {
            IList<TVeiculo> tVeiculos = new List<TVeiculo>();

            Parallel.ForEach(veiculos, veiculo =>
            {
                TVeiculo tVeiculo = new TVeiculo();
                tVeiculo.Id = veiculo.Id;
                tVeiculo.Placa = veiculo.Placa;
                tVeiculo.Chassi = veiculo.Chassi;
                tVeiculo.Marca = veiculo.Marca;
                tVeiculo.Modelo = veiculo.Modelo;
                tVeiculo.AnoModelo = veiculo.AnoModelo;
                tVeiculo.AnoFabricacao = veiculo.AnoFabricacao;
                tVeiculo.Inativo = veiculo.Inativo;
                tVeiculos.Add(tVeiculo);
            }
            );

            return tVeiculos;
        }

        private Veiculo TVeiculoParaVeiculo(TVeiculo tVeiculo)
        {
            Veiculo Veiculo = new Veiculo();
            Veiculo.Id = tVeiculo.Id;
            Veiculo.Placa = tVeiculo.Placa;
            Veiculo.Chassi = tVeiculo.Chassi;
            Veiculo.Marca = tVeiculo.Marca;
            Veiculo.Modelo = tVeiculo.Modelo;
            Veiculo.AnoModelo = tVeiculo.AnoModelo;
            Veiculo.AnoFabricacao = tVeiculo.AnoFabricacao;
            Veiculo.Inativo = tVeiculo.Inativo;

            return Veiculo;

        }
    }
}
