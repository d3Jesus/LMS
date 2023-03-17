
import Alert from '../../../shared/layout/Alert';

async function DeleteBookcase (id)  {

    try {
        let res = await fetch(`https://localhost:7078/api/bookcases/${id}`, {
            method: "DELETE",
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

export default DeleteBookcase;