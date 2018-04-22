// JavaScript Document

function DisplayMD(){
	document.getElementById('Maryland').className = "";
	document.getElementById('Virginia').className = "hidden";
	document.getElementById('MDLink').className = "ThinActive";
	document.getElementById('VALink').className = "Thin";
}

function DisplayVA(){
	document.getElementById('Maryland').className = "hidden";
	document.getElementById('Virginia').className = "";
	document.getElementById('MDLink').className = "Thin";
	document.getElementById('VALink').className = "ThinActive";
}

function UpdateSalePriceMD(){
	var formatedSP = formatCurrency(objSalePriceMD.value);
	if(formatedSP == "NaN" && objSalePriceMD.value != "") {
		objSalePriceMD.className = "Error";
		ClearAllMD();
	}else{
		objSalePriceMD.className = "";
		if(objLoanAmountMD.className != "Error")
			UpdateAllMD();
	}
}

function FormatSalePriceMD(){
	var formatedSP = formatCurrency(objSalePriceMD.value);
	if(formatedSP == "NaN" && objSalePriceMD.value != "") {
		objSalePriceMD.className = "Error";
		ClearAllMD();
	}else{
		if(objSalePriceMD.value == "")
			objSalePriceMD.value = "0.00";
		else
			objSalePriceMD.value = formatedSP;
		
		objSalePriceMD.className = "";
		if(objLoanAmountMD.className != "Error" && objBalanceMD.className != "Error")
			UpdateAllMD();
	}
}

function UpdateLoanAmountMD(){
	var formatedLA = formatCurrency(objLoanAmountMD.value);
	if(formatedLA == "NaN" && objLoanAmountMD.value != "") {
		objLoanAmountMD.className = "Error";
		ClearAllMD();
	}else{
		objLoanAmountMD.className = "";
		if(objSalePriceMD.className != "Error")
			UpdateAllMD();
	}
}

function FormatLoanAmountMD(){
	var formatedLA = formatCurrency(objLoanAmountMD.value);
	if(formatedLA == "NaN" && objLoanAmountMD.value != "") {
		objLoanAmountMD.className = "Error";
		ClearAllMD();
	}else{
		if(objLoanAmountMD.value == "")
			objLoanAmountMD.value = "0.00";
		else
			objLoanAmountMD.value = formatedLA;
		
		objLoanAmountMD.className = "";
		if(objSalePriceMD.className != "Error" && objBalanceMD.className != "Error")
			UpdateAllMD();
	}
}

function UpdateBalanceMD(){
	var formatedBal = formatCurrency(objBalanceMD.value);
	if(formatedBal == "NaN" && objBalanceMD.value != "") {
		objBalanceMD.className = "Error";
		ClearAllMD();
	}else{
		objBalanceMD.className = "";
		if(objSalePriceMD.className != "Error" && objLoanAmountMD.className != "Error")
			UpdateAllMD();
	}
}

function FormatBalanceMD(){
	var formatedBal = formatCurrency(objBalanceMD.value);
	if(formatedBal == "NaN" && objBalanceMD.value != "") {
		objBalanceMD.className = "Error";
		ClearAllMD();
	}else{
		if(objBalanceMD.value == "")
			objBalanceMD.value = "0.00";
		else
			objBalanceMD.value = formatedBal;
		
		objBalanceMD.className = "";
		if(objSalePriceMD.className != "Error" && objLoanAmountMD.className != "Error")
			UpdateAllMD();
	}
}

