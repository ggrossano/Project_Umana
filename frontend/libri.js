document.addEventListener("DOMContentLoaded", function () {
    const booksContainer = document.getElementById('books-container');

    const booksUrl = 'http://localhost:5215/api/Book';
    const authorsUrl = 'http://localhost:5215/api/Author';
    const categoriesUrl = 'http://localhost:5215/api/Category';

    // Funzione per ottenere i dati dai vari endpoint
    async function fetchData() {
        try {
            const [booksResponse, authorsResponse, categoriesResponse] = await Promise.all([
                fetch(booksUrl),
                fetch(authorsUrl),
                fetch(categoriesUrl)
            ]);

            const books = await booksResponse.json();
            const authors = await authorsResponse.json();
            const categories = await categoriesResponse.json();

            displayBooks(books, authors, categories);
        } catch (error) {
            console.error('Errore:', error);
            booksContainer.innerHTML = '<p>Errore nel caricamento dei dati.</p>';
        }
    }

    window.deleteBook = async function(id) {
        try {
            const response = await fetch(`http://localhost:5215/api/Book/${id}`, {
                method: 'DELETE'
            });
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            fetchData(); // Ricarica la lista dei libri dopo la cancellazione
        } catch (error) {
            console.error("Errore:", error);
        }
    }

    // Funzione per mostrare i libri con i dettagli degli autori e delle categorie
    function displayBooks(books, authors, categories) {
        booksContainer.innerHTML = '';

        books.forEach(book => {
            const author = authors.find(a => a.id === book.authorId);
            const category = categories.find(c => c.id === book.categoryId);

            const bookElement = document.createElement('div');
            bookElement.className = 'book';
            bookElement.innerHTML = `
                <h2>${book.title}</h2>
                <p><strong>Descrizione:</strong> ${book.description}</p>
                <p><strong>Anno:</strong> ${book.year}</p>
                <p><strong>Autore:</strong> ${author ? author.name : 'Sconosciuto'}</p>
                <p><strong>Categoria:</strong> ${category ? category.name : 'Sconosciuta'}</p>
                <button class="delete-button" onclick="deleteBook(${book.id})">Delete</button>
            `;

            booksContainer.appendChild(bookElement);
        });
    }

    // Chiamare la funzione per ottenere e mostrare i dati
    fetchData();
});