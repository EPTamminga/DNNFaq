function GetFaqAnswerSuccess(result, ctx) {
	var lblAnswer = dnn.dom.getById(ctx);
    lblAnswer.innerHTML = result;
}

function GetFaqAnswerError(result, ctx) {
	var lblAnswer = dnn.dom.getById(ctx);
	lblAnswer.innerHTML = result;

}