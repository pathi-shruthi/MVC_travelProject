using MVC_TravelProject.Models;

namespace MVC_TravelProject.Repository
{
    public interface ITravelRequestRepository
    {
     

        IEnumerable<TravelRequest> GetRequests();

         public void RaiseRequest(TravelRequest request);

         public void DeleteRequest(int RequestedId);

          public void UpdateTravelRequest(TravelRequest request,int RequestedId);
      

        public TravelRequest GetTravelRequestById(int RequestedId);
        void ApproveTravelRequest(int RequestedId, string ApproveStatus);
        void BookingTravelRequest(int RequestedId, string BookingStatus);

    }
}
