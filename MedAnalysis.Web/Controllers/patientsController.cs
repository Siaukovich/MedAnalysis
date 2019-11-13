using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using MedAnalysis.Core.Interfaces;
using MedAnalysis.Core.Models;

namespace MedAnalysis.Web.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IAnalysisService _service;

        public PatientsController(IAnalysisService service)
        {
            _service = service;
        }

        // GET: patients
        public async Task<ActionResult> Index()
        {
            var patients = await _service.GetPatientsAsync();
            return View(patients.ToList());
        }

        // GET: patients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var patient = await _service.GetPatientAsync(id.Value);
            if (patient == null)
            {
                return HttpNotFound();
            }

            return View(patient);
        }

        // GET: patients/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Birthdate")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                await _service.InsertPatientAsync(patient);
                return RedirectToAction("Index");
            }

            return View(patient);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAnalysis([Bind(Include = "Id,Name,Result,TakenAt")] AnalysisResult analysisResult)
        {
            if (ModelState.IsValid)
            {
                await _service.InsertAnalysisAsync(analysisResult);
                return RedirectToAction("Index");
            }

            return View(analysisResult);
        }

        // GET: patients/CreateAnalysis/5
        public ActionResult CreateAnalysis(int? patientId)
        {
            if (patientId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var analysis = new AnalysisResult { PatientId = patientId.Value };
            return View(analysis);
        }
    }
}
