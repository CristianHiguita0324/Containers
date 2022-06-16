// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Stats.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Entities.Entities
{
    public class Stats
    {
        /// <summary>
        /// The containers dispatched
        /// </summary>
        public double ContainersDispatched { get; set; }

        /// <summary>
        /// The containers not dispatched
        /// </summary>
        public double ContainersNotDispatched { get; set; }

        /// <summary>
        /// The budget used
        /// </summary>
        public double BudgetUsed { get; set; }
    }
}
