﻿using ItechArt.Survey.DomainModel.Survey.Questions;
using ItechArt.Survey.DomainModel.UserModel;
using System;
using System.Collections.Generic;

namespace ItechArt.Survey.DomainModel.SurveyModel;

public class Survey
{
    public const int TitleMaxLength = 128;


    public long Id { get; set; }

    public string Title { get; set; }

    public bool IsAnonymous { get; set; } = false;

    public DateTime DateOfCreation { get; set; } = DateTime.Now;

    public int СreatorId { get; set; }


    public User Сreator { get; set; }

    public ICollection<AnswerVariantsQuestion> AnswerVariantsQuestions { get; set; }

    public ICollection<FileAnswerQuestion> FileAnswerQuestions { get; set; }

    public ICollection<ScaleAnswerQuestion> ScaleAnswerQuestions { get; set; }

    public ICollection<StarRatingAnswerQuestion> StarRatingAnswerQuestions { get; set; }

    public ICollection<TextAnswerQuestion> TextAnswerQuestions { get; set; }
}