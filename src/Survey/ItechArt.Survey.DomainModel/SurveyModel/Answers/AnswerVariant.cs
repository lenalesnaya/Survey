﻿using ItechArt.Survey.DomainModel.SurveyModel.Questions;

namespace ItechArt.Survey.DomainModel.SurveyModel.Answers;

public class AnswerVariant
{
    public const int TextMaxLength = 500;


    public long Id { get; set; }

    public string Text { get; set; }

    public long QuestionId { get; set; }


    public AnswerVariantsQuestion Question { get; set; }
}