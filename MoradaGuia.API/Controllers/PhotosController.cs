using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MoradaGuia.API.Data;
using MoradaGuia.API.Dtos;
using MoradaGuia.API.Helpers;
using MoradaGuia.API.Models;

namespace MoradaGuia.API.Controllers
{
    //[Authorize]
    [Route("api/imoveis/{imovelId}/photos")]
    public class PhotosController : ControllerBase
    {
        private readonly IMoradaRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PhotosController(IMoradaRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;
            _repo = repo;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret 
            );

            _cloudinary = new Cloudinary(acc);
        }

        [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<IActionResult> GetPhoto (int id)
        {
            var photoFromRepo = await _repo.GetPhoto(id);

            var photo = _mapper.Map<PhotoForReturnDto>(photoFromRepo);

            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForImovel(int imovelId, [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            {
                //if (imovelId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                //    return Unauthorized();

                var imovelFromRepo = await _repo.GetImovel(imovelId);

                var file = photoForCreationDto.File;
                var uploadResult = new ImageUploadResult();
                if(file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.Name, stream),
                            Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                        };
                        uploadResult = _cloudinary.Upload(uploadParams);
                    }
                }

                photoForCreationDto.Url = uploadResult.Uri.ToString();
                photoForCreationDto.PublicId = uploadResult.PublicId;

                var photo = _mapper.Map<Photo>(photoForCreationDto);

                if(!imovelFromRepo.Fotos.Any(i => i.Principal))
                    photo.Principal = true;

                imovelFromRepo.Fotos.Add(photo);


                if(await _repo.SaveAll())
                {
                    var photoToReturn = _mapper.Map<PhotoForReturnDto>(photo);

                    return CreatedAtRoute("GetPhoto", new {id = photo.Id}, photoToReturn);
                }

                return BadRequest("Não foi possível inserir esta imagem!");
            }
        }

        [HttpPost("{id}/principal")]
        public async Task<IActionResult> SetMainPhoto(int imovelId, int id)
        {
            //if (imovelId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //return Unauthorized();

            var imovel = await _repo.GetImovel(imovelId);

            if (!imovel.Fotos.Any(p => p.Id == id))
            {
                return Unauthorized();
            }
            var photoFromRepo = await _repo.GetPhoto(id);

            if (photoFromRepo.Principal)
                return BadRequest ("Esta já é a foto principal!");
            
            var currentMainPhoto = await _repo.GetMainPhotoForImovel(imovelId);
            currentMainPhoto.Principal = false;

            photoFromRepo.Principal = true;

            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest("Foto não pode ser a principal");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletePhoto(int imovelId, int id)
        {
            // if (imovelId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            // return Unauthorized();

            var imovel = await _repo.GetImovel(imovelId);

            if (!imovel.Fotos.Any(p => p.Id == id))
            {
                return Unauthorized();
            }
            var photoFromRepo = await _repo.GetPhoto(id);

            if (photoFromRepo.Principal)
                return BadRequest ("Foto principal não pode ser apagada!");

            if (photoFromRepo.Principal != true)
            {
                var deleteParams = new DeletionParams(photoFromRepo.PublicId);

                var result = _cloudinary.Destroy(deleteParams);

                if (result.Result == "ok") {
                    _repo.Delete(photoFromRepo);
                }

            }

            if (photoFromRepo.PublicId == null) {
                _repo.Delete(photoFromRepo);
            }

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Falha ao deletar a foto!");
        }

    }
}
