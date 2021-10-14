const submitVisitorInfo = async (e) => {
    e.preventDefault();
    let data = new FormData();

    function cleanupForm() {
        document.querySelector("#rVisitor").value = "";
        document.querySelector("#rArrivalTime").value = "";
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
    if (!document.querySelector("#rArrivalTime").value.trim()) {
        return toastr.error("You didn't choose arrival time");
    }

    data.append('VisitorId', document.querySelector("#rVisitor").value);
    data.append('ArrivalTime', document.querySelector("#rArrivalTime").value);

    try {
        const response = await fetch('/api/prisoner/submit/visitorarrival', {
            method: 'POST',
            body: data,
        });
        console.log(data);
        if (response.status === 200) {
            cleanupForm();
            toastr["success"]("successfully added arrival info")

        } else {
            toastr["error"]("Failed to add arrival info. Check arrival time")
            cleanupForm();
        }

    } catch (error) {
        console.log({ error });
    }
};

const form = document.querySelector("#visitorArrivalForm");
form.addEventListener("submit", submitVisitorInfo);






