

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP_FinalExam_Net5.Controllers;
using ASP_FinalExam_Net5.Data;
using ASP_FinalExam_Net5.Models;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using ASP_FinalExam_Net5.Test;

namespace ASP_FinalExam_Net5.Test
{
    public class EmployeesControllerTest : BasicTest
    {
        [Fact]
        public async Task Index_Basic_Test()
        {
            using (var testDb = new ApplicationDbContext(this._opts))
            {
                var testCtrl = new EmployeesController(testDb);
                var res = await testCtrl.Index();
                var resVr = Assert.IsType<ViewResult>(res);
                Assert.IsAssignableFrom<IEnumerable<Employee>>(resVr.ViewData.Model);
            }
        }

        [Fact]
        public async Task Add_And_Remove_Test()
        {
            using (var testDb = new ApplicationDbContext(this._opts))
            {
                var testCtrl = new EmployeesController(testDb);
                var fakeJobs = MakeFakeJobs(3);

                // Adding Jobs
                foreach (var job in fakeJobs)
                {
                    var res = await testCtrl.Create(job);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }

                // Testing Saved Values
                var idxRes = await testCtrl.Index();
                var idxResVr = Assert.IsType<ViewResult>(idxRes);
                var returnedJobs = Assert.IsAssignableFrom<IEnumerable<Employee>>(idxResVr.ViewData.Model);
                foreach (var job in fakeJobs)
                {
                    Assert.Contains(job, returnedJobs);
                }

                // Removing All Existing Jobs
                foreach (var job in returnedJobs)
                {
                    var res = await testCtrl.DeleteConfirmed(job.id);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }
            }
        }
    }
}


