function loadProducts() {
    let storedProducts = localStorage.getItem('products');
    return storedProducts ? JSON.parse(storedProducts) : [];
}

// Function to save products to localStorage
function saveProducts(products) {
    localStorage.setItem('products', JSON.stringify(products));
}


let products = loadProducts();

function addProduct() {
    
    clearErrorMessages();

    
    let name = document.getElementById("product-name").value.trim();
    let price = document.getElementById("product-price").value.trim();
    let quantity = document.getElementById("product-quantity").value.trim();

    let isValid = validateInputs(name, price, quantity);
    if (!isValid) {
        return;
    }

  
    let id = products.length > 0 ? products[products.length - 1].id + 1 : 1;
    price = parseFloat(price).toFixed(2);
    quantity = parseInt(quantity);

    
    products.push({ id, name, price, quantity });

   
    saveProducts(products);

    document.getElementById("product-form").reset();


    renderTable();
}

function validateInputs(name, price, quantity) {
    let valid = true;
    if (name === "") {
        displayErrorMessage("product-name", "Name is required.");
        valid = false;
    }
     if (price === "" || isNaN(price) || parseFloat(price) <= 0) {
        displayErrorMessage("product-price", "Enter a valid price.");
        valid =  false;
    }
    if ( isNaN(quantity) || parseInt(quantity) <= 0) {
        displayErrorMessage("product-quantity", "Enter a valid quantity.");
        valid = false;
    }

    return valid;
}

function displayErrorMessage(inputId, message) {
    let inputElement = document.getElementById(inputId);
    let errorElement = document.createElement("p");
    errorElement.className = "text-red-500 text-xs mt-1";
    errorElement.innerText = message;
    inputElement.parentNode.appendChild(errorElement);
}

function clearErrorMessages() {
    let errorMessages = document.querySelectorAll(".text-red-500");
    errorMessages.forEach(error => error.remove());
}

function renderTable() {
    let tableBody = document.getElementById("product-table-body");
    tableBody.innerHTML = "";

    products.forEach(product => {
        let row = `<tr>
            <td class="border px-4 py-2">${product.id}</td>
            <td class="border px-4 py-2">${product.name}</td>
            <td class="border px-4 py-2">${product.price}</td>
            <td class="border px-4 py-2">${product.quantity}</td>
        </tr>`;
        tableBody.innerHTML += row;
    });
}

window.onload = renderTable;