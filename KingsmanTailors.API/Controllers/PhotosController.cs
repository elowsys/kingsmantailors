using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using KingsmanTailors.API.Dtos;
using KingsmanTailors.API.Helpers;
using KingsmanTailors.API.Interfaces;
using KingsmanTailors.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace KingsmanTailors.API.Controllers
{
    [Authorize]
    [Route("api/photos/")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IRepository<User> _userRepo;

        private readonly IRepository<Suit> _suitRepo;

        private readonly IRepository<SuitPhoto> _suitPhotoRepo;

        private readonly IRepository<UserRole> _userRole;
        private readonly IRepository<Role> _role;
        private readonly IMapper _mapper;

        private readonly IOptions<CloudinarySettings> _cloudinaryOptions;

        private readonly Cloudinary _cloudinary;

        public PhotosController(
            IRepository<User> userRepo,
            IRepository<UserRole> userRole,
            IRepository<Suit> suitRepo,
            IRepository<SuitPhoto> suitPhotoRepo,
            IRepository<Role> role,
            IMapper mapper,
            IOptions<CloudinarySettings> cloudinaryOptions)
        {
            _userRepo = userRepo;
            _suitRepo = suitRepo;
            _suitPhotoRepo = suitPhotoRepo;
            _userRole = userRole;
            _role = role;
            _mapper = mapper;
            _cloudinaryOptions = cloudinaryOptions;

            //create new Cloudinary account object
            var acct = new Account
            {
                ApiKey = _cloudinaryOptions.Value.ApiKey,
                ApiSecret = _cloudinaryOptions.Value.ApiSecret,
                Cloud = _cloudinaryOptions.Value.CloudName
            };

            // create new cloudinary object from account
            _cloudinary = new Cloudinary(acct);
        }

        [HttpGet("user/{id}", Name = "GetUserPhoto")]
        public async Task<IActionResult> GetUserPhoto(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var fromDb = await _userRepo.Find(x => x.UserId == id);
            if (fromDb != null)
            {
                var result = _mapper.Map<UserForDetailedDto>(fromDb);
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("suit/{id}", Name = "GetSuitPhoto")]
        public async Task<IActionResult> GetSuitPhoto(int id)
        {
            var fromDb = await _suitPhotoRepo.Find(x => x.Id == id);
            if (fromDb != null)
            {
                // get the photo from cloudinary
                var photo = _mapper.Map<PhotoForReturnDto>(fromDb);
                if (photo != null)
                {
                    return Ok(photo);
                }
            }

            return NotFound();
        }


        [HttpPost("user/{id}")]
        public async Task<IActionResult> AddPhotoToUser(string id, [FromForm]PhotoForCreateDto photoForCreate)
        {
            var editorRole = await isValidEditor();
            if (editorRole == null)
            {
                return Unauthorized();
            }

            var fromDb = await _userRepo.Find(x => x.UserId == id);
            if (fromDb != null)
            {
                // assume all is well for starters
                var success = false;

                var file = photoForCreate.File;
                var uploadResult = new ImageUploadResult();
                // did the user upload anything?
                if (file != null && file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams
                        {
                            File = new FileDescription(file.Name, stream),
                            Folder = "users",
                            Transformation = new Transformation()
                            .Width(120)
                            .Height(120)
                            .Crop("fill")
                            .Gravity("face")
                        };
                        uploadResult = _cloudinary.Upload(uploadParams);
                    }
                    // if successfull
                    if (!string.IsNullOrEmpty(uploadResult.PublicId))
                    {
                        photoForCreate.Url = uploadResult.Uri.ToString();
                        photoForCreate.PublicId = uploadResult.PublicId;
                        // photoForCreate.InternalId = uid;

                        // could have used mapper also
                        fromDb.PublicId = uploadResult.PublicId;
                        fromDb.Url = photoForCreate.Url;
                        success = await _userRepo.SaveAll();
                    }
                }

                if (success)
                {
                    return CreatedAtRoute("GetUserPhoto", new { id = id });
                }
            }
            return BadRequest("Failed to complete photo add to user");
        }

        [HttpPost("suit/{id}")]
        public async Task<IActionResult> AddPhotoToSuit(int id, PhotoForCreateDto photoForCreate)
        {
            var editorRole = await isValidEditor();
            if (editorRole == null)
            {
                return Unauthorized();
            }

            var fromDb = await _suitRepo.Find(x => x.SuitId == id);
            if (fromDb != null)
            {
                // assume all is well for starters
                var success = false;

                var file = photoForCreate.File;
                var uploadResult = new ImageUploadResult();
                // did the user upload anything?
                SuitPhoto photo = null;
                if (file != null && file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams
                        {
                            File = new FileDescription(file.Name, stream),
                            Folder = "suits",
                            Transformation = new Transformation()
                            .Width(180)
                            .Height(180)
                            .Crop("fill")
                            // .Gravity("face")
                        };
                        uploadResult = _cloudinary.Upload(uploadParams);
                    }
                    // if successfull
                    if (!string.IsNullOrEmpty(uploadResult.PublicId))
                    {
                        photoForCreate.Url = uploadResult.Uri.ToString();
                        photoForCreate.PublicId = uploadResult.PublicId;
                        photoForCreate.InternalId = id;
                        // // Use mapper to transfer map for updating
                        photo = _mapper.Map<SuitPhoto>(photoForCreate);

                        // set first upload as default
                        if (!await _suitPhotoRepo.Any(x => x.SuitId == id))
                        {
                            photo.IsDefault = true;
                        }

                        // on success then add to user
                        _suitPhotoRepo.Add<SuitPhoto>(photo);
                        success = await _suitPhotoRepo.SaveAll();
                    }
                }
                if (success)
                {
                    var returnPhoto = _mapper.Map<PhotoForReturnDto>(photo);
                    return CreatedAtRoute("GetSuitPhoto", new { id = photo.Id }, returnPhoto);
                }
            }
            return BadRequest("Failed to complete add photo to suit");
        }

        private async Task<Role> isValidEditor()
        {
            // make sure that we have the user making the changes and that user is allowed to make changes
            var editorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (editorId == 0)
            {
                return null;
            }

            // make sure that this user is of admin role
            var editor = await _userRepo.Get(editorId);
            if (editor == null)
            {
                return null;
            }

            // get the role
            var editorRole = await _userRole.Find(x => x.UserId == editor.UserId);
            if (editorRole == null)
            {
                return null;
            }

            // is the user roleId id greater than user being updated
            return await _role.Find(x => x.RoleId == editorRole.RoleId);
        }
    }
}
