﻿using System.Data.Entity;
using ExpeditionMapper.BE.Domain;
using ExpeditionMapper.BE.Domain.LookUps;
using ExpeditionMapper.Models.Domain;

namespace ExpeditionMapper.DAL.Provider
{
    public class ExpeditionContext : DbContext
    {
        public ExpeditionContext() : base("ExpeditionContext")
        {
        }

        public DbSet<Expedition> Expeditions { get; set; }
        public DbSet<CaseStudy> CaseStudies { get; set; }
        public DbSet<GuidingQuestion> GuidingQuestions { get; set; }
        public DbSet<GradeLevel> GradeLevels { get; set; }
        public DbSet<ExpeditionHabit> ExpeditionHabits { get; set; }
        public DbSet<ScienceBigIdea> ScienceBigIdeases { get; set; }
        public DbSet<SocialStudiesBigIdea> SocialStudiesBigIdeas { get; set; }
        public DbSet<Fieldwork> Fieldworks { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<ServiceLearning> ServiceLearnings { get; set; }
        public DbSet<StaCollection> StaCollections { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<LongTermTarget> LongTermTargets { get; set; }
        public DbSet<ShortTermTarget> ShortTermTargets { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<StaGrid> StaGrid { get; set; }
    }
}