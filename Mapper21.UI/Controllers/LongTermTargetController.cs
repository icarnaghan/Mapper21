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
    public class LongTermTargetController : BaseController
    {
        private readonly Mapper21Context db = new Mapper21Context();

        public ActionResult LongTermTarget_Read(int staCollectionId, [DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<SubSectionLongTermTarget> longTermTargets =
                db.LongTermTargets.Where(h => h.StaCollectionId == staCollectionId);
            return Json(longTermTargets.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LongTermTarget_Create([DataSourceRequest] DataSourceRequest request,
            LongTermTargetViewModel longTermTarget)
        {
            if (ModelState.IsValid)
            {
                // Create a new Section entity and set its properties from the posted Section Model
                var entity = new SubSectionLongTermTarget
                {
                    Id = longTermTarget.Id,
                    Name = longTermTarget.Name,
                    StaCollectionId = longTermTarget.StaCollectionId
                };
                // Add the entity
                db.LongTermTargets.Add(entity);
                // Insert the entities in the database
                db.SaveChanges();
                // Get the Id generated by the database
                longTermTarget.Id = entity.Id;
            }
            // Return the inserted entities. The grid needs the generated ID. Also return any validation errors.
            return Json(new[] {longTermTarget}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult LongTermTarget_Update([DataSourceRequest] DataSourceRequest request,
            LongTermTargetViewModel longTermTarget)
        {
            if (ModelState.IsValid)
            {
                // Create a new Product entity and set its properties from the posted Section Model
                var entity = new SubSectionLongTermTarget
                {
                    Id = longTermTarget.Id,
                    Name = longTermTarget.Name,
                    StaCollectionId = longTermTarget.StaCollectionId
                };
                // Attach the entity
                db.LongTermTargets.Attach(entity);
                // Change its state to Modified so Entity Framework can update the existing product instead of creating a new one
                db.Entry(entity).State = EntityState.Modified;
                // Update the entity in the database
                db.SaveChanges();
            }
            // Return the updated entities. Also return any validation errors.
            return Json(new[] {longTermTarget}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult LongTermTarget_Destroy([DataSourceRequest] DataSourceRequest request,
            LongTermTargetViewModel longTermTarget)
        {
            if (ModelState.IsValid)
            {
                // Create a new Product entity and set its properties from the posted ProductViewModel
                var entity = new SubSectionLongTermTarget
                {
                    Id = longTermTarget.Id,
                    Name = longTermTarget.Name,
                    StaCollectionId = longTermTarget.StaCollectionId
                };
                // Attach the entity
                db.LongTermTargets.Attach(entity);
                // Delete the entity
                db.LongTermTargets.Remove(entity);
                // Delete the entity in the database
                db.SaveChanges();
            }
            // Return the removed product. Also return any validation errors.
            return Json(new[] {longTermTarget}.ToDataSourceResult(request, ModelState));
        }
    }
}