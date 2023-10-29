﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPIRestaurante.Datos;

namespace WEBAPIRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbM;
        public MesaController(ApplicationDbContext dbM)
        {
            _dbM = dbM;
        }
        [HttpGet]
        public async Task<IActionResult> Mesas()
        {
            return Ok(await _dbM.Mesas.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerMesa(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var mesa = _dbM.Mesas.FirstOrDefaultAsync(m => m.IdMesa == id);
            if (mesa == null)
            {
                return NotFound();
            }
            return Ok(mesa);
        }
        
    }
}
