﻿using ItechArt.Survey.DomainModel.SurveyModel.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItechArt.Survey.Repositories.Configurations.QuestionsConfigurations;

public class AnswerVariantsQuestionConfiguration : IEntityTypeConfiguration<AnswerVariantsQuestion>
{
    public void Configure(EntityTypeBuilder<AnswerVariantsQuestion> builder)
    {
        builder
            .Property(q => q.Title)
            .HasMaxLength(Question.TextMaxLength)
            .IsRequired();
        builder
            .HasOne(q => q.Survey)
            .WithMany(s => s.AnswerVariantsQuestions)
            .HasForeignKey(q => q.SurveyId)
            .IsRequired();
    }
}