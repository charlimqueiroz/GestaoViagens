namespace Viajante.Peristencia.ConfiguracaoServidor
{
    public class ConfiguracaoServidor : ConfiguracaoBaseServidor<TemplateConfiguracao>
    {
        public ConfiguracaoServidor()
        {
            FileName = @"serverBD.cfg.xml";
        }
    }
}
