const submitPrisonerInfo = async (e) => {
    e.preventDefault();
    let data = new FormData();

    function cleanupForm() {
        document.querySelector("#rPassportPicture");
       //document.querySelector("#rClassify").value = "";
       //document.querySelector("#rCell").value = "";
        document.querySelector("#rHealthConditions").value = "";
        document.querySelector("#rEmergencyContact").value = "";
        document.querySelector("#rDetails").value = "";
        document.querySelector("#rSentence").value = "";
        document.querySelector("#rOffence").value = "";
        document.querySelector("#rExpectedJailTerm").value = "";
        document.querySelector("#rDateConvicted").value = "";
        document.querySelector("#rDOB").value = "";
        document.querySelector("#rOtherName").value = "";
        document.querySelector("#rLastName").value = "";
        document.querySelector("#rFirstName").value = "";
        document.querySelector("#rColorOfEye").value = "";
        document.querySelector("#rWeight").value = "";
        document.querySelector("#rHeight").value = "";
    }


    //if (!$("#prisonerForm").valid()) {
    //    return
    //} 

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
    if (!document.querySelector("#rClassify").value.trim()) {
        return toastr.error("You didn't choose a class of offence");
    }
    if (!document.querySelector("#rCell").value.trim()) {
        return toastr.error("You didn't choose a cell");
    }
    if (!document.querySelector("#rLastName").value.trim()) {
        return toastr.error("Provide a Last Name");
    }
    if (!document.querySelector("#rFirstName").value.trim()) {
        return toastr.error("Provide a First Name");
    }
    if (!document.querySelector("#rDOB").value.trim()) {
        return toastr.error("Add a Date of Birth");
    }

    data.append('PassportPicture', document.querySelector("#rPassportPicture").files[0]);
    data.append('PrisonerClassificationId',document.querySelector("#rClassify").value);
    data.append('CellId',document.querySelector("#rCell").value);
    data.append('HealthConditions', document.querySelector("#rHealthConditions").value);
    data.append('EmergencyContact',document.querySelector("#rEmergencyContact").value);
    data.append('Description',document.querySelector("#rDetails").value);
    data.append('Sentence',document.querySelector("#rSentence").value);
    data.append('Offence', document.querySelector("#rOffence").value);
    data.append('ExpectedJailTerm',document.querySelector("#rExpectedJailTerm").value);
    data.append('DateConvicted',document.querySelector("#rDateConvicted").value);
    data.append('DateOfBirth',document.querySelector("#rDOB").value);
    data.append('OtherName',document.querySelector("#rOtherName").value);
    data.append('LastName',document.querySelector("#rLastName").value);
    data.append('FirstName',document.querySelector("#rFirstName").value);
    data.append('ColorOfEye', document.querySelector("#rColorOfEye").value);
    data.append('Weight', document.querySelector("#rWeight").value);
    data.append('Height', document.querySelector("#rHeight").value);
    data.append('Gender', document.querySelector("input[name=gender]:checked").value);

    try {
        const response = await fetch('/api/prisoner/submit/prisonerinfo', {
            method: 'POST',
            body: data,
        });
        console.log(data);
        if (response.status === 200) {
            cleanupForm();
            toastr["success"]("successfully added prisoner")

        } else {
            toastr["error"]("Failed to add prisoner")
            cleanupForm();
        }

    } catch (error) {
        console.log({ error });
    }
};

const form = document.querySelector("#prisonerForm");
form.addEventListener("submit", submitPrisonerInfo);






