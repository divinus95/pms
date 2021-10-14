const submitVisitorInfo = async (e) => {
    e.preventDefault();
    let data = new FormData();

    function cleanupForm() {
        document.querySelector("#rLastName").value = "";
        document.querySelector("#rFirstName").value = "";
        document.querySelector("#rPrisoner").value = "";
        document.querySelector("#rResidentialAddress").value = "";
        document.querySelector("#rPhone").value = "";
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


    data.append('LastName', document.querySelector("#rLastName").value);
    data.append('FirstName', document.querySelector("#rFirstName").value);
    data.append('PrisonerId', document.querySelector("#rPrisoner").value);
    data.append('ResidentAddress', document.querySelector("#rResidentialAddress").value);
    data.append('Phone', document.querySelector("#rPhone").value);
    data.append('Gender', document.querySelector("input[name=gender]:checked").value);

    try {
        const response = await fetch('/api/prisoner/submit/visitorinfo', {
            method: 'POST',
            body: data,
        });
        console.log(data);
        if (response.status === 200) {
            cleanupForm();
            toastr["success"]("successfully added visitor")

        } else {
            toastr["error"]("Failed to add visitor")
            cleanupForm();
        }

    } catch (error) {
        console.log({ error });
    }
};

const form = document.querySelector("#visitorForm");
form.addEventListener("submit", submitVisitorInfo);






