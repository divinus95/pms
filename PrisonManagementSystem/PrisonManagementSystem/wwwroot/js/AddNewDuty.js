const submitNewDuty = async (e) => {
    e.preventDefault();
    let data = new FormData();

    function cleanupForm() {
        document.querySelector("#rDutyName").value = "";
        document.querySelector("#rDescription").value = "";
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
    if (!document.querySelector("#rDutyTypeId").value.trim()) {
        return toastr.error("You didn't select Duty Type");
    }
    if (!document.querySelector("#rDutyName").value.trim()) {
        return toastr.error("You didn't give duty a name");
    }
    if (!document.querySelector("#rDescription").value.trim()) {
        return toastr.error("You didn't give a meaningful description");
    }
    data.append('DutyTypeId', document.querySelector("#rDutyTypeId").value);
    data.append('DutyName', document.querySelector("#rDutyName").value);
    data.append('Description', document.querySelector("#rDescription").value);

    try {
        const response = await fetch('/api/admins/submit/addnewduty', {
            method: 'POST',
            body: data,
        });
        console.log(data);
        if (response.status === 200) {
            cleanupForm();
            toastr["success"]("successfully added duty for officers")

        } else {
            toastr["error"]("Failed to add duty")
            cleanupForm();
        }

    } catch (error) {
        console.log({ error });
    }
};

const form = document.querySelector("#newDutyForm");
form.addEventListener("submit", submitNewDuty);






