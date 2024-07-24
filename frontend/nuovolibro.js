document.addEventListener("DOMContentLoaded", async () => {
    const form = document.getElementById("book-form");
    const authorsUrl = 'http://localhost:5215/api/Author';
    const categoriesUrl = 'http://localhost:5215/api/Category';

    // Funzione per popolare i campi select con i dati degli autori e delle categorie
    async function populateSelect(url, selectElement) {
        try {
            const response = await fetch(url);
            if (!response.ok) {
                throw new Error(`Errore nel recupero dei dati da ${url}`);
            }
            const data = await response.json();
            data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.id;
                option.textContent = item.name;
                selectElement.appendChild(option);
            });
        } catch (error) {
            console.error("Errore:", error);
        }
    }

    // Popola i campi select per autore e categoria
    await populateSelect(authorsUrl, document.getElementById("authorId"));
    await populateSelect(categoriesUrl, document.getElementById("categoryId"));

    form.addEventListener("submit", async (e) => {
        e.preventDefault();

        const title = document.getElementById("title").value;
        const description = document.getElementById("description").value;
        const year = document.getElementById("year").value;
        const authorId = document.getElementById("authorId").value;
        const categoryId = document.getElementById("categoryId").value;

        const book = {
            title,
            description,
            year,
            authorId,
            categoryId
        };

        console.log(book);

        try {
            const response = await fetch("http://localhost:5215/api/Book", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(book)
            });

            if (response.ok) {
                alert("Libro aggiunto con successo!");
                form.reset();
            } else {
                const errorData = await response.json();
                alert(`Errore: ${errorData.message || 'Impossibile aggiungere il libro'}`);
            }
        } catch (error) {
            console.error("Errore:", error);
            alert("Errore: Impossibile aggiungere il libro");
        }
    });
});