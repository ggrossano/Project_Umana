// Funzione per caricare il contenuto di un file HTML e inserirlo in un elemento specifico
function loadCommon() {
    fetch('common.html')
        .then(response => response.text())
        .then(data => {
            document.getElementById('common-container').innerHTML = data;
        })
        .catch(error => console.error('Error loading common content:', error));
}

// Chiamata della funzione per caricare la parte comune
loadCommon();