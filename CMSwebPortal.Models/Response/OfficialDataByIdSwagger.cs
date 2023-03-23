using CMSwebPortal.Models.DbModels;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.Models.Response
{
    public class OfficialDataByIdSwagger : IExamplesProvider<Official>
    {
        public Official GetExamples()
        {
            return new Official()
            {
                Id = 5,
                Name = "kazim",
                Position = "Full Stack Developer",
                Message = "Hello this is testing for official swagger documentation",
                Path = "image path",
                Contact = "03130682985",
                isHome = true,
                From = "codeprogammer88@gmail.com",
                To = "encodingmaster786@gmail.com",
                Type = "any",
                CreatedBy = "nothing",
                ModifiedBy = "nothing",
                CreatedDate = null,
                ModifiedDate = null,
                IsActive = true
            };
        }
    }
}