function UpdateAllMD() {
	var salePrice = parseFloat(objSalePriceMD.value.toString().replace(/\,/g,''));
	var loanAmount = parseFloat(objLoanAmountMD.value.toString().replace(/\,/g,''));
	var balance = parseFloat(objBalanceMD.value.toString().replace(/\,/g,''));
	
	if(objSalePriceMD.value == "")
		salePrice = 0;
	if(objLoanAmountMD.value == "")
		loanAmount = 0;
	if(objBalanceMD.value == "")
		balance = 0;
	
	var selectedCounty = objCountyMD[objCountyMD.selectedIndex].value;
	
	if(selectedCounty == "AnneAr"){
		obj1A.innerHTML = "$" + formatCurrency(salePrice * 0.005);
		obj1B.innerHTML = "$" + formatCurrency(salePrice * 0.005 / 2);
		if(salePrice > 0){
			obj1C.innerHTML = "$" + formatCurrency(salePrice * 0.007);
			obj1D.innerHTML = "$" + formatCurrency(salePrice * 0.007 / 2);
		}else{
			obj1C.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007);
			obj1D.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007 / 2);			
		}
		obj1E.innerHTML = "$" + formatCurrency(salePrice * 0.01);
		obj1F.innerHTML = "$" + formatCurrency(salePrice * 0.01 / 2);
	}else if(selectedCounty == "BaltimoreCity"){
		obj1A.innerHTML = "$" + formatCurrency(salePrice * 0.005);
		obj1B.innerHTML = "$" + formatCurrency(salePrice * 0.005 / 2);
		if(salePrice > 0){
			obj1C.innerHTML = "$" + formatCurrency(salePrice * 0.007);
			obj1D.innerHTML = "$" + formatCurrency(salePrice * 0.007 / 2);
		}else{
			obj1C.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007);
			obj1D.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007 / 2);			
		}
		obj1E.innerHTML = "$" + formatCurrency(salePrice * 0.015);
		obj1F.innerHTML = "$" + formatCurrency(salePrice * 0.015 / 2);
	}else if(selectedCounty == "Carroll"){
		obj1A.innerHTML = "$" + formatCurrency(salePrice * 0.005);
		obj1B.innerHTML = "$" + formatCurrency(salePrice * 0.005 / 2);
		if(salePrice > 0){
			obj1C.innerHTML = "$" + formatCurrency(salePrice * 0.007);
			obj1D.innerHTML = "$" + formatCurrency(salePrice * 0.007 / 2);
		}else{
			obj1C.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007);
			obj1D.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007 / 2);			
		}
		obj1E.innerHTML = "$" + formatCurrency(salePrice * 0.015);
		obj1F.innerHTML = "$" + formatCurrency(salePrice * 0.015 / 2);
	}else if(selectedCounty == "BaltimoreCounty"){
		obj1A.innerHTML = "$" + formatCurrency(salePrice * 0.005);
		obj1B.innerHTML = "$" + formatCurrency(salePrice * 0.005 / 2);
		if(salePrice > 0){
			obj1C.innerHTML = "$" + formatCurrency(salePrice * 0.007);
			obj1D.innerHTML = "$" + formatCurrency(salePrice * 0.007 / 2);
		}else{
			obj1C.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007);
			obj1D.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007 / 2);			
		}
		obj1E.innerHTML = "$" + formatCurrency(salePrice * 0.015);
		obj1F.innerHTML = "$" + formatCurrency(salePrice * 0.015 / 2);
	}else if(selectedCounty == "Charles"){
		obj1A.innerHTML = "$" + formatCurrency(salePrice * 0.005);
		obj1B.innerHTML = "$" + formatCurrency(salePrice * 0.005 / 2);
		if(salePrice > 0){
			obj1C.innerHTML = "$" + formatCurrency(salePrice * 0.007);
			obj1D.innerHTML = "$" + formatCurrency(salePrice * 0.007 / 2);
		}else{
			obj1C.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007);
			obj1D.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007 / 2);			
		}
		obj1E.innerHTML = "N/A";
		obj1F.innerHTML = "N/A";
	}else if(selectedCounty == "Frederick"){
		obj1A.innerHTML = "$" + formatCurrency(salePrice * 0.005);
		obj1B.innerHTML = "$" + formatCurrency(salePrice * 0.005 / 2);
		if(salePrice > 0){
			obj1C.innerHTML = "$" + formatCurrency(salePrice * 0.007);
			obj1D.innerHTML = "$" + formatCurrency(salePrice * 0.007 / 2);
		}else{
			obj1C.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007);
			obj1D.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007 / 2);			
		}
		obj1E.innerHTML = "N/A";
		obj1F.innerHTML = "N/A";
	}else if(selectedCounty == "Howard"){
		obj1A.innerHTML = "$" + formatCurrency(salePrice * 0.005);
		obj1B.innerHTML = "$" + formatCurrency(salePrice * 0.005 / 2);
		if(salePrice > 0){
			obj1C.innerHTML = "$" + formatCurrency(salePrice * 0.007);
			obj1D.innerHTML = "$" + formatCurrency(salePrice * 0.007 / 2);
		}else{
			obj1C.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007);
			obj1D.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007 / 2);			
		}
		obj1E.innerHTML = "$" + formatCurrency(salePrice * 0.01);
		obj1F.innerHTML = "$" + formatCurrency(salePrice * 0.01 / 2);
	}else if(selectedCounty == "Montgomery"){
		obj1A.innerHTML = "$" + formatCurrency(salePrice * 0.005);
		obj1B.innerHTML = "$" + formatCurrency(salePrice * 0.005 / 2);
		if(salePrice > 0){
			obj1C.innerHTML = "$" + formatCurrency(salePrice * 0.007);
			obj1D.innerHTML = "$" + formatCurrency(salePrice * 0.007 / 2);
		}else{
			obj1C.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007);
			obj1D.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007 / 2);			
		}
		obj1E.innerHTML = "$" + formatCurrency(salePrice * 0.01);
		obj1F.innerHTML = "$" + formatCurrency(salePrice * 0.01 / 2);
	}else if(selectedCounty == "PrinceGeorges"){
		obj1A.innerHTML = "$" + formatCurrency(salePrice * 0.005);
		obj1B.innerHTML = "$" + formatCurrency(salePrice * 0.005 / 2);
		if(salePrice > 0){
			obj1C.innerHTML = "$" + formatCurrency(salePrice * 0.007);
			obj1D.innerHTML = "$" + formatCurrency(salePrice * 0.007 / 2);
		}else{
			obj1C.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007);
			obj1D.innerHTML = "$" + formatCurrency((loanAmount - balance) * 0.007 / 2);			
		}
		obj1E.innerHTML = "$" + formatCurrency(salePrice * 0.014);
		obj1F.innerHTML = "$" + formatCurrency(salePrice * 0.014 / 2);
	}else{
		ClearAllMD();
	}
		
	if(salePrice > 0)
		obj10A.innerHTML = "$" + formatCurrency(getOwnersPolicyTotalMD() - getLendersPolicyTotalMD());
	else
		obj10A.innerHTML = "$0.00";
	obj11A.innerHTML = "$" + formatCurrency(getLendersPolicyTotalMD());

	if(obj1A.innerHTML == "$NaN"){
		obj1A.innerHTML = "$0.00";
		obj1B.innerHTML = "$0.00";
	}
	if(obj1C.innerHTML == "$NaN"){
		obj1C.innerHTML = "$0.00";
		obj1D.innerHTML = "$0.00";
	}
	if(obj1E.innerHTML == "$NaN"){
		obj1E.innerHTML = "$0.00";
		obj1F.innerHTML = "$0.00";
	}
	if(obj10A.innerHTML == "$NaN"){
		obj10A.innerHTML = "$0.00";
	}
	if(obj11A.innerHTML == "$NaN"){
		obj11A.innerHTML = "$0.00";
	}
	
}


