﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ExpeditionMapper.DAL;
using ExpeditionMapper.Models.Domain;
using ExpeditionMapper.Models.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace ExpeditionMapper.Controllers
{
    public class StaStandardController : BaseController
    {
        private readonly ExpeditionContext db = new ExpeditionContext();

        public ActionResult StaStandard_Read(int standardTargetAssessmentId, [DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<Standard> staStandards = db.Standards.Where(s => s.StandardTargetAssessmentId == standardTargetAssessmentId);
            return Json(staStandards.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StaStandard_Create([DataSourceRequest] DataSourceRequest request,
            StandardViewModel staStandard)
        {
            if (ModelState.IsValid)
            {
                // Create a new Expedition entity and set its properties from the posted FallExpedition Model
                var entity = new Standard
                {
                    Id = staStandard.Id,
                    Description = staStandard.Description,
                    StandardTargetAssessmentId = staStandard.StandardTargetAssessmentId
                };
                // Add the entity
                db.Standards.Add(entity);
                // Insert the entities in the database
                db.SaveChanges();
                // Get the Id generated by the database
                staStandard.Id = entity.Id;
            }
            // Return the inserted entities. The grid needs the generated ID. Also return any validation errors.
            return Json(new[] {staStandard}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult StaStandard_Update([DataSourceRequest] DataSourceRequest request,
            StandardViewModel staStandard)
        {
            if (ModelState.IsValid)
            {
                // Create a new Product entity and set its properties from the posted ExpeditionViewModel
                var entity = new Standard
                {
                    Id = staStandard.Id,
                    Description = staStandard.Description,
                    StandardTargetAssessmentId = staStandard.StandardTargetAssessmentId
                };
                // Attach the entity
                db.Standards.Attach(entity);
                // Change its state to Modified so Entity Framework can update the existing product instead of creating a new one
                db.Entry(entity).State = EntityState.Modified;
                // Update the entity in the database
                db.SaveChanges();
            }
            // Return the updated entities. Also return any validation errors.
            return Json(new[] {staStandard}.ToDataSourceResult(request, ModelState));
        }

        //public ActionResult ExpeditionHabit_Destroy(int expeditionId, [DataSourceRequest] DataSourceRequest request,
        //    ExpeditionHabitViewModel expeditionHabit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Create a new Product entity and set its properties from the posted ProductViewModel
        //        var entity = new ExpeditionHabit
        //        {
        //            Id = expeditionHabit.Id,
        //            Habit = expeditionHabit.Habit,
        //            Rationale = expeditionHabit.Rationale,
        //            ExpeditionId = expeditionHabit.ExpeditionId
        //        };
        //        // Attach the entity
        //        db.ExpeditionHabits.Attach(entity);
        //        // Delete the entity
        //        db.ExpeditionHabits.Remove(entity);
        //        // Delete the entity in the database
        //        db.SaveChanges();
        //    }
        //    // Return the removed product. Also return any validation errors.
        //    return Json(new[] {expeditionHabit}.ToDataSourceResult(request, ModelState));
        //}
    }
}