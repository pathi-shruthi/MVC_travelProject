using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using MVC_TravelProject.Models;
using MVC_TravelProject.Repository;
using System.Runtime.ConstrainedExecution;

namespace MVC_TravelProject.Controllers
{
    public class TravelRequestController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITravelRequestRepository _travelRepository;
        public TravelRequestController(IEmployeeRepository employeeRepository, ITravelRequestRepository travelRepository)
        {
            _employeeRepository = employeeRepository;
            _travelRepository = travelRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<TravelRequest> req = _travelRepository.GetRequests();
            return View(req);
        }
        public IActionResult RaiseRequest()
        {

            var employees = _employeeRepository.GetEmployees()
                .Select(e => new
                {
                    EmployeeId = e.EmployeeId,
                    FullName = $"{e.FirstName} {e.LastName}"
                });

            ViewBag.Employees = new SelectList(employees, "EmployeeId", "FullName");
            return View();
        }

            
        


        
        [HttpPost]
        public IActionResult RaiseRequest(TravelRequest request) 
        {
            if(ModelState.IsValid) 
            {
            
            _travelRepository.RaiseRequest(request);
            }
            return RedirectToAction("Index");
        
        }
        public IActionResult DeleteRequest(int RequestedId)
        {
            _travelRepository.DeleteRequest(RequestedId);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateTravelRequest(int RequestedId)
        {
            TravelRequest? travel = _travelRepository.GetTravelRequestById(RequestedId);
            
            var employees = _employeeRepository.GetEmployees()
                   .Select(e => new
                   {
                       EmployeeId = e.EmployeeId,
                       FullName = $"{e.FirstName} {e.LastName}"
                   });
            ViewBag.Employees = new SelectList(employees, "EmployeeId", "FullName");
            if (travel != null)
            {
                return View(travel);
            }
            return RedirectToAction("Index");
        }
           
        

        [HttpPost]
        public IActionResult UpdateTravelRequest(TravelRequest travel, int RequestedId)
        {
            if (ModelState.IsValid)
            {
                _travelRepository.UpdateTravelRequest(travel, RequestedId);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ApproveTravelRequest(int RequestedId)
        {
            TravelRequest tr = _travelRepository.GetTravelRequestById( RequestedId);
            return View(tr);
        }

        [HttpPost]
        public IActionResult ApproveTravelRequest(int RequestedId, string ApproveStatus)
        {
            if (ModelState.IsValid)
            {
                _travelRepository.ApproveTravelRequest(RequestedId, ApproveStatus);
            }
            return RedirectToAction("Index");
        }

        public IActionResult BookingTravelRequest(int RequestedId)
        {
            TravelRequest tr = _travelRepository.GetTravelRequestById(RequestedId);
            return View(tr);
        }

        [HttpPost]
        public IActionResult BookingTravelRequest(int RequestedId, string BookingStatus)
        {
            if (ModelState.IsValid)
            {
                _travelRepository.BookingTravelRequest(RequestedId, BookingStatus);
            }
            return RedirectToAction("Index");
        }

    }
}
