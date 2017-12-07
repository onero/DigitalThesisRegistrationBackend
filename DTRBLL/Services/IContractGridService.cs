using System.Collections.Generic;
using DTRBLL.BusinessObjects;

namespace DTRBLL.Services
{
    public interface IContractGridService
    {
        /// <summary>
        /// Get all ContractGridBOs
        /// </summary>
        /// <returns>Collection of ContractGridBO</returns>
        List<ContractGridBO> GetAll();
    }
}