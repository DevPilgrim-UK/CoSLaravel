using CampaignApp.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
namespace CampaignApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NpcController : ControllerBase
    {
        private readonly string _connectionString;

        public NpcController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpPost]
        public async Task<IActionResult> CreateNpc([FromBody] Npc npc)
        {
            using var connection = new SqlConnection(_connectionString);

            var parameters = new
            {
                npc.Name,
                npc.Affinity,
                npc.Met,
                npc.LocationId
            };

            await connection.ExecuteAsync("AddNpc", parameters, commandType: CommandType.StoredProcedure);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Npc>>> GetAll()
        {
            using var conn = new SqlConnection(_connectionString);
            var npcs = await conn.QueryAsync<Npc>("GetAllNpcs", commandType: CommandType.StoredProcedure);
            return Ok(npcs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Npc>> GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            var npc = await conn.QuerySingleOrDefaultAsync<Npc>("GetNpcById", new { Id = id }, commandType: CommandType.StoredProcedure);
            return npc is null ? NotFound() : Ok(npc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Npc npc)
        {
            npc.Id = id;
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync("UpdateNpc", npc, commandType: CommandType.StoredProcedure);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync("DeleteNpc", new { Id = id }, commandType: CommandType.StoredProcedure);
            return NoContent();
        }
    }
}
