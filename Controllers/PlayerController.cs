using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameTrack.Data.Repository;
using GameTrack.Dtos;
using GameTrack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameTrack.Controller
{
    [ApiController]
    [Route("api/v1/player")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepo _repository;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PlayerReadDto>>> GetAllPlayers()
        {
            var players = await _repository.GetPlayers();

            return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(players));

        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public async Task<ActionResult<PlayerReadDto>> GetPlayer(string id)
        {
            try
            {
                var player = await _repository.GetPlayer(id);

                if (player != null)
                {
                    return Ok(_mapper.Map<PlayerReadDto>(player));
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PlayerReadDto>> CreatePlayer(PlayerCreateDto playerCreateDto)
        {
            var player = _mapper.Map<Player>(playerCreateDto);
            _repository.CreatePlayer(player);
            await _repository.SaveChanges();

            var playerReadDto = _mapper.Map<PlayerReadDto>(player);

            return CreatedAtRoute(nameof(GetPlayer), new { Id = playerReadDto.PlayerId }, playerReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlayer(string id, PlayerUpdateDto playerUpdateDto)
        {
            var player = await _repository.GetPlayer(id);
            if (player == null)
            {
                return NotFound();
            }
            _mapper.Map(playerUpdateDto, player);

            _repository.UpdatePlayer(player);

            await _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMessage(string id)
        {
            var player = await _repository.GetPlayer(id);
            if (player == null)
            {
                return NotFound();
            }
            _repository.DeletePlayer(player);
            await _repository.SaveChanges();

            return NoContent();
        }


    }
}
