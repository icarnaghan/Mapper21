﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Mapper21.BE.Domain;
using Mapper21.DAL.Provider;
using Mapper21.UI.Models;

namespace Mapper21.UI.Controllers
{
    public class ServiceLearningController : BaseController
    {
        private readonly Mapper21Context db = new Mapper21Context();

        public ActionResult ServiceLearning_Read(int caseStudyId, [DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<ServiceLearning> serviceLearning = db.ServiceLearnings.Where(f => f.SubSectionId == caseStudyId);
            return Json(serviceLearning.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ServiceLearning_Create([DataSourceRequest] DataSourceRequest request,
            ServiceLearningViewModel serviceLearning)
        {
            if (ModelState.IsValid)
            {
                // Create a new Section entity and set its properties from the posted Section Model
                var entity = new ServiceLearning
                {
                    Id = serviceLearning.Id,
                    Name = serviceLearning.Name,
                    Description = serviceLearning.Description,
                    SubSectionId = serviceLearning.CaseStudyId
                };
                // Add the entity
                db.ServiceLearnings.Add(entity);
                // Insert the entities in the database
                db.SaveChanges();
                // Get the Id generated by the database
                serviceLearning.Id = entity.Id;
            }
            // Return the inserted entities. The grid needs the generated ID. Also return any validation errors.
            return Json(new[] {serviceLearning}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult ServiceLearning_Update([DataSourceRequest] DataSourceRequest request,
            ServiceLearningViewModel serviceLearning)
        {
            if (ModelState.IsValid)
            {
                // Create a new Product entity and set its properties from the posted Section Model
                var entity = new ServiceLearning
                {
                    Id = serviceLearning.Id,
                    Name = serviceLearning.Name,
                    Description = serviceLearning.Description,
                    SubSectionId = serviceLearning.CaseStudyId
                };
                // Attach the entity
                db.ServiceLearnings.Attach(entity);
                // Change its state to Modified so Entity Framework can update the existing product instead of creating a new one
                db.Entry(entity).State = EntityState.Modified;
                // Update the entity in the database
                db.SaveChanges();
            }
            // Return the updated entities. Also return any validation errors.
            return Json(new[] {serviceLearning}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult ServiceLearning_Destroy([DataSourceRequest] DataSourceRequest request,
            ServiceLearningViewModel serviceLearning)
        {
            if (ModelState.IsValid)
            {
                // Create a new Product entity and set its properties from the posted ProductViewModel
                var entity = new ServiceLearning
                {
                    Id = serviceLearning.Id,
                    Name = serviceLearning.Name,
                    Description = serviceLearning.Description,
                    SubSectionId = serviceLearning.CaseStudyId
                };

                // Attach the entity
                db.ServiceLearnings.Attach(entity);
                // Delete the entity
                db.ServiceLearnings.Remove(entity);
                // Delete the entity in the database
                db.SaveChanges();
            }
            // Return the removed product. Also return any validation errors.
            return Json(new[] {serviceLearning}.ToDataSourceResult(request, ModelState));
        }
    }
}