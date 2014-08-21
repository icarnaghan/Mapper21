﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Mapper21.BE.Domain;
using Mapper21.DAL.Provider;
using Mapper21.UI.Models;

namespace Mapper21.UI.Controllers
{
    public class ScienceBigIdeaController : BaseController
    {
        private readonly Mapper21Context db = new Mapper21Context();

        public ActionResult ScienceBigIdea_Read(Guid sectionId, [DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<SectionScienceBigIdea> scienceBigIdeas = db.SectionScienceBigIdeas.Where(b => b.SectionId == sectionId);
            return Json(scienceBigIdeas.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ScienceBigIdea_Create([DataSourceRequest] DataSourceRequest request,
            ScienceBigIdeaViewModel scienceBigIdea)
        {
            if (ModelState.IsValid)
            {
                // Create a new Section entity and set its properties from the posted Section Model
                var entity = new SectionScienceBigIdea
                {
                    Id = scienceBigIdea.Id,
                    BigIdeaForScienceId = scienceBigIdea.BigIdeaForScienceId,
                    Context = scienceBigIdea.Context,
                    SectionId = scienceBigIdea.SectionId
                };
                // Add the entity
                db.SectionScienceBigIdeas.Add(entity);
                // Insert the entities in the database
                db.SaveChanges();
                // Get the Id generated by the database
                scienceBigIdea.Id = entity.Id;
            }
            // Return the inserted entities. The grid needs the generated ID. Also return any validation errors.
            return Json(new[] {scienceBigIdea}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult ScienceBigIdea_Update([DataSourceRequest] DataSourceRequest request,
            ScienceBigIdeaViewModel scienceBigIdea)
        {
            if (ModelState.IsValid)
            {
                // Create a new Product entity and set its properties from the posted Section Model
                var entity = new SectionScienceBigIdea
                {
                    Id = scienceBigIdea.Id,
                    BigIdeaForScienceId = scienceBigIdea.BigIdeaForScienceId,
                    Context = scienceBigIdea.Context,
                    SectionId = scienceBigIdea.SectionId
                };
                // Attach the entity
                db.SectionScienceBigIdeas.Attach(entity);
                // Change its state to Modified so Entity Framework can update the existing product instead of creating a new one
                db.Entry(entity).State = EntityState.Modified;
                // Update the entity in the database
                db.SaveChanges();
            }
            // Return the updated entities. Also return any validation errors.
            return Json(new[] {scienceBigIdea}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult ScienceBigIdea_Destroy([DataSourceRequest] DataSourceRequest request,
            ScienceBigIdeaViewModel scienceBigIdea)
        {
            if (ModelState.IsValid)
            {
                // Create a new Product entity and set its properties from the posted ProductViewModel
                var entity = new SectionScienceBigIdea
                {
                    Id = scienceBigIdea.Id,
                    BigIdeaForScienceId = scienceBigIdea.BigIdeaForScienceId,
                    Context = scienceBigIdea.Context,
                    SectionId = scienceBigIdea.SectionId
                };
                // Attach the entity
                db.SectionScienceBigIdeas.Attach(entity);
                // Delete the entity
                db.SectionScienceBigIdeas.Remove(entity);
                // Delete the entity in the database
                db.SaveChanges();
            }
            // Return the removed product. Also return any validation errors.
            return Json(new[] {scienceBigIdea}.ToDataSourceResult(request, ModelState));
        }
    }
}