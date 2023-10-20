using AutoMapper;
using BookStore.Api.Applications.AuthorOperations.Commands.CreateAuthor;
using BookStore.Api.Applications.AuthorOperations.Commands.DeleteAuthor;
using BookStore.Api.Applications.AuthorOperations.Commands.UpdateAuthor;
using BookStore.Api.Applications.AuthorOperations.Queries.GetAuthorById;
using BookStore.Api.Applications.AuthorOperations.Queries.GetAuthors;
using BookStore.Api.DbOperations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly Context _dbContext;
        private readonly IMapper _mapper;

        public AuthorsController(Context dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_dbContext, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(_dbContext, _mapper);
            query.AuthorId = id;
            GetAuthorByIdQueryValidator validator = new GetAuthorByIdQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

        //[HttpGet]
        //public Author Get([FromQuery] string id)
        //{
        //    var result = AuthorList.Where(x => x.Id == Convert.ToInt32(id)).SingleOrDefault();

        //    return result;
        //}

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel request)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_dbContext, _mapper);
            try
            {
                command.Model = request;
                CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
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
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_dbContext);
            try
            {
                command.Model = updatedAuthor;
                command.AuthorId = id;
                UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
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
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_dbContext);
            try
            {
                command.AuthorId = id;
                DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
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
