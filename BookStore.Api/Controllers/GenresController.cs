using AutoMapper;
using BookStore.Api.Applications.GenreOperations.Commands.CreateGenre;
using BookStore.Api.Applications.GenreOperations.Commands.DeleteGenre;
using BookStore.Api.Applications.GenreOperations.Commands.UpdateGenre;
using BookStore.Api.Applications.GenreOperations.Queries.GetGenreById;
using BookStore.Api.Applications.GenreOperations.Queries.GetGenres;
using BookStore.Api.DbOperations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenresController(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_dbContext, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(_dbContext, _mapper);
            query.GenreId = id;
            GetGenreByIdQueryValidator validator = new GetGenreByIdQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

        //[HttpGet]
        //public Genre Get([FromQuery] string id)
        //{
        //    var result = GenreList.Where(x => x.Id == Convert.ToInt32(id)).SingleOrDefault();

        //    return result;
        //}

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel request)
        {
            CreateGenreCommand command = new CreateGenreCommand(_dbContext, _mapper);
            try
            {
                command.Model = request;
                CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updatedGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_dbContext);
            try
            {
                command.Model = updatedGenre;
                command.GenreId = id;
                UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_dbContext);
            try
            {
                command.GenreId = id;
                DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
