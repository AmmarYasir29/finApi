using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ReceveDto;
using api.Models;

namespace FinApi.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllSAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync (Stock stockModel);
        Task<Stock?> UpdateAsync(int id, StockDtoRec stockDto);
        Task<Stock?> DeleteAsync(int id);
    }
}