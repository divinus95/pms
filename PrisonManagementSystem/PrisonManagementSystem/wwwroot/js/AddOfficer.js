const submitOfficerInfo = async (e) => {
    e.preventDefault();
    let data = new FormData();

    function cleanupForm() {
        document.querySelector("#rLastName").value = "";
        document.querySelector("#rFirstName").value = "";
        document.querySelector("#rResidentialAddress").value = "";
        document.querySelector("#rPhone").value = "";
        document.querySelector("#rEmail").value = "";
        document.querySelector("#rEmergencyContact").value = "";
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
    if (!document.querySelector("#rPhone").value.trim()) {
        return toastr.error("You didn't add a phone number");
    }
    if (!document.querySelector("#rResidentialAddress").value.trim()) {
        return toastr.error("You didn't add a residential address");
    }
    if (!document.querySelector("#rLastName").value.trim()) {
        return toastr.error("Provide a Last Name");
    }
    if (!document.querySelector("#rFirstName").value.trim()) {
        return toastr.error("Provide a First Name");
    }
    if (!document.querySelector("#rPhone").value.trim()) {
        return toastr.error("Provide a Phone Number");
    }
    if (!document.querySelector("#rEmail").value.trim()) {
        return toastr.error("Provide a Email Address");
    }
    if (!document.querySelector("#rRank").value.trim()) {
        return toastr.error("Select Officer Rank");
    }

    data.append('RankId', document.querySelector("#rRank").value);
    data.append('FirstName', document.querySelector("#rFirstName").value);
    data.append('LastName', document.querySelector("#rLastName").value);
    data.append('ResidentialAddress', document.querySelector("#rResidentialAddress").value);
    data.append('Phone', document.querySelector("#rPhone").value);
    data.append('Email', document.querySelector("#rEmail").value);
    data.append('EmergencyContact', document.querySelector("#rEmergencyContact").value);
    data.append('Gender', document.querySelector("input[name=gender]:checked").value);

    try {
        const response = await fetch('/api/admins/submit/addofficer', {
            method: 'POST',
            body: data,
        });
        console.log(data);
        if (response.status === 200) {
            cleanupForm();
            toastr["success"]("successfully added officer")

        } else {
            toastr["error"]("Failed to add officer")
           // cleanupForm();
        }

    } catch (error) {
        console.log({ error });
    }
};

const form = document.querySelector("#OfficerForm");
form.addEventListener("submit", submitOfficerInfo);






