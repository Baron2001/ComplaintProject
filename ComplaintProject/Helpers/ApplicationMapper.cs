using AutoMapper;
using ComplaintProject.Model;
using DomainLayer.Model;

namespace ComplaintProject.Helpers
{
    public class ApplicationMapper : Profile
    {
        public class AutoMapping : Profile
        {
            public AutoMapping()
            {
                CreateMap<Complaint, ComplaintModel>().ReverseMap(); 
            }
        }
    }
}
