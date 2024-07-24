document.addEventListener("DOMContentLoaded", function () {
    const categoriesContainer = document.getElementById('categories-container');

    const booksUrl = 'http://localhost:5215/api/Book';
    const categoriesUrl = 'http://localhost:5215/api/Category';

    // Funzione per ottenere i dati dai vari endpoint
    async function fetchData() {
        try {
            const [booksResponse, categoriesResponse] = await Promise.all([
                fetch(booksUrl),
                fetch(categoriesUrl)
            ]);

            const books = await booksResponse.json();
            const categories = await categoriesResponse.json();

            displayCategories(books, categories);
        } catch (error) {
            console.error('Errore:', error);
            categoriesContainer.innerHTML = '<p>Errore nel caricamento dei dati.</p>';
        }
    }

    window.deleteCategory = async function(id) {
        try {
            const response = await fetch(`http://localhost:5215/api/Category/${id}`, {
                method: 'DELETE'
            });
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            fetchData(); // Ricarica la lista delle categorie dopo la cancellazione
        } catch (error) {
            console.error("Errore:", error);
        }
    }

    // Funzione per mostrare le categorie con i dettagli dei libri
    function displayCategories(books, categories) {
        categoriesContainer.innerHTML = '';

        categories.forEach(category => {
            const categoryElement = document.createElement('div');
            categoryElement.className = 'category';
            categoryElement.innerHTML = `
                <div>
                    <h2>${category.name}</h2>
                    <button class="show-button" onclick="toggleBooks(${category.id})">Show Books</button>
                    <button class="delete-button" onclick="deleteCategory(${category.id})">Delete</button>
                </div>
                <div class="books-list" id="books-list-${category.id}">
                </div>
            `;

            categoriesContainer.appendChild(categoryElement);
        });

        books.forEach(book => {
            const bookElement = document.createElement('div');
            bookElement.className = 'book-item';
            bookElement.innerHTML = `
                <p><strong>${book.title}</strong></p>
                <p>${book.description}</p>
                <p>${book.year}</p>
            `;

            const categoryBooksList = document.getElementById(`books-list-${book.categoryId}`);
            if (categoryBooksList) {
                categoryBooksList.appendChild(bookElement);
            }
        });
    }

    window.toggleBooks = function(categoryId) {
        const booksList = document.getElementById(`books-list-${categoryId}`);
        if (booksList.style.display === 'none' || booksList.style.display === '') {
            booksList.style.display = 'flex';
        } else {
            booksList.style.display = 'none';
        }
    }

    // Chiamare la funzione per ottenere e mostrare i dati
    fetchData();
});