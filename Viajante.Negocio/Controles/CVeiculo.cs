using Noventa.Dominio.IRepositorio;
using System.Collections.Generic;
using System.Threading.Tasks;
using Viajante.Dominio.Dominio;
using Viajante.Dominio.Fabrica;
using Viajante.Transporte.Cadastros;
using Viajante.Transporte.IControles;

namespace Viajante.Negocio.Controles
{
    public class CVeiculo : ICVeiculo
    {
        public IList<TVeiculo> BuscarTosdos()
        {
            IList<Veiculo> veiculos = FabricaDeRepositorios<IVeiculoRepositorio>.Instancia.BuscarTodos();

            IList<TVeiculo> tVeiculos = VeiculoparaTVeiculo(veiculos);

            return tVeiculos;
        }

        public void Salvar(TVeiculo tVeiculo)
        {
            Veiculo veiculo = TVeiculoParaVeiculo(tVeiculo);

            FabricaDeRepositorios<IVeiculoRepositorio>.Instancia.Salvar(veiculo);

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
