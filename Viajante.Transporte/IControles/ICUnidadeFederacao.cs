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
    public interface ICUnidadeFederacao
    {
        IList<TUnidadeFederacao> BuscarTodos();
        TUnidadeFederacao BuscarPeloId(long Id);
        void Salvar(TUnidadeFederacao tVeiculo);
        void Excluir(long idUnidadeFederacao);
    }
}
