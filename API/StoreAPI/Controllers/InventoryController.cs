﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreDB.Models;
using StoreLib;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }


        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult AddInventoryItem(InventoryItem item)
        {
            try
            {
                inventoryService.AddInventoryItem(item);
                return CreatedAtAction("AddInventoryItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult UpdateInventoryItem(InventoryItem item)
        {
            try
            {
                inventoryService.UpdateInventoryItem(item);
                return CreatedAtAction("UpdateInventoryItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult DeleteInventoryItem(InventoryItem item)
        {
            try
            {
                inventoryService.DeleteInventoryItem(item);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{locationId}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllInventoryItemsByLocationId(int locationId)
        {
            try
            {
                return Ok(inventoryService.GetAllInventoryItemsByLocationId(locationId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{locationId}/{bookId}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetItemByLocationIdBookId(int locationId, int bookId)
        {
            try
            {
                return Ok(inventoryService.GetItemByLocationIdBookId(locationId, bookId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //List<InventoryItem> GetAllInventoryItemsById(int id);
        //InventoryItem GetInventoryItemById(int id);
        //InventoryItem GetInventoryItemByLocationId(int id);
    }
}
