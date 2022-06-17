// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationConstants.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Ch.Kpi.Containers.Entities.Configuration
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The configuration constants.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ConfigurationConstants
    {
        /// <summary>
        /// The data base name
        /// </summary>
        public static readonly string DataBaseName = "MongoSettings:DatabaseName";

        /// <summary>
        /// The reference data  connection string.
        /// </summary>
        public static readonly string ConnectionString = "MongoSettings:Connection";
    }
}
