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

                if ("cliente".Equals(campo, StringComparison.OrdinalIgnoreCase))
                {
                    return string.Format("and   Cliente.nome_cliente like '%' + @{0} + '%'", campo);
                }
                else if ("uf".Equals(campo, StringComparison.OrdinalIgnoreCase))
                {
                    return string.Format("and   Cliente.uf_cliente like '%' + @{0} + '%'", campo);
                }
                else if ("cidade".Equals(campo, StringComparison.OrdinalIgnoreCase))
                {
                    return string.Format("and   Cliente.cidade_cliente like '%' + @{0} + '%'", campo);
                }
                else if ("bairro".Equals(campo, StringComparison.OrdinalIgnoreCase))
                {
                    return string.Format("and   Cliente.bairro_cliente like '%' + @{0} + '%'", campo);
                }
                else if ("tipoServ".Equals(campo, StringComparison.OrdinalIgnoreCase))
                {
                    return string.Format("and   TipoServico.nome_tipo_serv like '%' + @{0} + '%'", campo);
                }

                return "";
            }));

            var map = parametros.ToDictionary();

            if (map.ContainsKey("valMin") && map.ContainsKey("valMax") && map["valMin"] != null && map["valMax"] != null)
            {
                sb.AppendLine("and  ServicoPrestado.valor_prestado between @valMin and @valMax");
            }
            else if (map.ContainsKey("valMin") && map["valMin"] != null)
            {
                sb.AppendLine("and  ServicoPrestado.valor_prestado >= @valMin");
            }
            else if (map.ContainsKey("valMax") && map["valMax"] != null)
            {
                sb.AppendLine("and  ServicoPrestado.valor_prestado <= @valMax");
            }

            if (map.ContainsKey("dtMin") && map.ContainsKey("dtMax") && map["dtMin"] != null && map["dtMax"] != null)
            {
                sb.AppendLine("and  ServicoPrestado.dt_atend_prestado between @dtMin and @dtMax");
            }
            else if (map.ContainsKey("dtMin") && map["dtMin"] != null)
            {
                sb.AppendLine("and  ServicoPrestado.dt_atend_prestado >= @dtMin");
            }
            else if (map.ContainsKey("dtMax") && map["dtMax"] != null)
            {
                sb.AppendLine("and  ServicoPrestado.dt_atend_prestado >= @dtMax");
            }

            return sb.ToString();
        }
    }
}