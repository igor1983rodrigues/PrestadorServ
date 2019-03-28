using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PrestadorServ.Models.Bo
{
    internal static class BusinessObject
    {
        public static string Where<T>(this string target, T parametros, Func<string, string, string> callBack)
        {

            StringBuilder sb = new StringBuilder(target);

            foreach (PropertyInfo prop in parametros.GetType().GetProperties())
            {
                if (!prop.CanRead) continue;

                string value = prop.GetValue(parametros)?.ToString();

                if (string.IsNullOrEmpty(value)) continue;

                sb.AppendLine(callBack.Invoke(prop.Name, value));
            }

            return sb.ToString();
        }

        public static Dictionary<string, object> ToDictionary<T>(this T parametros)
        {

            Dictionary<string, object> map = new Dictionary<string, object>();

            foreach (PropertyInfo prop in parametros.GetType().GetProperties())
            {
                if (!prop.CanRead) continue;

                map.Add(prop.Name, prop.GetValue(parametros));
            }

            return map;
        }
    }

    public static class ServicoPrestadoBo
    {
        public static string Filtro<T>(this string target, T parametros)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(target.Where(parametros, (campo, valor) =>
            {

                if ("IdFornecedor".Equals(campo, StringComparison.OrdinalIgnoreCase))
                {
                    return string.Format("and   UPPER(Fornecedor.id_fornecedor) = @{0}", campo);
                }
                else if ("Fornecedor".Equals(campo, StringComparison.OrdinalIgnoreCase))
                {
                    return string.Format("and   UPPER(Fornecedor.nome_fornecedor) like '%' +UPPER( @{0}) + '%'", campo);
                }
                else if ("Cliente".Equals(campo, StringComparison.OrdinalIgnoreCase))
                {
                    return string.Format("and   UPPER(Cliente.nome_cliente) like '%' +UPPER( @{0}) + '%'", campo);
                }
                else if ("Uf".Equals(campo, StringComparison.OrdinalIgnoreCase))
                {
                    return string.Format("and   UPPER(Cliente.uf_cliente) like '%' +UPPER( @{0}) + '%'", campo);
                }
                else if ("Cidade".Equals(campo, StringComparison.OrdinalIgnoreCase))
                {
                    return string.Format("and   UPPER(Cliente.cidade_cliente) like '%' +UPPER( @{0}) + '%'", campo);
                }
                else if ("Bairro".Equals(campo, StringComparison.OrdinalIgnoreCase))
                {
                    return string.Format("and   UPPER(Cliente.bairro_cliente) like '%' +UPPER( @{0}) + '%'", campo);
                }
                else if ("TipoServ".Equals(campo, StringComparison.OrdinalIgnoreCase))
                {
                    return string.Format("and   UPPER(TipoServico.nome_tipo_serv) like '%' +UPPER( @{0}) + '%'", campo);
                }

                return "";
            }));

            var map = parametros.ToDictionary();

            if (map.ContainsKey("ValMin") && map.ContainsKey("ValMax") && map["ValMin"] != null && map["ValMax"] != null)
            {
                sb.AppendLine("and  ServicoPrestado.valor_prestado between @ValMin and @ValMax");
            }
            else if (map.ContainsKey("ValMin") && map["ValMin"] != null)
            {
                sb.AppendLine("and  ServicoPrestado.valor_prestado >= @ValMin");
            }
            else if (map.ContainsKey("ValMax") && map["ValMax"] != null)
            {
                sb.AppendLine("and  ServicoPrestado.valor_prestado <= @ValMax");
            }

            if (map.ContainsKey("DtMin") && map.ContainsKey("DtMax") && map["DtMin"] != null && map["DtMax"] != null)
            {
                sb.AppendLine("and  ServicoPrestado.dt_atend_prestado between @DtMin and @DtMax");
            }
            else if (map.ContainsKey("DtMin") && map["DtMin"] != null)
            {
                sb.AppendLine("and  ServicoPrestado.dt_atend_prestado >= @DtMin");
            }
            else if (map.ContainsKey("DtMax") && map["DtMax"] != null)
            {
                sb.AppendLine("and  ServicoPrestado.dt_atend_prestado >= @DtMax");
            }

            return sb.ToString();
        }
    }
}