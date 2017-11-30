
using System;
using System.ComponentModel;
using System.Reflection;

namespace Viajante
{
    /// <summary>
    /// Definição de tipos de operação bancária
    /// </summary>
    public enum TipoTelefone
    {
        Residencial = 0,
        Celular = 1,
        Recado = 2
    }

    public enum TipoLogradouro
    {
        Nenhum = 0,
        Rua = 1,
        Acesso = 2,
        Aeroporto = 3,
        Alameda = 4,
        Atalho = 5,
        Avenida = 6,
        Beco = 7,
        Boulevara = 8,
        Caminho = 9,
        Chacara = 10,
        Conjunto = 11,
        Campo = 12,
        Corredor = 13,
        Entroncam = 14,
        Esplanada = 15,
        Estiva = 16,
        [Description("Estação")]
        Estacao = 17,
        Estrada = 18,
        Fazenda = 19,
        Ferrovia = 20,
        Galeria = 21,
        Jardim = 22,
        Ladeira = 23,
        Lago = 24,
        Lagoa = 25,
        Large = 26,
        Morro = 27,
        Parque = 28,
        Passagem = 29,
        [Description("Praça")]
        Praca = 30,
        Praia = 31,
        Porto = 32,
        Passeio = 33,
        Rodovia = 34,
        Ruela = 35,
        Rio = 36,
        Sitio = 37,
        Sup = 38,
        Quadra = 39,
        Travessa = 40,
        Vale = 41,
        Viaduto = 42,
        Viela = 43,
        Via = 44,
        Vila = 45,
        Vargem = 46
    }

    public enum TipoBairro
    {
        Nenhum = 0,
        Bairro = 1,
        Bosque = 2,
        Chacara = 3,
        Conjunto = 4,
        [Description("Desmeb.")]
        Desmeb = 5,
        Distrito = 6,
        Favela = 7,
        Fazenda = 8,
        Gleba = 9,
        Horto = 10,
        Jardim = 11,
        Loteamento = 12,
        Nucleo = 13,
        Parque = 14,
        [Description("Residenc.")]
        Residenc = 15,
        Sitio = 16,
        Tropical = 17,
        Vila = 18,
        Zona = 19

    }

    public enum TipoHerancaPessoa
    {
        Cliente = 0,
        Fornecedor = 1,
        Contato = 4,
        [Description("Funcionário")]
        Funcionario = 5,
        Solicitante = 6,
        Comprador = 7,
        Contador = 8,
        Imobiliaria = 9,
        Subempreiteiro = 10,
        Socio = 11,
        [Description("Representante Legal")]
        RepresentanteLegal = 12
    }

    public enum TipoPessoa
    {
        [Description("Jurídica")]
        Juridica = 0,
        [Description("Física")]
        Fisica = 1

    }

    public enum TipoGenero
    {
        Feminino = 0,
        Masculino = 1
    }

    public enum EstadoCivil
    {
        Outros = 0,
        [Description("Casado(a)")]
        Casado = 1,
        [Description("Divorciado(a)")]
        Divorciado = 2,
        [Description("Separado(a) Judicialmente")]
        SeparadoJudicialmente = 3,
        [Description("Solteiro(a)")]
        Solteiro = 4,
        [Description("Viúvo(a)")]
        Viuvo = 5
    }


    public static class EnumMethods // transformar para extension method no C# 3.0
    {
        [Obsolete("Usar método do namespace Utils90.Extensions.EnumHelper")]
        public static Enum GetEnumByDescription(Type enumType, string description)
        {
            FieldInfo[] aFI = enumType.GetFields();

            for (int i = 0; i <= aFI.Length; i++)
            {
                FieldInfo fi = aFI[i];
                DescriptionAttribute[] da = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                string s = (da.Length > 0) ? da[0].Description : fi.Name;

                if (s == description)
                    return (Enum)fi.GetValue(enumType);
            }

            return null;
        }

        public static Enum GetEnumByDescriptionCI(Type enumType, string description)
        {
            FieldInfo[] aFI = enumType.GetFields();

            for (int i = 1; i < aFI.Length; i++)
            {
                FieldInfo fi = aFI[i];
                DescriptionAttribute[] da = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                string s = (da.Length > 0) ? da[0].Description : fi.Name;

                if (s.ToLower() == description.ToLower())
                    return (Enum)fi.GetValue(enumType);
            }

            return null;
        }

        [Obsolete("Use o método extendido GetDescription para enums")]
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
              (DescriptionAttribute[])fi.GetCustomAttributes
              (typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        [Obsolete("Usar método do namespace Utils90.Extensions.EnumHelper")]
        public static string[] GetDescriptions(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = type.GetGenericArguments()[0];
            }

            FieldInfo[] aFI = type.GetFields();

            string[] attributes = new string[aFI.Length];

            for (int i = 1; i < aFI.Length; i++)
            {
                FieldInfo fi = aFI[i];
                DescriptionAttribute[] da = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                attributes[i - 1] = (da.Length > 0) ? da[0].Description : fi.Name;
            }

            return attributes;
        }
    }

    public static class EnumExtensions
    {
        [Obsolete("Usar método do namespace Utils90.Extensions.EnumHelper")]
        public static string GetDescription(this Enum value)
        {
            if (value != null)
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes
                  (typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
            }
            return null;
        }
    }
}
