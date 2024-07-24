document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("author-form");

    form.addEventListener("submit", async (e) => {
        e.preventDefault();

        const name = document.getElementById("name").value;

        const author = {
            name
        };

        try {
            const response = await fetch("http://localhost:5215/api/Author", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(author)
            });

            if (response.ok) {
                alert("Autore aggiunto con successo!");
                form.reset();
            } else {
                const errorData = await response.json();
                alert(`Errore: ${errorData.message || 'Impossibile aggiungere il nuovo autore'}`);
            }
        } catch (error) {
            console.error("Errore:", error);
            alert("Errore: Impossibile aggiungere il nuovo autore");
        }
    });
});