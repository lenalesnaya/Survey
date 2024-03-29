﻿function showPopup(){
    $("[id=MyModal]").modal('show');
}

function hidePopup() {
    $("[id=MyModal]").modal('hide');
}

function hideQuestion(){
    $('.question-body-jq').remove();
}

let checkRadioButton = 0;
function checkRadioButtons() {
    $('#questionForm').click(function () {
        var response = $("input[type=radio]:checked").val();
        switch (response) {
            case '0':
                hideQuestion()
                questionOneAnswersVariantGeneration();
                break;
            case '1':
                hideQuestion();
                questionWithSomeAnswersVariantGeneration();
                break;
            case  'text':
                hideQuestion();
                questionWithText();
                break;
            case 'file':
                hideQuestion();
                questionWithFile();
                break;
            case 'starRating':
                hideQuestion();
                questionWithStar();
                break;
            case 'scale':
                hideQuestion();
                questionWithScale();
                break;
        }
    })
}

function questionOneAnswersVariantGeneration() {
    var response = $("input[type=radio]:checked").val();
    if (response === '0') {
        $('.question-body')
            .append($('<div class="question-body-jq">\n' +
                '                      <input type="text" class="inp form-control w-50" placeholder="Enter answer" id="InputAnswer"/>\n' +
                '                      <input type="text" class="inp form-control w-50" placeholder="Enter answer" id="InputAnswer"/>\n' +
                '                      <input type="text" class="inp form-control w-50" placeholder="Enter answer" id="InputAnswer"/>\n' +
                '                    </div>'))
    }
}

function questionWithSomeAnswersVariantGeneration(){
    var response = $("input[type=radio]:checked").val();
    if (response === '1') {
        $('.question-body').append($('<div class="question-body-jq">\n' +
            '                      <input type="text" class="inp form-control w-50" placeholder="Enter answer" id="InputAnswer"/>\n' +
            '                      <input type="text" class="inp form-control w-50" placeholder="Enter answer" id="InputAnswer"/>\n' +
            '                      <input type="text" class="inp form-control w-50" placeholder="Enter answer" id="InputAnswer"/>\n' +
            '                      <input type="text" class="inp form-control w-50" placeholder="Enter answer" id="InputAnswer"/>\n' +
            '                    </div>'))
    }
}

function questionWithText() {
    var response = $("input[type=radio]:checked").val();
    if (response === 'text'){
        console.log('some')
    }
}

function questionWithFile() {
    var response = $("input[type=radio]:checked").val();
    if (response === 'file'){
        console.log('some')
    }
}


function questionWithStar() {
    var response = $("input[type=radio]:checked").val();
    if (response === 'starRating'){
        console.log('some')
    }
}

function questionWithScale() {
    var response = $("input[type=radio]:checked").val();
    if (response === 'scale'){
        console.log('some')
    }
}

function saveQuestion(id){
    const text = $("[id=InputQuestionTitle]").val();
    const canChooseManyAnswers = !!Number($("[name=radio]:checked").val());
    var answerVariants = $("input[id=InputAnswer]").map( (i,el) => ({
        title: $(el).val(),
    })).get();
    const data = {
        canChooseManyAnswers,
        title: text,
        surveyId: id,
        answerVariants,
    };
    var request = $.ajax({
        contentType: 'application/json',
        url: `/api/SurveyApi/AddQuestionWithAnswerVariants`,
        method: 'post',
        data: JSON.stringify(data),
    })
    request.done((result)=> {
        if (result.isSuccessful){
            location.reload();
        }
    });
}