function ClearAllMD() {
	obj1A.innerHTML = "&nbsp;"
	obj1B.innerHTML = "&nbsp;"
	obj1C.innerHTML = "&nbsp;"
	obj1D.innerHTML = "&nbsp;"
	obj1D.innerHTML = "&nbsp;"
	obj1E.innerHTML = "&nbsp;"
	obj1F.innerHTML = "&nbsp;"
	
	obj10A.innerHTML = "&nbsp;"
	obj11A.innerHTML = "&nbsp;"
}

function UpdateSalePriceVA(){
	var formatedSP = formatCurrency(objSalePriceVA.value);
	if(formatedSP == "NaN" && objSalePriceVA.value != "") {
		objSalePriceVA.className = "Error";
		ClearAllVA();
	}else{
		objSalePriceVA.className = "";
		if(objLoanAmountVA.className != "Error" && objAssetsValueVA.className != "Error")
			UpdateAllVA();
	}
}

function FormatSalePriceVA(){
	var formatedSP = formatCurrency(objSalePriceVA.value);
	if(formatedSP == "NaN" && objSalePriceVA.value != "") {
		objSalePriceVA.className = "Error";
		ClearAllVA();
	}else{
		if(objSalePriceVA.value == "")
			objSalePriceVA.value = "0.00";
		else
			objSalePriceVA.value = formatedSP;

		objSalePriceVA.className = "";
		if(objLoanAmountVA.className != "Error" && objAssetsValueVA.className != "Error")
			UpdateAllVA();
	}
}

