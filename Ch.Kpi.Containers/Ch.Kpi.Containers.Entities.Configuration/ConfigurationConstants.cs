// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationConstants.cs" company="CristianHiguita">
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//   THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//   OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//   ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//   OTHER DEALINGS IN THE SOFTWARE.
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
