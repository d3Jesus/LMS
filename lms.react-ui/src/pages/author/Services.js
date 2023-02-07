
const getAuthors = async () => {
    const response = await fetch('https://localhost:7078/api/authors');
    return await response.json()
}

export default getAuthors;