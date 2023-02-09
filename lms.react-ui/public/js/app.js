$(document).ready(function () {
    $('#example').DataTable().destroy();
    $('#example').DataTable({
        language : {
            "zeroRecords": " "             
        }
    });
});