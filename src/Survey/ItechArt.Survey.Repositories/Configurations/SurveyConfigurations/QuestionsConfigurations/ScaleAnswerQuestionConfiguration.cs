﻿using ItechArt.Survey.DomainModel.SurveyModel.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItechArt.Survey.Repositories.Configurations.SurveyConfigurations.QuestionsConfigurations;

public class ScaleAnswerQuestionConfiguration : IEntityTypeConfiguration<ScaleAnswerQuestion>
{
    public void Configure(EntityTypeBuilder<ScaleAnswerQuestion> builder)
    {
        builder.HasKey(q => new { q.Id, q.SurveyId });
        builder
            .Property(q => q.Text)
            .HasMaxLength(Question.TextMaxLength)
            .IsRequired();
        builder
            .Property(q => q.ScaleMinValue)
            .IsRequired();
        builder
            .Property(q => q.ScaleMaxValue)
            .IsRequired();
        builder
            .HasOne(q => q.Survey)
            .WithMany(s => s.ScaleAnswerQuestions)
            .HasForeignKey(q => q.SurveyId)
            .IsRequired();
    }
}