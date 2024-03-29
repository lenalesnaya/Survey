﻿using ItechArt.Survey.DomainModel.SurveyModel.Questions;
using ItechArt.Survey.DomainModel.UserModel;
using System;
using System.Collections.Generic;

namespace ItechArt.Survey.DomainModel.SurveyModel;

public class Survey
{
    public const int TitleMaxLength = 128;


    public long Id { get; set; }

    public string Title { get; set; }

    public bool IsAnonymous { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public long CreatorId { get; set; }


    public virtual User Сreator { get; set; }

    public virtual ICollection<AnswerVariantsQuestion> AnswerVariantsQuestions { get; set; }

    public virtual ICollection<FileAnswerQuestion> FileAnswerQuestions { get; set; }

    public virtual ICollection<ScaleAnswerQuestion> ScaleAnswerQuestions { get; set; }

    public virtual ICollection<StarRatingAnswerQuestion> StarRatingAnswerQuestions { get; set; }

    public virtual ICollection<TextAnswerQuestion> TextAnswerQuestions { get; set; }
}