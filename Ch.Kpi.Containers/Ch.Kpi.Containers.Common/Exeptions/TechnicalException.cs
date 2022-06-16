// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TechnicalException.cs" company="CristianHiguita">
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//   THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//   OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//   ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//   OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Common.Exeptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TechnicalException : Exception
    {
        public string TramaBroker { get; }

        public TechnicalException(string message) : base(message)
        {
        }

        public TechnicalException(string message, string tramaBroker) : base(message)
        {
            TramaBroker = tramaBroker == null ? string.Empty : tramaBroker;
        }

        public TechnicalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TechnicalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TechnicalException()
        {
        }
    }
}
