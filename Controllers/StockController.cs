using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ReceveDto;
using api.Mappers;
using FinApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/stock")]
[ApiController]
public class StockController : ControllerBase {
private readonly ApplicationDBContext _context;
private readonly IStockRepository _stockRepo;
public StockController(ApplicationDBContext context, IStockRepository stockRepo) {
    _context = context;
    _stockRepo = stockRepo;
}
[HttpGet]
public async Task<IActionResult> GetAll () {
    var stocks = await _stockRepo.GetAllSAsync();
    var stockDto = stocks.Select ( s => s.ToStockDto());
    return Ok(stockDto);
}

[HttpGet("{id}")]
public async Task<IActionResult> GetById([FromRoute] int id) {
var stock = await _stockRepo.GetByIdAsync(id);
if (stock == null) return NotFound();
return Ok(stock.ToStockDto());
}

[HttpPost]
public async Task<IActionResult> CreateStock([FromBody] StockDtoRec stockDto) {
    var stockModel = stockDto.ToStockModel();
    await _stockRepo.CreateAsync(stockModel);
    return CreatedAtAction(nameof(GetById),new {id = stockModel.Id},stockModel.ToStockDto());
}

[HttpPut]
[Route("{id}")]
public async Task<IActionResult> UpdateStock ([FromRoute] int id, [FromBody] StockDtoRec updateDto) {

var stockModel = await _stockRepo.UpdateAsync(id,updateDto);
if (stockModel == null) return NotFound();

return Ok(stockModel.ToStockDto());
}

[HttpDelete]
[Route("{id}")]
public async Task<IActionResult> DeleteStock ([FromRoute] int id) {

    var stockModel = await _stockRepo.DeleteAsync(id);
    if(stockModel == null) return NotFound();

    return NoContent();
}

}