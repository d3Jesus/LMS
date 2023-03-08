
import Alert from '../../../shared/layout/Alert';

async function DeleteAuthor (id)  {

    try {
        let res = await fetch(`https://localhost:7078/api/authors/${id}`, {
            method: "DELETE",
            mode: 'cors', cache: 'no-cache',
            headers: {
                'Content-Type': "application/json"
            }
        });
        let resJson = await res.json();

        if (resJson.succeeded) {
            Alert("success", "Success", resJson.message, "/authors");
        } else {
            Alert("error", "Failed", resJson.message, "/authors");
        }
    } catch (err) {
        console.log(err);
    }
}

export default DeleteAuthor;