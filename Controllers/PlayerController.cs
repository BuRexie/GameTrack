using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GameTrack.Data.Repository;
using GameTrack.Dtos;
using GameTrack.Models;
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

        public ActionResult<IEnumerable<PlayerReadDto>> GetAllPlayers()
        {
            var players = _repository.GetPlayers();

            return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(players));

        }

        [HttpGet("{id}", Name = "GetPlayer")]

        public ActionResult<PlayerReadDto> GetPlayer(int id)
        {
            var player = _repository.GetPlayer(id);

            if (player != null)
            {
                return Ok(_mapper.Map<PlayerReadDto>(player));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlayerReadDto> CreatePlayer(PlayerCreateDto playerCreateDto)
        {
            var player = _mapper.Map<Player>(playerCreateDto);
            _repository.CreatePlayer(player);
            _repository.SaveChanges();

            var playerReadDto = _mapper.Map<PlayerReadDto>(player);

            return CreatedAtRoute(nameof(GetPlayer), new { Id = playerReadDto.Id }, playerReadDto);
        }

        [HttpPut]
        public ActionResult UpdatePlayer(int id, PlayerUpdateDto playerUpdateDto)
        {
            var player = _repository.GetPlayer(id);
            if (player == null)
            {
                return NotFound();
            }
            _mapper.Map(playerUpdateDto, player);

            _repository.UpdatePlayer(player);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteMessage(int id)
        {
            var player = _repository.GetPlayer(id);
            if (player == null)
            {
                return NotFound();
            }
            _repository.DeletePlayer(player);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}