function UpdateLoanAmountVA(){
	var formatedLA = formatCurrency(objLoanAmountVA.value);
	if(formatedLA == "NaN" && objLoanAmountVA.value != "") {
		objLoanAmountVA.className = "Error";
		ClearAllVA();
	}else{
		objLoanAmountVA.className = "";
		if(objSalePriceVA.className != "Error" && objAssetsValueVA.className != "Error")
			UpdateAllVA();
	}
}

function FormatLoanAmountVA(){
	var formatedLA = formatCurrency(objLoanAmountVA.value);
	if(formatedLA == "NaN" && objLoanAmountVA.value != "") {
		objLoanAmountVA.className = "Error";
		ClearAllVA();
	}else{
		if(objLoanAmountVA.value == "")
			objLoanAmountVA.value = "0.00";
		else
			objLoanAmountVA.value = formatedLA;
		
		objLoanAmountVA.className = "";
		if(objSalePriceVA.className != "Error" && objAssetsValueVA.className != "Error")
			UpdateAllVA();
	}
}

function UpdateAssetsValueVA(){
	var formatedAV = formatCurrency(objAssetsValueVA.value);
	if(formatedAV == "NaN" && objAssetsValueVA.value != "") {
		objAssetsValueVA.className = "Error";
		ClearAllVA();
	}else{
		objAssetsValueVA.className = "";
		if(objSalePriceVA.className != "Error" && objAssetsValueVA.className != "Error")
			UpdateAllVA();
	}
}

function FormatAssetsValueVA(){
	var formatedAV = formatCurrency(objAssetsValueVA.value);
	if(formatedAV == "NaN" && objAssetsValueVA.value != "") {
		objAssetsValueVA.className = "Error";
		ClearAllVA();
	}else{
		if(objAssetsValueVA.value == "")
			objAssetsValueVA.value = "0.00";
		else
			objAssetsValueVA.value = formatedAV;
		
		objAssetsValueVA.className = "";
		if(objSalePriceVA.className != "Error" && objAssetsValueVA.className != "Error")
			UpdateAllVA();
	}
}

