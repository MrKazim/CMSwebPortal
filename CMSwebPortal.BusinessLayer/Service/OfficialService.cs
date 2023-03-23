using CMSwebPortal.BusinessLayer.IService;
using CMSwebPortal.DataLayer.Infrastructure.IRepository;
using CMSwebPortal.Models.DbModels;
using CMSwebPortal.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.BusinessLayer.Service
{
    public class OfficialService:IOfficialService
    {
        private readonly IOfficialRepository _officialRepository;

        public OfficialService(IOfficialRepository officialRepository)
        {
            _officialRepository = officialRepository;
        }

        public async Task<GenericApiResponse<Official>> AddOfficial(Official tbl)
        {
            var res = await _officialRepository.AddOfficial(tbl);

            return GenericApiResponse<Official>.Success(new Official
            {
                Id = tbl.Id,
                Name = tbl.Name,
                Position = tbl.Position,
                Message = tbl.Message
                //    FullName = String.Concat(user.FirstName, ' ', user.LastName),
                //UserName = user.UserName,
                //Email = user.Email,
                //WalletAddress = user.UserDapperAddress,
                //IsPrivacyPolicyAccepted = user.IsPrivacyPolicyAccepted,
                //UserProfileAvatar = user.ProfilePictureAvatar,
                //CreatedDate = user.CreatedDate
            }, "Record Add Sucessfully");
        }

        public async Task<GenericApiResponse<Official>> DeleteOfficial(int id)
        {
            var res = await _officialRepository.DeleteOfficial(id);
            
            return GenericApiResponse<Official>.Success(new Official
            {
               Id =id
            }, "Record Delete Sucessfully");
        }

        public async Task<GenericApiResponse<Official>> GetOfficialById(int id)
        {
            var res = await _officialRepository.GetOfficialById(id);
            
            return GenericApiResponse<Official>.Success(new Official
            {
                Id = id
            }, "Get Record by " +id);
        }

        public async Task<IEnumerable<Official>> GetOfficials()
        {
           return await _officialRepository.GetOfficials();
           
        }

        public async Task<IEnumerable<Official>> SearchOfficial(string name)
        {
            return await _officialRepository.SearchOfficial(name);
        }

        public async Task<GenericApiResponse<Official>> UpdateOfficial(Official tbl)
        {
           var res = await _officialRepository.UpdateOfficial(tbl);
            return GenericApiResponse<Official>.Success(new Official
            {
                Id = tbl.Id,
                Name = tbl.Name,
                Position = tbl.Position,
                Message = tbl.Message
                
            }, "Record Update Sucessfully");
        }
    }
}
