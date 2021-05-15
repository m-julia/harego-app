using API.DTO;
using AutoMapper;
using Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMembers()
        {
            try
            {
                return Ok(_unitOfWork.MemberRepository.GetAll());
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMember(Guid id)
        {
           try
           {
                var member = _unitOfWork.MemberRepository.Get(id);

                if (member == null)
                    return NotFound();
                
                return Ok(member);
           }
           catch (Exception ex)
           {
                return StatusCode(500, ex);
           }            
        }

        [HttpPost]
        public IActionResult AddMember(Member inModel)
        {
            try
            {
                if (inModel == null)
                    return BadRequest();

                Member outModel = _unitOfWork.MemberRepository.Add(inModel);
                _unitOfWork.SaveChanges();

                return Ok(outModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public IActionResult UpdateMember(Member inModel)
        {
            try
            {
                if (inModel == null)
                    return BadRequest();

                Member outModel = _unitOfWork.MemberRepository.Update(inModel);
                _unitOfWork.SaveChanges();
                return Ok(outModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(Guid id)
        {
            try
            {
                var member = _unitOfWork.MemberRepository.Get(id);

                if (member == null)
                    return NotFound();

                _unitOfWork.MemberRepository.Delete(member);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
