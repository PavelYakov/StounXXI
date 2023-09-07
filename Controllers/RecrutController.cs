using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using StounXXI.Models;

namespace StounXXI.Controllers
{
    public class RecrutController : Controller
    {
        private readonly ApplicationContext _context;
        public RecrutController(ApplicationContext context)
        {
            _context = context;
        }
      

        // Метод для перевода кандидата на следующий этап
        public IActionResult MoveToNextStage(int candidateId)
        {
            
            var candidate = _context.GetCandidateById(candidateId);

            if (candidate == null)
            {
                return NotFound(); 
            }

           
            candidate.Status = NextStage(candidate.Status); 

            
            _context.Update(candidate);

            // Обновление мотивации HR специалистов 
            UpdateHrMotivation();

            return RedirectToAction(nameof(Index), new { id = candidateId });
        }

        // Определение следующего этапа
        private CandidateStatus NextStage(CandidateStatus currentStatus)
        {
            switch (currentStatus)
            {
                case CandidateStatus.ResumeReceived:
                    return CandidateStatus.InterviewScheduled;
                case CandidateStatus.InterviewScheduled:
                    return CandidateStatus.TechnicalTest;
                case CandidateStatus.TechnicalTest:
                    return CandidateStatus.HRInterview;
                case CandidateStatus.HRInterview:
                    return CandidateStatus.OfferExtended;
                case CandidateStatus.OfferExtended:
                    return CandidateStatus.Hired;
                case CandidateStatus.Hired:
                    return CandidateStatus.Onboarded;
                default:
                    return currentStatus; 
            }

            
        }

        // Метод для обновления мотивации HR специалистов
        private void UpdateHrMotivation()
        {
            
        }

    }
}
