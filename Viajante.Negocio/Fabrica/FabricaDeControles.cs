using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viajante.Negocio.Fabrica
{
    public class FabricaDeControles<T> where T : class
    {
        private static T instancia;

        public static T Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = Construir();

                return instancia;
            }
        }

        private static T Construir()
        {
            //System.Reflection.Assembly assembly = controle.GetType().Assembly;
            string ns = "Viajante.Negocio";
            var assembly = System.Reflection.Assembly.Load(ns);

            string classe = ns + ".Controles." + typeof(T).Name.Substring(1, typeof(T).Name.Length - 1);

            Type tipo = assembly.GetType(classe, true, true);

            if (typeof(T).GetGenericArguments().Length > 0)
            {
                Type concreteType = tipo.MakeGenericType(typeof(T).GetGenericArguments());
                return (T)Activator.CreateInstance(concreteType);
            }
            else
            {
                System.Reflection.ConstructorInfo ci = tipo.GetConstructor(new Type[] { });
                return (T)ci.Invoke(null);
            }
        }

    }
}
