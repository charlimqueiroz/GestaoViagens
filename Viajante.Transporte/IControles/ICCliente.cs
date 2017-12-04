using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Viajante.Transporte.Cadastros;

namespace Viajante.Transporte.IControles
{
    [ServiceContract]
    public interface ICCliente
    {
        IList<TCliente> BuscarTosdos();
        void Salvar(TCliente tVeiculo);
        void Excluir(long idCliente);
    }
}