function UpdateAllVA() {
	var salePrice = parseFloat(objSalePriceVA.value.toString().replace(/\,/g,''));
	var assetsValue = parseFloat(objAssetsValueVA.value.toString().replace(/\,/g,''));
	var loanAmount = parseFloat(objLoanAmountVA.value.toString().replace(/\,/g,''));
	
	if(objSalePriceVA.value == "")
		salePrice = 0;
	if(objAssetsValueVA.value == "")
		assetsValue = 0;
	if(objLoanAmountVA.value == "")
		loanAmount = 0;

	var higherSP_AV = (salePrice > assetsValue) ? salePrice : assetsValue;
	
	obj12A.innerHTML = "$" + formatCurrency(((loanAmount*0.835)/1000)+((higherSP_AV*0.835)/1000))
	obj13A.innerHTML = "$" + formatCurrency(((loanAmount*2.5)/1000)+((higherSP_AV*2.5)/1000))
	
	var totalOwnersTitle;
	var totalLendersTitle;
	if(loanAmount < 250000){
		totalOwnersTitle = (salePrice*4.68/1000) + 125;
		totalLendersTitle = (loanAmount*3.48/1000);
	}else if(loanAmount < 500000){
		totalOwnersTitle = (salePrice*4.44/1000) + 125;
		totalLendersTitle = (loanAmount*3.24/1000);
	}else{
		totalOwnersTitle = (salePrice*3.96/1000) + 125;
		totalLendersTitle = (loanAmount*2.76/1000);
	}
	
	if(salePrice > 0)
		obj14A.innerHTML = "$" + formatCurrency(totalOwnersTitle - totalLendersTitle);
	else
		obj14A.innerHTML = "$0.00";
	
	obj15A.innerHTML = "$" + formatCurrency(totalLendersTitle);
	
	if(obj12A.innerHTML == "$NaN")
		obj12A.innerHTML = "$0.00";
	if(obj13A.innerHTML == "$NaN")
		obj13A.innerHTML = "$0.00";
	if(obj14A.innerHTML == "$NaN")
		obj14A.innerHTML = "$0.00";
	if(obj15A.innerHTML == "$NaN")
		obj15A.innerHTML = "$0.00";
}


function ClearAllVA() {
	obj12A.innerHTML = "&nbsp;"
	obj13A.innerHTML = "&nbsp;"

	obj14A.innerHTML = "&nbsp;"
	obj15A.innerHTML = "&nbsp;"
}

function formatCurrency(num) {
	if(num == "")
		return "NaN";
	num = num.toString().replace(/\$|\,/g,'');
	if(isNaN(num))
		return "NaN";
	sign = (num == (num = Math.abs(num)));
	num = Math.floor(num*100+0.50000000001);
	cents = num%100;
	num = Math.floor(num/100).toString();
	if(cents<10)
		cents = "0" + cents;
	for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
		num = num.substring(0,num.length-(4*i+3))+','+
	num.substring(num.length-(4*i+3));
	return (((sign)?'':'-') + num + '.' + cents);
}

function getOwnersPolicyTotalMD(){
	var salePrice = parseFloat(objSalePriceMD.value.toString().replace(/\,/g,''));

	if(salePrice < 250000)
		return (salePrice * 4.2 / 1000) + 75;
	else if(salePrice < 500000)
		return (salePrice * 3.6 / 1000) + 75;
	else
		return (salePrice * 3.3 / 1000) + 75;
}

function getLendersPolicyTotalMD(){
	var loanAmount = parseFloat(objLoanAmountMD.value.toString().replace(/\,/g,''));
	
	if(loanAmount < 250000)
		return loanAmount * 3 / 1000;
	else if(loanAmount < 500000)
		return loanAmount * 2.4 / 1000;
	else
		return loanAmount * 2.1 / 1000;
}

var objSalePriceMD = document.getElementById("SalePriceMD");
var objLoanAmountMD = document.getElementById("LoanAmountMD");
var objBalanceMD = document.getElementById("BalanceMD");
var objCountyMD = document.getElementById("CountyMD");
var objSalePriceVA = document.getElementById("SalePriceVA");
var objLoanAmountVA = document.getElementById("LoanAmountVA");
var objAssetsValueVA = document.getElementById("AssetsValueVA");
var obj1A = document.getElementById("1A");
var obj1B = document.getElementById("1B");
var obj1C = document.getElementById("1C");
var obj1D = document.getElementById("1D");
var obj1E = document.getElementById("1E");
var obj1F = document.getElementById("1F");
var obj10A = document.getElementById("10A");
var obj11A = document.getElementById("11A");
var obj12A = document.getElementById("12A");
var obj13A = document.getElementById("13A");
var obj14A = document.getElementById("14A");
var obj15A = document.getElementById("15A");

UpdateSalePriceMD();
UpdateSalePriceVA();