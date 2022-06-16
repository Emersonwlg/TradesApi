using Api.Application.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Trades.Application.Dtos;
using Trades.Application.Interfaces;

namespace Trades.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeCategoryController : ControllerBase
    {
        private readonly IApplicationServiceTradeCategory _applicationServiceTradeCategory;
        private readonly ILogger _logger;

        public TradeCategoryController(IApplicationServiceTradeCategory applicationServiceTradeCategory, 
                                       ILogger logger)
        {
            _applicationServiceTradeCategory = applicationServiceTradeCategory;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                _logger.Information($"Getting all trades categories.");

                var result = await _applicationServiceTradeCategory.GetAll();

                if (result == null)
                    return NotFound(false.AsNotFoundResponse("Trades categories not found."));

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                _logger.Information($"error: {ex.Message} - please contact the administrator.");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TradeCategoryDto>> GetById(Guid id)
        {
            try
            {
                _logger.Information($"Getting trade category by id.");

                var result = await _applicationServiceTradeCategory.GetById(id);

                if (result == null)
                    return NotFound(false.AsNotFoundResponse("Trade category not found."));

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                _logger.Information($"error: {ex.Message} - please contact the administrator.");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("GetTradeCategoriesByTrades")]
        public async Task<ActionResult> GetTradeCategoriesByTrades([FromBody] IList<TradeDto> tradesDto)
        {
            try
            {
                _logger.Information($"Getting trade categories.");

                var result = await _applicationServiceTradeCategory.GetTradeCategories(tradesDto);

                if (result == null)
                    return NotFound(false.AsNotFoundResponse("Trade category not found."));

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                _logger.Information($"error: {ex.Message} - please contact the administrator.");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TradeCategoryDto tradeCategoryDto)
        {
            try
            {
                if (tradeCategoryDto == null)
                    return NotFound();

                _logger.Information($"Creating trade category.");

                await _applicationServiceTradeCategory.Add(tradeCategoryDto);

                return Ok(true.AsSuccessResponse("Successfully created."));
            }
            catch (ArgumentException ex)
            {
                _logger.Information($"error: {ex.Message} - please contact the administrator.");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] TradeCategoryDto tradeCategoryDto)
        {
            try
            {
                if (tradeCategoryDto == null)
                    return NotFound();

                _logger.Information($"Updating trade category.");

                await _applicationServiceTradeCategory.Update(tradeCategoryDto);

                return Ok(true.AsSuccessResponse("Successfully updated."));
            }
            catch (ArgumentException ex)
            {
                _logger.Information($"error: {ex.Message} - please contact the administrator.");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete()]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var tradeCategoryDelete = await _applicationServiceTradeCategory.GetById(id);

                if (tradeCategoryDelete == null)
                    return NotFound();

                _logger.Information($"Deleting trade category.");

                await _applicationServiceTradeCategory.Remove(tradeCategoryDelete);
                return Ok("Successfully deleted.");
            }
            catch (ArgumentException ex)
            {
                _logger.Information($"error: {ex.Message} - please contact the administrator.");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}