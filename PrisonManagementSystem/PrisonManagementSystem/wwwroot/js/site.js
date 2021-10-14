
// inmates
$("#Inmates-list").click(function (e) {
	e.preventDefault();
	window.location = "/Prison/Prisoners"
});

$("#Register-Inmate").click(function (e) {
	e.preventDefault();
	window.location = "/Prison/RegisterPrisoner"
});

$("#Male-inmates").click(function (e) {
	e.preventDefault();
	window.location = "/Prison/MalePrisoners"
});

$("#Female-inmates").click(function (e) {
	e.preventDefault();
	window.location = "/Prison/FemalePrisoners"
});

//imate group
$("#Remands-pg").click(function (e) {
	e.preventDefault();
	window.location = "/Prison/RemandedInmates"
});
$("#Condemns-pg").click(function (e) {
	e.preventDefault();
	window.location = "//"
});
$("#Trials-pg").click(function (e) {
	e.preventDefault();
	window.location = "//"
});
$("#Convicts-pg").click(function (e) {
	e.preventDefault();
	window.location = "//"
});

//facility

//officers
$("#officers-list").click(function (e) {
	e.preventDefault();
	window.location = "/Officer/Officers"
});

$("#register-officer").click(function (e) {
	e.preventDefault();
	window.location = "/Admin/AddOfficer"
});

//visitors
$("#register-visitor").click(function (e) {
	e.preventDefault();
	window.location = "/Visitor/RegisterVisitor"
});

$("#visitor-arrival").click(function (e) {
	e.preventDefault();
	window.location = "/Visitor/visitingarrival"
});

$("#visitor-departure").click(function (e) {
	e.preventDefault();
	window.location = "/Visitor/visitingdeparture"
});

//more