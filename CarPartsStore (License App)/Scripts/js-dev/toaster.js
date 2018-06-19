$(document).ready(function () {

        $("#productdiv #addtocart").click(function (e) {

            e.preventDefault();
            $.ajax({
                url: $(this).attr('href'),
                success: function () {
                    toastr.success("Produs adaugat in cos.");
                }

            });
        });
    });