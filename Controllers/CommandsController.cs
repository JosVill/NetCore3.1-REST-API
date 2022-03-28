using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItem = _repository.GetAppCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItem));
            // return Ok(commandItem);
        }

        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<Command> GetCommandById(int id)
        {   
            var commandItem = _repository.GetCommandById(id);
            
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
            // return Ok(commandItem);
        }

        [HttpPut("{id}")]
        public ActionResult<Command> UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandItem = _repository.GetCommandById(id);

            if(commandItem == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandItem);
            _repository.UpdateCommand(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id= commandReadDto.Id }, commandReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult<Command> DeleteCommand(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if(commandItem == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}