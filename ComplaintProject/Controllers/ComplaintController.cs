using AutoMapper;
using ComplaintProject.Model;
using DomainLayer.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Contract;

namespace ComplaintProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly IGeneric<Complaint> _complaint;
        private readonly IMapper _mapper;
        public ComplaintController(IGeneric<Complaint> complaint, IMapper mapper)
        {
            _complaint = complaint;
            _mapper = mapper;
        }
        /// <summary>
        /// For Get All Complaint And I will consider that when I send adminId, I will consider it as a login As Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllComplaint")]
        public async Task<List<ComplaintModel>> GetAllAsync(long? userId = 0, long? adminId = 0)
        {
            try
            {
                var model = await _complaint.GetAllAsync(userId, adminId);
                return _mapper.Map<List<ComplaintModel>>(model);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        /// <summary>
        /// For Get Complaint By Complaint Id   
        /// </summary>
        /// <param name="Id">Complaint Id And This Id is A primary Key</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetComplaintById")]
        public async Task<ComplaintModel> GetByIdAsync(long Id)
        {
            try
            {
                var model = await _complaint.GetByIdAsync(Id);
                return _mapper.Map<ComplaintModel>(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// For Create A new Complaint
        /// </summary>
        /// <param name="model">this model is received From Client Side</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateComplaint")]
        public async Task<ComplaintModel> CreateAsync([FromForm] ComplaintModel model)
        {
            try
            {
                var modelMapper = _mapper.Map<Complaint>(model);
                var complaint = await _complaint.CreateAsync(modelMapper);
                return _mapper.Map<ComplaintModel>(complaint);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// For Update Complaint Data
        /// </summary>
        /// <param name="model">this model is received From Client Side</param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateComplaint")]
        public async Task<ComplaintModel> UpdateAsync([FromForm] ComplaintModel model)
        {
            try
            {
                if (model.UserId != null)
                {
                    var modelMapper = _mapper.Map<Complaint>(model);
                    var complaint = await _complaint.UpdateAsync(modelMapper);
                    return _mapper.Map<ComplaintModel>(complaint);
                }
                else
                {
                    return new ComplaintModel();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// for Update Status from the admin
        /// </summary>
        /// <param name="complaintId"></param>
        /// <param name="newStatusId"></param>
        /// <param name="adminId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateComplaintStatus")]
        public async Task<ComplaintModel> UpdateStatusAsync(long complaintId, int newStatusId, long adminId)
        {
            try
            {
                if (complaintId > 0 && (newStatusId == 2 || newStatusId == 3))
                {
                    //var modelMapper = _mapper.Map<Complaint>(model);
                    var complaint = await _complaint.UpdateStatusAsync(complaintId, newStatusId, adminId);
                    return _mapper.Map<ComplaintModel>(complaint);
                }
                else
                {
                    return new ComplaintModel();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// for change is delete to true
        /// </summary>
        /// <param name="Id">Complaint Id </param>
        /// <returns></returns>
        [HttpPut]
        [Route("DeleteComplaint")]
        public async Task<long> DeleteAsync(long Id)
        {
            try
            {
                var model = await _complaint.DeleteAsync(Id);
                if (model.ComplaintId != 0)
                {
                    return Id;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
