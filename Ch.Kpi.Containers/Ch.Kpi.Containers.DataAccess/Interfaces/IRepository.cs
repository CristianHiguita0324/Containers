// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IRepository<TEntity>
        where TEntity : class
    {
       
        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="obj"></param>
        void Add(TEntity obj);

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetById(Guid id);

        /// <summary>
        /// the get all
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Remove by id
        /// </summary>
        /// <param name="id"></param>
        void Remove(Guid id);
    }
}