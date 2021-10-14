const submitVisitorInfo = async (e) => {
    e.preventDefault();
    let data = new FormData();

    function cleanupForm() {
        document.querySelector("#rVisitor").value = "";
        document.querySelector("#rDepartedTime").value = "";
    }

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-center",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    //toastr validation
    if (!document.querySelector("#rVisitor").value.trim()) {
        return toastr.error("You didn't select Visitor");
    }
    if (!document.querySelector("#rDepartedTime").value.trim()) {
        return toastr.error("You didn't choose departure time");
    }

    data.append('VisitorId', document.querySelector("#rVisitor").value);
    data.append('DepartedTime', document.querySelector("#rDepartedTime").value);
    //data.append('VisitingId', document.querySelector("#rVisitingId").value);

    try {
        const response = await fetch('/api/prisoner/submit/visitordeparture', {
            method: 'POST',
            body: data,
        });
        console.log(data);
        if (response.status === 200) {
            cleanupForm();
            toastr["success"]("successfully added department info")

        } else {
            toastr["error"]("Failed to add arrival info. Check departure time")
            cleanupForm();
        }

    } catch (error) {
        console.log({ error });
    }
};

const form = document.querySelector("#visitorDepartureForm");
form.addEventListener("submit", submitVisitorInfo);






