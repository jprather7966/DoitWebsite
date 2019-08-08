// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//Checks if input if given is empty
function validateForm()
{
	var inputValue = document.getElementById("myInput").value;
	if (isEmptyOrSpaces(inputValue))
	{
		alert("Name must be filled out");
		return false;
	}
	return true;
}
//Checks if empty input has multiple spaces 
function isEmptyOrSpaces(str)
{
	return str === null || str.match(/^ *$/) !== null;
}

