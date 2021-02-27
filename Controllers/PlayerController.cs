using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GameTrack.Data;
using GameTrack.Dtos;
using GameTrack.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameTrack.Controller
{
  [ApiController]
  [Route("api/v1/player")]
  public class PlayerController : ControllerBase
  {
    private readonly GameTrackDbContext _context;
    private readonly IMapper _mapper;

    public PlayerController(GameTrackDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet("{id}")]
    public ActionResult<PlayerReadDto> GetPlayers(int id)
    {
      var players = _context.Players.FirstOrDefault(p => p.Id == id);

      if (players == null)
      {
        return NotFound();
      }

      return Ok(_mapper.Map<PlayerReadDto>(players));
    }
  }
}
