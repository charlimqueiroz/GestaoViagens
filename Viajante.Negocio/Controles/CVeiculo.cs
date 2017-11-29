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
    public class CVeiculo : ICVeiculo
    {
        public IList<TVeiculo> BuscarTosdos()
        {
            IList<TVeiculo> tVeiculos = Mapper.Map<List<TVeiculo>>(FabricaDeRepositorios<IVeiculoRepositorio>.Instancia.BuscarTodos());

            return tVeiculos;
        }

        public void Salvar(TVeiculo tVeiculo)
        {
            if (tVeiculo.Placa.Count() != 7)
            {
                throw new BusinessException("A placa do veículo deve possuir 7 caracteres.");
            }

            if (tVeiculo.Chassi.Count() != 17)
            {
                throw new BusinessException("O chassi do veículo deve possuir 17 caracteres.");
            }

            if (tVeiculo.Marca.Count() == 0)
            {
                throw new BusinessException("A Marca do veículo deve ser informada.");
            }

            if (tVeiculo.Modelo.Count() == 0)
            {
                throw new BusinessException("O Modelo do veículo deve ser informado.");
            }

            if (tVeiculo.AnoModelo == 0)
            {
                throw new BusinessException("O ano do modelo do veículo não pode ser igual a 0.");
            }

            if (tVeiculo.AnoFabricacao == 0)
            {
                throw new BusinessException("O ano de fabricação do veículo não pode ser igual a 0.");
            }

            if (tVeiculo.Placa.Substring(0, 3).Where(c => char.IsLetter(c)).Count() != 3)
            {
                throw new BusinessException("A placa do veículo deve possuir letras nos 3 primeiros caracteres.");
            }
            else
            if (tVeiculo.Placa.Substring(3, 4).Where(c => char.IsNumber(c)).Count() != 4)
            {
                throw new BusinessException("A placa do veículo deve possuir numeros nas posições de 4 a 7.");
            }

            var tVeic = FabricaDeRepositorios<IVeiculoRepositorio>.Instancia.BuscarPelaPlaca(tVeiculo.Placa);
            if (tVeic != null)
                tVeiculo.Id = tVeic.Id;
            Veiculo veiculo = Mapper.Map<Veiculo>(tVeiculo); //TVeiculoParaVeiculo(tVeiculo);

            try
            {
                FabricaDeRepositorios<IVeiculoRepositorio>.Instancia.SalvarOuAtualizar(veiculo);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        public void Excluir(long idVeiculo)
        {
            var tVeiculo = FabricaDeRepositorios<IVeiculoRepositorio>.Instancia.BuscarPorId(idVeiculo);
            FabricaDeRepositorios<IVeiculoRepositorio>.Instancia.Excluir(tVeiculo);
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
