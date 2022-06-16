using Api.Application.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
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

        public TradeCategoryController(IApplicationServiceTradeCategory applicationServiceTradeCategory, ILogger logger)
        {
            _applicationServiceTradeCategory = applicationServiceTradeCategory;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                _logger.Information($"Getting trade category by id.");

                var result = _applicationServiceTradeCategory.GetById(id);

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
        public ActionResult<IEnumerable<string>> GetTradeCategoriesByTrades([FromBody] IList<PortfolioDto> portfolioDto)
        {
            try
            {
                _logger.Information($"Getting trade categories.");

                var result = _applicationServiceTradeCategory.GetTradeCategories(portfolioDto);

                if (result == null)
                    return NotFound(false.AsNotFoundResponse("Trade category not found."));

                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.Information($"error: {ex.Message} - please contact the administrator.");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] TradeCategoryDto tradeCategoryDto)
        {
            try
            {
                if (tradeCategoryDto == null)
                    return NotFound();

                _logger.Information($"Creating trade categories.");

                _applicationServiceTradeCategory.Add(tradeCategoryDto);

                return Ok(true.AsSuccessResponse("Successfully created."));
            }
            catch (ArgumentException ex)
            {
                _logger.Information($"error: {ex.Message} - please contact the administrator.");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] TradeCategoryDto tradeCategoryDto)
        {
            try
            {
                if (tradeCategoryDto == null)
                    return NotFound();

                _logger.Information($"Updating trade categories.");

                _applicationServiceTradeCategory.Update(tradeCategoryDto);

                return Ok(true.AsSuccessResponse("Successfully updated."));
            }
            catch (ArgumentException ex)
            {
                _logger.Information($"error: {ex.Message} - please contact the administrator.");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] TradeCategoryDto tradeCategoryDto)
        {
            try
            {
                if (tradeCategoryDto == null)
                    return NotFound();

                _logger.Information($"Deleting trade categories.");

                _applicationServiceTradeCategory.Remove(tradeCategoryDto);
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