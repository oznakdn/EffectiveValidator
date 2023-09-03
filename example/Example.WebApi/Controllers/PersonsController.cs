using Example.WebApi.Context;
using Example.WebApi.Dtos;
using Example.WebApi.Entity;
using Gleeman.EffectiveValidator.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPersons()
        {
            using var dbContext = new AppDbContext();
            var persons = dbContext.Persons.ToList();
            return Ok(persons);
        }

        [HttpPost]
        public IActionResult PostPerson(CreatePersonDto createPerson)
        {
            Person person = new()
            {
                FirstName = createPerson.FirstName,
                LastName = createPerson.LastName,
                DateOfBirth = createPerson.DateOfBirth,
                Age = createPerson.Age,
                Email = createPerson.Email,
                PhoneNumber = createPerson.PhoneNumber,
                CreditCartNumber = createPerson.CreditCartNumber,
                PassportNumber = createPerson.PassportNumber,
                ZipCode = createPerson.ZipCode,
                IsActive = createPerson.IsActive
            };

            var validator = new EffectiveValidator<CreatePersonDto>();
            var validationResult = validator.Validate(createPerson);
            if (validationResult.IsValid)
            {
                using var dbContext = new AppDbContext();
                dbContext.Persons.Add(person);
                dbContext.SaveChanges();
                return Created("", createPerson);
            }

            return BadRequest(validationResult.ErrorMessages);
        }
    }
}
