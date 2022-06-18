// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Common
{
    using Newtonsoft.Json;

    public static class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static string SerializeObject (object entities)
        {
           return JsonConvert.SerializeObject(entities);
        }
    }
}
