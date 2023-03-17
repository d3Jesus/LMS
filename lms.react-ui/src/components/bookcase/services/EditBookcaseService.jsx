import Alert from "../../../shared/layout/Alert";

async function EditBookcaseService(bookcase){
    try {
        let res = await fetch("https://localhost:7078/api/bookcases", {
            method: "PUT",
            body: JSON.stringify(bookcase),
            mode: 'cors', cache: 'no-cache',
            headers: {
                'Content-Type': "application/json"
            }
        });
        let resJson = await res.json();

        if (resJson.succeeded) {
            Alert("success", "Success", resJson.message, "/bookcases");
        } else {
            Alert("error", "Failed", resJson.message, "/bookcases");
        }
    } catch (err) {
        console.log(err);
    }
}

export default EditBookcaseService;