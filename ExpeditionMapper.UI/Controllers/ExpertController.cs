﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ExpeditionMapper.BE.Domain;
using ExpeditionMapper.DAL.Provider;
using ExpeditionMapper.UI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace ExpeditionMapper.UI.Controllers
{
    public class ExpertController : BaseController
    {
        private readonly ExpeditionContext db = new ExpeditionContext();

        public ActionResult Expert_Read(int caseStudyId, [DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<Expert> expert = db.Experts.Where(f => f.CaseStudyId == caseStudyId);
            return Json(expert.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Expert_Create([DataSourceRequest] DataSourceRequest request, ExpertViewModel expert)
        {
            if (ModelState.IsValid)
            {
                // Create a new Expedition entity and set its properties from the posted FallExpedition Model
                var entity = new Expert
                {
                    Id = expert.Id,
                    Name = expert.Name,
                    Description = expert.Description,
                    CaseStudyId = expert.CaseStudyId
                };
                // Add the entity
                db.Experts.Add(entity);
                // Insert the entities in the database
                db.SaveChanges();
                // Get the Id generated by the database
                expert.Id = entity.Id;
            }
            // Return the inserted entities. The grid needs the generated ID. Also return any validation errors.
            return Json(new[] {expert}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Expert_Update([DataSourceRequest] DataSourceRequest request, ExpertViewModel expert)
        {
            if (ModelState.IsValid)
            {
                // Create a new Product entity and set its properties from the posted ExpeditionViewModel
                var entity = new Expert
                {
                    Id = expert.Id,
                    Name = expert.Name,
                    Description = expert.Description,
                    CaseStudyId = expert.CaseStudyId
                };
                // Attach the entity
                db.Experts.Attach(entity);
                // Change its state to Modified so Entity Framework can update the existing product instead of creating a new one
                db.Entry(entity).State = EntityState.Modified;
                // Update the entity in the database
                db.SaveChanges();
            }
            // Return the updated entities. Also return any validation errors.
            return Json(new[] {expert}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Expert_Destroy([DataSourceRequest] DataSourceRequest request, ExpertViewModel expert)
        {
            if (ModelState.IsValid)
            {
                // Create a new Product entity and set its properties from the posted ProductViewModel
                var entity = new Expert
                {
                    Id = expert.Id,
                    Name = expert.Name,
                    Description = expert.Description,
                    CaseStudyId = expert.CaseStudyId
                };
                // Attach the entity
                db.Experts.Attach(entity);
                // Delete the entity
                db.Experts.Remove(entity);
                // Delete the entity in the database
                db.SaveChanges();
            }
            // Return the removed product. Also return any validation errors.
            return Json(new[] {expert}.ToDataSourceResult(request, ModelState));
        }
    }
}