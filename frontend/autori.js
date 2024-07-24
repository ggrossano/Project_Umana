document.addEventListener("DOMContentLoaded", function () {
    const categoriesContainer = document.getElementById('authors-container');

    const authorsUrl = 'http://localhost:5215/api/Author';
    const booksUrl = 'http://localhost:5215/api/Book';


    // Funzione per ottenere i dati dai vari endpoint
    async function fetchData() {
        try {
            const [authorsResponse, booksResponse] = await Promise.all([
                fetch(authorsUrl),
                fetch(booksUrl)
            ]);

            const authors = await authorsResponse.json();
            const books = await booksResponse.json();

            displayAuthors(authors, books);
        } catch (error) {
            console.error('Errore:', error);
            categoriesContainer.innerHTML = '<p>Errore nel caricamento dei dati.</p>';
        }
    }

    window.deleteAuthor = async function (id) {
        try {
            const response = await fetch(`http://localhost:5215/api/Author/${id}`, {
                method: 'DELETE'
            });
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            fetchData(); // Ricarica la lista degli autori dopo la cancellazione
        } catch (error) {
            console.error("Errore:", error);
        }
    }

    // Funzione per mostrare le categorie con i dettagli dei libri
    function displayAuthors(authors, books) {
        categoriesContainer.innerHTML = '';

        authors.forEach(author => {
            const AuthorElement = document.createElement('div');
            AuthorElement.className = 'author';
            AuthorElement.innerHTML = `
                <div>
                    <img alt="My Image" src="icon.png"/>
                    <h2>${author.name}</h2>
                    <button class="show-button" onclick="toggleBooks(${author.id})">Show Books</button>
                    <button class="delete-button" onclick="deleteAuthor(${author.id})">Delete</button>
                </div>
                <div class="books-list" id="books-list-${author.id}">
                </div>
            `;

            categoriesContainer.appendChild(AuthorElement);
        });

        books.forEach(book => {
            const bookElement = document.createElement('div');
            bookElement.className = 'book-item';
            bookElement.innerHTML = `
                <p><strong>${book.title}</strong></p>
                <p>${book.description}</p>
                <p>${book.year}</p>
            `;

            const authorBooksList = document.getElementById(`books-list-${book.authorId}`);
            if (authorBooksList) {
                authorBooksList.appendChild(bookElement);
            }
        });
    }

    window.toggleBooks = function (authorId) {
        const booksList = document.getElementById(`books-list-${authorId}`);
        if (booksList.style.display === 'none' || booksList.style.display === '') {
            booksList.style.display = 'flex';
        } else {
            booksList.style.display = 'none';
        }
    }

    // Chiamare la funzione per ottenere e mostrare i dati
    fetchData();
});