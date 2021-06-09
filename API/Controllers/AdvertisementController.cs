using AutoMapper;
using Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdvertisementController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet, Route("api/[controller]")]
        public IActionResult GetAdvertisements()
        {
            try
            {
                return Ok(_unitOfWork.AdvertisementRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet, Route("api/[controller]/{id}")]
        public IActionResult GetAdvertisement(Guid id)
        {
            try
            {
                Advertisement adv = _unitOfWork.AdvertisementRepository.Get(id);
                if (adv == null)
                    return NotFound();
                
                return Ok(adv);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost, Route("api/member/{memberId}/[controller]")]
        public IActionResult AddAdvertisement(Guid memberId, Advertisement inModel)
        {
            try
            {
                if (inModel == null)
                    return BadRequest();
                inModel.MemberId = memberId;

                Advertisement outModel = _unitOfWork.AdvertisementRepository.Add(inModel);
                _unitOfWork.SaveChanges();
                return Ok(outModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut, Route("api/member/{memberId}/[controller]/{id}")]
        public IActionResult Update(Guid memberId, Guid id, Advertisement inModel)
        {
            try
            {
                if (inModel == null)
                    return BadRequest();

                inModel.MemberId = memberId;

                Advertisement outModel = _unitOfWork.AdvertisementRepository.Update(id, inModel);
                _unitOfWork.SaveChanges();
                return Ok(outModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete, Route("api/member/{memberId}/[controller]/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Advertisement adv = _unitOfWork.AdvertisementRepository.Get(id);

                if (adv == null)
                    return NotFound();

                _unitOfWork.AdvertisementRepository.Delete(adv);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
