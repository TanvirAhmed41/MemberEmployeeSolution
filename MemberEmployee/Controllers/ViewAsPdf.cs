using MemberEmployee.Models.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MemberEmployee.Controllers
{
    internal class ViewAsPdf : ActionResult
    {
        private string v;
        private List<Member> members;

        public ViewAsPdf(string v, List<Member> members)
        {
            this.v = v;
            this.members = members;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}