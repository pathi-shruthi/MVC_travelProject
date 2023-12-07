using Microsoft.EntityFrameworkCore;
using MVC_TravelProject.Models;

namespace MVC_TravelProject.Repository
{
    public class TravelRequestRepository : ITravelRequestRepository
    {
        private readonly travelRequestContext _context;

        public TravelRequestRepository(travelRequestContext context)
        {
            _context = context;
        }
        public IEnumerable<TravelRequest> GetRequests()
        {
            // IEnumerable<TravelRequest> request = _context.TravelRequests.Include(x => x.Employee);
            return _context.TravelRequests;
        }
        public void RaiseRequest(TravelRequest request) 
        {

            if(request != null)
            {
                //request.ApproveStatus = "Pending";
               // request.BookingStatus = "Pending";
                // request.CurrentStatus = "open";

             _context.TravelRequests.Add(request);
                _context.SaveChanges();
            
            
            }
        
        }

        public void DeleteRequest(int RequestedId)
        {

           TravelRequest? request = _context.TravelRequests.FirstOrDefault(x=>x.RequestedId == RequestedId);
            if(RequestedId != null) 
            {
                _context.TravelRequests.Remove(request);
                _context.SaveChanges();
            }
        }
        public TravelRequest GetTravelRequest(int RequestedId)
        {
            TravelRequest? request = _context.TravelRequests.FirstOrDefault(x => x.RequestedId == RequestedId);
            return request;
        }
        public TravelRequest GetTravelRequestById(int RequestedId)
        {
            TravelRequest? travel = _context.TravelRequests.FirstOrDefault(x => x.RequestedId == RequestedId);
            return travel;
        }

        public void UpdateTravelRequest(TravelRequest request, int RequestedId)
        {
            TravelRequest? request_old = _context.TravelRequests.FirstOrDefault(x => x.RequestedId == RequestedId);
            if (request_old != null)
            {
                request_old.RequestedId = request.RequestedId;
                request_old.EmployeeId = request.EmployeeId;
                request_old.FromLocation = request.FromLocation;
                request_old.ToLocation = request.ToLocation;
                request_old.RequestDate = request.RequestDate;

                _context.SaveChanges();

            }

        }
        public void ApproveTravelRequest(int RequestedId, string ApproveStatus)
        {
            TravelRequest tr = _context.TravelRequests.FirstOrDefault(x => x.RequestedId == RequestedId);

            if (tr != null)
            {
                tr.ApproveStatus = ApproveStatus;
                if (tr.ApproveStatus == "NotApproved")
                {
                    tr.CurrentStatus = "Close";
                   
                }
                _context.SaveChanges();

            }
        }
        public void BookingTravelRequest(int RequestedId, string BookingStatus)
        {

            TravelRequest? tr = _context.TravelRequests.FirstOrDefault(x => x.RequestedId == RequestedId);

            if (tr != null)
            {

                tr.BookingStatus = BookingStatus;
                tr.CurrentStatus = "Close";
                _context.SaveChanges(true);

            }

        }


    }
}

