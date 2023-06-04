﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using USOS.Entities;
using USOS.Models;
using USOS.Services;

namespace USOS.Controllers
{
    [Route("api/lecturer")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly ILecturerService _lecturerService;

        public LecturerController(ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Lecturer>> GetAll()
        {
            var lecturer = _lecturerService.GetAll();
            return Ok(lecturer);
        }
        [HttpGet("{id}")]
        public ActionResult<Lecturer> GetById([FromRoute] int id)
        {
            var lecturer = _lecturerService.GetById(id);
            return Ok(lecturer);
        }
        [HttpPost]
        public ActionResult Add([FromBody] LecturerAdd lecturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _lecturerService.Add(lecturer);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Del([FromRoute] int id)
        {
            _lecturerService.Del(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] LecturerUpdate lecturer)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            var result = _lecturerService.Update(id, lecturer);
            if (result) return NoContent();
            return NotFound();
        }
    }
}