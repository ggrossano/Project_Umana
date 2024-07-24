document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("category-form");

    form.addEventListener("submit", async (e) => {
        e.preventDefault();

        const name = document.getElementById("name").value;

        const category = {
            name
        };

        try {
            const response = await fetch("http://localhost:5215/api/Category", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(category)
            });

            if (response.ok) {
                alert("Categoria aggiunta con successo!");
                form.reset();
            } else {
                const errorData = await response.json();
                alert(`Errore: ${errorData.message || 'Impossibile aggiungere la categoria'}`);
            }
        } catch (error) {
            console.error("Errore:", error);
            alert("Errore: Impossibile aggiungere la categoria");
        }
    });
});