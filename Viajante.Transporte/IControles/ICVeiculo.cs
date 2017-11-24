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
    public interface ICVeiculo
    {
        IList<TVeiculo> BuscarTosdos();
        void Salvar(TVeiculo tVeiculo);
        void Excluir(long idVeiculo);
    }
}
