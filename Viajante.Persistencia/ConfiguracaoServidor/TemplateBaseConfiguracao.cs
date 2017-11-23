using System;

namespace Viajante.Peristencia.ConfiguracaoServidor
{
    [Serializable]
    public abstract class ConfiguracaoBaseRepositorio
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string PWD { get; set; }
        public int PortaConexaoMobile { get; set; }
        
        public abstract string GetConnectionString();
    }
}
