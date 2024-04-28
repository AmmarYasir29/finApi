using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ReceveDto;
using api.Dtos.sendDto;
using api.Models;

namespace api.Mappers;

public static class StockMappers {
public static StockDtoSend ToStockDto (this Stock stockModel) {
    return new StockDtoSend {
        Id = stockModel.Id,
        Symbol = stockModel.Symbol,
        CompanyName = stockModel.CompanyName,
        Purchase = stockModel.Purchase,
        LastDiv = stockModel.LastDiv,
        Industry = stockModel.Industry,
        MarketCap = stockModel.MarketCap
    };
}

public static Stock ToStockModel (this StockDtoRec stockDto) {
    return new Stock {
        Symbol = stockDto.Symbol,
        CompanyName = stockDto.CompanyName,
        Purchase = stockDto.Purchase,
        LastDiv = stockDto.LastDiv,
        Industry = stockDto.Industry,
        MarketCap = stockDto.MarketCap 
    };
}
}