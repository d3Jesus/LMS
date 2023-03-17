
import Alert from '../../../shared/layout/Alert';

async function DeleteLibrarian (id)  {

    try {
        let res = await fetch(`https://localhost:7078/api/librarians/${id}`, {
            method: "DELETE",
            mode: 'cors', cache: 'no-cache',
            headers: {
                'Content-Type': "application/json"
            }
        });
        let resJson = await res.json();

        if (resJson.succeeded) {
            Alert("success", "Success", resJson.message, "/librarians");
        } else {
            Alert("error", "Failed", resJson.message, "/librarians");
        }
    } catch (err) {
        console.log(err);
    }
}

export default DeleteLibrarian;