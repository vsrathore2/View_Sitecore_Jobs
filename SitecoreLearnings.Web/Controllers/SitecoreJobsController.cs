using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitecoreLearnings.Web.Controllers
{
    public class SitecoreJobsController : Controller
    {
        public ActionResult GetSitecoreJobs(string showAll)
        {
            List<SCJob> listSCJob = new List<SCJob>();

            if (!string.IsNullOrEmpty(showAll))
            {
                var jobs = GetJobs(showAll);
                foreach (var job in jobs)
                {
                    listSCJob.Add(new SCJob(job));
                }
            }

            return Json(listSCJob, JsonRequestBehavior.AllowGet);
        }

        public List<Sitecore.Jobs.Job> GetJobs(string showAll)
        {
            List<Sitecore.Jobs.Job> jobs = new List<Sitecore.Jobs.Job>();

            if (showAll.Equals("false"))
            {

                jobs = Sitecore.Jobs.JobManager.GetJobs().Where(i => i.IsDone == false).OrderBy(i => i.QueueTime).ToList();
            }
            else if (showAll.Equals("true"))
            {
                jobs = Sitecore.Jobs.JobManager.GetJobs().OrderBy(i => i.QueueTime).ToList();

            }

            return jobs;
        }

        /// <summary>
        /// Utility class
        /// </summary>
        public class SCJob
        {
            public string JobName { get; set; }
            public string JobStatus { get; set; }
            public string JobQueueTime { get; set; }
            public string JobCategory { get; set; }
            // To bind this class object to ListControl
            public string ItemId { get; set; }

            public SCJob(Sitecore.Jobs.Job job)
            {
                // TODO: Complete member initialization
                JobName = job.Name;
                JobCategory = job.Category;
                JobStatus = job.Status.State.ToString();
                JobQueueTime = job.QueueTime.ToLocalTime().ToString();
                ItemId = "itemId";
            }
        }
    }
}